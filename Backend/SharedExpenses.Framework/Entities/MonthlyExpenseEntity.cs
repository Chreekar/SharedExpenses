using System;

namespace SharedExpenses.Framework.Entities
{
	public class MonthlyExpenseEntity
	{
        public required string Id { get; init; }
        public required string TenantId { get; init; }
        public required int Year { get; init; }
        public required int Month { get; init; }
        public required int NetIncomePartner1 { get; init; }
        public required int NetIncomePartner2 { get; init; }
        public required int ExpenseFixed { get; init; }
        public required int ExpenseExtra { get; init; }
        public required int ExpenseSaving { get; init; }
        public required int ExpenseGroceries { get; init; }
        public required DateTime DateCreated { get; init; }
        public required DateTime? DateUpdated { get; init; }
    }
}

