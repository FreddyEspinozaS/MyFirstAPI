using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeRent.Models.AppEntities
{
    public class AppVet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }
    }
}