// import path from 'path'
import path from "path"
import tailwindcss from "@tailwindcss/vite"

import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';
import { TanStackRouterVite } from '@tanstack/router-plugin/vite'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [TanStackRouterVite({ target: 'react', autoCodeSplitting: true }), plugin(), tailwindcss(),  ],
  server: {
    port: 4200,
  },
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),

      // fix loading all icon chunks in dev mode
      // https://github.com/tabler/tabler-icons/issues/1233
      //   '@tabler/icons-react': '@tabler/icons-react/dist/esm/icons/index.mjs',
    },
    preserveSymlinks: true,
  },
})
