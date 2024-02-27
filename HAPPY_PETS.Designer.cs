
namespace HAPPY_PETS
{
    partial class FrmHappyPets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHappyPets));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblNameTag = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_medical = new System.Windows.Forms.Button();
            this.btn_doc = new System.Windows.Forms.Button();
            this.btn_pet = new System.Windows.Forms.Button();
            this.LblTimeDate = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblNameTag
            // 
            this.lblNameTag.AutoSize = true;
            this.lblNameTag.BackColor = System.Drawing.Color.White;
            this.lblNameTag.Font = new System.Drawing.Font("Segoe UI Emoji", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(115)))), ((int)(((byte)(85)))));
            this.lblNameTag.Location = new System.Drawing.Point(324, 76);
            this.lblNameTag.Name = "lblNameTag";
            this.lblNameTag.Size = new System.Drawing.Size(220, 51);
            this.lblNameTag.TabIndex = 32;
            this.lblNameTag.Text = "Happy Pets";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(46, 156);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(232, 319);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // btn_medical
            // 
            this.btn_medical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(115)))), ((int)(((byte)(85)))));
            this.btn_medical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_medical.Font = new System.Drawing.Font("Segoe UI Emoji", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_medical.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_medical.Location = new System.Drawing.Point(488, 328);
            this.btn_medical.Name = "btn_medical";
            this.btn_medical.Size = new System.Drawing.Size(324, 58);
            this.btn_medical.TabIndex = 38;
            this.btn_medical.Text = "Create Bill";
            this.btn_medical.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_medical.UseVisualStyleBackColor = false;
            this.btn_medical.Click += new System.EventHandler(this.btn_medical_Click);
            // 
            // btn_doc
            // 
            this.btn_doc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(115)))), ((int)(((byte)(85)))));
            this.btn_doc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_doc.Font = new System.Drawing.Font("Segoe UI Emoji", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_doc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_doc.Location = new System.Drawing.Point(488, 156);
            this.btn_doc.Name = "btn_doc";
            this.btn_doc.Size = new System.Drawing.Size(324, 58);
            this.btn_doc.TabIndex = 37;
            this.btn_doc.Text = "Doctor Details ";
            this.btn_doc.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_doc.UseVisualStyleBackColor = false;
            this.btn_doc.Click += new System.EventHandler(this.btn_doc_Click);
            // 
            // btn_pet
            // 
            this.btn_pet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(115)))), ((int)(((byte)(85)))));
            this.btn_pet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pet.Font = new System.Drawing.Font("Segoe UI Emoji", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pet.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_pet.Location = new System.Drawing.Point(488, 242);
            this.btn_pet.Name = "btn_pet";
            this.btn_pet.Size = new System.Drawing.Size(324, 58);
            this.btn_pet.TabIndex = 36;
            this.btn_pet.Text = "Pet Details";
            this.btn_pet.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_pet.UseVisualStyleBackColor = false;
            this.btn_pet.Click += new System.EventHandler(this.btn_pet_Click);
            // 
            // LblTimeDate
            // 
            this.LblTimeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTimeDate.AutoSize = true;
            this.LblTimeDate.BackColor = System.Drawing.Color.White;
            this.LblTimeDate.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTimeDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(115)))), ((int)(((byte)(85)))));
            this.LblTimeDate.Location = new System.Drawing.Point(690, 500);
            this.LblTimeDate.Name = "LblTimeDate";
            this.LblTimeDate.Size = new System.Drawing.Size(55, 22);
            this.LblTimeDate.TabIndex = 39;
            this.LblTimeDate.Text = "label1";
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(115)))), ((int)(((byte)(85)))));
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(488, 414);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(324, 49);
            this.btnReport.TabIndex = 40;
            this.btnReport.Text = "View Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.report_open_click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(115)))), ((int)(((byte)(85)))));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(388, 51);
            this.label2.TabIndex = 32;
            this.label2.Text = "Veterinarian hospital";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(115)))), ((int)(((byte)(85)))));
            this.btnClose.Location = new System.Drawing.Point(895, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 35);
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.White;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(115)))), ((int)(((byte)(85)))));
            this.btnMinimize.Location = new System.Drawing.Point(861, 9);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 35);
            this.btnMinimize.TabIndex = 41;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // FrmHappyPets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 531);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.LblTimeDate);
            this.Controls.Add(this.btn_medical);
            this.Controls.Add(this.btn_doc);
            this.Controls.Add(this.btn_pet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNameTag);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHappyPets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HAPPY_PETS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblNameTag;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_medical;
        private System.Windows.Forms.Button btn_doc;
        private System.Windows.Forms.Button btn_pet;
        private System.Windows.Forms.Label LblTimeDate;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
    }
}