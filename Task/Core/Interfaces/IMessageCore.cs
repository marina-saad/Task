using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Core.Interfaces
{
    public interface IMessageCore
    {
        Task<MessagesModel> WriteMessage(int UserId, string NewMessage);
        Task<MessagesModel> UpdateMessage(int MessageId, string NewMessage);
        Task<List<MessagesModel>> GetAllMessage(int UserId);
        Task<bool> DeleteMessage(int MessageId);
    }
}
