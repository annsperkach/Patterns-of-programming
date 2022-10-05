using System.Collections.Generic;
using System.Linq;
using System;

namespace Order.Models
{
    public class Publisher
    {
        public List<Client> Clients { get; set; }

        public Publisher()
        {
            Clients = new List<Client>();
        }

        public string Notify(int id)
        {
            foreach (var client in Clients)
            {
                if (client.Id == id)
                {
                    return client.nameSurname;
                }
            }
            return null;
        }

        public void Subscribe(Client client)
        {
            Clients.Add(client);
        }

        public void UnSubscribe(Client client)
        {
            Clients.Remove(client);
        }

        public Client GetSubscriberById(int id)
        {
            return Clients.Where(x => x.Id == id).First();
        }

    }
}
