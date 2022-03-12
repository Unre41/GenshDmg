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
        private string[] characterList;
        List<Weapon> weapons = new List<Weapon>();
        List<Secondary> secondaries = new List<Secondary>();
        List<WeaponType> weaponTypes = new List<WeaponType>();
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
            //LoadPers();
            LoadWeapons();
            persList.SelectedIndex = 0;
        }
        private void LoadWeapons()
        {
            foreach (string line in File.ReadAllLines("../../res/weaponTypes.txt"))
            {
                string[] lineParsed = line.Split(';');
                weaponTypes.Add(new WeaponType(lineParsed[0], lineParsed[1], lineParsed[2]));
            }

            foreach (string line in File.ReadAllLines("../../res/secondary.txt"))
            {
                string[] lineParsed = line.Split(';');
                secondaries.Add(new Secondary(lineParsed[0], lineParsed[1]));
            }
            foreach (string line in File.ReadAllLines("../../res/weapons.txt"))
            {
                string[] lineParsed = line.Split(';');

                if (lineParsed[3] == "")
                    weapons.Add(new Weapon(weaponTypes.Find(x => x.Name == lineParsed[0]), lineParsed[1], double.Parse(lineParsed[2])));
                else
                    weapons.Add(new Weapon(weaponTypes.Find(x => x.Name == lineParsed[0]), 
                        lineParsed[1], 
                        double.Parse(lineParsed[2]),
                        secondaries.Find(x => x.Name == lineParsed[3]),
                        double.Parse(lineParsed[4])
                        ));
            }


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //double dmg = (((hero_atk + weap_atk) + (100 + bon_atk_perc) / 100) + bon_atk) * ((100 + krit_dmg) / 100) * (skill_dmg / 100) * (modif / 100) * ((100 + bon_ms) / 100);
            //textBox10.Text = dmg.ToString();
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
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
