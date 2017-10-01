using BusinessLogicApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicApi.Business
{
    public interface IUserBusiness
    {
        CreatedUser Create(NewUser newUser);
        CreatedUser Update(UpdatedUser updatedUser);
        bool Remove(int Id);
        List<CreatedUser> FindAll();
        CreatedUser FindByUsername(string username);
        CreatedUser Login(string username, string password);
    }
}
