using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.DAL.Interfaces;
using Task.Entities;
using Task.Models;

namespace Task.DAL
{
    public class MessageDAL : IMessageDAL
    {
        private readonly IMapper mapper;
        private readonly TaskDbContext _Context;

        public MessageDAL(IMapper mapper, TaskDbContext context)
        {
            this.mapper = mapper;
            _Context = context;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _Context.SaveChangesAsync()) > 0;
        }
        public void Delete<T>(T entity) where T : class
        {
            _Context.Remove(entity);
        }
        

        public void Add<T>(T entity) where T : class
        {
            _Context.Add(entity);
        }

        public async Task<Message> GetMessage(int MessageId)
        {
            IQueryable<Message> M = _Context.Message.Where(x => x.Id == MessageId);
            return await M.FirstOrDefaultAsync();
        }

        public async Task<Message[]> GetAllMessage(int UserId)
        {
            return await _Context.Message.Where(x => x.userId == UserId).ToArrayAsync();
        }
    }
}
