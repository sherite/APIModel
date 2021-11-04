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

    public class UserGroups : IGenericDalManager<Entities.Models.UserGroups, UserGroupsDTO>
    {

        readonly DataBaseContext _context;

        public UserGroups(DataBaseContext context)
        {
            _context = context;
        }


        public async Task<ManagerResponse<UserGroupsDTO>> Change(UserGroupsDTO entity, object context)
        {
            var retVal = new ManagerResponse<UserGroupsDTO>
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            _context.Update(entity.ToModel());
            await _context.SaveChangesAsync();

            return retVal;

        }

        public async Task<ManagerResponse<UserGroupsDTO>> Delete(string id, object context)
        {
            var retVal = new ManagerResponse<UserGroupsDTO>()
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            var userGroups = await _context.UserGroups.FirstOrDefaultAsync(x => x.GroupID.ToString() == id);

            if (userGroups != null)
            {
                var result = _context.Remove(userGroups);
                await _context.SaveChangesAsync();
            }

            return retVal;

        }

        public async Task<ManagerResponse<UserGroupsDTO>> Insert(Entities.Models.UserGroups entity, object context)
        {
            var retVal = new ManagerResponse<UserGroupsDTO>
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            await _context.UserGroups.AddAsync(entity);
            await _context.SaveChangesAsync();


            return retVal;

        }

        public async Task<ManagerResponse<UserGroupsDTO>> SelectByFilter(Parameters filter, object context)
        {
            var retVal = new ManagerResponse<UserGroupsDTO>
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            var result = await _context.UserGroups.Where(u => u.UserID >= int.Parse(filter.FromId) && u.UserID <= int.Parse(filter.ToId)).ToListAsync();
            await _context.SaveChangesAsync();

            return retVal;
        }

        public async Task<ManagerResponse<UserGroupsDTO>> SelectById(string id, object context)
        {
            var retVal = new ManagerResponse<UserGroupsDTO>
            {
                ExternalCorrelationId = Guid.NewGuid(),
                Object = new List<ObjectResponse<UserGroupsDTO>>()
            };

            var result = await _context.UserGroups.FirstOrDefaultAsync(m => m.UserID.ToString() == id);

            var response = new ObjectResponse<UserGroupsDTO>
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
