using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string password { get; set; }

        public List<MessagesModel> Messages { get; set; }
    }
}
