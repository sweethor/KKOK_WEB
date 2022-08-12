using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Create;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Delete;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Update;
using OracleEFCore5.Application.Features.DbTestTable.Queries.Gets;
using OracleEFCore5.Application.Features.DbTestTable.Queries.GetById;
using Serilog;
using System;
using System.Threading.Tasks;


namespace KKOK_WEB.Controllers.TableEntityController
{
    [ApiVersion("1.0")]
    public class MembersNoticeController : DataController_base
    {
        private readonly ILoggerFactory _loggerFactory;
        public MembersNoticeController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        /// <summary>
        /// GET: api/controller
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetMembersNoticeQuery filter)
        {
            Log.Information($"GET Position called at {DateTime.Now}");
            _loggerFactory.CreateLogger("GET Position called at");
            return Ok(await Mediator.Send(filter));
        }

        /// <summary>
        /// GET api/controller/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetMemberNoticeByIdQuery { Id = id }));
        }

        /// <summary>
        /// POST api/controller
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        // [Authorize]
        public async Task<IActionResult> Post(CreateMemberNoticeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Bulk insert fake data by specifying number of rows
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddMock")]
        // [Authorize]
        public async Task<IActionResult> AddMock(InsertMockMemberNoticeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        /// <summary>
        /// PUT api/controller/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(Guid id, UpdateMemberNoticeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// DELETE api/controller/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteMemberNoticeByIdCommand { Id = id }));
        }
    }
}
