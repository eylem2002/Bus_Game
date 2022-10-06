using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace CS_Project
{
    public partial class Form1 : Form
    {
        private SoundPlayer _soundPlayer;

      


       // SoundPlayer music = new SoundPlayer("beep.wave");
        
        public Form1()
        {
            InitializeComponent();
            _soundPlayer = new SoundPlayer("Alaa.wav");
            
        }
        Profile profile = new Profile();
        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            profile.ShowDialog();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            profile.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame game = new newGame();
            game.Show();
            //this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            _soundPlayer.Play();

            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\SHAIMAA\Downloads:Sound Effects - Kids Laughing (mp3).mp3");
            //player.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;
            pictureBox1.Location = new Point(x+3, y);
        }

        private void statiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics();
            statistics.ShowDialog();
            
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.ShowDialog();
           
        }


        protected override CreateParams CreateParams { get { const int WS_EX_COMPOSITED = 0x02000000; 
                CreateParams cp = base.CreateParams; cp.ExStyle |= WS_EX_COMPOSITED; return cp; } }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            //string fileName = "M.mp3";
            //string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);

            //WMPLib.WindowsMediaPlayer sound = new WMPLib.WindowsMediaPlayer();
            //sound.URL = @"C:\Users\Dash Arabia\Desktop M.mp3";

            //sound.controls.play();

            _soundPlayer.Stop();

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }
    }
}




