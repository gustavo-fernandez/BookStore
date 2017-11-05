using BusinessLogicApi.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicApi.DTO;
using DataAccess.Context;
using DataAccess.Model;
using Common.Cryptography;
using System.Data.Entity;
using AutoMapper;

namespace BusinessLogicImpl.BusinessImpl
{
    public class UserBusiness : IUserBusiness
    {
        public CreatedUser Create(NewUser newUser)
        {
            using (BookStoreContext context = new BookStoreContext())
            {
                string randomSalt = CryptoUtils.RandomString();
                User user = new User()
                {
                    Username = newUser.Username,
                    Password = SHA256Utils.ComputeHMAC(newUser.Password, randomSalt),
                    Salt = randomSalt
                };
                User createdUser = context.Users.Add(user);
                context.SaveChanges();
                return Mapper.Map<CreatedUser>(createdUser);
            }
        }

        public CreatedUser FindByUsername(string username)
        {
            using (BookStoreContext context = new BookStoreContext())
            {
                User user = context.Users.Where(x => x.Username.Equals(username)).First();
                return Mapper.Map<CreatedUser>(user);
            }
        }

        public List<CreatedUser> FindAll()
        {
            using (BookStoreContext context = new BookStoreContext())
            {
                return context.Users.ToList().Select(Mapper.Map<CreatedUser>).ToList();
            }
        }

        public CreatedUser Login(string username, string password)
        {
            using (BookStoreContext context = new BookStoreContext())
            {
                User user = context.Users.Where(x => x.Username == username).First();
                if (user == null)
                {
                    return null;
                }
                string hmacLogin = SHA256Utils.ComputeHMAC(password, user.Salt);
                if (hmacLogin.Equals(user.Password))
                {
                    return Mapper.Map<CreatedUser>(user);
                }
                return null;
            }
        }

        public bool Remove(int Id)
        {
            using (BookStoreContext context = new BookStoreContext())
            {
                User user = new User()
                {
                    Id = Id
                };
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }

        public CreatedUser Update(UpdatedUser updatedUser)
        {
            using (BookStoreContext context = new BookStoreContext())
            {
                User user = context.Users.Find(updatedUser.Id);
                user.Password = SHA256Utils.ComputeHMAC(updatedUser.Password, user.Salt);
                user.ModifiedDate = DateTime.Now;
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return Mapper.Map<CreatedUser>(user);
            }
        }
    }
}
