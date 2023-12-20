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
      <div className="flex items-center justify-end">
        <Link
          href="/signup"
          className="rounded-sm bg-blue-600 mt-3 px-4 py-1 text-sm font-light leading-6 text-slate-300 shadow-2xl hover:bg-blue-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600 uppercase"
        >
          Sign Up
        </Link>
      </div>
      <div className="border border-blue-500 px-12 py-10 pb-20 rounded-3xl mx-10 sm:mx-auto space-y-16 min-w-min">
        <div className="mx-auto w-72">
          <h2 className="text-center text-4xl font-bold leading-9 tracking-tight text-blue-700">
            Sign In
          </h2>
        </div>
        <div className="w-32 h-28 relative sm:mx-auto">
          <Image
            fill
            className="rounded-full mx-auto"
            src="/assets/images/signin.webp"
            alt="Our blog logo"
          />
        </div>

        <div className="mx-auto">
          <form className="space-y-6" action="#" method="POST">
            <div className="mt-1">
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
                className="rounded-sm bg-blue-600 mt-3 px-4 py-1 text-sm font-light leading-6 text-slate-300 shadow-2xl hover:bg-blue-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600 uppercase"
              >
                SIGN IN
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Login;
