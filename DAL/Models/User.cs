namespace DAL.Models
{
    using Common;

    using Entities.DTOs;
    using Entities.Models;

    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class User : IGenericManager<User, UserDTO>
    {
        readonly DataBaseContext _context;

        public User(DataBaseContext context)
        {
            _context = context;
        }

        public Task<ManagerResponse<UserDTO>> Change(string id, string change)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<UserDTO>> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<UserDTO>> Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<UserDTO>> SelectByFilter(Parameters filter)
        {
            throw new NotImplementedException();
        }

        public async Task<ManagerResponse<UserDTO>> SelectById(string id, object context)
        {
            var retVal = new ManagerResponse<UserDTO>
            {
                CorrelationId = Guid.NewGuid()
            };

            var result = (await _context.Users.FirstOrDefaultAsync(m => m.ID.ToString() == id)).ToDTO();

            retVal.Object = result;
            retVal.AdditionalInfo = string.Empty;
            retVal.ErrorsList = new List<Error>();

            return retVal;
        }

        public Task<ManagerResponse<UserDTO>> ValidateInsert(User element)
        {
            throw new NotImplementedException();
        }

        public bool ValidateParams(Parameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
