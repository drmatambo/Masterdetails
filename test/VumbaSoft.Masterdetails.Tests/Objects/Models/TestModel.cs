using VumbaSoft.Masterdetails.Objects;
using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.Masterdetails.Tests.Objects
{
    public class TestModel : BaseModel
    {
        [StringLength(128)]
        public String Title { get; set; }
    }
}
