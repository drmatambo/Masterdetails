using System;

namespace VumbaSoft.Masterdetails.Components.Mvc
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AreaAttribute : Attribute
    {
        public String Name { get; }

        public AreaAttribute(String name)
        {
            Name = name;
        }
    }
}
