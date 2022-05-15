using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSellWebApp.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cast { get; set; }
        public string Actors { get; set; }
        public DateTime PremierDate { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
