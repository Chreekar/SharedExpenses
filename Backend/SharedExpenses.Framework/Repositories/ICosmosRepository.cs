using System;
using SharedExpenses.Models.Domain;
using SharedExpenses.Models.Dtos;

namespace SharedExpenses.Framework.Repositories
{
	public interface ICosmosRepository
    {
		Task<IEnumerable<MonthlyExpense>> GetAll(string tenantId);
		Task<MonthlyExpense?> Get(string tenantId, int year, int month);
		Task<MonthlyExpense> Create(string tenantId, MonthlyExpenseCreateDto model);
        Task<MonthlyExpense> Update(string tenantId, MonthlyExpenseUpdateDto model);
        Task Delete(string tenantId, Guid id);
	}
}

