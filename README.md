# SharedExpenses
Split household costs in relation to net income. By entering the net incomes of both partners and expenses in different categories, the amount that each partner should transfer to the household withdrawal account is calculated.

## How to run

```
cd Backend/SharedExpenses.Web
dotnet restore
dotnet run
cd ../../Frontend
npm install
npm run dev
```

## TODO

### Common
- Create ARM templates for Storage Account for Frontend + App Service for Backend + Cosmos instance with composite key on year+month
- Create Github actions to build and deploy to Azure

### Backend
- Better handling of Update without duplicate reading of entity
- Replace Constants.TenantId with a proper authentication solution
- Unit testing

### Frontend
- Use svelte-i18n to format money instead of hard coded SEK
- Error handling, loading state, unit testing...

## Gotchas

- When getting the month from the javascript `Date`, January will be 0 and not 1 as represented in the backend.
