using WebStack.Application.Common.Mappings;
using WebStack.Domain.Entities;

namespace WebStack.Application.Affirmations.Queries.GetPaginatedAffirmations;
public class AffirmationListItem : IMapFrom<Affirmation>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Subtitle { get; set; }
}
