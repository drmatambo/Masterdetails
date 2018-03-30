using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.Masterdetails.Objects
{
    public class City : BaseModel
    {
        [StringLength(256)]
        public string Name { get; set; }
        public Int32 StateId { get; set; }
        public virtual State State { get; set; }

    }
}
