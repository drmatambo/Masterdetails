using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.Masterdetails.Objects
{
    public class State : BaseModel
    {
        [StringLength(256)]
        public string Name { get; set; }
        public Int32 CountryId { get; set; }
        public virtual List<City> Cities { get; set; }
        public virtual Country Country { get; set; }
    }
}
