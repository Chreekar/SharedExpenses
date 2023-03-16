import type { MonthlyExpenseApiModel } from "./backend-proxy";
import type { AppConfig } from "./config";

export function getOrderedItems(items: MonthlyExpenseApiModel[]) {
    return [...items].sort((a, b) => a.year > b.year ? -1 : (a.year < b.year ? 1 : (a.month > b.month ? -1 : 1)));
}

export function getCalculations(item: MonthlyExpenseApiModel, appSettings: AppConfig): CalculationResults {
    const totalExpenses = item.expenseFixed + item.expenseExtra + item.expenseSaving + item.expenseGroceries;
    const roundedTotalExpenses = Math.ceil(totalExpenses / appSettings.roundUpTotalNearest) * appSettings.roundUpTotalNearest;
    if (!item.netIncomePartner1 && !item.netIncomePartner2) {
        return {
            roundedTotalExpenses,
            transferAmountPartner1: 0,
            transferAmountPartner2: 0
        };
    }
    const transferAmountPartner1 = totalExpenses * (item.netIncomePartner1 / (item.netIncomePartner1 + item.netIncomePartner2));
    const transferAmountPartner2 = totalExpenses * (item.netIncomePartner2 / (item.netIncomePartner1 + item.netIncomePartner2));
    return {
        roundedTotalExpenses,
        transferAmountPartner1,
        transferAmountPartner2
    }
}

export interface CalculationResults {
    roundedTotalExpenses: number,
    transferAmountPartner1: number,
    transferAmountPartner2: number
}