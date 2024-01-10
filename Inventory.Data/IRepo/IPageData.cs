using Inventory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Data.IRepo
{
    public interface IPageData
    {
        LoginandRegistration VerifyUser(LoginViewModel login);
        string saveUser(LoginandRegistration login);
        ProfileDataViewModel GetProfileDatabyEmail(string email);
        string UpdatePassword(ResetPassword resetPassword);
        bool IsEmailExist(string email);

    }
}
