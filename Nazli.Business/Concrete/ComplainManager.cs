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
            #region Business
            
            var isExists = _dalComplain.FindMessage(messageId: dto.MessageReferenceId);
            if (isExists==null)
            {
                return new BCResponse() { Errors = "Mesajlaşma yoktur." };

            }

            //var complainedExists = _dalComplain.Any(complainedOfUserId: dto.ComplainedOfUserId);
            //if (complainedExists)
            //{
            //    return new BCResponse() { Errors = "Sikayet edilen kişi sistemde kayıtlıdır." };

            //}
            //var complainantUserExists = _dalComplain.Any(complainantUserId: dto.ComplainantUserId);
            //if (complainantUserExists)
            //{
            //    return new BCResponse() { Errors = "Sikayetçi kişi sistemde kayıtlıdır." };

            //}
            var complainStatusExists = _dalComplain.Any(complainStatusId: dto.ComplainStatusId);
            if (!complainStatusExists)
            {
                return new BCResponse() { Errors = "Sikayet edilme nedeni sistemde kayıtlıdır." };
            }
            #endregion

            #region Map To Entity
            Complain entity = new Complain();
            entity.ComplainantUserId = dto.ComplainantUserId;
            entity.ComplainStatusId = dto.ComplainStatusId;
            entity.ComplainedOfUserId=dto.ComplainedOfUserId;
            entity.ComplainDate=dto.ComplainDate;
            entity.MessageReferenceId = dto.MessageReferenceId;
            #endregion


            #region Add
            var result = _dalComplain.Add(entity);
            if (result>0)
            {
                return new BCResponse() { Value = result };
            }

            return new BCResponse() { Errors = "Sistem Hatası" };
            #endregion
        }

        public BCResponse Delete(int id)
        {
            #region Business
            if (id <= 0)
            {
                return new BCResponse() { Errors = "hatalı veri" };
            }
            #endregion

            #region Delete
            Complain? entity = chatAppContext.Complains.FirstOrDefault(u => u.ComplainId== id);
            if (entity != null)
            {
                _dalComplain.Delete(entity);
                return new BCResponse() { Value = entity };

            }
            #endregion
            return new BCResponse() { Errors = "Kullanıcı silinemedi" };
        }

        public BCResponse Update(ComplainDto dto)
        {
            #region Business
            if (dto.ComplainId <= 0)
            {
                return new BCResponse() { Errors = "hatalı veri" };
            }
            
            var isExists = _dalComplain.Any(complainStatusId: dto.ComplainStatusId);

            if (isExists)
            {
                return new BCResponse() { Errors = "Aynı şikayet nedeni sistemde kayıtlıdır." };
            }

            isExists = _dalComplain.Any(complainedOfUserId: dto.ComplainedOfUserId);
            if (isExists)
            {

                return new BCResponse() { Errors = "Şikayet edilen kişi zaten sistemde kayıtlıdır." };
            }
            #endregion
            
            #region Map To Entity
            Complain? entity = _dalComplain.GetBy(complainId: dto.ComplainId);
            if (entity == null)
            {
                return new BCResponse() { Errors = "Şikayet bulunamadı" };
            }
           
            entity.ComplainantUserId = dto.ComplainantUserId;
            entity.ComplainStatusId = dto.ComplainStatusId;
            entity.ComplainedOfUserId = dto.ComplainedOfUserId;
            entity.ComplainDate = dto.ComplainDate;


            #endregion

            #region Update
            var result = _dalComplain.Update(entity);
            if (result > 0)
            {
                return new BCResponse() { Value = result };

            }
            #endregion
            return new BCResponse() { Errors = "Sistem Hatası" };
        }
       
 
        public BCResponse GetById(int id)
        {
            
            var result = _dalComplain.GetById(id);

            if (result != null)
            {
                return new BCResponse() { Value = result };
            }

            return new BCResponse() { Errors = "Kullanıcı Bulunamadı" };
        }

        public BCResponse GetComplainByUserID(int id)
        {
            var result = _dalComplain.GetComplainByUserID(id);

            if (result != null)
            {
                return new BCResponse() { Value = result };
            }

            return new BCResponse() { Errors = "Kullanıcı Bulunamadı" };
        }

        public BCResponse GetListAll()
        {
           
            var result = _dalComplain.GetListAll();
            if (result.Count > 0)
            {
                return new BCResponse() { Value = result };
            }
            return new BCResponse() { Errors = "Kayıt Bulunamadı" };
        }


    }
}
