using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Repositories.cs;

namespace TicketSellWebApp.Repositories
{
    public interface ITicketRepository<T>:IRepository<T>
    {
        public Task<int> countByInfo(int num);
        public Task<T> findCopy(T t);
        public Task<List<T>> FindByInfo1(T t);
    }
}
