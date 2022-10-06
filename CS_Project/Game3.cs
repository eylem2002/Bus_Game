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
    public partial class Game3 : Form
    {

        public bool moon = false;
        Random rand = new Random();

        bool moveup, movedown, moveleft, moveright;
        int speed = 15;
        int score = Game2.Lscore, level = 3, duration, val = Game2.dur;
        public static int Lscore;
        
        public Game3()
        {
            InitializeComponent();
        }
        
        string str;

        private void Form3_Load(object sender, EventArgs e)
        {
            str = newGame.comb();
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
            label1.Text = score.ToString();
            pictureBox4.Image = p.image;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            timer2.Start();


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
            if (num_rand >= 0 && num_rand <= 5)
            {
                busright.Location = new Point(x1, y1);
                size1 = new Size(32, 82);//i
                busright.Image = Properties.Resources.busdown;
            }
            else if (num_rand > 5 && num_rand <= 10)
            {
                busright.Location = new Point(x2, y1);
                size1 = new Size(32, 82);//i
                busright.Image = Properties.Resources.busdown;
            }
            else if (num_rand > 10 && num_rand <= 20)
            {
                busright.Location = new Point(x3, y3);
                size1 = new Size(82, 32);
                busright.Image = Properties.Resources.busright;
            }

            else
            {

                busright.Location = new Point(x3, y4);
                size1 = new Size(82, 32);//i
                busright.Image = Properties.Resources.busright;
            }


            busright.Size = size1;



            //random location 
            ///random location 
            int num_rand2 = rand.Next(0, 20);

            //Right street 
            int A1 = rand.Next(664, 667);
            int B1 = rand.Next(32, 392);

            //left street
            int A2 = rand.Next(239, 241);

            //up street 

            int A3 = rand.Next(3, 713);
            int B3 = rand.Next(156, 168);
            //down street 
            //int A4 = rand.Next(236, 526);
            int B4 = rand.Next(436, 438);

            if (num_rand2 >= 0 && num_rand2 <= 5)
            {
                pictureBox3.Location = new Point(A1, B1);

            }
            else if (num_rand2 > 5 && num_rand2 <= 10)
            {
                pictureBox3.Location = new Point(A2, B1);

            }
            else if (num_rand2 > 10 && num_rand2 <= 20)
            {
                pictureBox3.Location = new Point(A3, B3);

            }

            else
            {

                pictureBox3.Location = new Point(A3, B4);

            }



            int num_rand22 = rand.Next(0, 20);

            //////////////// load random location for second pic box 7 


            if (num_rand22 >= 0 && num_rand22 <= 5)
            {
                pictureBox7.Location = new Point(A1, B1);

            }
            else if (num_rand22 > 5 && num_rand22 <= 10)
            {
                pictureBox7.Location = new Point(A2, B1);

            }
            else if (num_rand22 > 10 && num_rand22 <= 20)
            {
                pictureBox7.Location = new Point(A3, B3);

            }

            else
            {

                pictureBox7.Location = new Point(A3, B4);

            }

            ///////// here to check IntersectsWith 

            while ((busright.Bounds.IntersectsWith(pictureBox2.Bounds) || busright.Bounds.IntersectsWith(pictureBox7.Bounds)) || busright.Bounds.IntersectsWith(pictureBox3.Bounds)  || pictureBox7.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                busright.Location = new Point(A3, B3);
                pictureBox7.Location = new Point(A2, B1);

            }

        }

        public static int dur;

        private void timer2_Tick(object sender, EventArgs e)
        {
            duration = val++;
            label9.Text = duration.ToString();
            while (busright.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                label1.Text = (score += 10).ToString();
                label7.Text = (level).ToString();
                
                //  Profile.addGame(new games(str, duration, score, level, DateTime.Now));
                dur = duration;
                Lscore = score;
                games l1 = new games(label5.Text, duration, score, level, DateTime.Now);
                Game.AddGame(l1);

                Profile.addGame(new games(str, duration, score, level, DateTime.Now));

                timer2.Stop();
                if (Lscore == 5 || Lscore == 10 || Lscore == 15 || Lscore == 20 || Lscore == 25 || Lscore == 30)
                {
                    MoverTimer2.Stop();
                    pictureBox1.Visible = true;
                    pictureBox1.Show();
                    
                }

                //MoverTimer.Stop();
                break;
            }


            while (busright.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                label1.Text = (score -= 5).ToString();
                label7.Text = (level).ToString();
                games l2 = new games(label5.Text, duration, score, level, DateTime.Now);
                Game.AddGame(l2);
                //  Profile.addGame(new games(str, duration, score, level, DateTime.Now));
                dur = duration;
                Lscore = score;

                Profile.addGame(new games(str, duration, score, level, DateTime.Now));

                if (Lscore <= 0)
                {
                    timer2.Stop();
                    MoverTimer2.Stop();
                    pictureBox6.Visible = true;
                    pictureBox6.Show();

                }

                //random location 
                ///random location 
                int num_rand2 = rand.Next(0, 20);

                //Right street 
                int A1 = rand.Next(664, 667);
                int B1 = rand.Next(32, 392);

                //left street
                int A2 = rand.Next(239, 241);

                //up street 

                int A3 = rand.Next(3, 713);
                int B3 = rand.Next(156, 168);
                //down street 
                //int A4 = rand.Next(236, 526);
                int B4 = rand.Next(436, 438);

                if (num_rand2 >= 0 && num_rand2 <= 5)
                {
                    pictureBox3.Location = new Point(A1, B1);

                }
                else if (num_rand2 > 5 && num_rand2 <= 10)
                {
                    pictureBox3.Location = new Point(A2, B1);

                }
                else if (num_rand2 > 10 && num_rand2 <= 20)
                {
                    pictureBox3.Location = new Point(A3, B3);

                }

                else
                {

                    pictureBox3.Location = new Point(A3, B4);
                }


                if
                    ( busright.Bounds.IntersectsWith(pictureBox3.Bounds) || busright.Bounds.IntersectsWith(pictureBox7.Bounds) || pictureBox3.Bounds.IntersectsWith(pictureBox7.Bounds)  )
                {
                    
                    pictureBox7.Location = new Point(A2, B1);
               
                } 
                //MoverTimer.Stop();
                break;
            }


            /// picbox 7 
            while (busright.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                label1.Text = (score -= 5).ToString();
                label7.Text = (level).ToString();
                games l2 = new games(label5.Text, duration, score, level, DateTime.Now);
                Game.AddGame(l2);
               
                dur = duration;
                Lscore = score;

                Profile.addGame(new games(str, duration, score, level, DateTime.Now));

                if (Lscore <= 0)
                {
                    timer2.Stop();
                    MoverTimer2.Stop();
                    pictureBox6.Visible = true;
                    pictureBox6.Show();

                }

                ///random location 
                int num_rand2 = rand.Next(0, 20);

                //Right street 
                int A1 = rand.Next(664, 667);
                int B1 = rand.Next(32, 392);

                //left street
                int A2 = rand.Next(239, 241);

                //up street 
                int A3 = rand.Next(3, 713);
                int B3 = rand.Next(156, 168);
                //down street 
                //int A4 = rand.Next(236, 526);
                int B4 = rand.Next(436, 438);

                if (num_rand2 >= 0 && num_rand2 <= 5)
                {
                    pictureBox7.Location = new Point(A1, B1);
                }
                else if (num_rand2 > 5 && num_rand2 <= 10)
                {
                    pictureBox7.Location = new Point(A2, B1);
                }
                else if (num_rand2 > 10 && num_rand2 <= 20)
                {
                    pictureBox7.Location = new Point(A3, B3);
                }
                else
                {

                    pictureBox7.Location = new Point(A3, B4);
                }
                
                   while (busright.Bounds.IntersectsWith(pictureBox7.Bounds) || busright.Bounds.IntersectsWith(pictureBox3.Bounds) || pictureBox3.Bounds.IntersectsWith(pictureBox7.Bounds))
                      {

                    pictureBox3.Location = new Point(A3, B4);
                    break;
                         }
                //MoverTimer.Stop();
                break;
            }

        }

        private void MoverTimer2_Tick(object sender, EventArgs e)
        {
            //first squre
            if (busright.Left > 119 && busright.Left < 346 && busright.Top < 150)
            {
                moveleft = false;
                moveright = false;
            }


            if (busright.Left > -46 && busright.Left < 225 && busright.Top < 212)
            {
                moveup = false;
                movedown = false;
            }

            //second squre 
            if (busright.Left > 643 && busright.Left < 923 && busright.Top < 150)
            {
                moveleft = false;
                moveright = false;
            }

            if (busright.Left > 280 && busright.Left < 650 && busright.Top < 212)
            {
                moveup = false;
                movedown = false;
            }
            //third squre
            if (busright.Left > 700 && busright.Left < 720 && busright.Top < 212)
            {
                moveup = false;
                movedown = false;
            }
            ////////////////////////////////////////////////////
            ///new area 

            //first squre
            if (busright.Left > -46 && busright.Left < 225 && busright.Top < 549)
            {
                moveup = false;
                movedown = false;
            }

            if (busright.Left > 280 && busright.Left < 650 && busright.Top < 549)
            {
                moveup = false;
                movedown = false;
            }
            //second squre

            if (busright.Left > 643 && busright.Left < 923 && busright.Top < 420 && busright.Top > 185)//alaa edit 
            {
                moveleft = false;
                moveright = false;
            }

            //second
            if (busright.Left > 700 && busright.Left < 800 && busright.Top < 212)
            {
                moveup = false;
                movedown = false;
            }


            if (busright.Left > 700 && busright.Left < 800 && busright.Top < 549)
            {
                moveup = false;
                movedown = false;
            }

            //third

            if (busright.Left > 700 && busright.Left < 720 && busright.Top < 549)
            {
                moveup = false;
                movedown = false;
            }

            if (busright.Left > 119 && busright.Left < 346 && busright.Top < 420 && busright.Top > 185)
            {
                moveleft = false;
                moveright = false;
            }
            //third area 
            //first squre

            if (busright.Left > 119 && busright.Left < 346 && busright.Top < 700 && busright.Top > 450)
            {
                moveleft = false;
                moveright = false;
            }

            //bus movement
            if (moveleft == true && busright.Left > 3)
            {
                busright.Left -= speed;
                Size size = new Size(63, 37);
                busright.Size = size;
                busright.Image = Properties.Resources.busleft;
            }
            if (moveright == true && busright.Left < 911)
            {
                busright.Left += speed;
                Size size = new Size(63, 37);
                busright.Size = size;
                busright.Image = Properties.Resources.busright;

            }
            if (moveup == true && busright.Top > 20)
            {
                busright.Top -= speed;
                Size size = new Size(37, 63);
                busright.Size = size;
                busright.Image = Properties.Resources.busup;

            }
            if (movedown == true && busright.Top < 667)
            {
                busright.Top += speed;
                Size size = new Size(37, 63);
                busright.Size = size;
                busright.Image = Properties.Resources.busdown;

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


        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_COMPOSITED = 0x02000000;
                CreateParams cp = base.CreateParams; cp.ExStyle |= WS_EX_COMPOSITED; return cp;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
