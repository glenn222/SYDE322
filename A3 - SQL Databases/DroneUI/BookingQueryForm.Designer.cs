namespace DroneUI
{
    partial class BookingQueryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.DateTakenPicker = new System.Windows.Forms.DateTimePicker();
            this.DateDuePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateLbl = new System.Windows.Forms.Label();
            this.EndDateLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DroneQueryTxtArea = new System.Windows.Forms.RichTextBox();
            this.DroneOutputLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DroneTypeTxtField = new System.Windows.Forms.TextBox();
            this.DroneManufacturerTxtField = new System.Windows.Forms.TextBox();
            this.DroneRangeTxtField = new System.Windows.Forms.TextBox();
            this.QueryDronesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exercise 2 - Booking Query";
            // 
            // DateTakenPicker
            // 
            this.DateTakenPicker.Checked = false;
            this.DateTakenPicker.Location = new System.Drawing.Point(179, 238);
            this.DateTakenPicker.Name = "DateTakenPicker";
            this.DateTakenPicker.Size = new System.Drawing.Size(434, 26);
            this.DateTakenPicker.TabIndex = 1;
            // 
            // DateDuePicker
            // 
            this.DateDuePicker.Checked = false;
            this.DateDuePicker.Location = new System.Drawing.Point(179, 274);
            this.DateDuePicker.Name = "DateDuePicker";
            this.DateDuePicker.Size = new System.Drawing.Size(434, 26);
            this.DateDuePicker.TabIndex = 2;
            // 
            // StartDateLbl
            // 
            this.StartDateLbl.AutoSize = true;
            this.StartDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDateLbl.Location = new System.Drawing.Point(56, 239);
            this.StartDateLbl.Name = "StartDateLbl";
            this.StartDateLbl.Size = new System.Drawing.Size(114, 25);
            this.StartDateLbl.TabIndex = 3;
            this.StartDateLbl.Text = "Date Taken";
            // 
            // EndDateLbl
            // 
            this.EndDateLbl.AutoSize = true;
            this.EndDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDateLbl.Location = new System.Drawing.Point(67, 275);
            this.EndDateLbl.Name = "EndDateLbl";
            this.EndDateLbl.Size = new System.Drawing.Size(94, 25);
            this.EndDateLbl.TabIndex = 4;
            this.EndDateLbl.Text = "Date Due";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(487, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Search for Drones Based on the Fields Provided Below";
            // 
            // DroneQueryTxtArea
            // 
            this.DroneQueryTxtArea.Location = new System.Drawing.Point(17, 414);
            this.DroneQueryTxtArea.Name = "DroneQueryTxtArea";
            this.DroneQueryTxtArea.Size = new System.Drawing.Size(615, 318);
            this.DroneQueryTxtArea.TabIndex = 8;
            this.DroneQueryTxtArea.Text = "";
            // 
            // DroneOutputLbl
            // 
            this.DroneOutputLbl.AutoSize = true;
            this.DroneOutputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DroneOutputLbl.Location = new System.Drawing.Point(26, 386);
            this.DroneOutputLbl.Name = "DroneOutputLbl";
            this.DroneOutputLbl.Size = new System.Drawing.Size(135, 25);
            this.DroneOutputLbl.TabIndex = 9;
            this.DroneOutputLbl.Text = "Query Results";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Drone Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Drone Manufacturer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(58, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Drone Range";
            // 
            // DroneTypeTxtField
            // 
            this.DroneTypeTxtField.Location = new System.Drawing.Point(226, 129);
            this.DroneTypeTxtField.Name = "DroneTypeTxtField";
            this.DroneTypeTxtField.Size = new System.Drawing.Size(387, 26);
            this.DroneTypeTxtField.TabIndex = 13;
            // 
            // DroneManufacturerTxtField
            // 
            this.DroneManufacturerTxtField.Location = new System.Drawing.Point(226, 168);
            this.DroneManufacturerTxtField.Name = "DroneManufacturerTxtField";
            this.DroneManufacturerTxtField.Size = new System.Drawing.Size(387, 26);
            this.DroneManufacturerTxtField.TabIndex = 14;
            // 
            // DroneRangeTxtField
            // 
            this.DroneRangeTxtField.Location = new System.Drawing.Point(226, 200);
            this.DroneRangeTxtField.Name = "DroneRangeTxtField";
            this.DroneRangeTxtField.Size = new System.Drawing.Size(387, 26);
            this.DroneRangeTxtField.TabIndex = 15;
            // 
            // QueryDronesBtn
            // 
            this.QueryDronesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueryDronesBtn.Location = new System.Drawing.Point(479, 357);
            this.QueryDronesBtn.Name = "QueryDronesBtn";
            this.QueryDronesBtn.Size = new System.Drawing.Size(134, 51);
            this.QueryDronesBtn.TabIndex = 16;
            this.QueryDronesBtn.Text = "Submit";
            this.QueryDronesBtn.UseVisualStyleBackColor = true;
            this.QueryDronesBtn.Click += new System.EventHandler(this.QueryDronesBtn_Click);
            // 
            // BookingQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 765);
            this.Controls.Add(this.QueryDronesBtn);
            this.Controls.Add(this.DroneRangeTxtField);
            this.Controls.Add(this.DroneManufacturerTxtField);
            this.Controls.Add(this.DroneTypeTxtField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DroneOutputLbl);
            this.Controls.Add(this.DroneQueryTxtArea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EndDateLbl);
            this.Controls.Add(this.StartDateLbl);
            this.Controls.Add(this.DateDuePicker);
            this.Controls.Add(this.DateTakenPicker);
            this.Controls.Add(this.label1);
            this.Name = "BookingQueryForm";
            this.Text = "BookingQueryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTakenPicker;
        private System.Windows.Forms.DateTimePicker DateDuePicker;
        private System.Windows.Forms.Label StartDateLbl;
        private System.Windows.Forms.Label EndDateLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox DroneQueryTxtArea;
        private System.Windows.Forms.Label DroneOutputLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DroneTypeTxtField;
        private System.Windows.Forms.TextBox DroneManufacturerTxtField;
        private System.Windows.Forms.TextBox DroneRangeTxtField;
        private System.Windows.Forms.Button QueryDronesBtn;
    }
}