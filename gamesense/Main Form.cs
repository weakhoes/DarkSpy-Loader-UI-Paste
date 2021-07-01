using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamesense
{
    public partial class Form2 : Form
    {
        string HWID;
        // Vars
        string dll_link = "https://github.com/flowxrc/storage/raw/main/cheat.dll"; // Нажмите "Loader setup" для подробностей
        string hwid_link = "https://github.com/flowxrc/storage/blob/main/hwid.txt"; // Нажмите "Loader setup" для подробностей (Ссылка на файл с хвидами)
        string dll_name = "svchost"; // Название файла (dll) которое качаеться без .dll
        int time_to_wait = 30000; // Сколько ждать времени перед инжектом (в милисекундах) (дефолт - 30 секунд)

        // SETUP VAR
        bool setted_up = false; // Измените на true если вы закончили настройку loader'a
        // SETUP VAR

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form2()
        {
            InitializeComponent();
        }

        private async void load_Click(object sender, EventArgs e)
        {
            // Основа замка по hwidу была взята с GitHub SimpleLoader

            WebClient wb = new WebClient();
            string access_list = wb.DownloadString(hwid_link);
            if (access_list.Contains(HWID))
            {
                this.Hide();
                string mainpath = "C:\\Windows\\" + dll_name + ".dll";
                wb.DownloadFile(dll_link, mainpath);

                Process.Start("steam://rungameid/730");
                await Task.Delay(time_to_wait);
                Process csgo = Process.GetProcessesByName("csgo").FirstOrDefault();
                Process[] csgo_array = Process.GetProcessesByName("csgo");
                if (csgo_array.Length != 0)
                {
                    // Инжект
                    injector.BasicInject.Inject(mainpath, "csgo");
                    Console.Read();
                    MessageBox.Show("Injected", "gamesense.pub", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    csgo.WaitForExit();
                    // Delete cheat
                    if (File.Exists(mainpath))
                    {
                        File.Delete(mainpath);
                    }
                    await Task.Delay(10000);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Error: CS:GO Process not found", "gamesense.pub", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Incorrect HWID", "gamesense.pub");
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        private void setup_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Form3 myForm = new Form3();
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
