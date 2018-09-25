using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models.Requests
{
    public class LoginRespone
    {
        public long id { get; set; }
        public string usr { get; set; }
        public string fullname { get; set; }
        public string token { get; set; }
    }
}
