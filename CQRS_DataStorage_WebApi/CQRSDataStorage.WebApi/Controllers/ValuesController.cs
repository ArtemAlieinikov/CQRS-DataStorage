using System.Collections.Generic;
using CQRSDataStorage.Domain.Entities;
using CQRSDataStorage.Queries.Abstractions;
using CQRSDataStorage.Queries.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDataStorage.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public ValuesController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<EmployeeEntity> Get()
        {
            var query = new GetAllEmployeesQuery();

            var result = _queryDispatcher.Execute<GetAllEmployeesQuery, IEnumerable<EmployeeEntity>>(query);

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
