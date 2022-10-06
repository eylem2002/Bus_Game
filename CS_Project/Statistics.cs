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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }
        int countGames;
        int countProfiles;
        int maxScore;
        int minScore;
        int minDuration;
        int maxDuration;
        int sum = 0;
        string highName = "";
        private void Statistics_Load(object sender, EventArgs e)
        {
            fun();
            label1.Text = countGames.ToString();
            label2.Text = countProfiles.ToString();
            label3.Text = maxScore.ToString();
            label4.Text = highName;
            label5.Text = minScore.ToString();
            label6.Text = minDuration.ToString();
            label7.Text = maxDuration.ToString();
            label8.Text = sum.ToString();

        }
        public void fun()
        {
            List<games> gamesList = Game.listOfgames();
            List<Player> profileList = Profile.listOfgames();
            if (gamesList.Count > 0)                                                 //handling exception
            {
                countGames = (from x in gamesList select x).Count();                //retrieve data
                maxScore = (from x in gamesList
                            select x.score).Max();
                minScore = (from x in gamesList
                            select x.score).Min();

                maxDuration = (from x in gamesList select x.duration).Max();
                minDuration = (from x in gamesList select x.duration).Min();

                var str = (from x in gamesList
                           where x.score == maxScore
                           select x.playername
                           );
                foreach (string item in str)
                {
                   highName += item.ToString(); 
                }
                

                var Duration = (from x in gamesList select x.duration);
                foreach (int item in Duration)
                {
                    sum += item;
                }

            }

            if (profileList.Count > 0)                                          //handling exception
                countProfiles = (from x in profileList select x).Count();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
