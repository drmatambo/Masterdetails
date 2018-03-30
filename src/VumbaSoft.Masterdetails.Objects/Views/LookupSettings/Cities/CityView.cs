using System;
using System.ComponentModel.DataAnnotations;
using Datalist;

namespace VumbaSoft.Masterdetails.Objects
{
    public class CityView : BaseView
    {
        [Required]
        [DatalistColumn]
        [StringLength(256)]
        public string Name { get; set; }
        public Int32 StateId { get; set; }
        public string StateName { get; set; }
        public virtual State State { get; set; }
    }
}
