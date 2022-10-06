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
    public partial class Game2 : Form
    {
        public bool moon = false;
        Random rand = new Random();


        bool moveup, movedown, moveleft, moveright;
        int speed = 15;
        int score = Game.Lscore, level = 2, duration, val= Game.dur;
        public static int Lscore;


        public Game2()
        {
            InitializeComponent();
        }

        string str;
        private void Game2_Load_1(object sender, EventArgs e)
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
            label8.Text = score.ToString();
            pictureBox3.Image = p.image;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            timer1.Start();

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
                pictureBox4.Location = new Point(A1, B1);

            }
            else if (num_rand2 > 5 && num_rand2 <= 10)
            {
                pictureBox4.Location = new Point(A2, B1);

            }
            else if (num_rand2 > 10 && num_rand2 <= 20)
            {
                pictureBox4.Location = new Point(A3, B3);

            }

            else
            {

                pictureBox4.Location = new Point(A3, B4);

            }


            while (topbus.Bounds.IntersectsWith(pictureBox2.Bounds) || topbus.Bounds.IntersectsWith(pictureBox4.Bounds))
            { 
                   topbus.Location = new Point(x1, y1);
                pictureBox4 .Location = new Point(A1, B1);
                break;
            }


        }


        public static int dur;

        private void timer1_Tick(object sender, EventArgs e)
        {
            duration = val++;
            label6.Text = duration.ToString();
            while (topbus.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                label8.Text = (score += 10).ToString();
                label7.Text = (level).ToString();
                //Add info for level2
                games l1 = new games(label5.Text, duration, score, level, DateTime.Now);
                Game.AddGame(l1);

                //  Profile.addGame(new games(str, duration, score, level, DateTime.Now));
                dur = duration;
                Lscore = score;

                Profile.addGame(new games(str, duration, score, level, DateTime.Now));

                timer1.Stop();
                if (Lscore == 5 || Lscore == 10 || Lscore == 15 || Lscore == 20)
                {
                    MoverTimer.Stop();
                    pictureBox1.Visible = true;
                    pictureBox1.Show();
                    button1.Visible = true;
                    button1.Show();
                }

                //MoverTimer.Stop();
                break;
            }


            while (topbus.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                label8.Text = (score -= 5).ToString();
                label7.Text = (level).ToString();

                //  Profile.addGame(new games(str, duration, score, level, DateTime.Now));

                dur = duration;
                Lscore = score;

                Profile.addGame(new games(str, duration, score, level, DateTime.Now));



                if (Lscore <= 0)
                {
                    timer1.Stop();
                    MoverTimer.Stop();
                    pictureBox5.Visible = true;
                    pictureBox5.Show();

                    //Add info for intersect with rocks
                    games l2 = new games(label5.Text, duration, score, level, DateTime.Now);
                    Game.AddGame(l2);

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
                    pictureBox4.Location = new Point(A1, B1);

                }
                else if (num_rand2 > 5 && num_rand2 <= 10)
                {
                    pictureBox4.Location = new Point(A2, B1);

                }
                else if (num_rand2 > 10 && num_rand2 <= 20)
                {
                    pictureBox4.Location = new Point(A3, B3);

                }

                else
                {

                    pictureBox4.Location = new Point(A3, B4);

                }


                //////to check 

                while (topbus.Bounds.IntersectsWith(pictureBox2.Bounds) || topbus.Bounds.IntersectsWith(pictureBox4.Bounds))
                {
                   
                    pictureBox4.Location = new Point(A1, B1);
                    break;
                }


                //MoverTimer.Stop();
                break;
            }

        }

        ///
        private void button1_Click(object sender, EventArgs e)
        {
            moon = true;
            Game3 game = new Game3();
            if (moon == true)
            {
                game.Show();
                this.Hide();
            }
        }

    
        private void MoverTimer_Tick_1(object sender, EventArgs e)
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

            if (topbus.Left > 643 && topbus.Left < 923 && topbus.Top < 420 && topbus.Top > 185)//alaa edit 
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
                topbus.Left -= speed;
                Size size = new Size(63, 37);
                topbus.Size = size;
                topbus.Image = Properties.Resources.busleft;
            }
            if (moveright == true && topbus.Left < 911)
            {
                topbus.Left += speed;
                Size size = new Size(63, 37);
                topbus.Size = size;
                topbus.Image = Properties.Resources.busright;

            }
            if (moveup == true && topbus.Top > 20)
            {
                topbus.Top -= speed;
                Size size = new Size(37, 63);
                topbus.Size = size;
                topbus.Image = Properties.Resources.busup;

            }
            if (movedown == true && topbus.Top < 667)
            {
                topbus.Top += speed;
                Size size = new Size(37, 63);
                topbus.Size = size;
                topbus.Image = Properties.Resources.busdown;

            }
        }

  
       
        private void Game2_Load(object sender, EventArgs e)
        {
            str = newGame.comb();


            Player p = Profile.PlayerInfo(str);
            label5.Text = p.Name;
            label7.Text = level.ToString();
            label8.Text = score.ToString();
            timer1.Start();

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



    }
}
