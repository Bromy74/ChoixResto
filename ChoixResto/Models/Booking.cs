using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


    public class Booking
    {
        public int Id { get; set; }
        public int Restochoisi { get; set; }
        [Required]
        public int Nbpeople { get; set; }
        [CustomValidator]
        public DateTime Date { get; set; }
        public int Orga { get; set; }
    }

