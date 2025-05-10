import path from 'path'
import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react-swc'
import { TanStackRouterVite } from '@tanstack/router-plugin/vite'

// https://vite.dev/config/
export default defineConfig(({ mode }) => {
  const env = loadEnv(mode, process.cwd(), '')
  console.log({ VITE_PORT: env.VITE_PORT, PORT: env.PORT })
  
  // services__api__https__0 is the env variable injected by the host
  // VITE_API_URL is the env variable injected by the host
  // VITE_PORT is the env variable injected by the host
  return {
    plugins: [react(), TanStackRouterVite()],
    server: {
      proxy: {
        '/api': {
          target: env.services__api__https__0 || env.VITE_API_URL,
          changeOrigin: true,
          secure: false,
          ws: true,
        },
      },
      port: parseInt(env.VITE_PORT || '4200'),
      strictPort: true,
      host: true,
    },
    resolve: {
      alias: {
        '@': path.resolve(__dirname, './src'),

        // fix loading all icon chunks in dev mode
        // https://github.com/tabler/tabler-icons/issues/1233
        '@tabler/icons-react': '@tabler/icons-react/dist/esm/icons/index.mjs',
      },
    },
    build: {
      outDir: 'dist',
      sourcemap: true,
    },
    define: {
      'process.env': env
    }
  }
})
