namespace BRL.Managers
{
    using Common;
    using static Common.Consts;

    using Entities.Models;

    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Entities.DTOs;

    using DAL;
    using DAL.Data;
    using Microsoft.EntityFrameworkCore;


    public class UserGroupsManager : IGenericManager<UserGroups, UserGroupsDTO>
    {
        public async Task<ManagerResponse<UserGroupsDTO>> Change(UserGroupsDTO entity, object context)
        {
            return await new DAL.Models.UserGroups((DataBaseContext)context).Change(entity, context);
        }

        public async Task<ManagerResponse<UserGroupsDTO>> Delete(string id, object context)
        {
            return await new DAL.Models.UserGroups((DataBaseContext)context).Delete(id, context);
        }

        public async Task<ManagerResponse<UserGroupsDTO>> Insert(UserGroups entity, object context)
        {
            return await new DAL.Models.UserGroups((DataBaseContext)context).Insert(entity, context);
        }

        public async Task<ManagerResponse<UserGroupsDTO>> SelectByFilter(Parameters filter, object context)
        {
            return await new DAL.Models.UserGroups((DataBaseContext)context).SelectByFilter(filter, context);
        }

        public async Task<ManagerResponse<UserGroupsDTO>> SelectById(string id, object context)
        {
            return await new DAL.Models.UserGroups((DataBaseContext)context).SelectById(id, context);
        }

        public bool ValidateDelete(object element)
        {
            return true;
        }

        public bool ValidateInsert(object element)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateSelectByFilter(object element)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateSelectById(object element)
        {
            return true;
        }

        public bool ValidateUpdate(object element)
        {
            throw new System.NotImplementedException();
        }
    }
}
