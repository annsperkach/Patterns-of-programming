using System;
using Order.Enums;

namespace Order.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public OrderType OrderType { get; set; }

        public string TextOrder { get; set; }

        private static int amount = 0;

        public Order(int clientId, string textOrder)
        {
            amount++;
            Id = amount;
            ClientId = clientId;
            TextOrder = textOrder;
        }
    }
}
