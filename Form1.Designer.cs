namespace Doan
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

		private void InitializeComponent()
		{
			this.lblBodoctailieuHTML = new System.Windows.Forms.Label();
			this.lblFileHTML = new System.Windows.Forms.Label();
			this.lblDanhSachFile = new System.Windows.Forms.Label();
			this.lblThaotacFile = new System.Windows.Forms.Label();
			this.pnThaotac = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnHienThi = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.lvFile1 = new System.Windows.Forms.ListView();
			this.txtNoiDung = new System.Windows.Forms.TextBox();
			this.lblHienthinoidung = new System.Windows.Forms.Label();
			this.rtbXulyFile = new System.Windows.Forms.RichTextBox();
			this.pnThaotac.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblBodoctailieuHTML
			// 
			this.lblBodoctailieuHTML.AutoSize = true;
			this.lblBodoctailieuHTML.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBodoctailieuHTML.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
			this.lblBodoctailieuHTML.Location = new System.Drawing.Point(220, 9);
			this.lblBodoctailieuHTML.Name = "lblBodoctailieuHTML";
			this.lblBodoctailieuHTML.Size = new System.Drawing.Size(564, 38);
			this.lblBodoctailieuHTML.TabIndex = 5;
			this.lblBodoctailieuHTML.Text = "BỘ ĐỌC NỘI DUNG TÀI LIỆU HTML";
			// 
			// lblFileHTML
			// 
			this.lblFileHTML.AutoSize = true;
			this.lblFileHTML.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			this.lblFileHTML.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
			this.lblFileHTML.Location = new System.Drawing.Point(30, 60);
			this.lblFileHTML.Name = "lblFileHTML";
			this.lblFileHTML.Size = new System.Drawing.Size(94, 19);
			this.lblFileHTML.TabIndex = 6;
			this.lblFileHTML.Text = "FILE HTML";
			// 
			// lblDanhSachFile
			// 
			this.lblDanhSachFile.AutoSize = true;
			this.lblDanhSachFile.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			this.lblDanhSachFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(178)))), ((int)(((byte)(170)))));
			this.lblDanhSachFile.Location = new System.Drawing.Point(689, 60);
			this.lblDanhSachFile.Name = "lblDanhSachFile";
			this.lblDanhSachFile.Size = new System.Drawing.Size(147, 19);
			this.lblDanhSachFile.TabIndex = 8;
			this.lblDanhSachFile.Text = "DANH SÁCH FILE";
			// 
			// lblThaotacFile
			// 
			this.lblThaotacFile.AutoSize = true;
			this.lblThaotacFile.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			this.lblThaotacFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
			this.lblThaotacFile.Location = new System.Drawing.Point(3, 0);
			this.lblThaotacFile.Name = "lblThaotacFile";
			this.lblThaotacFile.Size = new System.Drawing.Size(133, 19);
			this.lblThaotacFile.TabIndex = 0;
			this.lblThaotacFile.Text = "THAO TÁC FILE";
			// 
			// pnThaotac
			// 
			this.pnThaotac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
			this.pnThaotac.Controls.Add(this.btnSave);
			this.pnThaotac.Controls.Add(this.btnEdit);
			this.pnThaotac.Controls.Add(this.lblThaotacFile);
			this.pnThaotac.Location = new System.Drawing.Point(34, 352);
			this.pnThaotac.Name = "pnThaotac";
			this.pnThaotac.Size = new System.Drawing.Size(859, 70);
			this.pnThaotac.TabIndex = 13;
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
			this.btnSave.Location = new System.Drawing.Point(439, 34);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Lưu";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(238)))));
			this.btnEdit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(82)))), ((int)(((byte)(45)))));
			this.btnEdit.Location = new System.Drawing.Point(167, 34);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(113, 23);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Chỉnh sửa";
			this.btnEdit.UseVisualStyleBackColor = false;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnHienThi
			// 
			this.btnHienThi.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			this.btnHienThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
			this.btnHienThi.Location = new System.Drawing.Point(622, 303);
			this.btnHienThi.Name = "btnHienThi";
			this.btnHienThi.Size = new System.Drawing.Size(88, 30);
			this.btnHienThi.TabIndex = 10;
			this.btnHienThi.Text = "Hiển thị";
			this.btnHienThi.UseVisualStyleBackColor = true;
			this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
			// 
			// btnThem
			// 
			this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
			this.btnThem.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
			this.btnThem.Location = new System.Drawing.Point(720, 302);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(92, 31);
			this.btnThem.TabIndex = 11;
			this.btnThem.Text = "Thêm";
			this.btnThem.UseVisualStyleBackColor = false;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(205)))));
			this.btnXoa.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.btnXoa.Location = new System.Drawing.Point(818, 301);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(75, 31);
			this.btnXoa.TabIndex = 12;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = false;
			this.btnXoa.Click += new System.EventHandler(this.Xóa_Click);
			// 
			// lvFile1
			// 
			this.lvFile1.HideSelection = false;
			this.lvFile1.Location = new System.Drawing.Point(622, 82);
			this.lvFile1.Name = "lvFile1";
			this.lvFile1.Size = new System.Drawing.Size(271, 214);
			this.lvFile1.TabIndex = 14;
			this.lvFile1.UseCompatibleStateImageBehavior = false;
			// 
			// txtNoiDung
			// 
			this.txtNoiDung.Location = new System.Drawing.Point(394, 82);
			this.txtNoiDung.Multiline = true;
			this.txtNoiDung.Name = "txtNoiDung";
			this.txtNoiDung.ReadOnly = true;
			this.txtNoiDung.Size = new System.Drawing.Size(222, 248);
			this.txtNoiDung.TabIndex = 15;
			// 
			// lblHienthinoidung
			// 
			this.lblHienthinoidung.AutoSize = true;
			this.lblHienthinoidung.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.lblHienthinoidung.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHienthinoidung.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblHienthinoidung.Location = new System.Drawing.Point(402, 63);
			this.lblHienthinoidung.Name = "lblHienthinoidung";
			this.lblHienthinoidung.Size = new System.Drawing.Size(167, 19);
			this.lblHienthinoidung.TabIndex = 16;
			this.lblHienthinoidung.Text = "HIỂN THỊ NỘI DUNG";
			// 
			// rtbXulyFile
			// 
			this.rtbXulyFile.BackColor = System.Drawing.SystemColors.Info;
			this.rtbXulyFile.Location = new System.Drawing.Point(34, 82);
			this.rtbXulyFile.Name = "rtbXulyFile";
			this.rtbXulyFile.Size = new System.Drawing.Size(354, 248);
			this.rtbXulyFile.TabIndex = 17;
			this.rtbXulyFile.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(908, 445);
			this.Controls.Add(this.rtbXulyFile);
			this.Controls.Add(this.lblHienthinoidung);
			this.Controls.Add(this.txtNoiDung);
			this.Controls.Add(this.lvFile1);
			this.Controls.Add(this.pnThaotac);
			this.Controls.Add(this.btnHienThi);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.lblDanhSachFile);
			this.Controls.Add(this.lblFileHTML);
			this.Controls.Add(this.lblBodoctailieuHTML);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HTML";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnThaotac.ResumeLayout(false);
			this.pnThaotac.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion
		private System.Windows.Forms.Label lblBodoctailieuHTML;
		private System.Windows.Forms.Label lblFileHTML;
		private System.Windows.Forms.Label lblHienthinoidung;
		private System.Windows.Forms.Label lblDanhSachFile;
		private System.Windows.Forms.Label lblThaotacFile;
		private System.Windows.Forms.RichTextBox rtbXulyFile;
		private System.Windows.Forms.TextBox txtNoiDung;
		private System.Windows.Forms.Button btnHienThi;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Panel pnThaotac;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.ListView lvFile1;
	}
}

