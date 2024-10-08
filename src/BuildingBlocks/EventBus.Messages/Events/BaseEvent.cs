﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class BaseEvent
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public BaseEvent()
        {
            Id= Guid.NewGuid();
            CreatedDate= DateTime.Now;
        }
    }
}
