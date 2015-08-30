namespace WindowsFormsApplicationWCF
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonGetWorkerByID = new System.Windows.Forms.Button();
            this.buttonF4 = new System.Windows.Forms.Button();
            this.ANSWER = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "GetAllWorkers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(398, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // buttonGetWorkerByID
            // 
            this.buttonGetWorkerByID.Location = new System.Drawing.Point(95, 39);
            this.buttonGetWorkerByID.Name = "buttonGetWorkerByID";
            this.buttonGetWorkerByID.Size = new System.Drawing.Size(109, 23);
            this.buttonGetWorkerByID.TabIndex = 3;
            this.buttonGetWorkerByID.Text = "GetWorkerByID";
            this.buttonGetWorkerByID.UseVisualStyleBackColor = true;
            this.buttonGetWorkerByID.Click += new System.EventHandler(this.buttonGetWorkerByID_Click);
            // 
            // buttonF4
            // 
            this.buttonF4.Location = new System.Drawing.Point(175, 10);
            this.buttonF4.Name = "buttonF4";
            this.buttonF4.Size = new System.Drawing.Size(75, 23);
            this.buttonF4.TabIndex = 4;
            this.buttonF4.Text = "F4(  X, 2 )";
            this.buttonF4.UseVisualStyleBackColor = true;
            this.buttonF4.Click += new System.EventHandler(this.buttonF4_Click);
            // 
            // ANSWER
            // 
            this.ANSWER.AutoSize = true;
            this.ANSWER.Location = new System.Drawing.Point(256, 19);
            this.ANSWER.Name = "ANSWER";
            this.ANSWER.Size = new System.Drawing.Size(55, 13);
            this.ANSWER.TabIndex = 5;
            this.ANSWER.Text = "ANSWER";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 232);
            this.Controls.Add(this.ANSWER);
            this.Controls.Add(this.buttonF4);
            this.Controls.Add(this.buttonGetWorkerByID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonGetWorkerByID;
        private System.Windows.Forms.Button buttonF4;
        private System.Windows.Forms.Label ANSWER;
    }
}

