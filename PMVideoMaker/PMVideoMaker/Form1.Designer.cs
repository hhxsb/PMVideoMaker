namespace PMVideoMaker
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
            this.Button_AddSource = new System.Windows.Forms.Button();
            this.ListView_SourceList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Button_AddSource
            // 
            this.Button_AddSource.Location = new System.Drawing.Point(12, 415);
            this.Button_AddSource.Name = "Button_AddSource";
            this.Button_AddSource.Size = new System.Drawing.Size(140, 23);
            this.Button_AddSource.TabIndex = 0;
            this.Button_AddSource.Text = "Add";
            this.Button_AddSource.UseVisualStyleBackColor = true;
            this.Button_AddSource.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListView_SourceList
            // 
            this.ListView_SourceList.Location = new System.Drawing.Point(12, 12);
            this.ListView_SourceList.Name = "ListView_SourceList";
            this.ListView_SourceList.Size = new System.Drawing.Size(140, 397);
            this.ListView_SourceList.TabIndex = 1;
            this.ListView_SourceList.UseCompatibleStateImageBehavior = false;
            this.ListView_SourceList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListView_SourceList);
            this.Controls.Add(this.Button_AddSource);
            this.Name = "Form1";
            this.Text = "PMVideoMaker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_AddSource;
        private System.Windows.Forms.ListView ListView_SourceList;
    }
}

