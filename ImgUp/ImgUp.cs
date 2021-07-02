using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ImgUp
{
    public partial class ImgUp : Form
    {
        private const int GHKS_MAX = 10;
        private int memoMax = -1;

        private bool isLoaded = false;

        private GlobalHotkey[] ghks_memo;
        
        public ImgUp()
        {
            InitializeComponent();
        }

        private void ImgUp_Load(object sender, EventArgs e)
        {
            // Register hotkeys
            ghks_memo = new GlobalHotkey[GHKS_MAX];
            for(int i = 0; i < GHKS_MAX; i++)
            {
                ghks_memo[i] = new GlobalHotkey(GlobalHotkey.MOD_ALT + GlobalHotkey.MOD_SHIFT, Keys.D0 + i, this);
                ghks_memo[i].Register();
            }

            GlobalHotkey ghk_atf = new GlobalHotkey(GlobalHotkey.MOD_ALT + GlobalHotkey.MOD_SHIFT, Keys.S, this);
            ghk_atf.Register();

            // Make shared instance
            Variables.init();
            memoMax = Variables.MEMO_MAX;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == GlobalHotkey.WM_HOTKEY)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                if (key >= Keys.D0 && key <= Keys.D9)
                {
                    memoForm_Load((int)key);
                }
                else if (key == Keys.S)
                {
                    allToFront();
                }
            }
            base.WndProc(ref m);
        }

        private void allToFront()
        {
            for (int i = 0; i < memoMax; i++)
            {
                MemoForm mf = Variables.GetMemo(i);

                if (mf.Visible)
                {
                    if (mf.WindowState == FormWindowState.Minimized) mf.WindowState = FormWindowState.Normal;
                    mf.Activate();
                }
            }
        }

        private void savedMemoLoad()
        {
            string fileName = @"\imgup.bin";
            FileStream fs_file = null;
            BinaryReader br = null;

            try
            {
                fs_file = new FileStream(Application.StartupPath + fileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs_file);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("File imgup.bin read failed.");
            }
            
            if(br != null)
            {
                for (int i = 0; i < memoMax; i++)
                {
                    int temp_x = br.ReadInt32();
                    int temp_y = br.ReadInt32();

                    if (temp_x != Variables.NULL_LOCATION && temp_y != Variables.NULL_LOCATION)
                    {
                        string imageName = "\\memo_" + i.ToString() + ".png";
                        FileStream fs_image = null;

                        try
                        {
                            fs_image = new FileStream(Application.StartupPath + imageName, FileMode.Open, FileAccess.Read);                            
                        }
                        catch
                        {
                            System.Diagnostics.Debug.WriteLine("File memo_" + i.ToString() + ".png read failed.");
                        }
                        
                        if (fs_image != null)
                        {
                            // Handle to multi screens. If point is out of screen, then GetBounds() returns near screen.
                            Rectangle rect = Screen.GetBounds(new Point(temp_x, temp_y));
                            MemoForm mf = Variables.GetMemo(i);

                            mf.setMemo(Image.FromStream(fs_image));
                            
                            mf.Visible = true;
                            mf.Activate();
                            Point point;

                            // If point is in screen.
                            if (temp_x >= rect.X &&
                                temp_x <= rect.Width &&
                                temp_y >= rect.Y &&
                                temp_y <= rect.Height)
                            {
                                point = new Point(temp_x, temp_y);
                            }
                            // If point is out of screen, then set point to half of screen.
                            else
                            {
                                point = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                            }

                            mf.Location = point;
                            mf.setLocation(point);

                            fs_image.Close();
                            fs_image.Dispose();

                            isLoaded = true;
                        }
                    }
                }

                br.Close();
                fs_file.Close();
            }         
        }

        private void saveLocations()
        {
            string fileName = @"\imgup.bin";
            FileStream fs = null;
            BinaryWriter bw = null;

            try
            {
                fs = new FileStream(Application.StartupPath + fileName, FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("File imgup.bin write failed.");
            }

            if (bw != null)
            {
                for (int i = 0; i < memoMax; i++)
                {
                    Point point = Variables.GetLocation(i);
                    bw.Write(point.X);
                    bw.Write(point.Y);
                }

                bw.Close();
                fs.Close();
            }
        }

        private void memoForm_Load(int key)
        {
            int index = key - (int)Keys.D0;
            MemoForm mf = Variables.GetMemo(index);

            // If hided, then unhide
            if (mf.isHided())
            {
                mf.unHide();
            }
            else
            {
                Image image = Clipboard.GetImage();

                if (image != null)
                {
                    mf.setMemo(image);

                    if (!mf.Visible) mf.Visible = true;
                    if (mf.WindowState == FormWindowState.Minimized) mf.WindowState = FormWindowState.Normal;
                    // mf.Show() doesn't show at topmost.
                    mf.Activate();
                }
                // If covered up by other programs, then show up
                else if (mf.BackgroundImage != null) mf.Activate();
            }
        }

        private void ImgUp_Shown(object sender, EventArgs e)
        {
            // If mainform shown, then read saved memo.
            savedMemoLoad();

            if (isLoaded)
            {
                notifyIcon.BalloonTipIcon = ToolTipIcon.None;
                notifyIcon.BalloonTipTitle = "Hello";
                notifyIcon.BalloonTipText = "Loaded saved memo";
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void ImgUp_Resize(object sender, EventArgs e)
        {
            // If mainform minimized, then show up notifyicon.
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
            // If notifyicon double clikced, then show up mainform.
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
            for (int i = 0; i < memoMax; i++)
            {
                MemoForm mf = Variables.GetMemo(i);
                // Save image.
                Thread imgSaveThread = new Thread(new ThreadStart(mf.imageSave));
                imgSaveThread.Start();
            }
            // Save locations to binary file.
            Thread locSaveThread = new Thread(new ThreadStart(saveLocations));
            locSaveThread.Start();
        }

        private void mainForm_Cms_Exit()
        {
            this.Close();
        }
    }
}
