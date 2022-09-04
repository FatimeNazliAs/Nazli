using Nazli.Business.Abstract;
using Nazli.Common.DTOs;
using Nazli.Common.Utilities.Results;
using Nazli.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nazli.Business.Concrete
{
    public class ComplainManager : IComplainService
    {
        DalComplain _dalComplain;

        public ComplainManager(DalComplain dalComplain)
        {
            _dalComplain = dalComplain;
        }

        public BCResponse Add(ComplainDto dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse Delete(ComplainDto dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse Update(ComplainDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
