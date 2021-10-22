namespace BRL.Managers
{
    using Common;

    using Entities.DTOs;
    using Entities.Models;

    using System;
    using System.Threading.Tasks;

    public class GroupManager : IGenericManager<Group, GroupDTO>
    {
        public Task<ManagerResponse<GroupDTO>> Change(GroupDTO entity, object context)
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

        public bool ValidateDelete(object element)
        {
            throw new NotImplementedException();
        }

        public bool ValidateInsert(object element)
        {
            throw new NotImplementedException();
        }

        public bool ValidateSelectByFilter(object element)
        {
            throw new NotImplementedException();
        }

        public bool ValidateSelectById(object element)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUpdate(object element)
        {
            throw new NotImplementedException();
        }
    }
}