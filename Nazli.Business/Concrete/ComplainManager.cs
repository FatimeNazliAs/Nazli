using Nazli.Business.Abstract;
using Nazli.Common.DTOs;
using Nazli.Common.Utilities.Results;
using Nazli.DataLayer;
using Nazli.DataLayer.Entity;
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

        ChatAppContext chatAppContext = new ChatAppContext();

        public BCResponse Add(ComplainDto dto)
        {
            throw new NotImplementedException();
        }

        public BCResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Complain? GetById(int id)
        {
            return chatAppContext.Set<Complain>().FirstOrDefault(x => x.ComplainId == id);
        }

        public List<Complain> GetComplainByUserID(int id)
        {
            return chatAppContext.Set<Complain>().
                    Where(x => x.ComplainedOfUserId == id).
                    ToList();
        }

        public List<Complain> GetListAll()
        {
            return chatAppContext.Set<Complain>().ToList();
        }

        public BCResponse Update(ComplainDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
