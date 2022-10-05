using System;

namespace Order.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string nameSurname { get; set; }

        private static int amount = 0;

        public Client(string nmSurnm)
        {
            amount++;
            Id = amount;
            nameSurname = nmSurnm;
        }
    }
}
