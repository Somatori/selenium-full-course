using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace litecart
{
    public class ItemData
    {
        public ItemData()
        {
        }

        //public ItemData()
        //{
        //    Name = name;
        //    RegularPrice = regularPrice;
        //}

        public string Name { get; set; }

        public string RegularPrice { get; set; }

        public string CampaignPrice { get; set; }

        public string Phone { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

    }
}
