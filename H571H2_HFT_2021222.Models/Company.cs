using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(240)] 
        [Required]
        public string Name { get; set; }

        [StringLength(240)]
        [Required]
        public string Country { get; set; }

        [NotMapped]
        [Required]
        public virtual Person Executive { get; set; }

        [NotMapped]
        public virtual HashSet<Game> Game { get; set; }
        public Company()
        {
            Game = new HashSet<Game>();
        }
    }
}
