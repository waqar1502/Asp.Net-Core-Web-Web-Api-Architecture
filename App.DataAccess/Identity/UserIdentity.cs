using Microsoft.AspNetCore.Identity;

namespace App.DataAccess.Identity
{
    public class UserIdentity : IdentityUser
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
