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
        public Task<ManagerResponse<UserDTO>> Change(string id, string change, object context)
        {
            throw new System.NotImplementedException();
        }

        public Task<ManagerResponse<UserDTO>> Delete(string id, object context)
        {
            throw new System.NotImplementedException();
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

        public async Task<ManagerResponse<UserDTO>> ValidateInsert(User element, object ctx)
        {
            return await new DAL.Models.User((DataBaseContext)ctx).Insert(element, ctx);
        }

        public async Task<ManagerResponse<UserDTO>> ValidateParams(Parameters parameters, object ctx)
        {
            return await new DAL.Models.User((DataBaseContext)ctx).ValidateParams(parameters, ctx);
        }
    }
}