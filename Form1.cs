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
using Newtonsoft.Json;

namespace GenshDmg
{
    public partial class Form1 : Form
    {
        List<Character> characters = new List<Character>();
        List<Weapon> weapons = new List<Weapon>();

        Character currentCharacter = new Character();
        Weapon currentWeapon = new Weapon();

        public Form1()
        {
            InitializeComponent();
            LoadPers();
            LoadWeapons();

            charactersComboBox.SelectedIndex = 0;

        }
        private void LoadPers()
        {
            foreach (string s in Directory.GetFiles("../../src/characterData"))
            {
                characters.Add(JsonConvert.DeserializeObject<Character>(File.ReadAllText(s)));
            }
            foreach (Character c in characters)
            {
                charactersComboBox.Items.Add(c.name);
            }
        }
        private void LoadWeapons()
        {
            weapons = JsonConvert.DeserializeObject<List<Weapon>>(File.ReadAllText("../../src/weapons.json"));
        }
        private void SelectCharacter(Character character)
        {
            if (currentCharacter.weapon != character.weapon)
            {
                weaponsComboBox.Items.Clear();
                foreach (Weapon w in weapons)
                {
                    if (character.weapon == w.type)
                    {
                        weaponsComboBox.Items.Add(w.name);
                    }
                }
                weaponsComboBox.SelectedIndex = 0;
            }

            

            currentCharacter = character;
            characterAtk.Text = Math.Round((double)character.atk[(int)characterLVL.Value]).ToString();

            UpdateCharacterField();
        }
        private void SelectWeapon(Weapon weapon)
        {
            weaponAtk.Text = Math.Round((double)weapon.atk[(int)weaponLVL.Value]).ToString();

            currentWeapon = weapon;
        }

        private void UpdateCharacterField()
        {
            string statGrow = currentCharacter.statGrow;

            critRate.Text = statGrow == "critRate" ? Math.Round(currentCharacter.statGrowList[(int)characterLVL.Value] * 100, (int)characterLVL.Value > 41 ? 1 : 0).ToString() + "%" : "5%";
            characterAtk.Text = Math.Round((double)currentCharacter.atk[(int)characterLVL.Value]).ToString();
            critDmg.Text = statGrow == "critDamage" ? Math.Round(currentCharacter.statGrowList[(int)characterLVL.Value] * 100, (int)characterLVL.Value > 41 ? 1 : 0).ToString() + "%" : "50%";

            if (statGrow != "critRate" && statGrow != "critDamage")
            {
                characterStatGrowLabel.Text = statGrow;
                characterStatGrow.Text = Math.Round(currentCharacter.statGrowList[(int)characterLVL.Value] * 100, (int)characterLVL.Value > 41 ? 1 : 0).ToString();
                characterStatGrowLabel.Visible = true;
                characterStatGrow.Visible = true;
            }
            else
            {
                characterStatGrowLabel.Text = "";
                characterStatGrow.Text = "";
                characterStatGrowLabel.Visible = false;
                characterStatGrow.Visible = false;
            }
        }
        //42

        private void button1_Click(object sender, EventArgs e)
        {
            
            //double dmg = (((hero_atk + weap_atk) + (100 + bon_atk_perc) / 100) + bon_atk) * ((100 + krit_dmg) / 100) * (skill_dmg / 100) * (modif / 100) * ((100 + bon_ms) / 100);
            //textBox10.Text = dmg.ToString();
        }









        private void charactersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCharacter(characters.Find(m => m.name == charactersComboBox.SelectedItem.ToString()));
        }
        private void characterLVL_ValueChanged(object sender, EventArgs e)
        {
            UpdateCharacterField();
        }
        private void weaponsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectWeapon(weapons.Find(m => m.name == weaponsComboBox.SelectedItem.ToString()));
            weaponLVL.Maximum = currentWeapon.atk.Count - 1;
        }
        private void weaponLVL_ValueChanged(object sender, EventArgs e)
        {
            weaponAtk.Text = Math.Round((double)currentWeapon.atk[(int)weaponLVL.Value]).ToString();

        }
    }
}
