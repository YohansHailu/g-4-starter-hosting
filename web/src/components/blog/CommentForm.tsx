import React from "react";

const CommentForm = () => {
  return (
    <form>
      <div className="mb-3">
        <label htmlFor="comments" className="block mb-2 font-bold">
          COMMENTS
        </label>
        <textarea
          id="comments"
          placeholder="WRITE YOUR COMMENT HERE"
          className="w-full py-3 px-5  border-2 h-32 rounded-b-2xl rounded-r-2xl text-[15px]"
        />
      </div>
      <div className="flex justify-end">
        <button className="bg-blue-700 hover:bg-blue-800 px-5 py-2 rounded-sm text-white">
          POST
        </button>
      </div>
    </form>
  );
};

export default CommentForm;
