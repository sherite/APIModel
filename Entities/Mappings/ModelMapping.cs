namespace Entities.Models
{
    using AutoMapper;

    using Entities.DTOs;

    public static class ModelMapping
    {
        private static readonly IMapper mapper;

        static ModelMapping()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserDTO>(MemberList.None)
                .ReverseMap();

                config.CreateMap<Group, GroupDTO>(MemberList.None)
                .ReverseMap();

                config.CreateMap<UserDTO, User>(MemberList.None)
                .ReverseMap();

                config.CreateMap<GroupDTO, Group>(MemberList.None)
                .ReverseMap();
            });

            mapper = mapperConfig.CreateMapper();
        }

        public static User ToModel(this UserDTO user) => user == null ? null : mapper.Map<UserDTO, User>(user);
        public static Group ToModel(this GroupDTO group) => group == null ? null : mapper.Map<GroupDTO, Group>(group);

        public static UserDTO ToDTO(this User user) => user == null ? null : mapper.Map<User, UserDTO>(user);
        public static GroupDTO ToDTO(this Group group) => group == null ? null : mapper.Map<Group, GroupDTO>(group);
    }
}