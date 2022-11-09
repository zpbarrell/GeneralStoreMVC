﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GeneralStoreMVC.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
