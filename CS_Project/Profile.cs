using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS_Project.classes;
using CS_Project;

namespace CS_Project
{
    public partial class Profile : Form
    {
        static List<Player> players = new List<Player>();

        public Profile()
        {
            InitializeComponent();
        }
        public static List<Player> listOfgames()
        {
            List<Player> newList = new List<Player>();
            for (int i = 0; i < players.Count; i++)
            {
                newList.Add(players[i]);
            }
            return newList;
        }
        public static Player PlayerInfo(string str)
        {
            Player player = new Player();
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Name.Equals(str))
                    player = players[i];

            }
            return player;
        }
        public static void addGame(games g)
        {
            foreach (Player p in players)
            {
                if (p.Name.Equals(g.playername))
                    p.addGame(g);
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            Player p;

            for (int i = 0; i < players.Count; i++)
            {

                if (players[i].Name.Equals(name))
                {
                    players[i].Age = Convert.ToInt32(comboBox1.SelectedItem);
                    editRadio();
                }
            }

        }
        string gender = "", theme = "";
        private void editRadio()
        {
            if (radioButtonM.Checked)
                gender = "male";
            else if (radioButtonF.Checked)
                gender = "female";

            if (boyTheme.Checked)
                theme = "boy";
            else if (girlTheme.Checked)
                theme = "girl";
        }

       
        newGame game = new newGame();
        
        public static List<String> nameList = new List<String>();
        private void button3_Click_1(object sender, EventArgs e)
        {
          
        }
        
        private void girlTheme_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        
        private void boyTheme_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFile.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //profile should be created
            string message = "";
            if(nameTxt==null )
            {
                message += "Please enter your name \n";
            }
            if(!radioButtonF.Checked && !radioButtonM.Checked)
            {
                message += "Please select your gender \n";
            }
            if(comboBox1.SelectedItem == null)
            {
                message += "Please select your age \n";

            }
            if (pictureBox1.Image == null)
            {
                message += "Please select a picture \n";
                
            }
            if (!boyTheme.Checked && !girlTheme.Checked)
            {
                message += "Please select a theme \n";

            }
            if(nameTxt == null || (!radioButtonF.Checked && !radioButtonM.Checked) || comboBox1.SelectedItem == null || pictureBox1.Image == null || (!boyTheme.Checked && !girlTheme.Checked))
            {
                    MessageBox.Show(message);
            }
          
            


            if (radioButtonM.Checked)
                gender = "male";
            else if (radioButtonF.Checked)
                gender = "female";

            if (boyTheme.Checked)
                theme = "boy";
            else if (girlTheme.Checked)
                theme = "girl";

            Player player = new Player(nameTxt.Text, Convert.ToInt32(comboBox1.SelectedItem), gender, theme, pictureBox1.Image);
            players.Add(player);
           // MessageBox.Show("" + players[0].Name);
            
            nameList.Add(player.Name);
            //game.comboBox1.Items.Add(nameList.ToArray()[nameList.Count-1]);
            
            game.Show();
            this.Hide();

        }
        
    }
}
