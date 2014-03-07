using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab2_2ÄventyrligaKontakter.Model
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Required(ErrorMessage = "En emailadress måste anges.")]
        [RegularExpression(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", ErrorMessage = "Emailadress är inte korrekt sriven")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Ett förnamn måste anges.")]
        [StringLength(50, ErrorMessage = "Förnamnet kan bestå av som mest 50 tecken.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ett efternamn måste anges.")]
        [StringLength(50, ErrorMessage = "Efternamnet kan bestå av som mest 50 tecken.")]
        public string LastName { get; set; }

    }
}