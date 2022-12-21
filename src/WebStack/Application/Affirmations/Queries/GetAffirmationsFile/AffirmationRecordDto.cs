using AutoMapper;
using WebStack.Application.Common.Mappings;
using WebStack.Domain.Entities;

namespace WebStack.Application.Affirmations.Queries.GetAffirmationsFile
{
    public class AffirmationRecordDto : IMapFrom<Affirmation>
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }
        public bool Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Affirmation, AffirmationRecordDto>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Subtitle, opt => opt.MapFrom(s => s.Subtitle != null ? s.Subtitle : string.Empty))
                .ForMember(d => d.Active, opt => opt.MapFrom(s => s.Active != null ? s.Active : false));
        }
    }
}
