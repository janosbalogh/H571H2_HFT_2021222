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
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }

        [StringLength(240)]
        [Required]
        public string PersonName { get; set; }

        //[Required]
        public int Age { get; set; }

        //[Required]
        public int Salary { get; set; }

        //[Required]
        public int companyID { get; set; }

        [NotMapped]
        //[JsonIgnore]
        public virtual Company Company { get; set; }

        public Person()
        {
        }
        public Person(string line)
        {
            string[] split = line.Split('#');
            PersonID = int.Parse(split[0]);
            PersonName = split[1];
            Salary = int.Parse(split[2]);
            Age = int.Parse(split[3]);
            companyID = int.Parse(split[4]);
        }

    }
}
