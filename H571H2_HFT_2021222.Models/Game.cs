using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.Models
{
    class Game
    {
        public int GameID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public  int CompanyID { get; set; }
        public virtual Company Company { get; set; }

    }
}
