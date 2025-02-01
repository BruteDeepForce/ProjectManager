using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace Subutai.Domain.Model
{
    public  class UserTaskMapping
    {
        [Key]
        public  int Id { get; set; }
        public  int UserId { get; set; }
        public  int TaskId { get; set; }
    }
}