using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responses
{
    public class BaseCommandResponse<T>
    {
        public Guid ID { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } 

        public List<string> Errors { get; set; }
    }
}