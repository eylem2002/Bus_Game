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
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }
       
        private void History_Load(object sender, EventArgs e)
        {
            List<games> lgames = Game.listOfgames();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;
            dataGridView1.EnableHeadersVisualStyles = false;
            

            for (int i = 0; i < lgames.Count; i++)
            {
                dataGridView1.Rows.Add(lgames[i].playername, lgames[i].date, lgames[i].duration, lgames[i].score, lgames[i].level);
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            playBack p = new playBack();
            p.ShowDialog();

        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
