using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using DarkSpyPaste;

//----------------------------------------------------------------------------------------------------------//
//Krypted Loader Is A Paste Of DarkSpy UI / Injection Code And HWID Code And DLL Code Pasted From Gamesense //
//Redesign And Code Additons By Krypto On FunDip#6446/Me                                                    //
//This Is An Open Source Project I Don't Care What You Do With This Source You Can Sell It Or Whatever      //
//Do Not Call Paste Your Own Unless You Add Major Changes                                                   //
//----------------------------------------------------------------------------------------------------------//

namespace gamesense
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();          //= '.' The Charactar In The Middle Is What The Password Box Letter Will Change Too
            PasswordBox.PasswordChar = '•';

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   //If It Finds Any Of These Application Names Running The Application Will Close Itself
            Process[] ida64 = Process.GetProcessesByName("ida64");
            Process[] ida32 = Process.GetProcessesByName("ida32");
            Process[] ollydbg = Process.GetProcessesByName("ollydbg");
            Process[] ollydbg64 = Process.GetProcessesByName("ollydbg64");
            Process[] loaddll = Process.GetProcessesByName("loaddll");
            Process[] httpdebugger = Process.GetProcessesByName("httpdebugger");
            Process[] windowrenamer = Process.GetProcessesByName("windowrenamer");
            Process[] processhacker = Process.GetProcessesByName("processhacker");
            Process[] processhacker2 = Process.GetProcessesByName("Process Hacker");
            Process[] processhacker3 = Process.GetProcessesByName("ProcessHacker");
            Process[] HxD = Process.GetProcessesByName("HxD");
            Process[] parsecd = Process.GetProcessesByName("parsecd");
            Process[] ida = Process.GetProcessesByName("ida");
            Process[] dnSpy = Process.GetProcessesByName("dnSpy");
            if (ida64.Length != 0 || ida32.Length != 0 || ollydbg.Length != 0 || ollydbg64.Length != 0 || loaddll.Length != 0 || httpdebugger.Length != 0 || windowrenamer.Length != 0 || processhacker.Length != 0 || processhacker2.Length != 0 || processhacker3.Length != 0 || HxD.Length != 0 || ida.Length != 0 || parsecd.Length != 0 || dnSpy.Length != 0)
            {
                Application.Exit();
            }
        }
         
        //String Start
        string usernameget = "UsernameBox.Text";
        string passwordtext = "123"; // Change Password If You Want
        //String End
        
        //Suggestion If You Also Want To Add A Username They Have To Enter Then Copy And Paste The Code Below And Put It Behind PasswordBox.Text == "123"
        //UsernameBox.Text == "123" &&
       
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {                            
            if (PasswordBox.Text == passwordtext)
            {                    //Login Succesful Message
                MessageBox.Show("Succesfully Logged In!", "Krypted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form4 myForm = new form4();
                this.Hide();
                myForm.ShowDialog();
                this.Close();
            }
            else
            {                                                //Login Unsuccesful Message
                DialogResult dialogResult = MessageBox.Show("Login Invalid...", "Krypted Loader", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                //Asks A Question You Can Change The .Retry And .Cancel To Whatever Buttons And Also Change The Question
                if (dialogResult == DialogResult.Retry)
            {       //Clears Username Box And Password Box
                    UsernameBox.Clear();
                    PasswordBox.Clear();
                }
                else if (dialogResult == DialogResult.Cancel)
            {
                    Application.Exit();
                }
            }
        }

        private void login_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
