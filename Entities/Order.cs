using System;
using System.Text.Json.Serialization;

namespace SecuringWebApiJwt.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string Currency { get; set; }
        public DateTime TS { get; set; }
        public int ClienteId { get; set; }
        
        [JsonIgnore]
        public Customer Customer { get; set; }
    }
}