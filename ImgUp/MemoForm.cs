using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace ImgUp
{
    public partial class MemoForm : Form
    {
        private int index = -1;
        private bool isHide = false;
        private bool isSaving = false;
        private const int RESIZE_HANDLE_SIZE = 10;

        // When the cursor moves, when a mouse button is pressed or released, or in response to a call to a function such as WindowFromPoint.
        private const int WM_NCHITTEST = 0x0084;
        // When the user presses the right mouse button while the cursor is within the nonclient area of a window.
        private const int WM_NCRBUTTONDOWN = 0x00A4;

        // In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
        private IntPtr HTBOTTOMRIGHT = (IntPtr)17; 
        // In a title bar.
        private IntPtr HTCAPTION = (IntPtr)2;
        // In a client area
        private IntPtr HTCLIENT = (IntPtr)1; 

        public MemoForm(int index)
        {
            InitializeComponent();
            this.index = index;
        }

        public bool isHided()
        {
            return isHide;
        }

        public void unHide()
        {
            this.isHide = false;
            this.Visible = true;
            this.Activate();
        }

        public void imageSave()
        {
            isSaving = true;

            string fileName = "\\memo_" + index.ToString() + ".png";
            this.BackgroundImage.Save(Application.StartupPath + fileName, ImageFormat.Png);

            isSaving = false;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            if(m.Msg == WM_NCRBUTTONDOWN)
            {
                if(!memoForm_Cms.Visible) memoForm_Cms.Show(Cursor.Position);
            }
            
            if (m.Msg == WM_NCHITTEST) 
            {
                if (m.Result == HTCLIENT)
                {
                    Point screenPoint = new Point(m.LParam.ToInt32());
                    Point clientPoint = this.PointToClient(screenPoint);

                    if (clientPoint.X >= this.Size.Width - RESIZE_HANDLE_SIZE && clientPoint.Y >= this.Size.Height - RESIZE_HANDLE_SIZE)
                    {
                        m.Result = HTBOTTOMRIGHT;
                    }
                    else
                    {
                        m.Result = HTCAPTION;
                    }
                }
            }  
        }

        private void MemoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.BackgroundImage.Dispose();
            this.Dispose();
        }

        private void memoForm_cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedItem = e.ClickedItem.ToString();
            switch (clickedItem)
            {
                case "TopMost":
                    memoForm_Cms_TopMost();
                    break;

                case "Minimize":
                    memoForm_Cms_Minimize();
                    break;

                case "Save Image":
                    memoForm_Cms_SaveImage();
                    break;
                
                case "Hide":
                    memoForm_Cms_Hide();
                    break;

                case "Erase":
                    memoForm_Cms_Erase();
                    break;

                default:
                    break;
            }
        }

        private void memoForm_Cms_TopMost()
        {
            memoFormCmsItem_TopMost.Checked = !memoFormCmsItem_TopMost.Checked;
            this.TopMost = !this.TopMost;
        }

        private void memoForm_Cms_SaveImage()
        {
            Thread thread = new Thread(new ThreadStart(imageSave));
            thread.Start();
        }

        private void memoForm_Cms_Minimize()
        {
            if(memoForm_Cms.Visible) memoForm_Cms.Hide();
            this.WindowState = FormWindowState.Minimized;
        }

        private void memoForm_Cms_Hide()
        {
            this.isHide = true;
            this.Visible = false;
        }

        private void memoForm_Cms_Erase()
        {
            if (!isSaving)
            {
                this.BackgroundImage.Dispose();
                this.Dispose();
            }   
        }
    }
}
