using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshDmg
{
    class WeaponType
    {
        public string Name { get; set; }
        public string translatedName;
        public string description;

        public WeaponType(string name, string translatedName, string description)
        {
            this.Name = name;
            this.translatedName = translatedName;
            this.description = description;
        }
    }
}
