﻿using AltaSoft.Notifications.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL
{
    /// <summary>
    /// Queue to process send requests
    /// </summary>
    public class Message : ModelBase
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public string Content { get; set; }

        public MessageStates State { get; set; }

        public MessagePriority Priority { get; set; }

        /// <summary>
        /// If null, processes immediately, otherwise waits for ProcessDate
        /// </summary>
        public DateTime? ProcessDate { get; set; }
    }
}