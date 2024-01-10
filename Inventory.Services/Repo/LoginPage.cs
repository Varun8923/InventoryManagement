using Inventory.Core;
using Inventory.Data.IRepo;
using Inventory.Repo.IRepo;
using Inventory.Services.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Services.Repo
{

    public class LoginPage : ILoginPage
    {
        public readonly IPageData _pages;
        public LoginPage(IPageData pages)
        {
                _pages = pages;
        }

        public ProfileDataViewModel GetProfileData(string email)
        {
            ProfileDataViewModel result = new ProfileDataViewModel();
            
            if (!string.IsNullOrEmpty(email))
            {
                result = _pages.GetProfileDatabyEmail(email);
                //string[] name=result.FullName.Split(' ');
                //result.FirstName= name[0];
                //result.LastName= name[1];

            }
            return result;
        }

        public bool IsEmailExist(string email)
        {
            bool result=false;
            if(!string.IsNullOrEmpty(email)) {
                result = _pages.IsEmailExist(email);
               
            }
            return result;
        }

        public LoginandRegistration Login(LoginViewModel login)
        {
            LoginandRegistration result = new LoginandRegistration();
            if (login != null)
            {
                result=_pages.VerifyUser(login);
            }
            return result;
        }

        public string Registration(LoginandRegistration registration)
        {
            string result = string.Empty;
            if (registration != null)
            {
                result = _pages.saveUser(registration);
            }
            return result;
        }

        public string UpdatePassword(ResetPassword reset)
        {
            string result = string.Empty;
            if (reset != null)
            {
                result = _pages.UpdatePassword(reset);
            }
            return result;
        }
    }
}
