using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Data;
using TicketSellWebApp.Models;

namespace TicketSellWebApp.Repositories.cs
{
    public class ShowRepository : IRepository<Show>
    {
        public async Task<bool> Create(Show t)
        {
            _context.Add(t);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var show = await _context.Show.FindAsync(id);
            _context.Show.Remove(show);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Edit(int id, Show t)
        {
            try
            {
                _context.Update(t);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                Show u = this.FindById(id).Result;
                if (u == null)
                    return false;
                else
                    throw;
            }
            return true;
        }

        public async Task<Show> FindById(int id)
        {
            return await _context.Show.FindAsync(id);
        }

        public Task<Show> findByInfo(Show t)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Show>> GetList()
        {
            return await _context.Show.ToListAsync();
        }
        public ShowRepository(UserContext _context)
        {
            this._context = _context;
        }
        private readonly UserContext _context;
    }
}
