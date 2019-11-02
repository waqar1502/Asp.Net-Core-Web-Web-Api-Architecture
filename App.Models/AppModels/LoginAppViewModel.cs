using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.AppModels
{
   public class LoginAppViewModel : SuccessViewModel
    {
        public new JwtTokenViewModel Content { get; set; }
    }
}
