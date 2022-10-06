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

namespace CS_Project
{

    public partial class Game : Form
    {
        public  bool moon = false;
        Random rand = new Random();

        bool moveup, movedown, moveleft, moveright;
        int speed =15;//Edit
        int score, level=1, duration ,val;
        private static List<games> gamesList = new List<games>();

        //steps & duration info
        public static List<char> stepsList = new List<char>();
        public static List<int> durationList = new List<int>();
        public static List<int> timeTaken = new List<int>();
        
        public static Queue<Point> locations = new Queue<Point>();
        public Game()
        {
            InitializeComponent();
        }
        public static List<games> listOfgames()                   
        {
            List<games> newList = new List<games>();
            for (int i = 0; i < gamesList.Count; i++)
            {
                newList.Add(gamesList[i]);  
            }
            return newList;
        }
        string str;

        private void Game_Load(object sender, EventArgs e)
        {
            //takes name of player
            str = newGame.comb();

            //with player name from list in profile, makes a player object
            Player p = Profile.PlayerInfo(str);

            //changing Theme: color & font & picture
            if (p.Theme.Equals("boy"))
            {
                this.BackColor = Color.LightCyan;
                label1.Font = new Font("MV Boli", 11, FontStyle.Regular);
                label5.Font = new Font("MV Boli", 11, FontStyle.Regular);
                label2.Font = new Font("MV Boli", 11, FontStyle.Regular);
                label7.Font = new Font("MV Boli", 11, FontStyle.Regular);
                label3.Font = new Font("MV Boli", 11, FontStyle.Regular);
                label8.Font = new Font("MV Boli", 11, FontStyle.Regular);
                label4.Font = new Font("MV Boli", 11, FontStyle.Regular);

                theme.Image = Properties.Resources.boy;
                theme.BackColor = Color.LightCyan;

            }
            if (p.Theme.Equals("girl"))
            {
                this.BackColor = Color.MistyRose;
                label1.Font = new Font("Comic Sans MS", 11, FontStyle.Regular);
                label5.Font = new Font("Comic Sans MS", 11, FontStyle.Regular);
                label2.Font = new Font("Comic Sans MS", 11, FontStyle.Regular);
                label7.Font = new Font("Comic Sans MS", 11, FontStyle.Regular);
                label3.Font = new Font("Comic Sans MS", 11, FontStyle.Regular);
                label8.Font = new Font("Comic Sans MS", 11, FontStyle.Regular);
                label4.Font = new Font("Comic Sans MS", 11, FontStyle.Regular);

                theme.Image = Properties.Resources.girl;
                theme.BackColor = Color.MistyRose;

            }

          
            label5.Text = p.Name;
            label7.Text = level.ToString();
            label8.Text = score.ToString();
            pictureBox3.Image = p.image;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            timer1.Start();

            //initialize null and 0 in lists, for getting playback info
            stepsList.Add(' ');
            durationList.Add(0);

            //making a random number between 0 & 20
            int num_rand = rand.Next(0, 20);
            //Right street 
            int x1 = rand.Next(677, 688);
            int y1 = rand.Next(2, 359);
            //left street 
            int x2 = rand.Next(252, 267);
            //y1
            //top street
            int x3 = rand.Next(6, 710);
            int y3 = rand.Next(175, 181);

            //down street
            //x3
            int y4 = rand.Next(445, 452);
            Size size1;
            //putting bus in a random location
            if (num_rand >= 0 && num_rand <= 5)
            {
                topbus.Location = new Point(x1, y1);
                size1 = new Size(32, 82);//i
                topbus.Image = Properties.Resources.busdown;
            }
            else if (num_rand > 5 && num_rand <= 10)
            {
                topbus.Location = new Point(x2, y1);
                size1 = new Size(32, 82);//i
                topbus.Image = Properties.Resources.busdown;
            }
            else if (num_rand > 10 && num_rand <= 20)
            {
                topbus.Location = new Point(x3, y3);
                size1 = new Size(82, 32);
                topbus.Image = Properties.Resources.busright;
            }
            else
            {
                
                topbus.Location = new Point(x3, y4);
                size1 = new Size(82, 32);//i
                topbus.Image = Properties.Resources.busright;
            }


            topbus.Size = size1;


            //not intersecting with school after random location
            while (topbus.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                topbus.Location = new Point(x3, x3);
                break;
            }


        }
        public static void AddGame(games g)
        {
            gamesList.Add(g);
        }
        //to transfare level info to another level
        public static int dur;
        public static int Lscore;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //make a duration 
            duration = val++;
            label6.Text = duration.ToString();

            
            while (topbus.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                durationList.Add(duration);
                timeTaken.Add(durationList[durationList.Count - 1] - durationList[durationList.Count - 2]);
                locations.Enqueue(topbus.Location);
                stepsList.Add('E');
                label8.Text = (score += 10).ToString();
                label7.Text = (level).ToString();
                dur = duration;
                Lscore = score;

                //foreach player adds a game in list of games
                Profile.addGame(new games(str, duration, score, level, DateTime.Now));
                //Add info for level1
                games l1 = new games(label5.Text, duration, score, level, DateTime.Now);
                AddGame(l1);
                timer1.Stop();

              
                    MoverTimer.Stop();
                    pictureBox4.Visible = true;
                    pictureBox4.Show();
                    button1.Visible = true;
                    button1.Show();




                break;

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            moon = true;
            Game2 game = new Game2();
            if (moon == true)
            {
                game.Show();
                this.Hide();
            }
        }


        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                movedown = false;
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveleft = true;

            }
            if (e.KeyCode == Keys.Right)
            {
                moveright = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                movedown = true;
            }
        }

        private void MoverTimer_Tick(object sender, EventArgs e)
        {

            //first squre
            if (topbus.Left > 119 && topbus.Left < 346 && topbus.Top < 150)
            {
                moveleft = false;
                moveright = false;
            }


            if (topbus.Left > -46 && topbus.Left < 225 && topbus.Top < 212)
            {
                moveup = false;
                movedown = false;
            }

            //second squre 
            if (topbus.Left > 643 && topbus.Left < 923 && topbus.Top < 150)
            {
                moveleft = false;
                moveright = false;
            }

            if (topbus.Left > 280 && topbus.Left < 650 && topbus.Top < 212)
            {
                moveup = false;
                movedown = false;
            }
            //third squre
            if (topbus.Left > 700 && topbus.Left < 720 && topbus.Top < 212)
            {
                moveup = false;
                movedown = false;
            }


            ////////////////////////////////////////////////////
            ///new area 

            //first squre
            if (topbus.Left > -46 && topbus.Left < 225 && topbus.Top < 549)
            {
                moveup = false;
                movedown = false;
            }

            if (topbus.Left > 280 && topbus.Left < 650 && topbus.Top < 549)
            {
                moveup = false;
                movedown = false;
            }

            //second squre

            if (topbus.Left > 643 && topbus.Left < 923 && topbus.Top < 420 && topbus.Top > 185)
            {
                moveleft = false;
                moveright = false;
            }
            //second
            if (topbus.Left > 700 && topbus.Left < 800 && topbus.Top < 212)
            {
                moveup = false;
                movedown = false;
            }


            if (topbus.Left > 700 && topbus.Left < 800 && topbus.Top < 549)
            {
                moveup = false;
                movedown = false;
            }


            //third

            if (topbus.Left > 700 && topbus.Left < 720 && topbus.Top < 549)
            {
                moveup = false;
                movedown = false;
            }

            if (topbus.Left > 119 && topbus.Left < 346 && topbus.Top < 420 && topbus.Top > 185)
            {
                moveleft = false;
                moveright = false;
            }
            //third area 
            //first squre

            if (topbus.Left > 119 && topbus.Left < 346 && topbus.Top < 700 && topbus.Top > 450)
            {
                moveleft = false;
                moveright = false;
            }



            //bus movement
            if (moveleft == true && topbus.Left > 3)
            {

                if (!stepsList[stepsList.Count - 1].Equals('L'))//save info of steps and duration 
                {
                    stepsList.Add('L');
                    if (stepsList.Count > 2)
                    {
                        if (stepsList[stepsList.Count - 1] != stepsList[stepsList.Count - 2])
                        {
                            durationList.Add(duration); 
                        }

                    }
                    if (durationList.Count > 1)
                        timeTaken.Add(durationList[durationList.Count - 1] - durationList[durationList.Count - 2]);
                    locations.Enqueue(topbus.Location);
                }
                topbus.Left -= speed;
                Size size = new Size(63, 37);
                topbus.Size = size;
                topbus.Image = Properties.Resources.busleft;
            }
            if (moveright == true && topbus.Left < 911)
            {
                if (!stepsList[stepsList.Count - 1].Equals('R'))
                {
                    stepsList.Add('R');
                    if (stepsList.Count > 2)
                    {
                        if (stepsList[stepsList.Count - 1] != stepsList[stepsList.Count - 2])
                        {
                            durationList.Add(duration); 

                        }
                    }
                    if (durationList.Count > 1)
                        timeTaken.Add(durationList[durationList.Count - 1] - durationList[durationList.Count - 2]);
                    locations.Enqueue(topbus.Location);
                }

                topbus.Left += speed;
                Size size = new Size(63, 37);
                topbus.Size = size;
                topbus.Image = Properties.Resources.busright;

            }
            if (moveup == true && topbus.Top > 20)
            {

                if (!stepsList[stepsList.Count - 1].Equals('U'))
                {
                    stepsList.Add('U');
                    if (stepsList.Count > 2)
                    {
                        if (stepsList[stepsList.Count - 1] != stepsList[stepsList.Count - 2])
                        {
                            durationList.Add(duration);  
                                                         
                        }

                    }
                    if (durationList.Count > 1)
                        timeTaken.Add(durationList[durationList.Count - 1] - durationList[durationList.Count - 2]);
                    locations.Enqueue(topbus.Location);
                }

                topbus.Top -= speed;
                Size size = new Size(37, 63);
                topbus.Size = size;
                topbus.Image = Properties.Resources.busup;

            }
            if (movedown == true && topbus.Top < 667)
            {
                if (!stepsList[stepsList.Count - 1].Equals('D'))
                {
                    stepsList.Add('D');
                    if (stepsList.Count > 2)
                    {
                        if (stepsList[stepsList.Count - 1] != stepsList[stepsList.Count - 2])
                        {
                            durationList.Add(duration);  
                        }
                    }
                    if (durationList.Count > 1)
                        timeTaken.Add(durationList[durationList.Count - 1] - durationList[durationList.Count - 2]);
                    locations.Enqueue(topbus.Location);
                }
                topbus.Top += speed;
                Size size = new Size(37, 63);
                topbus.Size = size;
                topbus.Image = Properties.Resources.busdown;

            }
          

        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_COMPOSITED = 0x02000000;
                CreateParams cp = base.CreateParams; cp.ExStyle |= WS_EX_COMPOSITED; return cp;
            }
        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
          //  moon = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

          
        }

       

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, MouseEventArgs e)
        {

        }

       
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void topbus_Click(object sender, EventArgs e)
        {

        }

       

        private void bus_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

       }



        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }






    }
}
