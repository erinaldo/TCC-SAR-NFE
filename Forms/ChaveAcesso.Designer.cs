namespace Tingle
{
    partial class ChaveAcesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChaveAcesso));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtURI = new System.Windows.Forms.TextBox();
            this.pbOk = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Informe a chave de acesso!";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(132, 105);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(216, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // txtURI
            // 
            this.txtURI.BackColor = System.Drawing.SystemColors.Control;
            this.txtURI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtURI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtURI.Location = new System.Drawing.Point(134, 112);
            this.txtURI.Name = "txtURI";
            this.txtURI.Size = new System.Drawing.Size(200, 16);
            this.txtURI.TabIndex = 5;
            this.txtURI.Text = "\r\n";
            this.txtURI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtURI_KeyPress);
            // 
            // pbOk
            // 
            this.pbOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOk.Location = new System.Drawing.Point(194, 155);
            this.pbOk.Name = "pbOk";
            this.pbOk.Size = new System.Drawing.Size(78, 26);
            this.pbOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOk.TabIndex = 3;
            this.pbOk.TabStop = false;
            this.pbOk.Click += new System.EventHandler(this.btnWS_Click);
            this.pbOk.MouseLeave += new System.EventHandler(this.Ok_MouseLeave_1);
            this.pbOk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ok_MouseMove);
            // 
            // ChaveAcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 406);
            this.Controls.Add(this.txtURI);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pbOk);
            this.Controls.Add(this.label1);
            this.Name = "ChaveAcesso";
            this.Text = "ChaveAcesso";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtURI;
        private System.Windows.Forms.PictureBox pbOk;
    }
}