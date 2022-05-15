using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSellWebApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ShowNumber { get; set; }
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
    }
}
