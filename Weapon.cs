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
        public List<object> stats { get; set; }
    }

    public class Weapon
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int rarity { get; set; }
        public string description { get; set; }
        public Skill skill { get; set; }
        public Secondary secondary { get; set; }
        public List<object> atk { get; set; }
    }
}
