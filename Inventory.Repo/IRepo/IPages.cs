using Inventory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Repo.IRepo
{
    public interface IPages
    {
        string Registration(LoginandRegistration registration);
        string Login(LoginandRegistration login);
    }
}
