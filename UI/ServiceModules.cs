namespace UI
{
    using Autofac;

    using BRL.Managers;

    using Common;

    using Entities.DTOs;
    using Entities.Models;

    /// <summary>
    /// 
    /// </summary>
    public class ServiceModules: Autofac.Module
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<UserManager>().As<IGenericManager<User,UserDTO>>();
            builder.RegisterType<GroupManager>().As<IGenericManager<Group, GroupDTO>>();
        }
    }
}