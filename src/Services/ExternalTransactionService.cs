using DemoApi.Models;
using DemoApi.Infrastructure;

namespace DemoApi.Services
{
    /// <summary>
    /// Handles business logic for external transactions
    /// </summary>
    public class ExternalTransactionService
    {
        /// <summary>
        /// Processes an external transaction request
        /// </summary>
        public ExternalTransactionResponse Process(ExternalTransactionRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.ExternalReference))
            {
                return new ExternalTransactionResponse
                {
                    Status = "ERROR",
                    Message = "ExternalReference is required"
                };
            }

            // Delegate persistence to the infrastructure layer
            return InMemoryStorage.Insert(request.ExternalReference);
        }
    }
}
