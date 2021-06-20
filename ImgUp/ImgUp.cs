using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImgUp
{
    public partial class ImgUp : Form
    {
        private const int GHKS_MAX = 10;
        private GlobalHotkey[] ghks;
        
        public ImgUp()
        {
            InitializeComponent();
        }

        private void memoForm_Load(int key)
        {
            int index = key - (int)Keys.D0;
            MemoForm mf = Variables.GetMemo(index);

            if (mf.isHided())
            {
                mf.unHide();
            }
            else
            {
                Image image = Clipboard.GetImage();

                if (image != null)
                {
                    if (mf.BackgroundImage != null) mf.BackgroundImage.Dispose();

                    mf.BackgroundImage = image;
                    mf.Width = image.Width;
                    mf.Height = image.Height;

                    if (!mf.Visible) mf.Show();
                    if (mf.WindowState == FormWindowState.Minimized) mf.WindowState = FormWindowState.Normal;
                }
            }
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
            // Register hotkeys
            ghks = new GlobalHotkey[GHKS_MAX];
            for(int i = 0; i < GHKS_MAX; i++)
            {
                ghks[i] = new GlobalHotkey(GlobalHotkey.ALT + GlobalHotkey.SHIFT, Keys.D0 + i, this);
                ghks[i].Register();
            }
            // Make shared instance
            Variables.init();
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

        private void notifyIcon_cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedItem = e.ClickedItem.ToString();
            switch (clickedItem)
            {
                case "Save":
                    cms_save_clicked();
                    break;

                case "HotKey":
                    cms_hk_clicked();
                    break;

                case "Exit":
                    cms_exit_clicked();
                    break;

                default:
                    break;
            }     
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
    }
}
