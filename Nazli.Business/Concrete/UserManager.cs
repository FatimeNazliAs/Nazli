﻿using Nazli.Business.Abstract;
using Nazli.Common.DataLayer.Entities;
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
    public class UserManager : IUserService
    {
        DalUser _dalUser;
        ChatAppContext chatAppContext = new ChatAppContext();

        public UserManager(DalUser dalUser)
        {
            _dalUser = dalUser;
        }

        public BCResponse Add(UserDto dto)
        {
            #region Business
            var isExists = _dalUser.Any(email: dto.Email);
            if (isExists)
            {
                return new BCResponse() { Errors = "Aynı mail adresi sistemde kayıtlıdır." };

            }
            isExists = _dalUser.Any(userName: dto.Username);
            if (isExists)
            {
                return new BCResponse() { Errors = "Aynı kullanıcı adı sistemde kayıtlıdır." };
            }

            #endregion

            #region Map To Entity
            User entity = new User();
            
            
            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.Username=dto.Username;
            entity.Email = dto.Email;
            entity.Password = dto.Password;
            entity.ProfilePhoto=dto.ProfilePhoto;
            entity.CreateDate=dto.CreateDate;
            entity.IsActive=dto.IsActive;
            entity.IsAdmin=dto.IsAdmin;

            #endregion

            #region Insert
            if (entity.Name.Length>2 && entity.Name.Length < 50)
            {
                var result = _dalUser.Add(entity);
                if (result > 0)
                {

                    return new BCResponse() { Value = result };

                }
                return new BCResponse() { Errors = "Sistem Hatası" };


            }
           
                return new BCResponse() { Errors = "Gereklilikler sağlanamadı" };

            #endregion
            
            
        }

        public BCResponse Update(UserDto dto)
        {
            #region Business
            if (dto.UserId <= 0)
            {
                return new BCResponse() { Errors= "hatalı veri" };
            }
            var isExists = _dalUser.Any(idExcept: dto.UserId,email: dto.Email);
            
            if (isExists)
            {
                return new BCResponse() { Errors = "Aynı mail adresi sistemde kayıtlıdır." };
            }

            isExists = _dalUser.Any(userName:dto.Username);
            if (isExists)
            {

                return new BCResponse() { Errors = "Aynı kullanıcı adı sistemde kayıtlıdır." };
            }
            #endregion
            #region Map To Entity
            User? entity = _dalUser.GetBy(id: dto.UserId);
            if (entity==null)
            {
                return new BCResponse() { Errors = "kayıt bulunamadı" };
            }
            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.Username = dto.Username;
            entity.Email = dto.Email;
            entity.Password = dto.Password;
            entity.ProfilePhoto = dto.ProfilePhoto;
            entity.CreateDate = dto.CreateDate;
            entity.IsActive = dto.IsActive;
            entity.IsAdmin = dto.IsAdmin;

            #endregion

            #region Update
            var result = _dalUser.Update(entity);
            if (result > 0)
            {
                return new BCResponse() { Value = result };

            }
            #endregion
            return new BCResponse() { Errors = "Sistem Hatası" };

        }

        public BCResponse Delete(UserDto dto)

        {
            #region Business
            if (dto.UserId <= 0)
            {
                return new BCResponse() { Errors = "hatalı veri" };
            }
            #endregion
            #region Delete
            User? entity = chatAppContext.Users.FirstOrDefault(u => u.UserId == dto.UserId);
            if (entity!=null)
            {
                _dalUser.Delete(entity);
                return new BCResponse() {Value=entity };

            }
            #endregion
            return new BCResponse() { Errors = "Kullanıcı silinemedi" };

        }

        
        public List<User> GetUsers()
        {
            return chatAppContext.Set<User>().ToList();

        }

        public User? GetById(int id)
        {

            return chatAppContext.Set<User>().FirstOrDefault(x => x.UserId == id);
        }

        public User? GetByUserName(string username)
        {

            return chatAppContext.Set<User>().FirstOrDefault(x => x.Username == username);
        }


    }
}