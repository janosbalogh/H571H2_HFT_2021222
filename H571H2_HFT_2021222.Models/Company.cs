﻿using System;
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
        public string CompanyName { get; set; }

        [StringLength(240)]
        
        public string Country { get; set; }

        
        public int executiveID { get; set; }
        
        public int EmployeeCount { get; set; }

        [NotMapped]
        [JsonIgnore]
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
            CompanyName = split[1];
            executiveID = int.Parse(split[2]);
            Country = split[3].ToUpper();
            EmployeeCount = int.Parse(split[4]);
        }
    }
}
