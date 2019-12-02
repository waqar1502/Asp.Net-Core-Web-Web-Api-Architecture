using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DataAccess.Identity
{
   public partial class AspNetUsers : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePicturePath { get; set; }

        public string Location { get; set; }

        public string Alias { get; set; }

        public string DateOfBrith { get; set; }

        public override string PhoneNumber { get; set; }
    }
}
