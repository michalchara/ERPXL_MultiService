namespace ERPXL_ServiceController
{
    partial class MainForm
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
            this.StartServiceButton = new System.Windows.Forms.Button();
            this.StopServiceButton = new System.Windows.Forms.Button();
            this.InstallServiceButton = new System.Windows.Forms.Button();
            this.UninstallServiceButton = new System.Windows.Forms.Button();
            this.ServiceStatusButton = new System.Windows.Forms.Button();
            this.WorkersListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartServiceButton
            // 
            this.StartServiceButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.StartServiceButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.StartServiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StartServiceButton.Location = new System.Drawing.Point(12, 12);
            this.StartServiceButton.Name = "StartServiceButton";
            this.StartServiceButton.Size = new System.Drawing.Size(140, 40);
            this.StartServiceButton.TabIndex = 0;
            this.StartServiceButton.Text = "Start usługi";
            this.StartServiceButton.UseVisualStyleBackColor = false;
            this.StartServiceButton.Click += new System.EventHandler(this.StartServiceButton_Click);
            // 
            // StopServiceButton
            // 
            this.StopServiceButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.StopServiceButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.StopServiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StopServiceButton.Location = new System.Drawing.Point(12, 58);
            this.StopServiceButton.Name = "StopServiceButton";
            this.StopServiceButton.Size = new System.Drawing.Size(140, 40);
            this.StopServiceButton.TabIndex = 1;
            this.StopServiceButton.Text = "Stop usługi";
            this.StopServiceButton.UseVisualStyleBackColor = false;
            this.StopServiceButton.Click += new System.EventHandler(this.StopServiceButton_Click);
            // 
            // InstallServiceButton
            // 
            this.InstallServiceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallServiceButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.InstallServiceButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.InstallServiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InstallServiceButton.Location = new System.Drawing.Point(295, 12);
            this.InstallServiceButton.Name = "InstallServiceButton";
            this.InstallServiceButton.Size = new System.Drawing.Size(140, 40);
            this.InstallServiceButton.TabIndex = 2;
            this.InstallServiceButton.Text = "Instaluj usługę";
            this.InstallServiceButton.UseVisualStyleBackColor = false;
            this.InstallServiceButton.Click += new System.EventHandler(this.InstallServiceButton_Click);
            // 
            // UninstallServiceButton
            // 
            this.UninstallServiceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UninstallServiceButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.UninstallServiceButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.UninstallServiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UninstallServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UninstallServiceButton.Location = new System.Drawing.Point(295, 58);
            this.UninstallServiceButton.Name = "UninstallServiceButton";
            this.UninstallServiceButton.Size = new System.Drawing.Size(140, 40);
            this.UninstallServiceButton.TabIndex = 3;
            this.UninstallServiceButton.Text = "Odinstaluj usługę";
            this.UninstallServiceButton.UseVisualStyleBackColor = false;
            this.UninstallServiceButton.Click += new System.EventHandler(this.UninstallServiceButton_Click);
            // 
            // ServiceStatusButton
            // 
            this.ServiceStatusButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServiceStatusButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ServiceStatusButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ServiceStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServiceStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ServiceStatusButton.Location = new System.Drawing.Point(158, 12);
            this.ServiceStatusButton.Name = "ServiceStatusButton";
            this.ServiceStatusButton.Size = new System.Drawing.Size(131, 86);
            this.ServiceStatusButton.TabIndex = 4;
            this.ServiceStatusButton.Text = "Status usługi";
            this.ServiceStatusButton.UseVisualStyleBackColor = false;
            this.ServiceStatusButton.Click += new System.EventHandler(this.ServiceStatusButton_Click);
            // 
            // WorkersListBox
            // 
            this.WorkersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkersListBox.BackColor = System.Drawing.Color.AliceBlue;
            this.WorkersListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WorkersListBox.FormattingEnabled = true;
            this.WorkersListBox.ItemHeight = 16;
            this.WorkersListBox.Location = new System.Drawing.Point(12, 132);
            this.WorkersListBox.Name = "WorkersListBox";
            this.WorkersListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.WorkersListBox.Size = new System.Drawing.Size(423, 148);
            this.WorkersListBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Zarejestrowane workery:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(450, 316);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WorkersListBox);
            this.Controls.Add(this.ServiceStatusButton);
            this.Controls.Add(this.UninstallServiceButton);
            this.Controls.Add(this.InstallServiceButton);
            this.Controls.Add(this.StopServiceButton);
            this.Controls.Add(this.StartServiceButton);
            this.Name = "MainForm";
            this.Text = "ERPXL_ServiceController";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartServiceButton;
        private System.Windows.Forms.Button StopServiceButton;
        private System.Windows.Forms.Button InstallServiceButton;
        private System.Windows.Forms.Button UninstallServiceButton;
        private System.Windows.Forms.Button ServiceStatusButton;
        private System.Windows.Forms.ListBox WorkersListBox;
        private System.Windows.Forms.Label label1;
    }
}

