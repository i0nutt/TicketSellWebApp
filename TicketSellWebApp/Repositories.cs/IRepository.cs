using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSellWebApp.Repositories.cs
{
    public interface IRepository<T>
    {
        public Task<T> FindById(int id);
        public Task<T> findByInfo(T t);
        public Task<List<T>> GetList();
        public Task<bool> Create(T t);
        public Task<bool> Edit(int id, T t);
        public Task<bool> Delete(int id);
    }
}
