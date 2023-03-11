using System;
using System.Drawing;
using SharedExpenses.Framework.Entities;
using SharedExpenses.Framework.Mappers;
using SharedExpenses.Models.Domain;
using SharedExpenses.Models.Dtos;
using SharedExpenses.Models.Settings;

namespace SharedExpenses.Framework.Repositories
{
    public class MockRepository : ICosmosRepository
    {
        private List<MonthlyExpenseEntity> _items;

        public MockRepository()
        {
            _items = GetMockItems();
        }

        public Task<IEnumerable<MonthlyExpense>> GetAll(string tenantId)
        {
            return Task.FromResult(_items.OrderByDescending(x => x.Year).ThenByDescending(x => x.Month).Select(x => x.ToDomain()));
        }

        public Task<MonthlyExpense?> Get(string tenantId, int year, int month)
        {
            return Task.FromResult(_items.FirstOrDefault(x => x.Year == year && x.Month == month)?.ToDomain());
        }

        public Task<MonthlyExpense> Create(string tenantId, MonthlyExpenseCreateDto model)
        {
            var entity = model.ToEntity(tenantId);
            _items.Add(entity);
            return Task.FromResult(entity.ToDomain());
        }

        public Task<MonthlyExpense> Update(string tenantId, MonthlyExpenseUpdateDto model)
        {
            var existing = _items.First(x => x.Id == model.Id.ToString("N"));
            var entity = model.ToEntity(existing);
            _items[_items.IndexOf(existing)] = entity;
            return Task.FromResult(entity.ToDomain());
        }

        public Task Delete(string tentantId, Guid id)
        {
            var entity = _items.First(x => x.Id == id.ToString("N"));
            _items.Remove(entity);
            return Task.CompletedTask;
        }

        #region Helpers

        private List<MonthlyExpenseEntity> GetMockItems()
        {
            return new[] {
                new MonthlyExpenseEntity
                {
                    Id = Guid.NewGuid().ToString("N"),
                    TenantId = Constants.TenantId,
                    Year = 2023,
                    Month = 2,
                    NetIncomePartner1 = 38743,
                    NetIncomePartner2 = 29700,
                    ExpenseFixed = 17133,
                    ExpenseExtra = 0,
                    ExpenseSaving = 4500,
                    ExpenseGroceries = 10000,
                    DateCreated = DateTime.UtcNow.AddMonths(-1),
                    DateUpdated = null
                },
                new MonthlyExpenseEntity
                {
                    Id = Guid.NewGuid().ToString("N"),
                    TenantId = Constants.TenantId,
                    Year = 2023,
                    Month = 1,
                    NetIncomePartner1 = 29014,
                    NetIncomePartner2 = 21739,
                    ExpenseFixed = 9493,
                    ExpenseExtra = 1500,
                    ExpenseSaving = 4500,
                    ExpenseGroceries = 10000,
                    DateCreated = DateTime.UtcNow.AddMonths(-2),
                    DateUpdated = null
                },
                new MonthlyExpenseEntity
                {
                    Id = Guid.NewGuid().ToString("N"),
                    TenantId = Constants.TenantId,
                    Year = 2022,
                    Month = 12,
                    NetIncomePartner1 = 32540,
                    NetIncomePartner2 = 29020,
                    ExpenseFixed = 9539,
                    ExpenseExtra = 0,
                    ExpenseSaving = 500,
                    ExpenseGroceries = 10000,
                    DateCreated = DateTime.UtcNow.AddMonths(-3),
                    DateUpdated = null
                },
                new MonthlyExpenseEntity
                {
                    Id = Guid.NewGuid().ToString("N"),
                    TenantId = Constants.TenantId,
                    Year = 2022,
                    Month = 11,
                    NetIncomePartner1 = 34321,
                    NetIncomePartner2 = 23001,
                    ExpenseFixed = 11453,
                    ExpenseExtra = 1000,
                    ExpenseSaving = 500,
                    ExpenseGroceries = 10000,
                    DateCreated = DateTime.UtcNow.AddMonths(-4),
                    DateUpdated = null
                }
            }.ToList();
        }

        #endregion
    }
}

