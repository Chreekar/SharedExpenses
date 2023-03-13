<script lang="ts">
  import { createEventDispatcher } from "svelte";

  import type { MonthlyExpenseApiModel } from "../core/backend-proxy";
  import { formatMonth, formatMoney } from "../core/format-helpers";

  export let items: MonthlyExpenseApiModel[];

  const dispatch = createEventDispatcher<{
    selected: MonthlyExpenseApiModel;
  }>();

  function select(item: MonthlyExpenseApiModel) {
    dispatch("selected", item);
  }
</script>

<table class="table">
  <thead>
    <tr>
      <th scope="col">Month</th>
      <th scope="col">Partner1</th>
      <th scope="col">Partner2</th>
      <th scope="col">Actions</th>
    </tr>
  </thead>
  <tbody>
    {#each items as item}
      <tr>
        <td>{item.year} {formatMonth(item.month)}</td>
        <td>{formatMoney(item.netIncomePartner1)}</td>
        <td>{formatMoney(item.netIncomePartner2)}</td>
        <td
          ><button class="btn btn-primary btn-sm mb-0" on:click={(e) => select(item)}
            >View</button
          ></td
        >
      </tr>
    {/each}
  </tbody>
</table>

<style>
  td {
    vertical-align: middle;
  }
</style>
