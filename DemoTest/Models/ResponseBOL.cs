using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoTest.Models
{
    public class ResponseBOL
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public object Data { get; set; }

        public ResponseBOL(int code, bool status, string message, object data)
        {
            Status = code;
            Success = status;
            Message = message;
            Data = data;
        }
       
    }
}