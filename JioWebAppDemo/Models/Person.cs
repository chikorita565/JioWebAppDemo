using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JioWebAppDemo.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Airline { get; set; }
        public string Flight { get; set; }
        public string Terminal { get; set; }
        public string Status { get; set; }
    }
}
