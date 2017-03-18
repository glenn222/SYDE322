namespace DroneUI
{
    partial class BookingRegistrationForm
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
            this.StartDateLbl = new System.Windows.Forms.Label();
            this.EndDateLbl = new System.Windows.Forms.Label();
            this.DroneIdLbl = new System.Windows.Forms.Label();
            this.ClientIdLbl = new System.Windows.Forms.Label();
            this.DroneIdTxtField = new System.Windows.Forms.TextBox();
            this.ClientIdTxtField = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RegisterBookingBtn = new System.Windows.Forms.Button();
            this.DroneOutputLbl = new System.Windows.Forms.Label();
            this.ResultBookingTxtArea = new System.Windows.Forms.RichTextBox();
            this.DateDuePicker = new System.Windows.Forms.DateTimePicker();
            this.DateTakenPicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // StartDateLbl
            // 
            this.StartDateLbl.AutoSize = true;
            this.StartDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDateLbl.Location = new System.Drawing.Point(37, 187);
            this.StartDateLbl.Name = "StartDateLbl";
            this.StartDateLbl.Size = new System.Drawing.Size(142, 32);
            this.StartDateLbl.TabIndex = 2;
            this.StartDateLbl.Text = "Start Date";
            // 
            // EndDateLbl
            // 
            this.EndDateLbl.AutoSize = true;
            this.EndDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDateLbl.Location = new System.Drawing.Point(37, 241);
            this.EndDateLbl.Name = "EndDateLbl";
            this.EndDateLbl.Size = new System.Drawing.Size(133, 32);
            this.EndDateLbl.TabIndex = 3;
            this.EndDateLbl.Text = "End Date";
            // 
            // DroneIdLbl
            // 
            this.DroneIdLbl.AutoSize = true;
            this.DroneIdLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DroneIdLbl.Location = new System.Drawing.Point(37, 134);
            this.DroneIdLbl.Name = "DroneIdLbl";
            this.DroneIdLbl.Size = new System.Drawing.Size(115, 32);
            this.DroneIdLbl.TabIndex = 7;
            this.DroneIdLbl.Text = "DroneId";
            // 
            // ClientIdLbl
            // 
            this.ClientIdLbl.AutoSize = true;
            this.ClientIdLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientIdLbl.Location = new System.Drawing.Point(40, 83);
            this.ClientIdLbl.Name = "ClientIdLbl";
            this.ClientIdLbl.Size = new System.Drawing.Size(112, 32);
            this.ClientIdLbl.TabIndex = 6;
            this.ClientIdLbl.Text = "ClientId";
            // 
            // DroneIdTxtField
            // 
            this.DroneIdTxtField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DroneIdTxtField.Location = new System.Drawing.Point(232, 134);
            this.DroneIdTxtField.Name = "DroneIdTxtField";
            this.DroneIdTxtField.Size = new System.Drawing.Size(216, 35);
            this.DroneIdTxtField.TabIndex = 5;
            // 
            // ClientIdTxtField
            // 
            this.ClientIdTxtField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientIdTxtField.Location = new System.Drawing.Point(232, 80);
            this.ClientIdTxtField.Name = "ClientIdTxtField";
            this.ClientIdTxtField.Size = new System.Drawing.Size(216, 35);
            this.ClientIdTxtField.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(312, 37);
            this.label7.TabIndex = 12;
            this.label7.Text = "Booking Registration";
            // 
            // RegisterBookingBtn
            // 
            this.RegisterBookingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterBookingBtn.Location = new System.Drawing.Point(280, 296);
            this.RegisterBookingBtn.Name = "RegisterBookingBtn";
            this.RegisterBookingBtn.Size = new System.Drawing.Size(159, 51);
            this.RegisterBookingBtn.TabIndex = 19;
            this.RegisterBookingBtn.Text = "Register";
            this.RegisterBookingBtn.UseVisualStyleBackColor = true;
            this.RegisterBookingBtn.Click += new System.EventHandler(this.RegisterBookingBtn_Click);
            // 
            // DroneOutputLbl
            // 
            this.DroneOutputLbl.AutoSize = true;
            this.DroneOutputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DroneOutputLbl.Location = new System.Drawing.Point(43, 327);
            this.DroneOutputLbl.Name = "DroneOutputLbl";
            this.DroneOutputLbl.Size = new System.Drawing.Size(152, 25);
            this.DroneOutputLbl.TabIndex = 18;
            this.DroneOutputLbl.Text = "Booking Results";
            // 
            // ResultBookingTxtArea
            // 
            this.ResultBookingTxtArea.Location = new System.Drawing.Point(43, 361);
            this.ResultBookingTxtArea.Name = "ResultBookingTxtArea";
            this.ResultBookingTxtArea.Size = new System.Drawing.Size(396, 318);
            this.ResultBookingTxtArea.TabIndex = 17;
            this.ResultBookingTxtArea.Text = "";
            // 
            // DateDuePicker
            // 
            this.DateDuePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateDuePicker.Checked = false;
            this.DateDuePicker.Location = new System.Drawing.Point(199, 246);
            this.DateDuePicker.Name = "DateDuePicker";
            this.DateDuePicker.Size = new System.Drawing.Size(288, 26);
            this.DateDuePicker.TabIndex = 21;
            // 
            // DateTakenPicker
            // 
            this.DateTakenPicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTakenPicker.Checked = false;
            this.DateTakenPicker.Location = new System.Drawing.Point(199, 193);
            this.DateTakenPicker.Name = "DateTakenPicker";
            this.DateTakenPicker.Size = new System.Drawing.Size(288, 26);
            this.DateTakenPicker.TabIndex = 20;
            // 
            // BookingRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 716);
            this.Controls.Add(this.DateDuePicker);
            this.Controls.Add(this.DateTakenPicker);
            this.Controls.Add(this.RegisterBookingBtn);
            this.Controls.Add(this.DroneOutputLbl);
            this.Controls.Add(this.ResultBookingTxtArea);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DroneIdLbl);
            this.Controls.Add(this.ClientIdLbl);
            this.Controls.Add(this.DroneIdTxtField);
            this.Controls.Add(this.ClientIdTxtField);
            this.Controls.Add(this.EndDateLbl);
            this.Controls.Add(this.StartDateLbl);
            this.Name = "BookingRegistrationForm";
            this.Text = "BookingRegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label StartDateLbl;
        private System.Windows.Forms.Label EndDateLbl;
        private System.Windows.Forms.Label DroneIdLbl;
        private System.Windows.Forms.Label ClientIdLbl;
        private System.Windows.Forms.TextBox DroneIdTxtField;
        private System.Windows.Forms.TextBox ClientIdTxtField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button RegisterBookingBtn;
        private System.Windows.Forms.Label DroneOutputLbl;
        private System.Windows.Forms.RichTextBox ResultBookingTxtArea;
        private System.Windows.Forms.DateTimePicker DateDuePicker;
        private System.Windows.Forms.DateTimePicker DateTakenPicker;
    }
}