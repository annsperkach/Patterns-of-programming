using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2
{
    public class Agreement
    {
        public int AgreementId { get; set; }
        public int CarsId { get; set; }
        public int ClientsId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Agreement(int id, int clientsId, DateTime issueDate, DateTime returnDate, int carsId)
        {
            this.AgreementId = id;
            this.ClientsId = clientsId;
            this.IssueDate = issueDate;
            this.ReturnDate = returnDate;
            this.CarsId = carsId;
        }

        public Agreement()
        {
        }
    }
}
