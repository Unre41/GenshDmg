using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshDmg
{
    class Weapon
    {
        public WeaponType type;
        public string Name { get; set; }
        public double damage;
        public Secondary secondary;
        public double secondaryDMG;
        public bool isSecondary;

        public Weapon(WeaponType type, string name, double damage, Secondary secondary, double secondaryDMG)
        {
            this.Name = name;
            this.type = type;
            this.damage = damage;
            this.secondary = secondary;
            this.secondaryDMG = secondaryDMG;
            isSecondary = true;
        }
        public Weapon(WeaponType type, string name, double damage)
        {
            this.Name = name;
            this.type = type;
            this.damage = damage;
            isSecondary = false;
        }
    }
}
