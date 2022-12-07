using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlansLibrary.Models
{

    public class LoginApi
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(6)]
        public string Password { get; set; }

        internal class LoginApi
        {

        }
    }
}