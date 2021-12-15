using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Entities;
using Task.Models;

namespace Task.DAL.Interfaces
{
    public interface IMessageDAL
    {
        Task<bool> SaveChangesAsync();
        //Task<MessagesModel> WriteMessage(int UserId, string Message);
        Task<Message> GetMessage(int MessageId);
        Task<Message[]> GetAllMessage(int UserId);
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
    }
}
