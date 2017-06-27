using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;



[Table("Restos")]
public class Resto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Le nom du restaurant doit être saisi")]
    public string Nom { get; set; }
    [Display(Name = "Téléphone")]
    [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Le numéro de téléphone est incorrect")]
    public string Telephone { get; set; }
}

//public class Resto : IValidatableObject
//{
//    public int Id { get; set; }
//    public string Nom { get; set; }
//    public string Telephone { get; set; }
//    public string Email { get; set; }

//    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
//    {
//        if (string.IsNullOrWhiteSpace(Telephone) && string.IsNullOrWhiteSpace(Email))
//            yield return new ValidationResult("Vous devez saisir au moins un moyen de contacter le restaurant", new[] { "Telephone", "Email" });
//        // etc.
//    }
//}
//[Table("Restos")]
//public class Resto
//{
//    public int Id { get; set; }
//    [Required, MaxLength(90)]
//    public string Nom { get; set; }
//    [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Le numéro de téléphone est incorrect")]
//    public string Telephone { get; set; }


//}