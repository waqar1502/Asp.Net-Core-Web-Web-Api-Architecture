using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.ViewModels
{
   public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //public string _ProfilePicturePath;
        //public string ProfilePicturePath
        //{
        //    get
        //    {
        //        return _ProfilePicturePath;
        //    }
        //    set
        //    {
        //        _ProfilePicturePath = value;
        //    }
        //}
        public string ProfilePicturePath { get; set; }
        public string Location { get; set; }
        public string Alias { get; set; }
        public string DateOfBrith { get; set; }
        public string PhoneNumber { get; set; }
    }
}
