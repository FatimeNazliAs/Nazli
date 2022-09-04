using Nazli.Common.DTOs;
using Nazli.Common.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.Business.Abstract
{
    public interface IBaseService<DTO> where DTO : class
    {
        BCResponse Add(DTO dto);
        BCResponse Update(DTO dto);
        BCResponse Delete(DTO dto);
    }
}
