using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetUpcAPI.Models.AppEntities
{
    public class AppPet
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public System.DateTime DateOfBirth { get; set; }
    }
}