using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshDmg
{
    class Secondary
    {
        public string Name { get; set; }
        public string translatedName;

        public Secondary(string name, string translatedName)
        {
            this.Name = name;
            this.translatedName = translatedName;
        }
    }
}
