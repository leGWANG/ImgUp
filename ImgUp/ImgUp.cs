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

                    if (!mf.Visible) mf.Visible = true;
                    if (mf.WindowState == FormWindowState.Minimized) mf.WindowState = FormWindowState.Normal;
                    
                    mf.Activate();
                }
            }
        }
        private void allToFront()
        {
            int memoMax = Variables.MEMO_MAX;
            for(int i = 0; i < memoMax; i++)
            {
                MemoForm mf = Variables.GetMemo(i);

                if (mf.Visible)
                {
                    if (mf.WindowState == FormWindowState.Minimized) mf.WindowState = FormWindowState.Normal;
                    mf.Activate();
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == GlobalHotkey.WM_HOTKEY)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                if(key >= Keys.D0 && key <= Keys.D9)
                {
                    memoForm_Load((int)key);
                }
                else if(key == Keys.S)
                {
                    allToFront();
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
                ghks[i] = new GlobalHotkey(GlobalHotkey.MOD_ALT + GlobalHotkey.MOD_SHIFT, Keys.D0 + i, this);
                ghks[i].Register();
            }

            GlobalHotkey ghk_atf = new GlobalHotkey(GlobalHotkey.MOD_ALT + GlobalHotkey.MOD_SHIFT, Keys.S, this);
            ghk_atf.Register();
            
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
                case "Save All":
                    mainForm_Cms_SaveAll();
                    break;

                case "Exit":
                    mainForm_Cms_Exit();
                    break;

                default:
                    break;
            }     
        }

        private void mainForm_Cms_SaveAll()
        {

        }

        private void mainForm_Cms_Exit()
        {
            this.Close();
        }
    }
}
