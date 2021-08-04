﻿using System;

namespace SunstoneProject.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime Created { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }
    }
}
