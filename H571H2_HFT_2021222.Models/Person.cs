using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(240)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int YearOfBirth { get; set; }
        public int CompanyID { get; set; }
        [NotMapped]
        public virtual Company Company { get; set; }

    }
}
