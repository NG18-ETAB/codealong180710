using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codealong180710.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNr { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        [Display(Name = "Social security number")]
        public string SocialSecNr { get; set; }

        public virtual ICollection<Vehicle> ParkedVehicles { get; set; }
    }
}