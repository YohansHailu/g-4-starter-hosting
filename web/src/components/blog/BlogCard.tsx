"use client";

import { Menu, Transition } from "@headlessui/react";
import React, { Fragment } from "react";
import { BookmarkIcon, EllipsisVerticalIcon } from "@heroicons/react/20/solid";
import Image from "next/image";

function classNames(...classes: string[]) {
  return classes.filter(Boolean).join(" ");
}

export default function BlogCard() {
  return (
    <div className="bg-white border border-gray-200 rounded-md px-4 py-5 sm:px-6">
      <div className="flex space-x-3">
        <div className="w-10 h-10 relative flex-shrink-0">
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
          <p className="text-sm text-gray-500">
            <a href="#" className="hover:underline" suppressHydrationWarning>
              {new Date().toLocaleString()}
            </a>
          </p>
        </div>

        <div className="flex flex-shrink-0 self-center">
          <Menu as="div" className="relative inline-block text-left">
            <div>
              <Menu.Button className="-m-2 flex items-center rounded-full p-2 text-gray-400 hover:text-gray-600">
                <span className="sr-only">Open options</span>
                <EllipsisVerticalIcon className="h-5 w-5" aria-hidden="true" />
              </Menu.Button>
            </div>

            <Transition
              as={Fragment}
              enter="transition ease-out duration-100"
              enterFrom="transform opacity-0 scale-95"
              enterTo="transform opacity-100 scale-100"
              leave="transition ease-in duration-75"
              leaveFrom="transform opacity-100 scale-100"
              leaveTo="transform opacity-0 scale-95"
            >
              <Menu.Items className="absolute right-0 z-10 mt-2 w-56 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                <div className="py-1">
                  <Menu.Item>
                    {({ active }) => (
                      <a
                        href="#"
                        className={classNames(
                          active
                            ? "bg-gray-100 text-gray-900"
                            : "text-gray-700",
                          "flex px-4 py-2 text-sm"
                        )}
                      >
                        <BookmarkIcon
                          className="mr-3 h-5 w-5 text-gray-400"
                          aria-hidden="true"
                        />
                        <span>Bookmark</span>
                      </a>
                    )}
                  </Menu.Item>
                </div>
              </Menu.Items>
            </Transition>
          </Menu>
        </div>
      </div>
      <div className="mt-4">
        <h2 className="text-lg font-semibold">This is a title</h2>
        <div className="text-sm text-justify text-gray-700">
          Lorem ipsum dolor, sit amet consectetur adipisicing elit. Iure debitis
          dicta libero commodi dignissimos voluptatum qui pariatur molestiae
          cumque, aperiam, autem magnam dolorem alias sit nulla vitae adipisci.
          Culpa, sit?
        </div>
      </div>
      <div className="mt-4">
        <span className="text-gray-500 text-sm">2 min read</span>
      </div>
    </div>
  );
}
