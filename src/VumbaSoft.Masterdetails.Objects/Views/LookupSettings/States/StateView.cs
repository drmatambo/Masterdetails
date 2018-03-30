using System;
using System.ComponentModel.DataAnnotations;
using Datalist;

namespace VumbaSoft.Masterdetails.Objects
{
    public class StateView : BaseView
    {
        [Required]
        [DatalistColumn]
        [StringLength(256)]
        public string Name { get; set; }
        public Int32 CountryId { get; set; }
        public string CountryName { get; set; }
        public virtual Country Country { get; set; }
    }
}
