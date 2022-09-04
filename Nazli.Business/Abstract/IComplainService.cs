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
    public interface IComplainService: IBaseService<ComplainDto>
    {
        Complain? GetById(int id);
        List<Complain> GetListAll();
        List<Complain> GetComplainByUserID(int id);



    }
}
