namespace DroneUI
{
    partial class ClientRegistrationForm
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
            this.Exercise_1_Text = new System.Windows.Forms.Label();
            this.ClientNameTxtField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClientAddressTxtField = new System.Windows.Forms.TextBox();
            this.RegisterClientBtn = new System.Windows.Forms.Button();
            this.ClientStatusLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Exercise_1_Text
            // 
            this.Exercise_1_Text.AutoSize = true;
            this.Exercise_1_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exercise_1_Text.Location = new System.Drawing.Point(12, 26);
            this.Exercise_1_Text.Name = "Exercise_1_Text";
            this.Exercise_1_Text.Size = new System.Drawing.Size(450, 37);
            this.Exercise_1_Text.TabIndex = 0;
            this.Exercise_1_Text.Text = "Exercise 1 - Client Registration";
            // 
            // ClientNameTxtField
            // 
            this.ClientNameTxtField.Location = new System.Drawing.Point(19, 134);
            this.ClientNameTxtField.Name = "ClientNameTxtField";
            this.ClientNameTxtField.Size = new System.Drawing.Size(263, 26);
            this.ClientNameTxtField.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Address";
            // 
            // ClientAddressTxtField
            // 
            this.ClientAddressTxtField.Location = new System.Drawing.Point(19, 228);
            this.ClientAddressTxtField.Name = "ClientAddressTxtField";
            this.ClientAddressTxtField.Size = new System.Drawing.Size(263, 26);
            this.ClientAddressTxtField.TabIndex = 3;
            // 
            // RegisterClientBtn
            // 
            this.RegisterClientBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterClientBtn.Location = new System.Drawing.Point(19, 276);
            this.RegisterClientBtn.Name = "RegisterClientBtn";
            this.RegisterClientBtn.Size = new System.Drawing.Size(265, 57);
            this.RegisterClientBtn.TabIndex = 5;
            this.RegisterClientBtn.Text = "Register Client";
            this.RegisterClientBtn.UseVisualStyleBackColor = true;
            this.RegisterClientBtn.Click += new System.EventHandler(this.RegisterClientBtn_Click);
            // 
            // ClientStatusLbl
            // 
            this.ClientStatusLbl.AutoSize = true;
            this.ClientStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientStatusLbl.Location = new System.Drawing.Point(19, 349);
            this.ClientStatusLbl.Name = "ClientStatusLbl";
            this.ClientStatusLbl.Size = new System.Drawing.Size(85, 29);
            this.ClientStatusLbl.TabIndex = 6;
            this.ClientStatusLbl.Text = "Status:";
            // 
            // ClientRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 399);
            this.Controls.Add(this.ClientStatusLbl);
            this.Controls.Add(this.RegisterClientBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ClientAddressTxtField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClientNameTxtField);
            this.Controls.Add(this.Exercise_1_Text);
            this.Name = "ClientRegistrationForm";
            this.Text = "ClientRegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Exercise_1_Text;
        private System.Windows.Forms.TextBox ClientNameTxtField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ClientAddressTxtField;
        private System.Windows.Forms.Button RegisterClientBtn;
        private System.Windows.Forms.Label ClientStatusLbl;
    }
}