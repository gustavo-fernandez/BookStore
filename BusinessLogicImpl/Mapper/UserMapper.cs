using BusinessLogicApi.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicImpl.Mapper
{
    public class UserMapper
    {
        private UserMapper()
        {
        }
        public static CreatedUser mapToCreatedUser(User user)
        {
            if (user == null)
            {
                return null;
            }
            CreatedUser createdUser = new CreatedUser();
            createdUser.Id = user.Id;
            createdUser.Username = user.Username;
            createdUser.Password = user.Password;
            return createdUser;
        }

    }
}
