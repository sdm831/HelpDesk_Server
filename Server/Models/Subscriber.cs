using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Server.Models
{
    [DataContractAttribute]
    public class Subscriber
    {
        public Subscriber() { }

        public Subscriber(string family, string phone)
        {
            Id = Guid.NewGuid();
            FIO = family;            
            Phone = phone;
        }
                
        public Guid Id { get; set; }

        [Required]
        public string FIO { get; set; }
        
        [Required]
        public string Phone { get; set; }

        public DateTime BirthDay { get; set; } = DateTime.Now;

        public string Address { get; set; } = null;

        public override string ToString()
        {
            var str = "ФИО: " + FIO + " "
                + "Телефон: " + Phone + " "
                ;
            return str;
        }
    }
}
