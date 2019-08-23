﻿using System;
using System.Collections.Generic;

namespace Backend.Model
{
    public partial class City
    {
        public City()
        {
            Client = new HashSet<Client>();
        }

        public int CityId { get; set; }
        public string CityDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Client> Client { get; set; }
    }
}
