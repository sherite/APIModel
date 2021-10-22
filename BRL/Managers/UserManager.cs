namespace BRL.Managers
{
    using Common;
    using static Common.Consts;

    using Entities.Models;

    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Entities.DTOs;

    using DAL;
    using DAL.Data;
    using Microsoft.EntityFrameworkCore;

    public class UserManager : IGenericManager<User, UserDTO>
    {
        public Task<ManagerResponse<UserDTO>> Change(UserDTO entity, object ctx)
        {
            return new DAL.Models.User((DataBaseContext)ctx).Change(entity, ctx);
        }

        public Task<ManagerResponse<UserDTO>> Delete(string id, object ctx)
        {
            return new DAL.Models.User((DataBaseContext)ctx).Delete(id, ctx);
        }

        public Task<ManagerResponse<UserDTO>> Insert(User entity, object ctx)
        {
           return new DAL.Models.User((DataBaseContext)ctx).Insert(entity, ctx);
        }

        public Task<ManagerResponse<UserDTO>> SelectByFilter(Parameters filter, object context)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ManagerResponse<UserDTO>> SelectById(string id, object ctx)
        {
            return await new DAL.Models.User((DataBaseContext)ctx).SelectById(id, ctx);
        }

        public bool ValidateDelete(object element)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateInsert(object element)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateSelectByFilter(object element)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateSelectById(object element)
        {
            return true;
        }

        public bool ValidateUpdate(object element)
        {
            throw new System.NotImplementedException();
        }
    }
}