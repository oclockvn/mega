import path from 'path'
import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react-swc'
import { TanStackRouterVite } from '@tanstack/router-plugin/vite'

// https://vite.dev/config/
export default defineConfig(({ mode }) => {
  const env = loadEnv(mode, process.cwd(), '')
  
  return {
    plugins: [react(), TanStackRouterVite()],
    server: {
      proxy: {
        '/api': {
          target: env.services__mega_api__https__0 || env.VITE_API_URL || 'https://localhost:9200',
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
