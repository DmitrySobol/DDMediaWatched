
namespace DDMediaWatched
{
    partial class Form1
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
            this.listViewTitles = new System.Windows.Forms.ListView();
            this.labelTitles = new System.Windows.Forms.Label();
            this.textBoxTitleInfo = new System.Windows.Forms.TextBox();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.labelTitleInfo = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewTitles
            // 
            this.listViewTitles.Font = new System.Drawing.Font("Consolas", 8F);
            this.listViewTitles.HideSelection = false;
            this.listViewTitles.Location = new System.Drawing.Point(12, 25);
            this.listViewTitles.Name = "listViewTitles";
            this.listViewTitles.Size = new System.Drawing.Size(410, 673);
            this.listViewTitles.TabIndex = 0;
            this.listViewTitles.UseCompatibleStateImageBehavior = false;
            // 
            // labelTitles
            // 
            this.labelTitles.AutoSize = true;
            this.labelTitles.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelTitles.Location = new System.Drawing.Point(12, 9);
            this.labelTitles.Name = "labelTitles";
            this.labelTitles.Size = new System.Drawing.Size(49, 13);
            this.labelTitles.TabIndex = 1;
            this.labelTitles.Text = "Titles:";
            // 
            // textBoxTitleInfo
            // 
            this.textBoxTitleInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxTitleInfo.Location = new System.Drawing.Point(436, 25);
            this.textBoxTitleInfo.Multiline = true;
            this.textBoxTitleInfo.Name = "textBoxTitleInfo";
            this.textBoxTitleInfo.Size = new System.Drawing.Size(410, 673);
            this.textBoxTitleInfo.TabIndex = 2;
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxInfo.Location = new System.Drawing.Point(858, 25);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(410, 336);
            this.textBoxInfo.TabIndex = 3;
            // 
            // labelTitleInfo
            // 
            this.labelTitleInfo.AutoSize = true;
            this.labelTitleInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelTitleInfo.Location = new System.Drawing.Point(433, 9);
            this.labelTitleInfo.Name = "labelTitleInfo";
            this.labelTitleInfo.Size = new System.Drawing.Size(73, 13);
            this.labelTitleInfo.TabIndex = 4;
            this.labelTitleInfo.Text = "Title info:";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelInfo.Location = new System.Drawing.Point(855, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(37, 13);
            this.labelInfo.TabIndex = 5;
            this.labelInfo.Text = "Info:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 710);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelTitleInfo);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.textBoxTitleInfo);
            this.Controls.Add(this.labelTitles);
            this.Controls.Add(this.listViewTitles);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Dax_Donamo Media Watched";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTitles;
        private System.Windows.Forms.Label labelTitles;
        private System.Windows.Forms.TextBox textBoxTitleInfo;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Label labelTitleInfo;
        private System.Windows.Forms.Label labelInfo;
    }
}

