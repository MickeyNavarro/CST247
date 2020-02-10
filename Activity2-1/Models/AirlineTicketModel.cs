using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity2_1.Models
{
    public class AirlineTicketModel
    {
        public int ID { set; get; }
        public string Destination { set; get; }
        public DateTime Date { set; get; }

        public AirlineTicketModel(int iD, string destination, DateTime date)
        {
            ID = iD;
            Destination = destination;
            Date = date;
        }
    }
}