# SharedExpenses
Split household costs in relation to net income

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

### Frontend
- Use svelte-i18n to format money instead of hard coded SEK
