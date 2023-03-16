<script lang="ts">
  import { createEventDispatcher } from "svelte";

  import type { MonthlyExpenseApiModel } from "../core/backend-proxy";
  import type { AppConfig } from "../core/config";
  import { formatMoney } from "../core/format-helpers";
  import { getCalculations } from "../core/logic";

  export let item: MonthlyExpenseApiModel;
  export let appSettings: AppConfig;

  $: workingCopy = { ...item };
  $: calculationResults = getCalculations(workingCopy, appSettings);

  const dispatch = createEventDispatcher<{
    cancelled: void;
    changed: MonthlyExpenseApiModel;
  }>();

  function updateValue(target: EventTarget & HTMLInputElement, propertyName: string) {
    const value = Number.isNaN(target.valueAsNumber) ? 0 : target.valueAsNumber;
    workingCopy = {
      ...workingCopy,
      [propertyName]: value,
    };
  }

  function isDirty(workingCopy: MonthlyExpenseApiModel) {
    return Object.keys(workingCopy).some(
      (key) => workingCopy[key] !== item[key]
    );
  }

  function cancel() {
    dispatch("cancelled");
  }

  function change() {
    // TODO: Show spinner and lock inputs + disable buttons
    dispatch("changed", workingCopy);
  }
</script>

<form>
  <div class="form-group">
    <label for="inputNetIncomePartner1">Net income partner 1</label>
    <input
      type="number"
      min="0"
      class="form-control"
      id="inputNetIncomePartner1"
      placeholder="Enter income after taxes"
      value={workingCopy.netIncomePartner1}
      on:input={(e) => updateValue(e.currentTarget, "netIncomePartner1")}
    />
  </div>
  <div class="form-group">
    <label for="inputNetIncomePartner2">Net income partner 2</label>
    <input
      type="number"
      min="0"
      class="form-control"
      id="inputNetIncomePartner2"
      placeholder="Enter income after taxes"
      value={workingCopy.netIncomePartner2}
      on:input={(e) => updateValue(e.currentTarget, "netIncomePartner2")}
    />
  </div>
  <div class="form-group">
    <label for="inputExpenseFixed">Fixed expenses</label>
    <input
      type="number"
      min="0"
      class="form-control"
      id="inputExpenseFixed"
      aria-describedby="expenseFixedHelp"
      placeholder="Enter an amount"
      value={workingCopy.expenseFixed}
      on:input={(e) => updateValue(e.currentTarget, "expenseFixed")}
    />
    <small id="expenseFixedHelp" class="form-text text-muted">Mortages, billing and so on</small>
  </div>
  <div class="form-group">
    <label for="inputExpenseExtra">Extra expenses</label>
    <input
      type="number"
      min="0"
      class="form-control"
      id="inputExpenseExtra"
      aria-describedby="expenseExtraHelp"
      placeholder="Enter an amount"
      value={workingCopy.expenseExtra}
      on:input={(e) => updateValue(e.currentTarget, "expenseExtra")}
    />
    <small id="expenseExtraHelp" class="form-text text-muted">Special expenses for this month</small>
  </div>
  <div class="form-group">
    <label for="inputSavingExtra">Saving expenses</label>
    <input
      type="number"
      min="0"
      class="form-control"
      id="inputSavingExtra"
      placeholder="Enter an amount"
      value={workingCopy.expenseSaving}
      on:input={(e) => updateValue(e.currentTarget, "expenseSaving")}
    />
  </div>
  <div class="form-group">
    <label for="inputExpenseGroceries">Household expenses</label>
    <input
      type="number"
      min="0"
      class="form-control"
      id="inputExpenseGroceries"
      aria-describedby="expenseGroceriesHelp"
      placeholder="Enter an amount"
      value={workingCopy.expenseGroceries}
      on:input={(e) => updateValue(e.currentTarget, "expenseGroceries")}
    />
    <small id="expenseGroceriesHelp" class="form-text text-muted">Groceries, restaurant visits and so on</small>
  </div>
  <hr />
  <p>
    Total expenses: {formatMoney(calculationResults.roundedTotalExpenses)} 
    (rounded up to nearest {appSettings.roundUpTotalNearest})
  </p>
  <p>
    Partner 1 should transfer: {formatMoney(calculationResults.transferAmountPartner1)}
  </p>
  <p>
    Partner 2 should transfer: {formatMoney(calculationResults.transferAmountPartner2)}
  </p>
</form>
<hr />
<div class="mt-4">
  <button class="btn btn-primary" on:click={cancel}>Close</button>
  {#if isDirty(workingCopy)}
    <button class="btn btn-success float-right" on:click={change}>Save</button>
  {/if}
</div>
