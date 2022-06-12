using SignalRMVCChat.Models.HelpDesk;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using AbstractLibrary.Model.MarketModel;
using BigPardakht.Model;

namespace SignalRMVCChat.Models
{
    public class Comment : Entity
    {

        public Comment()
        {
            CreationDateTime = DateTime.Now;
        }
        
        
        
        [Text]
        public string SenderName { get; set; }

        
        [Text]
        public string Email { get; set; }


        public bool Show { get; set; } = false;
        
        
        
        

        [Text]
        public string Title { get; set; }

        [TextArea]
        public string Text { get; set; }
        
        
        public DateTime CreationDateTime { get; set; } = DateTime.Now;

        [NotMapped]
        public string CreationDateTimeStr
        {
            get
            {

                return MyGlobal.ToIranianDateWidthTime(CreationDateTime);

            }
        }


        public long? ProductId { get; set; }

        public Product Products { get; set; }

        public long? ArticleId { get; set; }

        public Article Article { get; set; }
        public bool IsHelpful { get;  set; }
      //  public int? CustomerId { get;  set; }


        public Customer Customer { get; set; }
    }
}