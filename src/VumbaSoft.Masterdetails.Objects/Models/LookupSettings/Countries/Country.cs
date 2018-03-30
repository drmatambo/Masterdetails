using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.Masterdetails.Objects
{
    public class Country : BaseModel
    {
        [StringLength(3)]
        public string Shortname { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        public virtual List<State> States { get; set; }
    }
}
