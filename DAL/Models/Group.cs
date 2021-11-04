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

    public class Group : IGenericDalManager<Entities.Models.Group, GroupDTO>
    {
        readonly DataBaseContext _context;

        public Group(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ManagerResponse<GroupDTO>> Change(GroupDTO entity, object context)
        {
            var retVal = new ManagerResponse<GroupDTO>
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            _context.Update(entity.ToModel());
            await _context.SaveChangesAsync();

            return retVal;

        }

        public async Task<ManagerResponse<GroupDTO>> Delete(string id, object context)
        {
            var retVal = new ManagerResponse<GroupDTO>()
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            var user = await _context.Groups.FirstOrDefaultAsync(x => x.ID.ToString() == id);

            if (user != null)
            {
                var result = _context.Remove(user);
                await _context.SaveChangesAsync();
            }

            return retVal;

        }

        public async Task<ManagerResponse<GroupDTO>> Insert(Entities.Models.Group entity, object context)
        {
            var retVal = new ManagerResponse<GroupDTO>
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            await _context.Groups.AddAsync(entity);
            await _context.SaveChangesAsync();


            return retVal;

        }

        public async Task<ManagerResponse<GroupDTO>> SelectByFilter(Parameters filter, object context)
        {
            var retVal = new ManagerResponse<GroupDTO>
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            var result = await _context.Groups.Where(u => u.ID >= int.Parse(filter.FromId) && u.ID <= int.Parse(filter.ToId)).ToListAsync();
            await _context.SaveChangesAsync();

            return retVal;
        }

        public async Task<ManagerResponse<GroupDTO>> SelectById(string id, object context)
        {
            var retVal = new ManagerResponse<GroupDTO>
            {
                ExternalCorrelationId = Guid.NewGuid()
            };

            var result = await _context.Groups.FirstOrDefaultAsync(m => m.ID.ToString() == id);

            var response = new ObjectResponse<GroupDTO>
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