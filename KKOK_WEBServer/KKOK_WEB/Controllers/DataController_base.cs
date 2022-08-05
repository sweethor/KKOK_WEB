using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace KKOK_WEB.Controllers
{
    
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class DataController_base : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
