﻿using KGD.Application.Contracts;
using KGD.Domain.Entity;
using KGD.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KGD.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUserList(CancellationToken cancellationToken) => await _context.Users.ToListAsync(cancellationToken);

        public async Task AddUser(User user)
        {
            try
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
            }catch (Exception ex)
            {

            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
