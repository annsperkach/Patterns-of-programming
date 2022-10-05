using Order.Enums;
using System;
using System.Collections.Generic;

namespace Order.Models
{
    public class Shop
    {
        private List<Order> Orders { get; set; }

        private Publisher Publisher { get; set; }

        public Shop()
        {
            Orders = new List<Order>();
            Publisher = new Publisher();
        }

        public void AddClient(Client client)
        {
            Publisher.Subscribe(client);
        }

        public void DeleteClient(Client client)
        {
            Publisher.UnSubscribe(client);
        }

        public void MakeOrder(string textOrder, int clientID)
        {
            Orders.Add(new Order(clientID, textOrder));

        }

        public void ChangeOrderState(int person, int orderId)
        {
            int sub;
            OrderType type = OrderType.Cancelled;
            if (person == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press 1: Set Accepted\nPress 2: To set Proccessing\nPress 3: To set paid\nPress 4: To set Cancelled");
                Console.ResetColor();
                Console.Write("Your choice: ");
                sub = Convert.ToInt32(Console.ReadLine());
                switch (sub)
                {
                    case 1:
                        {
                            type = OrderType.Accepted;
                            break;
                        }
                    case 2:
                        {
                            type = OrderType.Processing;
                            break;
                        }
                    case 3:
                        {
                            type = OrderType.Paid;
                            break;
                        }
                    case 4:
                        {
                            type = OrderType.Cancelled;
                            break;
                        }
                }
            }
            else if (person == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press 1: To set ShipmentAllowed\nPress 2: To set DeliveryAllowed\n");
                Console.ResetColor();
                Console.Write("Your choice: ");
                sub = Convert.ToInt32(Console.ReadLine());
                switch (sub)
                {
                    case 1:
                        {
                            type = OrderType.ShipmentAllowed;
                            break;
                        }
                    case 2:
                        {
                            type = OrderType.DeliveryAllowed;
                            break;
                        }
                }
            }
            else if (person == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press 1: To set DeliveredToThePointOfIssue\nPress 2: To set BuyerGot\n");
                Console.ResetColor();
                Console.Write("Your choice: ");
                sub = Convert.ToInt32(Console.ReadLine());
                switch (sub)
                {
                    case 1:
                        {
                            type = OrderType.DeliveredToThePointOfIssue;
                            break;
                        }
                    case 2:
                        {
                            type = OrderType.BuyerGot;
                            break;
                        }
                }
            }
            foreach (var order in Orders)
            {
                if (order.Id == orderId)
                {
                    order.OrderType = type;
                }
            }
            Notify(orderId);
        }

        private void Notify(int orderId)
        {
            foreach (var order in Orders)
            {
                if(order.Id == orderId)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(Publisher.Notify(order.ClientId) + " your Order: " + order.TextOrder + " has state: " + order.OrderType);
                    Console.ResetColor();
                }
            }
            Console.WriteLine("Done!");
        }
    }
}