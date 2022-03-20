using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshDmg
{
    public class Constellation
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Passive
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Burst
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<string> skillLabels { get; set; }
        public List<string> skillStatsLabels { get; set; }
        public List<List<List<double>>> skillStats { get; set; }
    }

    public class Attack
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<string> skillLabels { get; set; }
        public List<string> skillStatsLabels { get; set; }
        public List<List<List<double>>> skillStats { get; set; }
    }

    public class ElementalSkill
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<string> skillLabels { get; set; }
        public List<string> skillStatsLabels { get; set; }
        public List<List<List<double>>> skillStats { get; set; }
    }

    public class Character
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string weapon { get; set; }
        public string rarity { get; set; }
        public List<double?> hp { get; set; }
        public List<double?> atk { get; set; }
        public List<double?> def { get; set; }
        public List<double> statGrowList { get; set; }
        public string statGrow { get; set; }
        public List<Constellation> constellations { get; set; }
        public List<Passive> passives { get; set; }
        public Burst burst { get; set; }
        public Attack attack { get; set; }
        public ElementalSkill elementalSkill { get; set; }
    }
}
