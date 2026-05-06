using DemoApi.Models;

namespace DemoApi.Infrastructure
{
    /// <summary>
    /// Simulates SQL Server persistence with idempotent behavior
    /// </summary>
    public static class InMemoryStorage
    {
        private static readonly Dictionary<string, int> Storage = new();

        public static ExternalTransactionResponse Insert(string externalReference)
        {
            // Idempotency check
            if (Storage.ContainsKey(externalReference))
            {
                return new ExternalTransactionResponse
                {
                    Status = "OK",
                    ExternalId = Storage[externalReference],
                    Message = "Record already exists"
                };
            }

            // Simulate auto-increment primary key
            var newId = Random.Shared.Next(1000, 9999);

            Storage[externalReference] = newId;

            return new ExternalTransactionResponse
            {
                Status = "OK",
                ExternalId = newId,
                Message = "Record created"
            };
        }
    }
}
