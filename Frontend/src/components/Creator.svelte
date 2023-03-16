<script lang="ts">
  import { createEventDispatcher } from "svelte";
  import type { MonthlyExpenseApiModel } from "../core/backend-proxy";
  import { formatMonth } from "../core/format-helpers";

  export let items: MonthlyExpenseApiModel[];

  $: selectableDates = getSelectableDates(items);
  $: selectedDate = selectableDates[0];

  const dispatch = createEventDispatcher<{ selectedForCreation: Date }>();

  function getSelectableDates(items: MonthlyExpenseApiModel[]) {
    const result: Date[] = [];
    let current = new Date();
    do {
      if (
        items.some(
          (x) =>
            x.year === current.getFullYear() &&
            x.month === current.getMonth() + 1
        )
      ) {
        continue;
      }
      result.push(current);
    } while ((current = getPreviousMonth(current)) && result.length < 12);
    return result;
  }

  function getPreviousMonth(current: Date) {
    const result = new Date(
      current.getFullYear(),
      current.getMonth(),
      current.getDate()
    );
    result.setMonth(current.getMonth() - 1);
    return result;
  }

  function setSelectedDate(target: EventTarget & HTMLSelectElement) {
    selectedDate = selectableDates[target.selectedIndex];
  }

  function confirm() {
    dispatch("selectedForCreation", selectedDate);
  }
</script>

<div class="row mb-5">
  <div class="col-sm-6 pr-0">
    <select
      class="form-control"
      on:change={(e) => setSelectedDate(e.currentTarget)}
    >
      {#each selectableDates as selectableDate}
        <option
          value={selectableDate}
          selected={selectableDate === selectedDate}
        >
          {selectableDate.getFullYear()}
          {formatMonth(selectableDate.getMonth() + 1)}
        </option>
      {/each}
    </select>
  </div>
  <div class="col-sm-3">
    <button class="btn btn-success" on:click={confirm}>Create new</button>
  </div>
</div>
