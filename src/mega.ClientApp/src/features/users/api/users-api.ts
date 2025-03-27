import api from '@/lib/api-client'
import { User } from '../data/schema'
// import { User, userListSchema } from '../data/schema'

export const usersApi = {
  getUsers: async () => {
    const response = await api.get<User[]>('/user')
    // return userListSchema.parse(response.
    // data)
    return response.data
  },
} 