using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientAddress { get; set; }

        public Client(int clientId, string firstName, string lastName, string address)
        {
            this.ClientId = clientId;
            this.ClientFirstName = firstName;
            this.ClientLastName = lastName;
            this.ClientAddress = address;
        }

        public Client()
        {
        }
    }
}
