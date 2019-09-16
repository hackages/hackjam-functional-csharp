using System;

namespace MishmashApi.Entities.Shop
{
    public class Perishable : Product
    {
        public DateTime Validity { get; set; }
    }
}