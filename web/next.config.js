/** @type {import('next').NextConfig} */
const nextConfig = {
  images: {
    remotePatterns: [
      {
        protocol: "https",
        hostname: "res.cloudinary.com",
        port: "",
        pathname:
          "/eskalate/image/upload/f_auto,q_auto/v1/a2sv/success-stories/**",
      },
    ],
  },
};

module.exports = nextConfig;
