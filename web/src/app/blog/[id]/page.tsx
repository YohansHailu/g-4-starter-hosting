"use client";

import Image from "next/image";
import { notFound } from "next/navigation";
import blogsData from "@/data/blogs.json";
import CommentForm from "@/components/blog/CommentForm";

interface Blog {
  id: number;
  title: string;
  content: string;
  image: string;
}

interface Props {
  params: { id: string };
}

const blogs: Blog[] = blogsData;

const BlogDetailPage = ({ params }: Props) => {
  const blogId = parseInt(params.id, 10);
  const blog = blogs.find((blog) => blog.id === blogId);

  if (!blog) notFound();

  return (
    <div key={blog.id} className="flex justify-center items-center mx-60">
      <div className="px-8 py-14 prose">
        <h1 className="text-5xl flex justify-center mb-14">{blog.title}</h1>
        <div className="grid grid-flow-row items-center">
          <Image src={blog.image} alt="Blog Image" width={700} height={300} />
          <div className="my-10">
            {blog.content.split("\n").map((paragraph, index) => (
              <p key={index} className="mb-4 text-[15px]">
                {paragraph}
              </p>
            ))}
          </div>
        </div>
        <CommentForm />
      </div>
    </div>
  );
};

export default BlogDetailPage;
