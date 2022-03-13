using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshDmg
{
    public class Skill
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Secondary
    {
        public string name { get; set; }
        public List<double?> stats { get; set; }
    }

    public class Type
    {
        public string id { get; set; }
        public string name;
        public string translation;
    }

    public class Weapon
    {
        public string id { get; set; }
        public string name { get; set; }
        public Type type { get; set; }
        public int rarity { get; set; }
        public string description { get; set; }
        public Skill skill { get; set; }
        public Secondary secondary { get; set; }
        public List<double?> atk { get; set; }
    }
}
