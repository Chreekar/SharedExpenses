using System;
using System.Drawing;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using SharedExpenses.Framework.Entities;
using SharedExpenses.Framework.Mappers;
using SharedExpenses.Models.Domain;
using SharedExpenses.Models.Dtos;
using SharedExpenses.Models.Settings;

namespace SharedExpenses.Framework.Repositories
{
    public class CosmosRepository : ICosmosRepository
    {
        private readonly string _connectionString;

        public CosmosRepository(IOptions<ApplicationOptions> options)
        {
            _connectionString = options.Value.CosmosConnectionString;
        }

        public async Task<IEnumerable<MonthlyExpense>> GetAll(string tenantId)
        {
            using (var client = GetClient())
            {
                var container = await GetContainer(client);

                var query = new QueryDefinition("SELECT * FROM c ORDER BY c.year DESC, c.month DESC ");

                var options = new QueryRequestOptions
                {
                    PartitionKey = new PartitionKey(tenantId)
                };

                var result = new List<MonthlyExpenseEntity>();

                using (var feed = container.GetItemQueryIterator<MonthlyExpenseEntity>(query, requestOptions: options))
                {
                    while (feed.HasMoreResults)
                    {
                        var response = await feed.ReadNextAsync();

                        result.AddRange(response.AsEnumerable());
                    }
                }

                return result.Select(x => x.ToDomain());
            }
        }

        public async Task<MonthlyExpense?> Get(string tenantId, int year, int month)
        {
            using (var client = GetClient())
            {
                var container = await GetContainer(client);

                var query = new QueryDefinition("SELECT * FROM c WHERE c.year = @year AND c.month = @month")
                                    .WithParameter("@year", year)
                                    .WithParameter("@month", month);

                var options = new QueryRequestOptions
                {
                    PartitionKey = new PartitionKey(tenantId)
                };

                using (var feed = container.GetItemQueryIterator<MonthlyExpenseEntity>(query, requestOptions: options))
                {
                    if (!feed.HasMoreResults)
                    {
                        return null;
                    }

                    var response = await feed.ReadNextAsync();

                    return response.FirstOrDefault()?.ToDomain();
                }
            }
        }

        public async Task<MonthlyExpense> Create(string tenantId, MonthlyExpenseCreateDto model)
        {
            using (var client = GetClient())
            {
                var container = await GetContainer(client);

                var entity = model.ToEntity(tenantId);

                await container.CreateItemAsync(entity);

                return entity.ToDomain();
            }
        }

        public async Task<MonthlyExpense> Update(string tenantId, MonthlyExpenseUpdateDto model)
        {
            using (var client = GetClient())
            {
                var container = await GetContainer(client);

                var existing = await container.ReadItemAsync<MonthlyExpenseEntity>(model.Id.ToString("N"), new PartitionKey(tenantId));

                var entity = model.ToEntity(existing);

                await container.UpsertItemAsync(entity);

                return entity.ToDomain();
            }
        }

        public async Task Delete(string tenantId, Guid id)
        {
            using (var client = GetClient())
            {
                var container = await GetContainer(client);

                await container.DeleteItemAsync<MonthlyExpenseEntity>(id.ToString("N"), new PartitionKey(tenantId));
            }
        }

        #region Helpers

        private CosmosClient GetClient()
        {
            return new CosmosClient(_connectionString);
        }

        private async Task<Container> GetContainer(CosmosClient client)
        {
            var database = client.GetDatabase("sharedexpenses");

            return await database.CreateContainerIfNotExistsAsync(
                id: "monthlyexpense",
                partitionKeyPath: "/tenantId",
                throughput: 400
            );
        }

        #endregion
    }
}

