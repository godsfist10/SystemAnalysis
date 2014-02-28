namespace Rss_Winform
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
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.URL = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(77, 27);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(660, 20);
            this.UrlTextBox.TabIndex = 0;
            // 
            // URL
            // 
            this.URL.AutoSize = true;
            this.URL.Location = new System.Drawing.Point(7, 30);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(64, 13);
            this.URL.TabIndex = 1;
            this.URL.Text = "URL to load";
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Location = new System.Drawing.Point(776, 25);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(117, 23);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "Load RSS Feed";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(10, 65);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ReadOnly = true;
            this.TextBox1.Size = new System.Drawing.Size(869, 429);
            this.TextBox1.TabIndex = 3;
            this.TextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 534);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.URL);
            this.Controls.Add(this.UrlTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Label URL;
        private System.Windows.Forms.Button goButton;
        public System.Windows.Forms.RichTextBox TextBox1;
    }
}

