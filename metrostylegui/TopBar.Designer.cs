namespace metrostylegui
{
    partial class TopBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.maingroup = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // maingroup
            // 
            this.maingroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maingroup.HorizontalScrollbarBarColor = true;
            this.maingroup.HorizontalScrollbarHighlightOnWheel = false;
            this.maingroup.HorizontalScrollbarSize = 10;
            this.maingroup.Location = new System.Drawing.Point(0, 0);
            this.maingroup.Name = "maingroup";
            this.maingroup.Size = new System.Drawing.Size(600, 40);
            this.maingroup.TabIndex = 0;
            this.maingroup.VerticalScrollbarBarColor = true;
            this.maingroup.VerticalScrollbarHighlightOnWheel = false;
            this.maingroup.VerticalScrollbarSize = 10;
            // 
            // TopBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.maingroup);
            this.Name = "TopBar";
            this.Size = new System.Drawing.Size(600, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel maingroup;
    }
}
