using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyID { get; set; }

        [StringLength(240)] 
        [Required]
        public string Name { get; set; }

        [StringLength(240)]
        [Required]
        public string Country { get; set; }

        [Required]
        public int executiveID { get; set; }
        [Required]
        public int EmployeeCount { get; set; }

        [NotMapped]        
        public virtual Person Executive { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Game> Game { get; set; }
        public Company()
        {
            
        }
        public Company(string line)
        {
            string[] split = line.Split('#');
            CompanyID = int.Parse(split[0]);
            Name = split[1];
            executiveID = int.Parse(split[2]);
            Country = split[3].ToUpper();
            EmployeeCount = int.Parse(split[4]);


        }
    }
}
