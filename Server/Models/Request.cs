using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Request
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public TypeRequest Type { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime DateRequest { get; set; }

        [Required]
        public Subscriber Subscriber { get; set; }

        [Required]
        public string Source { get; set; }

        public Request() { }


        public Request(TypeRequest type, string text, Subscriber subscriber, string source)
        {
            Id = Guid.NewGuid();
            Type = type;
            Text = text;
            DateRequest = DateTime.Now;
            Subscriber = subscriber;
            Source = source;
        }

        public override string ToString()
        {
            return 
                "ФИО: " + Subscriber.FIO + " "
                + "Date: " + DateRequest.ToString() + " "
                + "Type: " + Type + " "
                + "Source: " + Source + " "
                + "Text: " + Text + " "
                + "Id: " + Id;
        }        
    }
}
