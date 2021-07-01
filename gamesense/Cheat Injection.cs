using System;
using System.Windows.Forms;

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
            MessageBox.Show("Copied HWID", "gamesense.pub");
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void howtoDLL_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создайте репозиторий на Github, затем загрузите туда свою DLL'ку и скопируйте ссылку на свой DLL.\n\nПример: https://github.com/test/loader/cheat.dll \nПосле, вставьте эту ссылку в переменную dll_link в Form2.cs", "gamesense.pub");
        }

        private void howtoHWID_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создайте репозиторий на Github (если у вас уже есть репозиторий с DLL-кой то не надо), затем создайте там текстовый файл и скопируйте свой HWID в этой панели.\nПосле, вставьте туда свой HWID и скопируйте ссылку.\nПример 1: https://github.com/test/loader/hwids.txt \nПосле, вставьте эту ссылку в переменную hwid_link в Form2.cs", "gamesense.pub");
        }

        private void finished_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В Form2.cs есть переменная setted_up (boolean). Поменяйте её на true если вы закончили настройку loader'a", "gamesense.pub");
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
