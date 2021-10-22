namespace DAL.Models
{
    using Common;

    using Entities.DTOs;
    using Entities.Models;

    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class User : IGenericDalManager<Entities.Models.User, UserDTO>
    {
        readonly DataBaseContext _context;

        public User(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IManagerResponse<UserDTO>> Change(UserDTO entity, object context)
        {
            var retVal = new ManagerResponse<UserDTO>
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            _context.Update(entity.ToModel());
            await _context.SaveChangesAsync();

            return retVal;
        }

        public async Task<IManagerResponse<UserDTO>> Delete(string id, object context)
        {
            var retVal = new ManagerResponse<UserDTO>()
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            var user = await _context.Users.FirstOrDefaultAsync(x => x.ID.ToString() == id);

            if (user != null)
            {
                var result = _context.Remove(user);
                await _context.SaveChangesAsync();
            }

            return retVal;
        }

        public async Task<IManagerResponse<UserDTO>> Insert(Entities.Models.User entity, object context)
        {
            var retVal = new ManagerResponse<UserDTO>
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();


            return retVal;
        }

        public async Task<IManagerResponse<UserDTO>> SelectByFilter(Parameters filter, object context)
        {
            var retVal = new ManagerResponse<UserDTO>
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            var result = await _context.Users.Where(u => u.ID >= int.Parse(filter.FromId) && u.ID <= int.Parse(filter.ToId)).ToListAsync();
            await _context.SaveChangesAsync();

            return retVal;
        }

        public async Task<IManagerResponse<UserDTO>> SelectById(string id, object context)
        {
            var retVal = new ManagerResponse<UserDTO>
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            var result = await _context.Users.FirstOrDefaultAsync(m => m.ID.ToString() == id);

            var response = new ObjectResponse<UserDTO>
            {
                InternalCorrelationId = Guid.NewGuid(),
                Object = result.ToDTO(),
                Error = null
            };

            retVal.Object.Add(response);

            retVal.HasErrors = false;

            return retVal;
        }
    }
}