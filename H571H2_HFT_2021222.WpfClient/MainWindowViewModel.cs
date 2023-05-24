using H571H2_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H571H2_HFT_2021222.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Company> Companies { get; set; }

        public MainWindowViewModel()
        {
            Companies = new RestCollection<Company>("http://localhost:38231/", "company");
        }

    }
}
