import type { NextConfig } from "next"
import path from "node:path"

const nextConfig: NextConfig = {
  sassOptions: {
    includePaths: [path.join(__dirname, "src")],
    prependData: `@use './app/variables' as *;`,
  },
  images: {
    remotePatterns: [
      {
        protocol: "http",
        hostname: "dummyimage.com",
      },
      {
        protocol: "https",
        hostname: "dummyimage.com",
      },
    ],
  },
}

export default nextConfig
