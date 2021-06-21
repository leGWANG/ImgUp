
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
            this.memoForm_Cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.memoFormCmsItem_TopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.memoFormCmsItem_Minimize = new System.Windows.Forms.ToolStripMenuItem();
            this.memoFormCmsItem_SaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.memoFormCmsItem_Hide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.memoFormCmsItem_Erase = new System.Windows.Forms.ToolStripMenuItem();
            this.memoForm_Cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoForm_Cms
            // 
            this.memoForm_Cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memoFormCmsItem_TopMost,
            this.memoFormCmsItem_Minimize,
            this.memoFormCmsItem_SaveImage,
            this.memoFormCmsItem_Hide,
            this.toolStripSeparator1,
            this.memoFormCmsItem_Erase});
            this.memoForm_Cms.Name = "memoForm_cms";
            this.memoForm_Cms.Size = new System.Drawing.Size(137, 120);
            this.memoForm_Cms.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.memoForm_cms_ItemClicked);
            // 
            // memoFormCmsItem_TopMost
            // 
            this.memoFormCmsItem_TopMost.Name = "memoFormCmsItem_TopMost";
            this.memoFormCmsItem_TopMost.Size = new System.Drawing.Size(136, 22);
            this.memoFormCmsItem_TopMost.Text = "TopMost";
            // 
            // memoFormCmsItem_Minimize
            // 
            this.memoFormCmsItem_Minimize.Name = "memoFormCmsItem_Minimize";
            this.memoFormCmsItem_Minimize.Size = new System.Drawing.Size(136, 22);
            this.memoFormCmsItem_Minimize.Text = "Minimize";
            // 
            // memoFormCmsItem_SaveImage
            // 
            this.memoFormCmsItem_SaveImage.Name = "memoFormCmsItem_SaveImage";
            this.memoFormCmsItem_SaveImage.Size = new System.Drawing.Size(136, 22);
            this.memoFormCmsItem_SaveImage.Text = "Save Image";
            // 
            // memoFormCmsItem_Hide
            // 
            this.memoFormCmsItem_Hide.Name = "memoFormCmsItem_Hide";
            this.memoFormCmsItem_Hide.Size = new System.Drawing.Size(136, 22);
            this.memoFormCmsItem_Hide.Text = "Hide";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // memoFormCmsItem_Erase
            // 
            this.memoFormCmsItem_Erase.Name = "memoFormCmsItem_Erase";
            this.memoFormCmsItem_Erase.Size = new System.Drawing.Size(136, 22);
            this.memoFormCmsItem_Erase.Text = "Erase";
            // 
            // MemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.ContextMenuStrip = this.memoForm_Cms;
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
            this.memoForm_Cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip memoForm_Cms;
        private System.Windows.Forms.ToolStripMenuItem memoFormCmsItem_TopMost;
        private System.Windows.Forms.ToolStripMenuItem memoFormCmsItem_SaveImage;
        private System.Windows.Forms.ToolStripMenuItem memoFormCmsItem_Minimize;
        private System.Windows.Forms.ToolStripMenuItem memoFormCmsItem_Erase;
        private System.Windows.Forms.ToolStripMenuItem memoFormCmsItem_Hide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}