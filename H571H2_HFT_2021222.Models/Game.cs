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
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameID { get; set; }

        [StringLength(240)]
        [Required]
        public string Name { get; set; }

        [StringLength(240)]
        [Required]
        public string Genre { get; set; }

        [Required]
        public int PositiveVote { get; set; }

        [Required]
        public int NegativeVote { get; set; }

        [Required]
        public int AverageForever { get; set; }

        [Required]
        public int Average2Weeks { get; set; }

        [Required]
        public double OriginalPrice { get; set; }

        [Required]
        public double CurrentPrice { get; set; }

        [Required]
        public bool IsDiscounted { get; set; }

        [Required]
        public int RecentConcurrentPeak { get; set; }

        public  int companyID { get; set; }

        [NotMapped]
        //[JsonIgnore]
        public virtual Company Company { get; set; }

        public Game()
        {
        }
        public Game(string line)
        {
            string[] split = line.Split('#');
            GameID = int.Parse(split[0]);
            Genre = split[1].ToUpper();
            Name = split[2];
            companyID = int.Parse(split[3]);
            PositiveVote = int.Parse(split[4]);
            NegativeVote = int.Parse(split[5]);
            AverageForever = int.Parse(split[6]);
            Average2Weeks = int.Parse(split[7]);
            CurrentPrice = (int.Parse(split[8])) / 10;
            OriginalPrice = (int.Parse(split[9]))/10;
            IsDiscounted = OriginalPrice > CurrentPrice;
            RecentConcurrentPeak = int.Parse(split[10]);

        }

    }
}
