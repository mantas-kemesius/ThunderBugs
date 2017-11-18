namespace Foosball
{
    partial class frmMain
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
            this.tlpOuter = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tlbInner = new System.Windows.Forms.TableLayoutPanel();
            this.btnPauseOrResume = new System.Windows.Forms.Button();
            this.txtXYRadius = new System.Windows.Forms.TextBox();
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.ibThresh = new Emgu.CV.UI.ImageBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tlpOuter.SuspendLayout();
            this.tlbInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibThresh)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpOuter
            // 
            this.tlpOuter.ColumnCount = 2;
            this.tlpOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOuter.Controls.Add(this.label4, 1, 3);
            this.tlpOuter.Controls.Add(this.label1, 0, 2);
            this.tlpOuter.Controls.Add(this.tlbInner, 0, 1);
            this.tlpOuter.Controls.Add(this.ibOriginal, 0, 0);
            this.tlpOuter.Controls.Add(this.ibThresh, 1, 0);
            this.tlpOuter.Controls.Add(this.label2, 1, 2);
            this.tlpOuter.Controls.Add(this.label3, 0, 3);
            this.tlpOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOuter.Location = new System.Drawing.Point(0, 0);
            this.tlpOuter.Name = "tlpOuter";
            this.tlpOuter.RowCount = 4;
            this.tlpOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tlpOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.83333F));
            this.tlpOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tlpOuter.Size = new System.Drawing.Size(1354, 525);
            this.tlpOuter.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(680, 481);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(671, 42);
            this.label4.TabIndex = 5;
            this.label4.Text = "0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(671, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Red Team";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlbInner
            // 
            this.tlbInner.ColumnCount = 2;
            this.tlpOuter.SetColumnSpan(this.tlbInner, 2);
            this.tlbInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlbInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlbInner.Controls.Add(this.btnPauseOrResume, 0, 0);
            this.tlbInner.Controls.Add(this.txtXYRadius, 1, 0);
            this.tlbInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlbInner.Location = new System.Drawing.Point(3, 331);
            this.tlbInner.Name = "tlbInner";
            this.tlbInner.RowCount = 1;
            this.tlbInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlbInner.Size = new System.Drawing.Size(1348, 103);
            this.tlbInner.TabIndex = 0;
            this.tlbInner.Paint += new System.Windows.Forms.PaintEventHandler(this.tlbInner_Paint);
            // 
            // btnPauseOrResume
            // 
            this.btnPauseOrResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPauseOrResume.AutoSize = true;
            this.btnPauseOrResume.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPauseOrResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseOrResume.Location = new System.Drawing.Point(3, 36);
            this.btnPauseOrResume.Name = "btnPauseOrResume";
            this.btnPauseOrResume.Size = new System.Drawing.Size(64, 30);
            this.btnPauseOrResume.TabIndex = 0;
            this.btnPauseOrResume.Text = "Pause";
            this.btnPauseOrResume.UseVisualStyleBackColor = true;
            this.btnPauseOrResume.Click += new System.EventHandler(this.btnPauseOrResume_Click);
            // 
            // txtXYRadius
            // 
            this.txtXYRadius.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXYRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXYRadius.Location = new System.Drawing.Point(73, 3);
            this.txtXYRadius.Multiline = true;
            this.txtXYRadius.Name = "txtXYRadius";
            this.txtXYRadius.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXYRadius.Size = new System.Drawing.Size(1272, 97);
            this.txtXYRadius.TabIndex = 1;
            this.txtXYRadius.WordWrap = false;
            // 
            // ibOriginal
            // 
            this.ibOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibOriginal.Enabled = false;
            this.ibOriginal.Location = new System.Drawing.Point(3, 3);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(671, 322);
            this.ibOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ibOriginal.TabIndex = 2;
            this.ibOriginal.TabStop = false;
            // 
            // ibThresh
            // 
            this.ibThresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibThresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibThresh.Enabled = false;
            this.ibThresh.Location = new System.Drawing.Point(680, 3);
            this.ibThresh.Name = "ibThresh";
            this.ibThresh.Size = new System.Drawing.Size(671, 322);
            this.ibThresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ibThresh.TabIndex = 2;
            this.ibThresh.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(680, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(671, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Blue Team";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 481);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(671, 42);
            this.label3.TabIndex = 4;
            this.label3.Text = "0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 525);
            this.Controls.Add(this.tlpOuter);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tlpOuter.ResumeLayout(false);
            this.tlpOuter.PerformLayout();
            this.tlbInner.ResumeLayout(false);
            this.tlbInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibThresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpOuter;
        private System.Windows.Forms.TableLayoutPanel tlbInner;
        private System.Windows.Forms.Button btnPauseOrResume;
        private Emgu.CV.UI.ImageBox ibOriginal;
        private Emgu.CV.UI.ImageBox ibThresh;
        private System.Windows.Forms.TextBox txtXYRadius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

