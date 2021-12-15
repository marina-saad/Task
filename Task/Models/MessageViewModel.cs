using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public class MessageViewModel
    {
        public List<MessagesModel> Messages { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
    }
}
