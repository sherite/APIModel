namespace BRL.Managers
{
    using System.Threading.Tasks;

    using Common;
    using DAL;
    using Entities.Models;
    using Entities.DTOs;

    public class GroupManager : IGenericManager<Group, GroupDTO>
    {
        public async Task<ManagerResponse<GroupDTO>> Change(GroupDTO entity, object context)
        {
            return await new DAL.Models.Group((DataBaseContext)context).Change(entity, context);
        }

        public async Task<ManagerResponse<GroupDTO>> Delete(string id, object context)
        {
            return await new DAL.Models.Group((DataBaseContext)context).Delete(id, context);
        }

        public async Task<ManagerResponse<GroupDTO>> Insert(Group entity, object context)
        {
            return await new DAL.Models.Group((DataBaseContext)context).Insert(entity, context);
        }

        public async Task<ManagerResponse<GroupDTO>> SelectByFilter(Parameters filter, object context)
        {
            return await new DAL.Models.Group((DataBaseContext)context).SelectByFilter(filter, context);
        }

        public async Task<ManagerResponse<GroupDTO>> SelectById(string id, object context)
        {
            return await new DAL.Models.Group((DataBaseContext)context).SelectById(id, context);
        }

        public bool ValidateDelete(object element)
        {
            bool retVal = false;

            return retVal;
        }

        public bool ValidateInsert(object element)
        {
            bool retVal = false;

            return retVal;
        }

        public bool ValidateSelectByFilter(object element)
        {
            bool retVal = false;

            return retVal;
        }

        public bool ValidateSelectById(object element)
        {
            bool retVal = false;

            return retVal;
        }

        public bool ValidateUpdate(object element)
        {
            bool retVal = false;

            return retVal;
        }
    }
}