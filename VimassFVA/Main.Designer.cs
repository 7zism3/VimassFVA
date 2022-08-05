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
            this.btn_luuKM = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_soVi = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_luuDacTrungGiongNoi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_xacThuc = new System.Windows.Forms.Button();
            this.btn_khoiDongCamera = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_ketQuaDangKiKhuonMat = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_ketQuaDangKiKhuonMat);
            this.panel1.Controls.Add(this.btn_luuKM);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_soVi);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btn_luuDacTrungGiongNoi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_xacThuc);
            this.panel1.Controls.Add(this.btn_khoiDongCamera);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 707);
            this.panel1.TabIndex = 0;
            // 
            // btn_luuKM
            // 
            this.btn_luuKM.Location = new System.Drawing.Point(28, 264);
            this.btn_luuKM.Name = "btn_luuKM";
            this.btn_luuKM.Size = new System.Drawing.Size(122, 46);
            this.btn_luuKM.TabIndex = 13;
            this.btn_luuKM.Text = "Đăng kí khuôn mặt";
            this.btn_luuKM.UseVisualStyleBackColor = true;
            this.btn_luuKM.Click += new System.EventHandler(this.btn_dangKiKhuonMat_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(23, 551);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Không thành công";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(192, 166);
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
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 521);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kết quả xác thực: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số ví";
            // 
            // txt_soVi
            // 
            this.txt_soVi.Location = new System.Drawing.Point(28, 214);
            this.txt_soVi.Name = "txt_soVi";
            this.txt_soVi.Size = new System.Drawing.Size(139, 20);
            this.txt_soVi.TabIndex = 8;
            this.txt_soVi.Text = "0357897375";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VimassFVA.Properties.Resources.voice_recognition_icon_154433;
            this.pictureBox2.Location = new System.Drawing.Point(610, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 56);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // btn_luuDacTrungGiongNoi
            // 
            this.btn_luuDacTrungGiongNoi.ForeColor = System.Drawing.Color.MediumBlue;
            this.btn_luuDacTrungGiongNoi.Location = new System.Drawing.Point(742, 27);
            this.btn_luuDacTrungGiongNoi.Name = "btn_luuDacTrungGiongNoi";
            this.btn_luuDacTrungGiongNoi.Size = new System.Drawing.Size(122, 56);
            this.btn_luuDacTrungGiongNoi.TabIndex = 5;
            this.btn_luuDacTrungGiongNoi.Text = "Lưu đặc trưng giọng nói";
            this.btn_luuDacTrungGiongNoi.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(38, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(455, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "* Tuân thủ các quy định của nhà nước về quyền bảo mật thông tin. \r\nVimass tuyệt đ" +
    "ối không gửi bất kì dữ liệu khuôn mặt hay giọng nói nào của quý khách ra ngoài!";
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
            this.btn_xacThuc.Location = new System.Drawing.Point(27, 431);
            this.btn_xacThuc.Name = "btn_xacThuc";
            this.btn_xacThuc.Size = new System.Drawing.Size(122, 51);
            this.btn_xacThuc.TabIndex = 2;
            this.btn_xacThuc.Text = "Xác thực";
            this.btn_xacThuc.UseVisualStyleBackColor = true;
            // 
            // btn_khoiDongCamera
            // 
            this.btn_khoiDongCamera.ForeColor = System.Drawing.Color.MediumBlue;
            this.btn_khoiDongCamera.Location = new System.Drawing.Point(742, 97);
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
            // lb_ketQuaDangKiKhuonMat
            // 
            this.lb_ketQuaDangKiKhuonMat.AutoSize = true;
            this.lb_ketQuaDangKiKhuonMat.Location = new System.Drawing.Point(28, 329);
            this.lb_ketQuaDangKiKhuonMat.Name = "lb_ketQuaDangKiKhuonMat";
            this.lb_ketQuaDangKiKhuonMat.Size = new System.Drawing.Size(0, 13);
            this.lb_ketQuaDangKiKhuonMat.TabIndex = 14;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 727);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Vimass - Face Voice Authentication";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_xacThuc;
        private System.Windows.Forms.Button btn_khoiDongCamera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_luuDacTrungGiongNoi;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_soVi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_luuKM;
        private System.Windows.Forms.Label lb_ketQuaDangKiKhuonMat;
    }
}

