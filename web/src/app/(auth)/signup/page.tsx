import Link from "next/link";
import React from "react";

interface SignUpProps {
  email: string;
  firstname: string;
  middlename: string;
  lastname: string;
  birthday: string;
  password: string;
}

const SignUp: React.FC<SignUpProps> = (props) => {
  return (
    <div className="flex min-h-full flex-1 flex-col justify-center p-6 space-y-12 lg:px-8">
      <div className="flex items-center justify-end">
        <Link
          href="/login"
          className="rounded-sm bg-blue-600 mt-3 px-4 py-1 text-sm font-light leading-6 text-slate-300 shadow-2xl hover:bg-blue-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600 uppercase"
        >
          Login
        </Link>
      </div>
      <div className="border border-blue-500 px-12 py-10 pb-20 rounded-3xl mx-10 sm:mx-auto space-y-16 min-w-min">
        <div className="mx-auto w-72">
          <h2 className="text-center text-4xl font-bold leading-9 tracking-tight text-blue-700">
            Sign Up
          </h2>
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
                id="firstname"
                name="firstname"
                type="text"
                placeholder="First Name"
                required
                className="block w-full rounded-sm border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-blue-600 sm:text-sm sm:leading-6"
              />
            </div>

            <div className="mt-2">
              <input
                id="lastname"
                name="lastname"
                type="text"
                placeholder="Last Name"
                required
                className="block w-full rounded-sm border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-blue-600 sm:text-sm sm:leading-6"
              />
            </div>

            <div className="mt-2">
              <input
                id="birthday"
                name="birthday"
                type="Date"
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
                SIGN UP
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default SignUp;
