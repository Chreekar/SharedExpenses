using System;

namespace SharedExpenses.Models.Settings
{
	public class ApplicationOptions
	{
        public const string Section = "ApplicationOptions";

        public required string CosmosConnectionString { get; init; }
	}
}

