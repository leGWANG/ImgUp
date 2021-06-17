using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImgUp
{
    public partial class MemoForm : Form
    {
        const int RESIZE_HANDLE_SIZE = 10;
        const int WM_NCHITTEST = 0x0084;
        IntPtr HTBOTTOMRIGHT = (IntPtr)17;
        IntPtr HTCAPTION = (IntPtr)2;

        public MemoForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate. (WM_NCHITTEST 0x0084)
            if (m.Msg == WM_NCHITTEST) 
            {
                if ((int)m.Result == 0x01/*HTCLIENT*/)
                {
                    Point screenPoint = new Point(m.LParam.ToInt32());
                    Point clientPoint = this.PointToClient(screenPoint);

                    if (clientPoint.X >= Size.Width - RESIZE_HANDLE_SIZE && clientPoint.Y >= Size.Height - RESIZE_HANDLE_SIZE)
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
    }
}
