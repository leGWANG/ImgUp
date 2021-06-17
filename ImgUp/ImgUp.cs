using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImgUp
{
    public partial class ImgUp : Form
    {
        private const int GHKS_MAX = 10;
        private const int MEMO_MAX = 10;
        private GlobalHotkey[] ghks;
        private MemoForm[] memoForm;
        
        public ImgUp()
        {
            InitializeComponent();
        }

        private void memoForm_Load(int key)
        {
            int index = key - (int)Keys.D0;
            if (memoForm[index] == null)
            {
                Console.WriteLine("new");
                memoForm[index] = new MemoForm();
                Image image = new Bitmap(@"C:\Users\GWANG\source\repos\bg.png");
                memoForm[index].BackgroundImage = image;
                memoForm[index].Width = image.Width;
                memoForm[index].Height = image.Height;
            }
            else
            {
                Console.WriteLine("else");
            }
            memoForm[index].Show();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == GlobalHotkey.WM_HOTKEY_MSG_ID)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                if(key >= Keys.D0 && key <= Keys.D9)
                {
                    memoForm_Load((int)key);
                }
            }
            base.WndProc(ref m);
        }

        private void ImgUp_Load(object sender, EventArgs e)
        {
            // register hotkeys
            ghks = new GlobalHotkey[GHKS_MAX];
            for(int i = 0; i < GHKS_MAX; i++)
            {
                ghks[i] = new GlobalHotkey(GlobalHotkey.ALT + GlobalHotkey.SHIFT, Keys.D0 + i, this);
                ghks[i].Register();
            }
            // make instance
            memoForm = new MemoForm[MEMO_MAX];
        }

        private void ImgUp_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notifyIcon.Visible = true;
            }
        }

        private void ImgUp_Show()
        {
            if(this.Visible == false && notifyIcon.Visible == true)
            {
                this.Visible = true;
                notifyIcon.Visible = false;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ImgUp_Show();
        }

        private void ImgUp_lnklb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/leGWANG/ImgUp");
        }

        private void cms_save_clicked()
        {

        }

        private void cms_hk_clicked()
        {

        }

        private void cms_exit_clicked()
        {
            this.Close();
        }

        private void notifyIcon_cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedItem = e.ClickedItem.ToString();
            switch (clickedItem)
            {
                case "Save":
                    Console.WriteLine(clickedItem);
                    cms_save_clicked();
                    break;

                case "HotKey":
                    Console.WriteLine(clickedItem);
                    cms_hk_clicked();
                    break;

                case "Exit":
                    Console.WriteLine(clickedItem);
                    cms_exit_clicked();
                    break;

                default:
                    break;
            }     
        }
    }
}
