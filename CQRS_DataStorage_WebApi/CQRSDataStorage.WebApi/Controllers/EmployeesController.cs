using System;
using System.Collections.Generic;
using CQRSDataStorage.Commands.Abstractions;
using CQRSDataStorage.Commands.Commands;
using CQRSDataStorage.Domain.Entities;
using CQRSDataStorage.Queries.Abstractions;
using CQRSDataStorage.Queries.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDataStorage.WebApi.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public EmployeesController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public IEnumerable<EmployeeEntity> Get()
        {
            var getAllQuery = new GetAllEmployeesQuery();

            var result = _queryDispatcher.Execute<GetAllEmployeesQuery, IEnumerable<EmployeeEntity>>(getAllQuery);

            return result;
        }

        [HttpPost]
        public void Post([FromBody] EmployeeEntity employeeEntity)
        {
            var createCommand = new AddEmployeeCommand(employeeEntity);

            _commandDispatcher.Execute(createCommand);
        }

        [HttpDelete("{companyName}/{countryName}/{employeeId}")]
        public IActionResult Delete(Guid employeeId, string companyName, string countryName)
        {
            var deleteCommand = new DeleteEmployeeCommand(employeeId, companyName, countryName);

            _commandDispatcher.Execute(deleteCommand);

            return Ok();
        }
    }
}
