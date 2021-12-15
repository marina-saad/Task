using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public string MessageBody { get; set; }

        [ForeignKey("userId")]
        public virtual User user { get; set; }
    }
}
