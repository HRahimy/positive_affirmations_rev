using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WebStack.Application.Common.Interfaces;
using WebStack.Application.Common.Mappings;
using WebStack.Application.Common.Models;

namespace WebStack.Application.Affirmations.Queries.GetPaginatedAffirmations;
public class GetPaginatedAffirmationsQuery : IRequest<PaginatedList<AffirmationListItem>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetPaginatedAffirmationsQueryHandler : IRequestHandler<GetPaginatedAffirmationsQuery, PaginatedList<AffirmationListItem>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetPaginatedAffirmationsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<AffirmationListItem>> Handle(GetPaginatedAffirmationsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Affirmations
            .OrderBy(x => x.Created)
            .ProjectTo<AffirmationListItem>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
