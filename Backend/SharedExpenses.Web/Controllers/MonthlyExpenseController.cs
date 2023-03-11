using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SharedExpenses.Framework.Repositories;
using SharedExpenses.Models.Settings;
using SharedExpenses.Web.Mappers;
using SharedExpenses.Web.Models;

namespace SharedExpenses.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("monthlyexpenses")]
    public class MonthlyExpenseController : ControllerBase
    {
        private readonly ICosmosRepository _repository;

        public MonthlyExpenseController(ICosmosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MonthlyExpenseApiModel>>> GetAll()
        {
            var items = await _repository.GetAll(Constants.TenantId);

            return Ok(items.Select(x => x.ToApiModel()));
        }

        [HttpGet]
        [Route("{year}/{month}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<MonthlyExpenseApiModel>> Get(int year, int month)
        {
            var item = await _repository.Get(Constants.TenantId, year, month);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item.ToApiModel());
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<ActionResult<MonthlyExpenseApiModel>> Post([FromBody] MonthlyExpensePostApiModel request)
        {
            var existing = await _repository.Get(Constants.TenantId, request.Year, request.Month);

            if (existing != null)
            {
                return Conflict();
            }

            var dto = request.ToCreateDto();

            var item = await _repository.Create(Constants.TenantId, dto);

            return Ok(item.ToApiModel());
        }

        [HttpPut]
        [Route("{year}/{month}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<MonthlyExpenseApiModel>> Put(int year, int month, [FromBody] MonthlyExpensePutApiModel request)
        {
            var existing = await _repository.Get(Constants.TenantId, year, month);

            if (existing == null)
            {
                return NotFound();
            }

            var dto = request.ToUpdateDto(existing);

            var item = await _repository.Update(Constants.TenantId, dto);

            return Ok(item.ToApiModel());
        }

        [HttpDelete]
        [Route("{year}/{month}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int year, int month)
        {
            var item = await _repository.Get(Constants.TenantId, year, month);

            if (item == null)
            {
                return NotFound();
            }

            await _repository.Delete(Constants.TenantId, item.Id);

            return Ok();
        }
    }
}

