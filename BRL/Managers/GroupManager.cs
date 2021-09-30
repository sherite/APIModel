namespace BRL.Managers
{
    using Common;

    using Entities.DTOs;
    using Entities.Models;

    using System;
    using System.Threading.Tasks;

    public class GroupManager : IGenericManager<Group, GroupDTO>
    {
        public Task<ManagerResponse<GroupDTO>> Change(string id, string change)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<GroupDTO>> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<GroupDTO>> Insert(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<GroupDTO>> SelectByFilter(Parameters filter)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<GroupDTO>> SelectById(string id, object context)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<GroupDTO>> ValidateInsert(Group element)
        {
            throw new NotImplementedException();
        }

        public bool ValidateParams(Parameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}