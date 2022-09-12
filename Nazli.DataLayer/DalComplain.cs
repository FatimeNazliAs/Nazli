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

        public bool Any(int? complainId = null, int? complainantUserId=null,int? complainedOfUserId=null,int? complainStatusId=null)
        {

            return chatAppContext.Complains.
                Any(x =>
                            (!complainId.HasValue || x.ComplainId == complainId) &&
                            (!complainedOfUserId.HasValue || x.ComplainedOfUserId== complainedOfUserId)&&
                            (!complainantUserId.HasValue || x.ComplainantUserId == complainantUserId)&&
                            (!complainStatusId.HasValue || x.ComplainStatusId == complainStatusId));
                     


        }

        public Complain? GetBy(int? complainId = null, int? complainantUserId = null, int? complainedOfUserId = null, int? complainStatusId = null)
        {

            return chatAppContext.Complains.
                Where(x =>
                            (!complainId.HasValue || x.ComplainId == complainId) &&
                            (!complainedOfUserId.HasValue || x.ComplainedOfUserId == complainedOfUserId) &&
                            (!complainantUserId.HasValue || x.ComplainantUserId == complainantUserId)&&
                            (!complainStatusId.HasValue || x.ComplainStatusId == complainStatusId)
                            ).FirstOrDefault();

        }


        public Message? FindMessage(int? messageId = null)
        {

            //return chatAppContext.Messages.
            //    FirstOrDefault(x =>
            //                (!messageId.HasValue || x.MessageId == messageId));

            return chatAppContext.Messages.Find(messageId);



        }

    }
}
