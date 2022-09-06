using Nazli.Common.DTOs;
using Nazli.Common.Utilities.Results;
using Nazli.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.Business.Abstract
{
    public interface IUserService: IBaseService<UserDto>
    {
        //List<User> GetUsers();
        //User? GetById(int id);
        //User? GetByUserName(string username);
        BCResponse GetUsers();
        BCResponse GetById(int id);
        BCResponse GetByUserName(string username);
    }
}
