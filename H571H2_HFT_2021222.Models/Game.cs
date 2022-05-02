using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        public double Price { get; set; }

        [Required]
        public int RecentConcurrentPeak { get; set; }

        public  int companyID { get; set; }

        [NotMapped]
        public virtual Company Company { get; set; }

        public Game()
        {

        }
        public Game(string line)
        {

        }

    }
}
