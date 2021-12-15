using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Core.Interfaces;

namespace Task.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageCore MessageCORE;

        public ChatHub(IMessageCore MessageCORE)
        {
            this.MessageCORE = MessageCORE;
        }

        public async void GetALL(int UserId)
        {
            var All = await MessageCORE.GetAllMessage(UserId);
            await Clients.Caller.SendAsync("allMessages", All);
        }
        
    }
}
