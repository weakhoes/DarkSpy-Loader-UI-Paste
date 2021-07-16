using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Namespace Start
using gamesense;
//Namespace End

namespace DarkSpyPaste
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            bunifuProgressBar1.Value += 2;
            if (bunifuProgressBar1.Value == 10)
            {
                timer1.Enabled = false;
                Form2 myForm = new Form2();
                this.Hide();
                myForm.ShowDialog();
                this.Close();
        }   }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

        }
        
        //Exit Message And Dialog Answer
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure you Want To Exit", "Krypted Loader", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //donothing
            }
        }
    }
}
