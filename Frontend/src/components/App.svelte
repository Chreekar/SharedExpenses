<script lang="ts">
  import {
    GeneratedBackendProxy,
    type MonthlyExpenseApiModel,
  } from "../core/backend-proxy";
  import { getAppConfig } from "../core/config";

  import Details from "./Details.svelte";
  import List from "./List.svelte";

  let isLoading = true;
  let isError = false;

  let api: GeneratedBackendProxy;
  let allItems: MonthlyExpenseApiModel[];
  let selectedItem: MonthlyExpenseApiModel;

  getAppConfig()
    .then((appConfig) => {
      api = new GeneratedBackendProxy(appConfig.apiBaseUrl);
      return api.getAllMonthlyExpenses();
    })
    .then((items) => {
      allItems = items;
    })
    .catch(() => {
      isError = true;
    })
    .finally(() => {
      isLoading = false;
    });

  function itemSelected(event: CustomEvent<MonthlyExpenseApiModel>) {
    selectedItem = event.detail;
  }
</script>

<div id="wrapper">
  <div class="container">
    <div class="row">
      <div class="col" />
      <div class="col-md-8 mt-5">
        <div class="card shadow mb-4">
          <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">Shared Expenses</h6>
          </div>
          <div class="card-body">
            {#if isLoading}
              Loading...
            {:else if isError}
              Error: could not load items!
            {:else if selectedItem}
              <Details item={selectedItem} />
            {:else}
              <List items={allItems} on:selected={itemSelected} />
            {/if}
          </div>
        </div>
      </div>
      <div class="col" />
    </div>
  </div>
</div>
