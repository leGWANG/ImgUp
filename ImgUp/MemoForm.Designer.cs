
namespace ImgUp
{
    partial class MemoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoForm));
            this.memoForm_cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.memoFormCmsItem_topmost = new System.Windows.Forms.ToolStripMenuItem();
            this.memoFormCmsItem_minimize = new System.Windows.Forms.ToolStripMenuItem();
            this.memoFormCmsItem_saveimage = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoForm_cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoForm_cms
            // 
            this.memoForm_cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memoFormCmsItem_topmost,
            this.memoFormCmsItem_minimize,
            this.memoFormCmsItem_saveimage,
            this.deleteToolStripMenuItem});
            this.memoForm_cms.Name = "memoForm_cms";
            this.memoForm_cms.Size = new System.Drawing.Size(137, 92);
            this.memoForm_cms.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.memoForm_cms_ItemClicked);
            // 
            // memoFormCmsItem_topmost
            // 
            this.memoFormCmsItem_topmost.Name = "memoFormCmsItem_topmost";
            this.memoFormCmsItem_topmost.Size = new System.Drawing.Size(136, 22);
            this.memoFormCmsItem_topmost.Text = "TopMost";
            // 
            // memoFormCmsItem_minimize
            // 
            this.memoFormCmsItem_minimize.Name = "memoFormCmsItem_minimize";
            this.memoFormCmsItem_minimize.Size = new System.Drawing.Size(136, 22);
            this.memoFormCmsItem_minimize.Text = "Minimize";
            // 
            // memoFormCmsItem_saveimage
            // 
            this.memoFormCmsItem_saveimage.Name = "memoFormCmsItem_saveimage";
            this.memoFormCmsItem_saveimage.Size = new System.Drawing.Size(136, 22);
            this.memoFormCmsItem_saveimage.Text = "Save Image";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.deleteToolStripMenuItem.Text = "Erase";
            // 
            // MemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.ContextMenuStrip = this.memoForm_cms;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "MemoForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemoForm_FormClosing);
            this.memoForm_cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip memoForm_cms;
        private System.Windows.Forms.ToolStripMenuItem memoFormCmsItem_topmost;
        private System.Windows.Forms.ToolStripMenuItem memoFormCmsItem_saveimage;
        private System.Windows.Forms.ToolStripMenuItem memoFormCmsItem_minimize;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}