using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BigPardakht.Model;
using Newtonsoft.Json;

namespace SignalRMVCChat.Models
{
    public class Customer : Entity
    {
        public Customer()
        {
            Comments = new List<Comment>();
        }

        

        public List<Comment> Comments { get;  set; }
    }


    public enum CustomerType
    {
        Chat=0,
        TelegramUser=0
    }
}