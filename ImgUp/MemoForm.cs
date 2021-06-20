using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImgUp
{
    public partial class MemoForm : Form
    {
        private int index = -1;
        const int RESIZE_HANDLE_SIZE = 10;

        // When the cursor moves, when a mouse button is pressed or released, or in response to a call to a function such as WindowFromPoint.
        const int WM_NCHITTEST = 0x0084; 
        // When the user presses the right mouse button while the cursor is within the nonclient area of a window.
        const int WM_NCRBUTTONDOWN = 0x00A4; 

        // In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
        IntPtr HTBOTTOMRIGHT = (IntPtr)17; 
        // In a title bar.
        IntPtr HTCAPTION = (IntPtr)2; 
        // In a client area
        IntPtr HTCLIENT = (IntPtr)1; 

        public MemoForm(int index)
        {
            InitializeComponent();
            this.index = index;
        }

        private void MemoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            if(m.Msg == WM_NCRBUTTONDOWN)
            {
                if(!memoForm_cms.Visible) memoForm_cms.Show(Cursor.Position);
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

        private void memoForm_cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedItem = e.ClickedItem.ToString();
            switch (clickedItem)
            {
                case "TopMost":
                    memoForm_cms_topmost();
                    break;

                case "Minimize":
                    memoForm_cms_minimize();
                    break;

                case "Save Image":
                    memoForm_cms_saveImage();
                    break;

                case "Erase":
                    memoForm_cms_erase();
                    break;

                default:
                    break;
            }
        }

        private void memoForm_cms_topmost()
        {
            memoFormCmsItem_topmost.Checked = !memoFormCmsItem_topmost.Checked;
            this.TopMost = !this.TopMost;
        }

        private void memoForm_cms_saveImage()
        {

        }

        private void memoForm_cms_minimize()
        {
            if(memoForm_cms.Visible) memoForm_cms.Hide();
            this.WindowState = FormWindowState.Minimized;
        }

        private void memoForm_cms_erase()
        {
            MemoForm mf = Variables.GetMemo(index);
            mf.BackgroundImage.Dispose();
            mf.Hide();
        }
    }
}
