using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageGalleryCore.Models
{
    public class Response
    {
        public Boolean isSuccess { get; set; } = true;
        public int code { get; set; } = 200;
        public String messenge { get; set; } = "success";
        public int count { get; set; } = 0;
        public object data { get; set; }
        public Response()
        {

        }
        public Response(object data, int count)
        {
            this.data = data;
            this.count = count;
        }
    }
}
