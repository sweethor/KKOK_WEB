using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Delete;
using OracleEFCore5.Application.Features.DbTestTable.Queries.Gets;
using OracleEFCore5.Application.Features.DbTestTable.Queries.GetById;
using Serilog;
using System;
using System.Threading.Tasks;
using OracleEFCore5.Domain.Entities.DBTables;
using Newtonsoft.Json;
using OracleEFCore5.Application.Features.DbTest_Table.Commands.Create;
using OracleEFCore5.Application.Features.DbTest_Table.Commands.Update;
using OracleEFCore5.Application.Features.DbTest_Table.Commands.Delete;

namespace KKOK_WEB.Controllers.TableEntityController
{
    [ApiVersion("1.0")]
    public class TestTablesController : DataController_base
    {
        private readonly ILoggerFactory _loggerFactory;
        public TestTablesController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        /// <summary>
        /// GET: api/controller
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProjectsQuery filter)//타입으로 받을 필요 X , 파라미터 통해서 값 전달 해서 DTO 통해서 de시리얼라이징 ->
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
            return Ok(await Mediator.Send(new GetTestTableByIdQuery { Id = id }));
        }

        /// <summary>
        /// POST api/controller
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        //[HttpPost]
        //// [Authorize]
        //public async Task<IActionResult> Post(CreateTestTableCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        [HttpPost]
        // [Authorize]
        public async Task<IActionResult> Post([FromBody] string json)
        {
            TestTable table = JsonConvert.DeserializeObject<TestTable>(json);
            CreateTestTableCommand command = new CreateTestTableCommand();
            command.TestName = table.test_name;
            return Ok(await Mediator.Send(command));
        }


        /*  제네릭 형태로 받아서 전송
        public async Task<IActionResult> Post<T>(T command)
        {
            return Ok(await Mediator.Send(command));
        }
        */

        /// <summary>
        /// Bulk insert fake data by specifying number of rows
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddMock")]
        // [Authorize]
        public async Task<IActionResult> AddMock(InsertMockTestTableCommand command)
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
        public async Task<IActionResult> Put(Guid id, UpdateTestTableCommand command)
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
            return Ok(await Mediator.Send(new DeleteTestTableByIdCommand { Id = id }));
        }
    }
}
