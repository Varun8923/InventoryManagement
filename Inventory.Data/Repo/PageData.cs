using Inventory.Core;
using Inventory.Data.IRepo;
using Inventory.Dto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Inventory.Data.Repo
{
    public class PageData : IPageData
    {
        public readonly InventoryManagementContext _context;
        public PageData(InventoryManagementContext context)
        {
                _context = context;
        }

        public ProfileDataViewModel GetProfileDatabyEmail(string email)
        {
            string result = string.Empty;
            ProfileDataViewModel userdata = new ProfileDataViewModel();
            try
            {
                if (email != null)
                {
                    var user = _context.People.Where(a => a.Email == email).FirstOrDefault();
                    if (user != null )
                    {
                        userdata.FirstName = user.FirstName;
                        userdata.LastName = user.LastName;
                        userdata.Email = user.Email;
                        userdata.Password = "";
                        //userdata.MobileNo = "9027203344";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return userdata;
        }
                

        public bool IsEmailExist(string email)
        {
            bool result = false;
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var user = _context.Users.Where(a => a.Email == email).FirstOrDefault();
                    if (user != null)
                    {
                        result = true;
                    }
                }
            }
            catch(Exception ex) {
                throw ex;
            } 
            return result;
        }

        public string saveUser(LoginandRegistration registration)
        {
            string result = string.Empty;
            string hostName = Dns.GetHostName();
            IPAddress[] localIPs = Dns.GetHostAddresses(hostName);
            string[] arrname=registration.FullName.Split(' ');
            if (registration != null)
            {
                _context.InsertUser(registration.Email, registration.Password, Convert.ToInt32(registration.Designation), localIPs[0].ToString(), arrname[0], arrname[1], true, DateTime.Now);
                
                //User user = new User();
                //Person person = new Person();
                //UserRole role = new UserRole(); 
                //user.Email = registration.Email;
                //person.Email = registration.Email;
                //user.Password = registration.Password;                
                //user.RoleId = Convert.ToInt32(registration.Designation);
                //user.CreatedOn=DateTime.Now;
                //user.Ip = localIPs[0].ToString();
                //person.FirstName = arrname[0];
                //person.LastName = arrname[1];
                //_context.Users.Add(user);
                //_context.SaveChanges();

                result = "Success";
            }
            return result;
        }

        public string UpdatePassword(ResetPassword resetPassword)
        {
            string result = string.Empty;
           if(resetPassword != null)
           {
                var user= _context.Users.Where(a=>a.Email==resetPassword.Email).FirstOrDefault();
                if(user != null)
                {
                    user.Password = resetPassword.Password;
                    _context.Update(user);
                    _context.SaveChanges();
                    result = "Password Updated Successfully";
                }
                
           }
            return result;
        }

        public LoginandRegistration VerifyUser(LoginViewModel login)
        {
            string result = string.Empty;
            LoginandRegistration userdata= new LoginandRegistration();
            if (login != null)
            {
                var user = from cust in _context.Users
                           join ord in _context.People
                                on cust.UserId equals ord.UserId where ord.Email == login.Email  && cust.Password == login.Password
                           select new
                           {
                               ord.FirstName , ord.LastName,
                                 ord.Email,
                               cust.RoleId,
                               cust.Password
                           };
                if (user != null)
                {
                    foreach (var item in user)
                    {
                        userdata.Email = item.Email;
                        userdata.FullName = item.FirstName+ " "+ item.LastName;
                        userdata.Password = item.Password;
                        userdata.Designation = item.RoleId.ToString();
                    }
                }
                else
                {
                    result = "Invalid Credentials";
                }
            }
            return userdata;
        }
    }
}
