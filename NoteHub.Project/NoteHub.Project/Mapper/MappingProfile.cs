using AutoMapper;
using NoteHub.Project.Entities;
using NoteHub.Project.ViewModels;

namespace NoteHub.Project.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NoteEntity, NoteViewModel>()
                .ForMember(
                    dest =>
                        dest.Date,
                    source =>
                        source.MapFrom(res => res.Date.ToString("dd MMMM yyyy")));
        }
    }
}