using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlansLibrary.Models
{
    public class LoginApiResult

    {
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
