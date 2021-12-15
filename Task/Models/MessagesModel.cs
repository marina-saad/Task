using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public class MessagesModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MessageBody { get; set; }
    }
}
