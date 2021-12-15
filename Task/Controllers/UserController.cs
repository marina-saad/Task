using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Entities;
using Task.Models;

namespace Task.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly TaskDbContext _Context;

        public UserController(IMapper mapper, TaskDbContext context)
        {
            this.mapper = mapper;
            _Context = context;
        }
        public IActionResult AllMessages(string Email)
        {
            var messages = _Context.User.Where(x => x.Email == Email);//.Select(y => y.Messages);
            var temp = mapper.Map<UserModel>(messages);
            var result2 = temp.Messages; //mapper.Map<List<MessagesModel>>(messages);
            MessageViewModel model = new MessageViewModel() {UserId=temp.ID, Email = Email, Messages = result2 };
            return View(model);
        }
        //public IActionResult WriteMessage(int id )
        //{
        //    MessagesModel model = new MessagesModel()
        //    {
        //        UserId = id
        //    };
            
        //    return View(model);
        //}
        [HttpPost]
        public async Task<IActionResult> WriteMessage(int Id, string message)
        {
            MessagesModel model = new MessagesModel() { MessageBody = message, UserId = Id };
            var M = mapper.Map<Message>(model);
            _Context.Message.Add(M);
            await _Context.SaveChangesAsync();

            return View("AllMessages");
        }
        [HttpPost]
        public async Task<IActionResult> EditMessage(int MId, string message)
        {
            var oldM=_Context.Message.Where(x => x.Id == MId).FirstOrDefault();
            oldM.MessageBody = message;
            await _Context.SaveChangesAsync();

            return View("AllMessages");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteMessage(int MId)
        {

            var oldM = _Context.Message.Select(x=>x.Id==MId);
            _Context.Remove(oldM);
            await _Context.SaveChangesAsync();

            return View("AllMessages");
        }

    }
}
