using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.HelperServices
{
    public interface IEmailSenderService
    {
        bool SendEmail(string mEmail, string mName, string mCode, string mUser);
    }
}
