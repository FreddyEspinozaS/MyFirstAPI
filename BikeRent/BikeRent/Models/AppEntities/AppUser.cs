using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetUpcAPI.Models.AppEntities
{
    public class AppUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<AppPet> Pets { get; set; }
    }
}