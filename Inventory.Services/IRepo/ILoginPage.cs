using Inventory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Services.IRepo
{
    public interface ILoginPage
    {
        string Registration(LoginandRegistration registration);
        LoginandRegistration Login(LoginViewModel login);
        ProfileDataViewModel GetProfileData(string email);
        string UpdatePassword(ResetPassword reset);

        bool IsEmailExist(string email);

    }
}
