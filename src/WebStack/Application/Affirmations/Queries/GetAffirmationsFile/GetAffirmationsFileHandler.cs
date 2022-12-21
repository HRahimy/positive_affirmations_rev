using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebStack.Application.Common.Interfaces;
using WebStack.Common;

namespace WebStack.Application.Affirmations.Queries.GetAffirmationsFile
{
    public class GetAffirmationsFileHandler : IRequestHandler<GetAffirmationsFileQuery, AffirmationsFileVm>
    {
        private readonly IWebStackDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly ICsvFileBuilder _fileBuilder;
        private readonly IMapper _mapper;

        public GetAffirmationsFileHandler(IWebStackDbContext context, IDateTime dateTime, ICsvFileBuilder fileBuilder, IMapper mapper)
        {
            _context = context;
            _dateTime = dateTime;
            _fileBuilder = fileBuilder;
            _mapper = mapper;
        }

        public async Task<AffirmationsFileVm> Handle(GetAffirmationsFileQuery request, CancellationToken cancellationToken)
        {
            var records = await _context.Affirmations
                .ProjectTo<AffirmationRecordDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var fileContent = _fileBuilder.BuildAffirmationsFile(records);

            return new AffirmationsFileVm
            {
                Content = fileContent,
                ContentType = "text/csv",
                FileName = $"{_dateTime.Now:yyyy-MM-dd}-Affirmations.csv"
            };
        }
    }
}
