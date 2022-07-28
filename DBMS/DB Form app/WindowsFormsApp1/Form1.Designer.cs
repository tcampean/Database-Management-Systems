namespace WindowsFormsApp1
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
            this.GridDepartment = new System.Windows.Forms.DataGridView();
            this.GridDeveloper = new System.Windows.Forms.DataGridView();
            this.Update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDeveloper)).BeginInit();
            this.SuspendLayout();
            // 
            // GridDepartment
            // 
            this.GridDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDepartment.Location = new System.Drawing.Point(57, 30);
            this.GridDepartment.Name = "GridDepartment";
            this.GridDepartment.RowHeadersWidth = 51;
            this.GridDepartment.RowTemplate.Height = 24;
            this.GridDepartment.Size = new System.Drawing.Size(416, 185);
            this.GridDepartment.TabIndex = 1;
            this.GridDepartment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDepartment_CellContentClick);
            // 
            // GridDeveloper
            // 
            this.GridDeveloper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDeveloper.Location = new System.Drawing.Point(57, 255);
            this.GridDeveloper.Name = "GridDeveloper";
            this.GridDeveloper.RowHeadersWidth = 51;
            this.GridDeveloper.RowTemplate.Height = 24;
            this.GridDeveloper.Size = new System.Drawing.Size(696, 183);
            this.GridDeveloper.TabIndex = 2;
            this.GridDeveloper.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDeveloper_CellContentClick);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(614, 57);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 23);
            this.Update.TabIndex = 0;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 546);
            this.Controls.Add(this.GridDeveloper);
            this.Controls.Add(this.GridDepartment);
            this.Controls.Add(this.Update);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDeveloper)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView GridDepartment;
        private System.Windows.Forms.DataGridView GridDeveloper;
        private System.Windows.Forms.Button Update;
    }
}

