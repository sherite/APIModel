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

        public async Task<ManagerResponse<UserDTO>> Change(UserDTO entity, object context)
        {
            return await new DAL.Models.User((DataBaseContext)context).Change(entity, context);
        }

        public async Task<ManagerResponse<UserDTO>> Delete(string id, object context)
        {
            return await new DAL.Models.User((DataBaseContext)context).Delete(id, context);
        }

        public async Task<ManagerResponse<UserDTO>> Insert(User entity, object context)
        {
            return await new DAL.Models.User((DataBaseContext)context).Insert(entity, context);
        }

        public async Task<ManagerResponse<UserDTO>> SelectByFilter(Parameters filter, object context)
        {
            return await new DAL.Models.User((DataBaseContext)context).SelectByFilter(filter, context);
        }

        public async Task<ManagerResponse<UserDTO>> SelectById(string id, object context)
        {
            return await new DAL.Models.User((DataBaseContext)context).SelectById(id, context);
        }
    }
}