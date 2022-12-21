using MediatR;
using WebStack.Application.Common.Interfaces;
using WebStack.Domain.Entities;

namespace WebStack.Application.Affirmations.Commands.CreateAffirmation
{
    public class CreateAffirmationCommand : IRequest
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public class Handler : IRequestHandler<CreateAffirmationCommand>
        {
            private readonly IWebStackDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IWebStackDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateAffirmationCommand command, CancellationToken cancellationToken)
            {
                var entity = new Affirmation
                {
                    Title = command.Title,
                    Subtitle = command.Subtitle,
                    Active = true,
                };

                _context.Affirmations.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
