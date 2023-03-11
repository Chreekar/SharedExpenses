using System;
using SharedExpenses.Framework.Entities;
using SharedExpenses.Models.Domain;
using SharedExpenses.Models.Dtos;
using SharedExpenses.Models.Settings;

namespace SharedExpenses.Framework.Mappers
{
    public static class MonthlyExpenseMappers
    {
        public static MonthlyExpense ToDomain(this MonthlyExpenseEntity from)
        {
            return new MonthlyExpense
            {
                Id = Guid.Parse(from.Id),
                Year = from.Year,
                Month = from.Month,
                NetIncomePartner1 = from.NetIncomePartner1,
                NetIncomePartner2 = from.NetIncomePartner2,
                ExpenseFixed = from.ExpenseFixed,
                ExpenseExtra = from.ExpenseExtra,
                ExpenseSaving = from.ExpenseSaving,
                ExpenseGroceries = from.ExpenseGroceries
            };
        }

        public static MonthlyExpenseEntity ToEntity(this MonthlyExpenseCreateDto from, string tenantId)
        {
            return new MonthlyExpenseEntity
            {
                Id = Guid.NewGuid().ToString("N"),
                TenantId = tenantId,
                Year = from.Year,
                Month = from.Month,
                NetIncomePartner1 = from.NetIncomePartner1,
                NetIncomePartner2 = from.NetIncomePartner2,
                ExpenseFixed = from.ExpenseFixed,
                ExpenseExtra = from.ExpenseExtra,
                ExpenseSaving = from.ExpenseSaving,
                ExpenseGroceries = from.ExpenseGroceries,
                DateCreated = DateTime.UtcNow,
                DateUpdated = null
            };
        }

        public static MonthlyExpenseEntity ToEntity(this MonthlyExpenseUpdateDto from, MonthlyExpenseEntity existing)
        {
            return new MonthlyExpenseEntity
            {
                Id = from.Id.ToString("N"),
                TenantId = existing.TenantId,
                Year = from.Year,
                Month = from.Month,
                NetIncomePartner1 = from.NetIncomePartner1,
                NetIncomePartner2 = from.NetIncomePartner2,
                ExpenseFixed = from.ExpenseFixed,
                ExpenseExtra = from.ExpenseExtra,
                ExpenseSaving = from.ExpenseSaving,
                ExpenseGroceries = from.ExpenseGroceries,
                DateCreated = existing.DateCreated,
                DateUpdated = DateTime.UtcNow
            };
        }
    }
}

