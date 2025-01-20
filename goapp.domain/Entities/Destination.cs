using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.domain.Entities
{
    public class Destination
    {
        public int Id { get; set; }
        public string description { get; set; }

        public Destination(int id, string description)
        {
            this.Id = id;
            this.description = description;
        }
    }
}
