using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Models;
using TicketSellWebApp.Data;
using Microsoft.EntityFrameworkCore;


namespace TicketSellWebApp.Repositories.cs
{
    public class UserRepository: IRepository<User>
    {
        public async Task<User> FindById(int id)
        {
            return await _context.User.FindAsync(id); ;
        }

        public async Task<User> findByInfo(User user)
        {
            return await _context.User.FirstOrDefaultAsync(m => m.Username.Equals(user.Username) && m.Password.Equals(user.Password));
        }

        public async Task<List<User>> GetList()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> Create(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Edit(int id, User user)
        {
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                User u = this.FindById(id).Result;
                if (u == null)
                    return false;
                else
                    throw;
            }
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public UserRepository(UserContext _context)
        {
            this._context = _context;
        }
        private readonly UserContext _context;
    }
}
