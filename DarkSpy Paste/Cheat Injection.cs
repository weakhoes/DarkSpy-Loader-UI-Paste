using System;
using System.Windows.Forms;

//----------------------------------------------------------------------------------------------------------//
//Krypted Loader Is A Paste Of DarkSpy UI / Injection Code And HWID Code And DLL Code Pasted From Gamesense //
//Redesign And Code Additons By Krypto On FunDip#6446/Me                                                    //
//This Is An Open Source Project I Don't Care What You Do With This Source You Can Sell It Or Whatever      //
//Do Not Call Paste Your Own Unless You Add Major Changes                                                   //
//----------------------------------------------------------------------------------------------------------//

namespace gamesense
{
    public partial class Form3 : Form
    {
        string HWID;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
        }

        private void copy_hwid_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(HWID);
            MessageBox.Show("Copied HWID", "DarkSpy Paste");
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
 
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            Form2 myForm = new Form2();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
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
