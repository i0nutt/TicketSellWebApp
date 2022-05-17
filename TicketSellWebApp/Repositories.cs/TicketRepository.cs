using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Data;
using TicketSellWebApp.Models;

namespace TicketSellWebApp.Repositories.cs
{
    public class TicketRepository : ITicketRepository<Ticket>
    {
        public async Task<bool> Create(Ticket t)
        {
            try
            {
                _context.Add(t);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var ticket = await _context.Ticket.FindAsync(id);
                _context.Ticket.Remove(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Edit(int id, Ticket t)
        {
            try
            {
                _context.Update(t);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public async Task<Ticket> FindById(int id)
        {
            return await _context.Ticket
              .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<Ticket> findCopy(Ticket t)
        {
            return await _context.Ticket
            .FirstOrDefaultAsync(m => m.RowNumber == t.RowNumber && m.ColumnNumber == t.ColumnNumber
                                      && m.Id != t.Id);
        }
        public async Task<int> countByInfo(int showNumber)
        {
            return await _context.Ticket
            .CountAsync(m => m.ShowNumber == showNumber);
        }

        public async Task<List<Ticket>> GetList()
        {
            return await _context.Ticket.ToListAsync();
        }

        public Task<Ticket> findByInfo(Ticket t)
        {
            throw new NotImplementedException();
        }

        public TicketRepository(UserContext context)
        {
            _context = context;
        }
        private readonly UserContext _context;
    }
}
