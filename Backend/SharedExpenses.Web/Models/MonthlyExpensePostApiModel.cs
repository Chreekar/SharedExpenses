using System;
using System.ComponentModel.DataAnnotations;

namespace SharedExpenses.Web.Models
{
    public class MonthlyExpensePostApiModel
    {
        [Required]
        [Range(1900, 2100)]
        public required int Year { get; init; }
        [Required]
        [Range(1, 12)]
        public required int Month { get; init; }
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

