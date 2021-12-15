using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Core.Interfaces;
using Task.DAL.Interfaces;
using Task.Entities;
using Task.Models;

namespace Task.Core
{
    public class MessageCORE : IMessageCore
    {
        private readonly IMessageDAL repository;
        private readonly IMapper mapper;

        public MessageCORE(IMessageDAL repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<bool> DeleteMessage(int MessageId)
        {
            var m = await repository.GetMessage(MessageId);
            repository.Delete(m);
            if (await repository.SaveChangesAsync())
                return true;
            else
                return false;
            
        }

        public async Task<List<MessagesModel>> GetAllMessage(int UserId)
        {
            var All = await repository.GetAllMessage(UserId);
            var result= mapper.Map<MessagesModel[]>(All).ToList();
            return result;
        }

        public async Task<MessagesModel> UpdateMessage(int MessageId, string NewMessage)
        {
            var M = repository.GetMessage(MessageId);
            //if (M == null) return NewMessage;
            M.Result.MessageBody = NewMessage;
           
            if (await repository.SaveChangesAsync())
                return mapper.Map<MessagesModel>(M);
            else
                throw new NotImplementedException();
        }

        public async Task<MessagesModel> WriteMessage(int UserId, string NewMessage)
        {
            MessagesModel model = new MessagesModel() { UserId = UserId, MessageBody = NewMessage };
            var m= mapper.Map<Message>(model);
            repository.Add(m);
            if (await repository.SaveChangesAsync())
                return mapper.Map<MessagesModel>(m);
            else
                return model;
        }
    }
}
