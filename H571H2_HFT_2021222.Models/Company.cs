using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Models
{
    class Company
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual Person Executive { get; set; }
        public virtual ICollection<Game> Game { get; set; }
        public Company()
        {
            Game = new HashSet<Game>();
        }
    }
}
