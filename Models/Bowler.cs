using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBMission13.Models
{
    public class Bowler // One instance of a bowler
    {
        [Key]
        [Required]
        public long BowlerID { get; set; }
        [Required(ErrorMessage = "Please enter a last name")]
        public string BowlerLastName { get; set; }
        [Required(ErrorMessage = "Please enter a first name")]
        public string BowlerFirstName { get; set; }
        public string BowlerMiddleInit { get; set; }
        public string BowlerAddress { get; set; }
        public string BowlerCity { get; set; }

        [StringLength(2, MinimumLength = 0)]
        public string BowlerState { get; set; }
        public string BowlerZip { get; set; }
        public string BowlerPhoneNumber { get; set; }
        public long? TeamID { get; set; }
        public virtual Team Team { get; set; }
    }
}
