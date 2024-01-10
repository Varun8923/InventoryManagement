using Inventory.Core;
using Inventory.Data.IRepo;
using Inventory.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Repo.Repo
{
    public class Pages:IPages
    {
        public readonly IPageData _pageData;
        public Pages(IPageData pageData)
        {
                _pageData = pageData;
        }

        public string Login(LoginandRegistration login)
        {
            string result = string.Empty;
            if (login != null)
            {
                result = _pageData.VerifyUser(login);
            }
            return result;
        }

        public string Registration(LoginandRegistration registration)
        {
            string result = string.Empty;
            if (registration != null)
            {
                result = _pageData.saveUser(registration);
            }
            return result;
        }
    }
}
