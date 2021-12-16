﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string NotificationType { get; set; }
        public string NotificationTypeSymbol { get; set; }
        public string NotificationColor { get; set; }
        public string NotificationDetails { get; set; }
        public bool NotificationStatus { get; set; }
        public DateTime NotificationCreatedAt { get; set; }

    }
}
