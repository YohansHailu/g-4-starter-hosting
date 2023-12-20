import BlogCard from "@/components/blog/BlogCard";
import BlogSidebar from "@/components/blog/BlogSidebar";

export default function Home() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <div className="grid grid-cols-12">
        <div className="col-span-8">
          {[1, 2, 3].map((_, idx) => {
            return (
              <div className="flex mb-4 mx-4 lg:mx-10" key={idx}>
                <BlogCard />
              </div>
            );
          })}
        </div>
        <div className="col-span-4 mx-4 lg:mx-10">
          <BlogSidebar />
        </div>
      </div>
    </main>
  );
}
