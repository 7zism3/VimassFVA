using Microsoft.Win32;
using System;

namespace VimassFVA
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_thongBao = new System.Windows.Forms.Label();
            this.btn_dangKy = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_soVi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_xacThuc = new System.Windows.Forms.Button();
            this.btn_khoiDongCamera = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_thongBao);
            this.panel1.Controls.Add(this.btn_dangKy);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_soVi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_xacThuc);
            this.panel1.Controls.Add(this.btn_khoiDongCamera);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 802);
            this.panel1.TabIndex = 0;
            // 
            // lb_thongBao
            // 
            this.lb_thongBao.AutoSize = true;
            this.lb_thongBao.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_thongBao.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_thongBao.Location = new System.Drawing.Point(36, 127);
            this.lb_thongBao.Name = "lb_thongBao";
            this.lb_thongBao.Size = new System.Drawing.Size(124, 23);
            this.lb_thongBao.TabIndex = 16;
            this.lb_thongBao.Text = "thông báo nè";
            // 
            // btn_dangKy
            // 
            this.btn_dangKy.Location = new System.Drawing.Point(134, 737);
            this.btn_dangKy.Name = "btn_dangKy";
            this.btn_dangKy.Size = new System.Drawing.Size(122, 51);
            this.btn_dangKy.TabIndex = 13;
            this.btn_dangKy.Text = "Đăng kí khuôn mặt";
            this.btn_dangKy.UseVisualStyleBackColor = true;
            this.btn_dangKy.Click += new System.EventHandler(this.btn_dangKiKhuonMat_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(41, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(672, 518);
            this.panel2.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(15, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 484);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(502, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Bạn đang xác thực với tư cách số ví:";
            // 
            // txt_soVi
            // 
            this.txt_soVi.Location = new System.Drawing.Point(540, 51);
            this.txt_soVi.Name = "txt_soVi";
            this.txt_soVi.Size = new System.Drawing.Size(124, 20);
            this.txt_soVi.TabIndex = 8;
            this.txt_soVi.Text = "0357897375";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phần mền lưu trữ đặc điểm nhận dạng khuôn mặt\r\n và giọng nói trên máy tính cá nhâ" +
    "n của khách hàng.\r\nDùng nó để xác thực giao dịch\r\n";
            // 
            // btn_xacThuc
            // 
            this.btn_xacThuc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_xacThuc.Location = new System.Drawing.Point(476, 737);
            this.btn_xacThuc.Name = "btn_xacThuc";
            this.btn_xacThuc.Size = new System.Drawing.Size(122, 51);
            this.btn_xacThuc.TabIndex = 2;
            this.btn_xacThuc.Text = "Xác thực";
            this.btn_xacThuc.UseVisualStyleBackColor = true;
            this.btn_xacThuc.Click += new System.EventHandler(this.btn_xacThuc_Click);
            // 
            // btn_khoiDongCamera
            // 
            this.btn_khoiDongCamera.ForeColor = System.Drawing.Color.MediumBlue;
            this.btn_khoiDongCamera.Location = new System.Drawing.Point(591, 127);
            this.btn_khoiDongCamera.Name = "btn_khoiDongCamera";
            this.btn_khoiDongCamera.Size = new System.Drawing.Size(122, 51);
            this.btn_khoiDongCamera.TabIndex = 1;
            this.btn_khoiDongCamera.Text = "Khởi động Camera";
            this.btn_khoiDongCamera.UseVisualStyleBackColor = true;
            this.btn_khoiDongCamera.Click += new System.EventHandler(this.btn_khoiDongCamera_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vimass";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 861);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Vimass - Face Voice Authentication";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_xacThuc;
        private System.Windows.Forms.Button btn_khoiDongCamera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_soVi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_dangKy;
        private System.Windows.Forms.Label lb_thongBao;
    }
}

