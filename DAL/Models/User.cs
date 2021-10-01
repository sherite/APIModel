namespace DAL.Models
{
    using Common;

    using Entities.DTOs;
    using Entities.Models;

    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class User : IGenericDalManager<Entities.Models.User, UserDTO>
    {
        readonly DataBaseContext _context;

        public User(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ManagerResponse<UserDTO>> Change(UserDTO entity, object context)
        {
            var retVal = new ManagerResponse<UserDTO>
            {
                CorrelationId = Guid.NewGuid()
            };

            _context.Update(entity.ToModel());
            await _context.SaveChangesAsync();

            return retVal;
        }

        public async Task<ManagerResponse<UserDTO>> Delete(string id, object context)
        {
            var retVal = new ManagerResponse<UserDTO>()
            {
                CorrelationId = Guid.NewGuid()
            };

            var user = await _context.Users.FirstOrDefaultAsync(x => x.ID.ToString() == id);

            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }

            return retVal;
        }

        public async Task<ManagerResponse<UserDTO>> Insert(Entities.Models.User entity, object context)
        {
            var retVal = new ManagerResponse<UserDTO>
            {
                CorrelationId = Guid.NewGuid()
            };

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            retVal.Object = entity.ToDTO();

            retVal.AdditionalInfo = string.Empty;
            retVal.ErrorsList = new List<Error>();

            return retVal;
        }

        public async Task<ManagerResponse<UserDTO>> SelectByFilter(Parameters filter, object context)
        {
            var retVal = new ManagerResponse<UserDTO>
            {
                CorrelationId = Guid.NewGuid()
            };

            await _context.SaveChangesAsync();

            return retVal;
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
    }
}