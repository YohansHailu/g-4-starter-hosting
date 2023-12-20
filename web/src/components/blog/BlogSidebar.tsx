"use-client";

import { MagnifyingGlassIcon, PlusIcon } from "@heroicons/react/20/solid";
import Image from "next/image";
import React from "react";

const tags = [
  "Python",
  "JavaScript",
  "TypeScript",
  "C++",
  "Java",
  "Codeforces",
  "Leetcode",
  "DSA",
];

export default function BlogSidebar() {
  return (
    <div className="flex flex-col">
      <div>
        <div className="relative mt-2 rounded-md shadow-sm">
          <div className="pointer-events-none absolute inset-y-0 left-0 flex items-center pl-3">
            <MagnifyingGlassIcon
              className="h-5 w-5 text-gray-400"
              aria-hidden="true"
            />
          </div>
          <input
            type="search"
            name="search"
            id="search"
            className="block w-full rounded-xl border-0 py-1.5 pl-10 text-gray-900 ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-blue-600 sm:text-sm sm:leading-6"
            placeholder="Search"
          />
        </div>
      </div>
      <div className="mt-10">
        <h2 className="text-3xl mb-6">Trending</h2>
        <div className="flex flex-col space-y-3 mt-3">
          {[1, 2].map((_, idx) => {
            return (
              <div key={idx} className="mb-3">
                <div className="flex space-x-3">
                  <div className="flex-shrink-0 h-5 w-5 relative">
                    <Image
                      fill
                      className="rounded-full"
                      src="https://images.unsplash.com/photo-1702903867714-178ba350fbeb?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyfHx8ZW58MHx8fHx8"
                      alt=""
                    />
                  </div>
                  <div className="min-w-0 flex-1">
                    <p className="text-sm font-semibold text-gray-900">
                      <a href="#" className="hover:underline">
                        Dr. Rafael
                      </a>
                    </p>
                  </div>
                </div>

                <div className="text-xs">Lorem ipsum dolor sit amet...</div>
              </div>
            );
          })}
        </div>
      </div>

      <div className="mt-20">
        <h2 className="text-3xl mb-6">Filter Articles</h2>
        <div className="flex flex-wrap gap-2">
          {tags.map((tag, idx) => {
            return (
              <button
                type="button"
                key={idx}
                className="inline-flex w-fit items-center gap-x-1.5 rounded-2xl bg-blue-200 px-4 py-1.5 text-sm font-light text-blue-800 shadow-sm hover:bg-blue-500 hover:text-white focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600 h-8 box-border"
              >
                <PlusIcon className="-ml-2 h-5 w-5" aria-hidden="true" />
                {tag}
              </button>
            );
          })}
        </div>
      </div>
    </div>
  );
}
