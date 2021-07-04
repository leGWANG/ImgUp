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
        // Location
        private int locationX = Variables.NULL_LOCATION;
        private int locationY = Variables.NULL_LOCATION;
        // Opacity
        private const double opacityChange = 0.1;
        private const double opacityMin = 0.1;
        private const double opacityMax = 1.0;
        // Save Lock
        private readonly object saveSyncLock = new object();
        // RESIZE_HANDLE_SIZE
        private const int RESIZE_HANDLE_SIZE = 10;

        // When the cursor moves, when a mouse button is pressed or released, or in response to a call to a function such as WindowFromPoint.
        private const int WM_NCHITTEST = 0x0084;
        // When the user presses the right mouse button while the cursor is within the nonclient area of a window.
        private const int WM_NCRBUTTONDOWN = 0x00A4;
        // Posted to the window with the keyboard focus when a nonsystem key is pressed.
        private const int WM_KEYDOWN = 0x0100;

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
            this.Text = index.ToString();
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
            lock (saveSyncLock)
            {
                string imageName = "\\memo_" + this.index.ToString() + ".png";
                if(this.BackgroundImage != null) this.BackgroundImage.Save(Application.StartupPath + imageName, ImageFormat.Png);

                locationX = this.Location.X;
                locationY = this.Location.Y;
                Variables.SetLocation(this.index, new Point(locationX, locationY));
            }
        }

        public void setLocation(Point point)
        {
            this.locationX = point.X;
            this.locationY = point.Y;
        }

        public void setMemo(Image image)
        {
            lock (saveSyncLock)
            {
                if (this.BackgroundImage != null) this.BackgroundImage.Dispose();

                this.BackgroundImage = image;
                this.Width = image.Width;
                this.Height = image.Height;
            }
        }

        public void setOpacity(double change) {
            double value = this.Opacity + change;

            if(value < opacityMin) value = opacityMin;
            else if (value > opacityMax) value = opacityMax;
            this.Opacity = value;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            if(m.Msg == WM_NCRBUTTONDOWN)
            {
                if (!memoForm_Cms.Visible) memoForm_Cms.Show(Cursor.Position);
            }

            if(m.Msg == WM_KEYDOWN)
            {
                if ((Keys)m.WParam == Keys.Q)
                {
                    setOpacity(-opacityChange);
                }
                else if ((Keys)m.WParam == Keys.W)
                {
                    setOpacity(opacityChange);
                }
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
            lock(saveSyncLock) {
                this.BackgroundImage.Dispose();
                this.Dispose();
            }
        }

        private void MemoForm_Move(object sender, EventArgs e)
        {
            locationX = this.Location.X;
            locationY = this.Location.Y;
            Variables.SetLocation(this.index, new Point(locationX, locationY));
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

                case "Copy":
                    memoForm_Cms_Copy();
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

        private void memoForm_Cms_Minimize()
        {
            // Hide ContextMenuStrip
            if(memoForm_Cms.Visible) memoForm_Cms.Close();
            this.WindowState = FormWindowState.Minimized;
        }

        private void memoForm_Cms_SaveImage()
        {
            // Save only image. It dosen't save location.
            Thread imgSaveThread = new Thread(new ThreadStart(imageSave));
            imgSaveThread.Start();
        }

        private void memoForm_Cms_Copy()
        {
            // Copy to Clipboard.
            Clipboard.SetImage(this.BackgroundImage);
        }

        private void memoForm_Cms_Hide()
        {
            this.isHide = true;
            this.Visible = false;            
        }

        private void memoForm_Cms_Erase()
        {
            // Wait if image saving thread works.
            lock (saveSyncLock)
            {
                this.BackgroundImage.Dispose();
                this.Dispose();
            }       
        }
    }
}
