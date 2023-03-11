using System;
using System.ComponentModel.DataAnnotations;

namespace SharedExpenses.Web.Models
{
	public class MonthlyExpensePutApiModel
	{
        [Required]
        [Range(0, int.MaxValue)]
        public required int NetIncomePartner1 { get; init; }
        [Required]
        [Range(0, int.MaxValue)]
        public required int NetIncomePartner2 { get; init; }
        [Required]
        [Range(0, int.MaxValue)]
        public required int ExpenseFixed { get; init; }
        [Required]
        [Range(0, int.MaxValue)]
        public required int ExpenseExtra { get; init; }
        [Required]
        [Range(0, int.MaxValue)]
        public required int ExpenseSaving { get; init; }
        [Required]
        [Range(0, int.MaxValue)]
        public required int ExpenseGroceries { get; init; }
    }
}

