using System;
using System.ComponentModel.DataAnnotations;
using Datalist;

namespace VumbaSoft.Masterdetails.Objects
{
    public class CountryView : BaseView
    {
        public string Shortname { get; set; }
        [Required]
        [DatalistColumn]
        [StringLength(256)]
        public string Name { get; set; }
    }
}
