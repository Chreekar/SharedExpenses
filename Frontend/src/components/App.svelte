<script lang="ts">
  import {
    GeneratedBackendProxy,
    type MonthlyExpenseApiModel,
    type MonthlyExpensePostApiModel,
    type MonthlyExpensePutApiModel,
  } from "../core/backend-proxy";
  import { getAppConfig, type AppConfig } from "../core/config";
  import { formatMonth } from "../core/format-helpers";
  import { getOrderedItems } from "../core/logic";

  import Details from "./Details.svelte";
  import Creator from "./Creator.svelte";
  import List from "./List.svelte";

  let isLoading = true;
  let isLoadError = false;

  let api: GeneratedBackendProxy;
  let appSettings: AppConfig;
  let allItems: MonthlyExpenseApiModel[];
  let selectedItem: MonthlyExpenseApiModel;

  getAppConfig()
    .then((appConfig) => {
      appSettings = appConfig;
      api = new GeneratedBackendProxy(appConfig.apiBaseUrl);
      return api.getAllMonthlyExpenses();
    })
    .then((items) => {
      allItems = items;
    })
    .catch(() => {
      isLoadError = true;
    })
    .finally(() => {
      isLoading = false;
    });

  function getSubTitle(item?: MonthlyExpenseApiModel) {
    if (item) {
      return `${item.year} ${formatMonth(item.month)}`;
    }
    return "Overview";
  }

  function viewItem(event: CustomEvent<MonthlyExpenseApiModel>) {
    selectedItem = event.detail;
  }

  function deleteItem(event: CustomEvent<MonthlyExpenseApiModel>) {
    api
      .deleteMonthlyExpense(event.detail.year, event.detail.month)
      .then(() => {
        allItems = allItems.filter((x) => x.id !== event.detail.id);
      })
      .catch((error) => {
        // TODO: Pass error message to List component
      });
  }

  function clearItem() {
    selectedItem = null;
  }

  function createItem(event: CustomEvent<Date>) {
    const requestModel: MonthlyExpensePostApiModel = {
      year: event.detail.getFullYear(),
      month: event.detail.getMonth() + 1,
      netIncomePartner1: 0,
      netIncomePartner2: 0,
      expenseFixed: 0,
      expenseExtra: 0,
      expenseSaving: appSettings.defaultExpenseSaving,
      expenseGroceries: appSettings.defaultExpenseGroceries,
    };
    api
      .postMonthlyExpense(requestModel)
      .then((result) => {
        allItems = getOrderedItems([...allItems, result]);
        selectedItem = result;
      })
      .catch((error) => {
        // TODO: Pass error message to Creator component
      });
  }

  function updateItem(event: CustomEvent<MonthlyExpenseApiModel>) {
    const requestModel: MonthlyExpensePutApiModel = {
      netIncomePartner1: event.detail.netIncomePartner1,
      netIncomePartner2: event.detail.netIncomePartner2,
      expenseFixed: event.detail.expenseFixed,
      expenseExtra: event.detail.expenseExtra,
      expenseSaving: event.detail.expenseSaving,
      expenseGroceries: event.detail.expenseGroceries,
    };
    api
      .putMonthlyExpense(event.detail.year, event.detail.month, requestModel)
      .then((result) => {
        allItems = allItems.map((x) => (x.id === result.id ? result : x));
        selectedItem = null;
      })
      .catch((error) => {
        // TODO: Pass error message to Details component
      });
  }
</script>

<div id="wrapper">
  <div class="container">
    <div class="row">
      <div class="col" />
      <div class="col-md-8 mt-5">
        <div class="card shadow mb-4">
          <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">
              Shared Expenses - {getSubTitle(selectedItem)}
            </h6>
          </div>
          <div class="card-body">
            {#if isLoading}
              Loading...
            {:else if isLoadError}
              Error: could not load items!
            {:else if selectedItem}
              <Details
                item={selectedItem}
                {appSettings}
                on:cancelled={clearItem}
                on:changed={updateItem}
              />
            {:else}
              <Creator items={allItems} on:selectedForCreation={createItem} />
              <List
                items={allItems}
                on:selectedForView={viewItem}
                on:selectedForDelete={deleteItem}
              />
            {/if}
          </div>
        </div>
      </div>
      <div class="col" />
    </div>
  </div>
</div>
