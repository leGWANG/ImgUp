using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


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
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == GlobalHotkey.WM_HOTKEY_MSG_ID)
            {
                
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);

                switch (key)
                {
                    case Keys.D0:
                        Console.WriteLine(key);
                        break;

                    case Keys.D1:
                        Console.WriteLine(key);
                        break;

                    case Keys.D2:
                        Console.WriteLine(key);
                        break;

                    case Keys.D3:
                        Console.WriteLine(key);
                        break;

                    case Keys.D4:
                        Console.WriteLine(key);
                        break;

                    case Keys.D5:
                        Console.WriteLine(key);
                        break;

                    case Keys.D6:
                        Console.WriteLine(key);
                        break;

                    case Keys.D7:
                        Console.WriteLine(key);
                        break;

                    case Keys.D8:
                        Console.WriteLine(key);
                        break;

                    case Keys.D9:
                        Console.WriteLine(key);
                        break;
                    
                    default:
                        break;  
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
    }
}
