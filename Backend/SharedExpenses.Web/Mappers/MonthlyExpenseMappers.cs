using System;
using SharedExpenses.Models.Domain;
using SharedExpenses.Models.Dtos;
using SharedExpenses.Web.Models;

namespace SharedExpenses.Web.Mappers
{
    public static class MonthlyExpenseMappers
    {
        public static MonthlyExpenseApiModel ToApiModel(this MonthlyExpense from)
        {
            return new MonthlyExpenseApiModel
            {
                Id = from.Id.ToString("N"),
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

        public static MonthlyExpenseCreateDto ToCreateDto(this MonthlyExpensePostApiModel from)
        {
            return new MonthlyExpenseCreateDto
            {
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

        public static MonthlyExpenseUpdateDto ToUpdateDto(this MonthlyExpensePutApiModel from, MonthlyExpense existing)
        {
            return new MonthlyExpenseUpdateDto
            {
                Id = existing.Id,
                Year = existing.Year,
                Month = existing.Month,
                NetIncomePartner1 = from.NetIncomePartner1,
                NetIncomePartner2 = from.NetIncomePartner2,
                ExpenseFixed = from.ExpenseFixed,
                ExpenseExtra = from.ExpenseExtra,
                ExpenseSaving = from.ExpenseSaving,
                ExpenseGroceries = from.ExpenseGroceries
            };
        }
    }
}

