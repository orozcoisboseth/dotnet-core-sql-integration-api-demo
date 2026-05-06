namespace DemoApi.Models
{
    /// <summary>
    /// Request received from an external system (e.g. NetSuite)
    /// </summary>
    public class ExternalTransactionRequest
    {
        /// <summary>
        /// External customer identifier
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// Unique external reference used for idempotency
        /// </summary>
        public string ExternalReference { get; set; }
    }
}
