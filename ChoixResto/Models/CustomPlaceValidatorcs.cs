using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


[AttributeUsage(AttributeTargets.Property |
  AttributeTargets.Field, AllowMultiple = false)]
    public class CustomPlaceValidator : ValidationAttribute
    {

        private IDal dal = new Dal();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int nb = 0;
            if (dal.ObtientTousLesBookings() != null)
            {
                foreach (var booking in dal.ObtientTousLesBookings())
                    nb += booking.Nbpeople;
                if (nb < 50) return ValidationResult.Success;
                return new ValidationResult("The restaurant is full for this date.");
            }
            //{
        
            //}
            //if ((int)value > nb)
            //    return new ValidationResult("Trop grand");
            return ValidationResult.Success;
        
        }

    }
