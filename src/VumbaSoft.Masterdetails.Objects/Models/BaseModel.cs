﻿using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.Masterdetails.Objects
{
    public abstract class BaseModel
    {
        [Key]
        public virtual Int32 Id
        {
            get;
            set;
        }

        public virtual DateTime CreationDate
        {
            get
            {
                if (!IsCreationDateSet)
                    CreationDate = DateTime.Now;

                return InternalCreationDate;
            }
            protected set
            {
                IsCreationDateSet = true;
                InternalCreationDate = value;
            }
        }
        private Boolean IsCreationDateSet
        {
            get;
            set;
        }
        private DateTime InternalCreationDate
        {
            get;
            set;
        }

        public virtual Int32? CreatedById { get; set; }
        public virtual Int32? UpdatedById { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual Int32? DeletedById { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
    }
}
