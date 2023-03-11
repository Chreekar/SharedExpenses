using System;

namespace SharedExpenses.Models.Dtos
{
	public class MonthlyExpenseCreateDto
    {
        public required int Year { get; init; }
        public required int Month { get; init; }
        public required int NetIncomePartner1 { get; init; }
        public required int NetIncomePartner2 { get; init; }
        public required int ExpenseFixed { get; init; }
        public required int ExpenseExtra { get; init; }
        public required int ExpenseSaving { get; init; }
        public required int ExpenseGroceries { get; init; }
    }
}

