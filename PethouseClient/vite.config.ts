import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    host: true, // Allows access from Docker container
    port: 5173, // Default Vite port
    watch: {
      usePolling: true, // Helps with file changes in Docker
    },
  },
})
