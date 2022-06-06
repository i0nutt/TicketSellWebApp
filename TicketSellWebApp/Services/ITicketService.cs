using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Models;

namespace TicketSellWebApp.Services
{
    public interface ITicketService<T>:IService<T>
    {
        public List<Ticket> FindByShow(int ShowNumber);
    }
}
