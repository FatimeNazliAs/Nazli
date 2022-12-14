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
    public interface IGroupService : IBaseService<GroupDto>
    {
        //List<Group> GetList(int id);
        BCResponse GetById(int id);
    }
}
