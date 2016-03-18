namespace GrSU.University.Domain.Services.Mapping
{
    using System;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;

    public static class Mapper
    {
        private static IMapper mapper;

        static Mapper()
        {
            InitMap();
        }

        public static T Map<T>(this object source)
        {
            return mapper.Map<T>(source);
        }

        private static void InitMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                foreach (var profileType in Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => t.BaseType != null && t.BaseType == typeof(Profile)))
                {
                    cfg.AddProfile((Profile)Activator.CreateInstance(profileType));
                }

                cfg.CreateMissingTypeMaps = true;
            });

            mapper = configuration.CreateMapper();
        }
    }
}
