namespace BRL.Managers
{
    using Common;

    using Entities.DTOs;
    using Entities.Models;

    using System;
    using System.Threading.Tasks;

    public class GroupManager : IGenericManager<Group, GroupDTO>
    {
        public Task<ManagerResponse<GroupDTO>> Change(string id, string change, object context)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<GroupDTO>> Delete(string id, object context)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<GroupDTO>> Insert(Group entity, object context)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<GroupDTO>> SelectByFilter(Parameters filter, object context)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<GroupDTO>> SelectById(string id, object context)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<GroupDTO>> ValidateInsert(Group element, object context)
        {
            throw new NotImplementedException();
        }

        public Task<ManagerResponse<GroupDTO>> ValidateParams(Parameters parameters, object context)
        {
            throw new NotImplementedException();
        }
    }
}