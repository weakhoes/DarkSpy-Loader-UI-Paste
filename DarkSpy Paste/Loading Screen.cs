using gamesense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkSpyPaste
{
    public partial class form4 : Form
    {
        public form4()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            bunifuProgressBar1.Value += 2;
            if (bunifuProgressBar1.Value == 60)
            {
                timer1.Enabled = false;
                Form5 myForm = new Form5();
                this.Hide();
                myForm.ShowDialog();
                this.Close();
            }
        }

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
