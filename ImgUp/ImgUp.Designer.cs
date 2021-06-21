
namespace ImgUp
{
    partial class ImgUp
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImgUp));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon_cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mainFormCmsItem_SaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainFormCmsItem_HotKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFormCmsItem_HkMemo = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFormCmsItem_HkATF = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFormCmsItem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ImgUp_pb = new System.Windows.Forms.PictureBox();
            this.ImgUp_lb = new System.Windows.Forms.Label();
            this.ImgUp_lnklb = new System.Windows.Forms.LinkLabel();
            this.notifyIcon_cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgUp_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIcon_cms;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyIcon_cms
            // 
            this.notifyIcon_cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainFormCmsItem_SaveAll,
            this.mainFormCmsItem_HotKeys,
            this.toolStripSeparator1,
            this.mainFormCmsItem_exit});
            this.notifyIcon_cms.Name = "notifyIcon_cms";
            this.notifyIcon_cms.Size = new System.Drawing.Size(119, 76);
            this.notifyIcon_cms.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.notifyIcon_cms_ItemClicked);
            // 
            // mainFormCmsItem_SaveAll
            // 
            this.mainFormCmsItem_SaveAll.Name = "mainFormCmsItem_SaveAll";
            this.mainFormCmsItem_SaveAll.Size = new System.Drawing.Size(180, 22);
            this.mainFormCmsItem_SaveAll.Text = "Save All";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // mainFormCmsItem_HotKeys
            // 
            this.mainFormCmsItem_HotKeys.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainFormCmsItem_HkMemo,
            this.mainFormCmsItem_HkATF});
            this.mainFormCmsItem_HotKeys.Name = "mainFormCmsItem_HotKeys";
            this.mainFormCmsItem_HotKeys.Size = new System.Drawing.Size(180, 22);
            this.mainFormCmsItem_HotKeys.Text = "HotKeys";
            // 
            // mainFormCmsItem_HkMemo
            // 
            this.mainFormCmsItem_HkMemo.Name = "mainFormCmsItem_HkMemo";
            this.mainFormCmsItem_HkMemo.Size = new System.Drawing.Size(209, 22);
            this.mainFormCmsItem_HkMemo.Text = "Alt+Shift+0~9 : Memo";
            // 
            // mainFormCmsItem_HkATF
            // 
            this.mainFormCmsItem_HkATF.Name = "mainFormCmsItem_HkATF";
            this.mainFormCmsItem_HkATF.Size = new System.Drawing.Size(209, 22);
            this.mainFormCmsItem_HkATF.Text = "Alt+Shfit+S : All to Front";
            // 
            // mainFormCmsItem_exit
            // 
            this.mainFormCmsItem_exit.Name = "mainFormCmsItem_exit";
            this.mainFormCmsItem_exit.Size = new System.Drawing.Size(180, 22);
            this.mainFormCmsItem_exit.Text = "Exit";
            // 
            // ImgUp_pb
            // 
            this.ImgUp_pb.BackgroundImage = global::ImgUp.Properties.Resources.ImgUp_Icon;
            this.ImgUp_pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImgUp_pb.Location = new System.Drawing.Point(23, 10);
            this.ImgUp_pb.Name = "ImgUp_pb";
            this.ImgUp_pb.Size = new System.Drawing.Size(190, 190);
            this.ImgUp_pb.TabIndex = 0;
            this.ImgUp_pb.TabStop = false;
            // 
            // ImgUp_lb
            // 
            this.ImgUp_lb.AutoSize = true;
            this.ImgUp_lb.Font = new System.Drawing.Font("돋움", 12F);
            this.ImgUp_lb.Location = new System.Drawing.Point(69, 23);
            this.ImgUp_lb.Name = "ImgUp_lb";
            this.ImgUp_lb.Size = new System.Drawing.Size(99, 16);
            this.ImgUp_lb.TabIndex = 0;
            this.ImgUp_lb.Text = "ImgUp (v1.0)";
            this.ImgUp_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImgUp_lnklb
            // 
            this.ImgUp_lnklb.AutoSize = true;
            this.ImgUp_lnklb.Font = new System.Drawing.Font("돋움", 10F);
            this.ImgUp_lnklb.Location = new System.Drawing.Point(95, 172);
            this.ImgUp_lnklb.Name = "ImgUp_lnklb";
            this.ImgUp_lnklb.Size = new System.Drawing.Size(49, 14);
            this.ImgUp_lnklb.TabIndex = 1;
            this.ImgUp_lnklb.TabStop = true;
            this.ImgUp_lnklb.Text = "Github";
            this.ImgUp_lnklb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ImgUp_lnklb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ImgUp_lnklb_LinkClicked);
            // 
            // ImgUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(234, 211);
            this.Controls.Add(this.ImgUp_lnklb);
            this.Controls.Add(this.ImgUp_lb);
            this.Controls.Add(this.ImgUp_pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImgUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ImgUp_Load);
            this.Resize += new System.EventHandler(this.ImgUp_Resize);
            this.notifyIcon_cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgUp_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.PictureBox ImgUp_pb;
        private System.Windows.Forms.Label ImgUp_lb;
        private System.Windows.Forms.LinkLabel ImgUp_lnklb;
        private System.Windows.Forms.ContextMenuStrip notifyIcon_cms;
        private System.Windows.Forms.ToolStripMenuItem mainFormCmsItem_SaveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mainFormCmsItem_HotKeys;
        private System.Windows.Forms.ToolStripMenuItem mainFormCmsItem_exit;
        private System.Windows.Forms.ToolStripMenuItem mainFormCmsItem_HkMemo;
        private System.Windows.Forms.ToolStripMenuItem mainFormCmsItem_HkATF;
    }
}

