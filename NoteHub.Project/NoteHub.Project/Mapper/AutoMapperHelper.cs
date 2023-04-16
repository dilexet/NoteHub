using AutoMapper;

namespace NoteHub.Project.Mapper
{
    public class AutoMapperHelper
    {
        private static IMapper _mapper;

        public static IMapper GetMapper()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

                _mapper = mappingConfig.CreateMapper();
            }

            return _mapper;
        }
    }
}