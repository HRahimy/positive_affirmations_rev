using Microsoft.AspNetCore.Mvc;
using WebStack.Application.Affirmations.Commands.CreateAffirmation;
using WebStack.Application.Affirmations.Queries.GetAffirmationsFile;

namespace WebStack.WebUI.Controllers
{
    public class AffirmationsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create(CreateAffirmationCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<FileResult> Download()
        {
            var vm = await Mediator.Send(new GetAffirmationsFileQuery());

            return File(vm.Content, vm.ContentType, vm.FileName);
        }
    }
}
