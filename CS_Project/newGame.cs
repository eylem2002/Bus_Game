using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace CS_Project
{
   
    public partial class newGame : Form
    {
        public newGame()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }
        static string str;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = comboBox1.SelectedItem;
            str = selectedItem.ToString();
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            //cant play if profile is not created
            if (comboBox1.SelectedItem==null)
                MessageBox.Show("make new profile OR select one");
            else { 
                Game game = new Game();
                 game.Show();
                this.Hide();
            }
        }
        //add players names to combobox
        private void newGame_Load(object sender, EventArgs e)
        {
            foreach (string item in Profile.nameList)
            {
                comboBox1.Items.Add(item);
            }
        }
        public static string comb()
        {
            return str;
        }
    }
}
