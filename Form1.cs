using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace GenshDmg
{
    public partial class Form1 : Form
    {
        private enum weaponType { bow, catalyst, sword, claymore, polearm };
        private string[] characterList;
        private string[] weaponsList = new string[200];
        private string[] currentHeroWeapons = new string[200]; 
        private void LoadPers()
        {
            characterList = File.ReadAllLines("../../res/Pers/pers.txt");
            foreach (string l in characterList)
            {
                persList.Items.Add(Split(3, l));
            };
        }
        public string Split(int index, string l)
        {
            return l.Split('|')[index].Trim();
        }
        public Form1()
        {
            InitializeComponent();
            LoadPers();
            LoadWeapons();
            persList.SelectedIndex = 0;
        }
        private void LoadWeapons()
        {
            weaponsList = File.ReadAllLines("../../res/Weap/weapons.txt");
            

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double hero_atk = Double.Parse(textBox1.Text);
            double weap_atk = Double.Parse(textBox2.Text);
            double bon_atk_perc = Double.Parse(textBox3.Text);
            double bon_atk = Double.Parse(textBox4.Text);
            double bon_dmg = Double.Parse(textBox5.Text);
            double krit_dmg = Double.Parse(textBox6.Text);
            double skill_dmg = Double.Parse(textBox7.Text);
            double modif = Double.Parse(textBox8.Text);
            double bon_ms = Double.Parse(textBox9.Text);
            double dmg = (((hero_atk + weap_atk) + (100 + bon_atk_perc) / 100) + bon_atk) * ((100 + krit_dmg) / 100) * (skill_dmg / 100) * (modif / 100) * ((100 + bon_ms) / 100);
            textBox10.Text = dmg.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = ""; 
            textBox4.Text = "";
            textBox5.Text = ""; 
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
            double weap_atk; string bonus_stat_weapon;
            string currentWeapon = weaponsList[weapList.SelectedIndex];
            weap_atk = double.Parse(Split(2, currentWeapon));
            if (currentWeapon.Split('|').Length > 3)
            {
                if (Split(4, currentWeapon).Contains("."))
                    bonus_stat_weapon = Split(4, currentWeapon).Replace('.',',');
                else 
                    bonus_stat_weapon = Split(4, currentWeapon);
            } 
            else bonus_stat_weapon = "0";
            textBox2.Text = weap_atk.ToString();
            if(weaponsList.Length > 3) 
            {
                switch (Split(3, currentWeapon))
                {
                    case "energy_recharge": textBox7.Text = bonus_stat_weapon.ToString(); break;
                    case "ms": textBox8.Text = bonus_stat_weapon.ToString(); break;
                    case "hp": textBox5.Text = bonus_stat_weapon.ToString(); break;
                    case "krit_dmg": textBox6.Text = bonus_stat_weapon.ToString();  break;
                    case "krit_chance": textBox4.Text = bonus_stat_weapon.ToString(); break;
                    case "defenf": textBox2.Text = bonus_stat_weapon.ToString(); break;
                    case "bonus_atk_percent": textBox3.Text = bonus_stat_weapon.ToString(); break;
                    case "physical_bonus": textBox1.Text = bonus_stat_weapon.ToString(); break;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            weapList.Items.Clear();
            foreach (string l in weaponsList)
            {
                if (Split(0, l) == Split(1, characterList[persList.SelectedIndex]))
                {
                    weapList.Items.Add(Split(1, l));
                    //currentHeroWeapons.
                }
            }
            weapList.SelectedIndex = 0;

            //LoadWeapons((weaponType)Enum.Parse(typeof(weaponType), characterList[persList.SelectedIndex].Split('|')[1].Trim()));
        }
    }
}
