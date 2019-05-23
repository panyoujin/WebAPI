using System;
using System.Collections.Generic;
using System.Text;

namespace Pan.Code.Models.ApiModel
{
    public class LoginUserModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
