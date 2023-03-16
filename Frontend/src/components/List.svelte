<script lang="ts">
  import { createEventDispatcher } from "svelte";

  import type { MonthlyExpenseApiModel } from "../core/backend-proxy";
  import { formatMonth, formatMoney } from "../core/format-helpers";

  export let items: MonthlyExpenseApiModel[];

  const dispatch = createEventDispatcher<{
    selectedForView: MonthlyExpenseApiModel;
    selectedForDelete: MonthlyExpenseApiModel;
  }>();

  function viewItem(item: MonthlyExpenseApiModel) {
    dispatch("selectedForView", item);
  }

  function deleteItem(item: MonthlyExpenseApiModel) {
    // TODO: Show spinner and disable buttons
    dispatch("selectedForDelete", item);
  }
</script>

<table class="table">
  <thead>
    <tr>
      <th scope="col">Month</th>
      <th scope="col">Partner 1</th>
      <th scope="col">Partner 2</th>
      <th scope="col">Actions</th>
    </tr>
  </thead>
  <tbody>
    {#each items as item}
      <tr>
        <td>{item.year} {formatMonth(item.month)}</td>
        <td>{formatMoney(item.netIncomePartner1)}</td>
        <td>{formatMoney(item.netIncomePartner2)}</td>
        <td>
          <button
            class="btn btn-primary btn-sm mb-0 mr-2"
            on:click={() => viewItem(item)}>View</button>
          <button
            class="btn btn-danger btn-sm mb-0"
            on:click={() => deleteItem(item)}>Delete</button>
        </td>
      </tr>
    {/each}
  </tbody>
</table>

<style>
  td {
    vertical-align: middle;
  }
</style>
