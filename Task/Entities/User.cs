using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string password { get; set; }

        public virtual ICollection<Message> Messages { get; set; } 
    }
}
