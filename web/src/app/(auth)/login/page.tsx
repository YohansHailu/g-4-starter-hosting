import Image from "next/image";
import Link from "next/link";
import React from "react";

interface LoginProps {
  email: string;
  password: string;
}

const Login: React.FC<LoginProps> = (props) => {
  return (
    <div className="flex min-h-full flex-1 flex-col justify-center p-6 space-y-12 lg:px-8">
      <div className="mt-6 flex items-center justify-end gap-x-6">
        <Link
          href="/signup"
          className="bg-blue-600 text-white px-5 py-2 rounded-sm"
        >
          Sign Up
        </Link>
      </div>
      <div className="border border-blue-700 px-20 py-10 rounded-xl mx-10 sm:mx-auto sm:max-w-sm space-y-16">
        <div className="mx-auto">
          <h2 className="text-center text-4xl font-bold leading-9 tracking-tight text-blue-700">
            Sign In
          </h2>
        </div>
        <div className="w-32 h-32 relative sm:mx-auto">
          <Image
            fill
            className="rounded-full mx-auto"
            src="https://cdn.discordapp.com/attachments/1184179126286954597/1186382809045139476/image.png?ex=65930c17&is=65809717&hm=98a863b38fb2a8e4b02a553df118f00012833a530b7f0b8f7e1141cb0b0d44bc&"
            alt="Our blog logo"
          />
        </div>

        <div className="mx-auto">
          <form className="space-y-6" action="#" method="POST">
            <div className="mt-2">
              <input
                id="email"
                name="email"
                type="email"
                placeholder="Email"
                required
                className="block w-full rounded-sm border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-blue-600 sm:text-sm sm:leading-6"
              />
            </div>

            <div className="mt-2">
              <input
                id="password"
                name="password"
                type="password"
                placeholder="Password"
                required
                className="block w-full rounded-sm border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-blue-600 sm:text-sm sm:leading-6"
              />
            </div>

            <div className="mt-6 flex items-center justify-end gap-x-6">
              <button
                type="submit"
                className="flex justify-center rounded-sm bg-blue-600 mt-3 px-4 py-1 text-sm font-light leading-6 text-white shadow-sm hover:bg-blue-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600"
              >
                SIGN UP
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Login;
