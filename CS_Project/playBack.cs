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
    public partial class playBack : Form
    {
        public playBack()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void playBack_Load(object sender, EventArgs e)
        {
            string s = "";
            for(int i = 1; i < Game.stepsList.Count-1; i++)
            {
                s += Game.stepsList[i];
                s += Environment.NewLine;
            }
            textBox1.Text = s + Environment.NewLine;

          
            s = "";
            for (int i = 0; i < Game.timeTaken.Count; i++)
            {
                s += Game.timeTaken[i];
                s += Environment.NewLine;
            }
            textBox2.Text = s + Environment.NewLine;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
          
            int index=1;
            
                if (Game.locations.Count > 0)
                {
                    if (Game.stepsList[index] == 'L')
                    {
                        topbus.Location = Game.locations.First();

                        Size size = new Size(63, 37);
                        topbus.Size = size;
                        topbus.Image = Properties.Resources.busleft;

                        Game.locations.Dequeue();
                        Game.stepsList.RemoveAt(index);
                    if(index<Game.stepsList.Count-1)
                        index++;

                    }
                    if (Game.stepsList[index] == 'R')
                    {
                        topbus.Location = Game.locations.First();

                        Size size = new Size(63, 37);
                        topbus.Size = size;
                        topbus.Image = Properties.Resources.busright;

                        Game.locations.Dequeue();
                        Game.stepsList.RemoveAt(index);

                    if (index < Game.stepsList.Count-1)
                        index++;

                    }
                    if (Game.stepsList[index] == 'U')
                    {
                        topbus.Location = Game.locations.First();
                        
                        Size size = new Size(37, 63);
                        topbus.Size = size;
                        topbus.Image = Properties.Resources.busup;

                        Game.locations.Dequeue();
                        Game.stepsList.RemoveAt(index);

                   if (index < Game.stepsList.Count-1)
                        index++;

                }
                    if (Game.stepsList[index] == 'D')
                    {
                        topbus.Location = Game.locations.First();

                        Size size = new Size(37, 63);
                        topbus.Size = size;
                        topbus.Image = Properties.Resources.busdown;

                        Game.locations.Dequeue();
                        Game.stepsList.RemoveAt(index);

                     if (index < Game.stepsList.Count-1)
                        index++;
                }
                }

            


        }
    }
}
