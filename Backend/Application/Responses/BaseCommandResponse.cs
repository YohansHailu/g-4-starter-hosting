using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responses
{
    public class BaseCommandResponse
    {
        public Guid ID { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } 

        public List<string> Errors { get; set; }
    }
}