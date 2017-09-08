using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeToJSON.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string NickName { get; set; }
        public int Points { get; set; }
        public int Hours { get; set; }

        public override string ToString()
        {
            return $"{Id} {Username} {NickName}";
        }
    }
}
