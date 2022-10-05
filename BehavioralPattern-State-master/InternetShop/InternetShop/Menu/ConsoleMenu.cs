using Order.Models;
using System;

namespace Order.Menu
{
    public class ConsoleMenu
    {
        private readonly Client _client;

        private readonly Shop _shop;

        public ConsoleMenu(Client client)
        {
            _client = client;
            _shop = new Shop();
            _shop.AddClient(client);
        }

        public void StartShopping()
        {
            string subject;
            int choosen;
            bool isRun = true;
            try
            {

                while (isRun)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press 1: Add order\nPress 2: Change order state like storekeeper\nPress 3:Change state order like courier\nPress 4:Change order`s state like administrator");
                    Console.ResetColor();
                    Console.Write("Your choice: ");
                    choosen = Convert.ToInt32(Console.ReadLine());
                    switch (choosen)
                    {
                        case 1:
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Enter text order(subject of order): ");
                                Console.ResetColor();
                                subject = Console.ReadLine();
                                _shop.MakeOrder(subject, _client.Id);
                                Console.WriteLine("Done");
                                break;
                            }
                        case 2:
                            {
                                int orderId;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Enter order id to change its state");
                                Console.ResetColor();
                                orderId = Convert.ToInt32(Console.ReadLine());
                                _shop.ChangeOrderState(1, orderId);
                                break;
                            }
                        case 3:
                            {
                                int orderId;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Enter order id to change its state");
                                Console.ResetColor();
                                orderId = Convert.ToInt32(Console.ReadLine());
                                _shop.ChangeOrderState(2, orderId);
                                break;
                            }
                        case 4:
                            {
                                int orderId;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Enter order id to change its state");
                                Console.ResetColor();
                                orderId = Convert.ToInt32(Console.ReadLine());
                                _shop.ChangeOrderState(3, orderId);
                                break;
                            }
                    }
                    Console.WriteLine("\n\n\n");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
