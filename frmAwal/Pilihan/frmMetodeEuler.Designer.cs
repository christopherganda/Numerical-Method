namespace frmAwal.Pilihan
{
    partial class frmMetodeEuler
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
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFungsi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNilaiEksak = new System.Windows.Forms.TextBox();
            this.txtX0 = new System.Windows.Forms.TextBox();
            this.txtY0 = new System.Windows.Forms.TextBox();
            this.txtXDicari = new System.Windows.Forms.TextBox();
            this.txtSegment = new System.Windows.Forms.TextBox();
            this.dgvHasil = new System.Windows.Forms.DataGridView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHasil)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(335, 204);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(225, 23);
            this.btnBack.TabIndex = 32;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Fungsi";
            // 
            // txtFungsi
            // 
            this.txtFungsi.Location = new System.Drawing.Point(105, 22);
            this.txtFungsi.Name = "txtFungsi";
            this.txtFungsi.Size = new System.Drawing.Size(455, 20);
            this.txtFungsi.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Nilai eksak";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "x0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "y0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "x yang di cari";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Segment";
            // 
            // txtNilaiEksak
            // 
            this.txtNilaiEksak.Location = new System.Drawing.Point(105, 53);
            this.txtNilaiEksak.Name = "txtNilaiEksak";
            this.txtNilaiEksak.Size = new System.Drawing.Size(455, 20);
            this.txtNilaiEksak.TabIndex = 40;
            // 
            // txtX0
            // 
            this.txtX0.Location = new System.Drawing.Point(105, 82);
            this.txtX0.Name = "txtX0";
            this.txtX0.Size = new System.Drawing.Size(455, 20);
            this.txtX0.TabIndex = 41;
            // 
            // txtY0
            // 
            this.txtY0.Location = new System.Drawing.Point(105, 113);
            this.txtY0.Name = "txtY0";
            this.txtY0.Size = new System.Drawing.Size(455, 20);
            this.txtY0.TabIndex = 42;
            // 
            // txtXDicari
            // 
            this.txtXDicari.Location = new System.Drawing.Point(105, 139);
            this.txtXDicari.Name = "txtXDicari";
            this.txtXDicari.Size = new System.Drawing.Size(455, 20);
            this.txtXDicari.TabIndex = 43;
            // 
            // txtSegment
            // 
            this.txtSegment.Location = new System.Drawing.Point(105, 169);
            this.txtSegment.Name = "txtSegment";
            this.txtSegment.Size = new System.Drawing.Size(455, 20);
            this.txtSegment.TabIndex = 44;
            // 
            // dgvHasil
            // 
            this.dgvHasil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHasil.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvHasil.Location = new System.Drawing.Point(18, 233);
            this.dgvHasil.Name = "dgvHasil";
            this.dgvHasil.Size = new System.Drawing.Size(542, 448);
            this.dgvHasil.TabIndex = 45;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(105, 204);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(212, 23);
            this.btnSubmit.TabIndex = 46;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Iterasi";
            this.Column1.Name = "Column1";
            this.Column1.Width = 99;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "x";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "y";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 697);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // frmMetodeEuler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 730);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.dgvHasil);
            this.Controls.Add(this.txtSegment);
            this.Controls.Add(this.txtXDicari);
            this.Controls.Add(this.txtY0);
            this.Controls.Add(this.txtX0);
            this.Controls.Add(this.txtNilaiEksak);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFungsi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Name = "frmMetodeEuler";
            this.Text = "frmMetodeEuler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMetodeEuler_FormClosed);
            this.Load += new System.EventHandler(this.frmMetodeEuler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHasil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFungsi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNilaiEksak;
        private System.Windows.Forms.TextBox txtX0;
        private System.Windows.Forms.TextBox txtY0;
        private System.Windows.Forms.TextBox txtXDicari;
        private System.Windows.Forms.TextBox txtSegment;
        private System.Windows.Forms.DataGridView dgvHasil;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label7;
    }
}