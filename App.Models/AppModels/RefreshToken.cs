using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.AppModels
{
   public class RefreshToken
    {
        public string Id { get; set; }
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
