using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSellWebApp.Services
{
    public interface IService<T>
    {
        public T FindById(int id);
        public T FindByInfo(T t);
        public List<T> GetList();
        public bool Create(T t);
        public bool Edit(int id, T t);
        public bool Delete(int id);
    }
}
