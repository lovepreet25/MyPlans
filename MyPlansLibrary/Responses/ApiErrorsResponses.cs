using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlansLibrary.Responses
{
    internal class ApiErrorsResponses
    {

       
            public string Message { get; set; }
            public string[] Errors { get; set; }
            public bool IsSuccess { get; set; }
        

    }
}
