using Nazli.Common.DataLayer.Entities;
using Nazli.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nazli.DataLayer
{
    
    public class DalComplain:DalBase<Complain>
    {
        ChatAppContext chatAppContext = new ChatAppContext();


        public Complain? GetById(int id) {
 
            return chatAppContext.Set<Complain>().FirstOrDefault(x => x.ComplainId == id);
        }
        public List<Complain> GetComplainByUserID(int id)
        {
            //sikayet edilenin ıd sini bulma
            return chatAppContext.Set<Complain>().
                    Where(x=>x.ComplainedOfUserId == id).
                    ToList();

        
        }
        public List<Complain> GetListAll()
        {
            return chatAppContext.Set<Complain>().ToList();

        }

    }
}
