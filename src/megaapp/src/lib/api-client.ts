// import axios from 'axios'

// export const apiClient = axios.create({
//   baseURL: '/api',
//   headers: {
//     'Content-Type': 'application/json',
//   },
// }) 

// apiClient.js
import axios, { AxiosInstance } from 'axios';

class ApiClient {
  baseURL: string;
  tokenStorage: any;
  axiosInstance: AxiosInstance;

  constructor(baseURL: string, tokenStorage: any) {
    this.baseURL = baseURL;
    this.tokenStorage = tokenStorage || {
      getAccessToken: () => localStorage.getItem('accessToken'),
      getRefreshToken: () => localStorage.getItem('refreshToken'),
      setTokens: (accessToken: string, refreshToken: string) => {
        localStorage.setItem('accessToken', accessToken);
        localStorage.setItem('refreshToken', refreshToken);
      },
      clearTokens: () => {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
      }
    };

    // Create axios instance with base configuration
    this.axiosInstance = axios.create({
      baseURL: this.baseURL,
      headers: {
        'Content-Type': 'application/json',
      },
    });

    // Add request interceptor to automatically add auth header
    this.axiosInstance.interceptors.request.use(
      (config) => {
        const token = this.tokenStorage.getAccessToken();
        if (token) {
          config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
      },
      (error) => Promise.reject(error)
    );

    // Add response interceptor to handle token refresh
    this.axiosInstance.interceptors.response.use(
      (response) => response,
      async (error) => {
        const originalRequest = error.config;
        
        // If error is 401 (Unauthorized) and we haven't tried to refresh the token yet
        if (error.response?.status === 401 && !originalRequest._retry) {
          originalRequest._retry = true;
          
          try {
            const refreshToken = this.tokenStorage.getRefreshToken();
            if (!refreshToken) {
              // No refresh token available, can't refresh
              this.tokenStorage.clearTokens();
              // Redirect to login or dispatch a logout action here if using Redux
              return Promise.reject(error);
            }
            
            // Call your token refresh endpoint
            const response = await axios.post(`${this.baseURL}/auth/refresh`, {
              refreshToken,
            });
            
            const { accessToken, refreshToken: newRefreshToken } = response.data;
            
            // Save the new tokens
            this.tokenStorage.setTokens(accessToken, newRefreshToken);
            
            // Update the header of the failed request and retry it
            originalRequest.headers.Authorization = `Bearer ${accessToken}`;
            
            // Retry the original request
            return this.axiosInstance(originalRequest);
          } catch (refreshError) {
            // Failed to refresh token, logout
            this.tokenStorage.clearTokens();
            // Redirect to login or dispatch a logout action here if using Redux
            return Promise.reject(refreshError);
          }
        }
        
        return Promise.reject(error);
      }
    );
  }

  // HTTP request methods
  async get<T = any>(url: string, params = {}, options = {}) {
    return this.axiosInstance.get<T>(url, { params, ...options });
  }

  async post<T = any>(url: string, data = {}, options = {}) {
    return this.axiosInstance.post<T>(url, data, options);
  }

  async put<T = any>(url: string, data = {}, options = {}) {
    return this.axiosInstance.put<T>(url, data, options);
  }

  async patch<T = any>(url: string, data = {}, options = {}) {
    return this.axiosInstance.patch<T>(url, data, options);
  }

  async delete<T = any>(url: string, options = {}) {
    return this.axiosInstance.delete<T>(url, options);
  }

  // Authentication methods
  async login(credentials: any) {
    try {
      const response = await this.post('/auth/login', credentials);
      const { accessToken, refreshToken } = response.data;
      this.tokenStorage.setTokens(accessToken, refreshToken);
      return response.data;
    } catch (error) {
      throw error;
    }
  }

  async logout() {
    try {
      // Call logout endpoint if your API has one
      await this.post('/auth/logout', { 
        refreshToken: this.tokenStorage.getRefreshToken() 
      });
    } catch (error) {
      console.error('Error during logout:', error);
    } finally {
      // Clear tokens from storage regardless of API call success
      this.tokenStorage.clearTokens();
    }
  }

  // Helper method to check if user is authenticated
  isAuthenticated() {
    return !!this.tokenStorage.getAccessToken();
  }
}

// export default ApiClient;

// api.js - Configure and export the API client
// import ApiClient from './apiClient';

const API_BASE_URL = '/api';

// Create and export a configured instance
const api = new ApiClient(API_BASE_URL, null);

export default api;