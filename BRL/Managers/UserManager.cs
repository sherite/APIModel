namespace BRL.Managers
{
    using Common;
    using static Common.Consts;

    using Entities.Models;

    using System.Threading.Tasks;
    using Entities.DTOs;

    using DAL;
    using DAL.Data;
    using Microsoft.EntityFrameworkCore;

    public class UserManager : IGenericManager<User, UserDTO>
    {
        public Task<ManagerResponse<UserDTO>> Change(string id, string change)
        {
            throw new System.NotImplementedException();
        }

        public Task<ManagerResponse<UserDTO>> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ManagerResponse<UserDTO>> Insert(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ManagerResponse<UserDTO>> SelectByFilter(Parameters filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ManagerResponse<UserDTO>> SelectById(string id, object ctx)
        {
            return await new DAL.Models.User((DataBaseContext)ctx).SelectById(id, ctx);
        }

        public Task<ManagerResponse<UserDTO>> ValidateInsert(User element)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateParams(Parameters parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}