using App.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.AppModels
{
   public class UserProfileAppViewModel : SuccessViewModel
    {
        public UserProfileAppViewModel()
        {
            Content = new ProfileViewModel();
        }
        public new ProfileViewModel Content { get; set; }
    }
}
