namespace ProjectImageCompressor
{
	partial class MForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MForm));
			this.SetProjectPathButton = new System.Windows.Forms.Button();
			this.ProjectPathBox = new System.Windows.Forms.TextBox();
			this.ProjectPathLabel = new System.Windows.Forms.Label();
			this.OutPathLabel = new System.Windows.Forms.Label();
			this.OutPathBox = new System.Windows.Forms.TextBox();
			this.OutPathSetButton = new System.Windows.Forms.Button();
			this.ProjectTreeView = new System.Windows.Forms.TreeView();
			this.ExportButton = new System.Windows.Forms.Button();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ProjectGroup = new System.Windows.Forms.GroupBox();
			this.TreeBox = new System.Windows.Forms.GroupBox();
			this.ObjName = new System.Windows.Forms.Label();
			this.ObjResize = new System.Windows.Forms.CheckBox();
			this.ObjExportFlag = new System.Windows.Forms.CheckBox();
			this.ExportGroup = new System.Windows.Forms.GroupBox();
			this.ImagesList = new System.Windows.Forms.ImageList(this.components);
			this.SaveProj = new System.Windows.Forms.Button();
			this.ResizeValueBox = new System.Windows.Forms.MaskedTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.ProjectGroup.SuspendLayout();
			this.TreeBox.SuspendLayout();
			this.ExportGroup.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// SetProjectPathButton
			// 
			this.SetProjectPathButton.Location = new System.Drawing.Point(673, 20);
			this.SetProjectPathButton.Name = "SetProjectPathButton";
			this.SetProjectPathButton.Size = new System.Drawing.Size(75, 23);
			this.SetProjectPathButton.TabIndex = 0;
			this.SetProjectPathButton.Text = "Set";
			this.SetProjectPathButton.UseVisualStyleBackColor = true;
			this.SetProjectPathButton.Click += new System.EventHandler(this.SetProjectPath_Click);
			// 
			// ProjectPathBox
			// 
			this.ProjectPathBox.Location = new System.Drawing.Point(74, 22);
			this.ProjectPathBox.Name = "ProjectPathBox";
			this.ProjectPathBox.ReadOnly = true;
			this.ProjectPathBox.Size = new System.Drawing.Size(593, 20);
			this.ProjectPathBox.TabIndex = 1;
			// 
			// ProjectPathLabel
			// 
			this.ProjectPathLabel.AutoSize = true;
			this.ProjectPathLabel.Location = new System.Drawing.Point(6, 25);
			this.ProjectPathLabel.Name = "ProjectPathLabel";
			this.ProjectPathLabel.Size = new System.Drawing.Size(62, 13);
			this.ProjectPathLabel.TabIndex = 2;
			this.ProjectPathLabel.Text = "ProjectPath";
			// 
			// OutPathLabel
			// 
			this.OutPathLabel.AutoSize = true;
			this.OutPathLabel.Location = new System.Drawing.Point(6, 54);
			this.OutPathLabel.Name = "OutPathLabel";
			this.OutPathLabel.Size = new System.Drawing.Size(46, 13);
			this.OutPathLabel.TabIndex = 5;
			this.OutPathLabel.Text = "OutPath";
			// 
			// OutPathBox
			// 
			this.OutPathBox.Location = new System.Drawing.Point(74, 51);
			this.OutPathBox.Name = "OutPathBox";
			this.OutPathBox.ReadOnly = true;
			this.OutPathBox.Size = new System.Drawing.Size(593, 20);
			this.OutPathBox.TabIndex = 4;
			// 
			// OutPathSetButton
			// 
			this.OutPathSetButton.Location = new System.Drawing.Point(673, 49);
			this.OutPathSetButton.Name = "OutPathSetButton";
			this.OutPathSetButton.Size = new System.Drawing.Size(75, 23);
			this.OutPathSetButton.TabIndex = 3;
			this.OutPathSetButton.Text = "Set";
			this.OutPathSetButton.UseVisualStyleBackColor = true;
			this.OutPathSetButton.Click += new System.EventHandler(this.OutPathSetButton_Click);
			// 
			// ProjectTreeView
			// 
			this.ProjectTreeView.ImageIndex = 0;
			this.ProjectTreeView.ImageList = this.ImagesList;
			this.ProjectTreeView.Location = new System.Drawing.Point(11, 19);
			this.ProjectTreeView.Name = "ProjectTreeView";
			this.ProjectTreeView.SelectedImageIndex = 0;
			this.ProjectTreeView.Size = new System.Drawing.Size(331, 342);
			this.ProjectTreeView.TabIndex = 6;
			this.ProjectTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ProjectTreeView_AfterSelect);
			// 
			// ExportButton
			// 
			this.ExportButton.Location = new System.Drawing.Point(673, 19);
			this.ExportButton.Name = "ExportButton";
			this.ExportButton.Size = new System.Drawing.Size(75, 23);
			this.ExportButton.TabIndex = 7;
			this.ExportButton.Text = "Export";
			this.ExportButton.UseVisualStyleBackColor = true;
			this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(9, 19);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(658, 23);
			this.ProgressBar.TabIndex = 8;
			// 
			// ProjectGroup
			// 
			this.ProjectGroup.Controls.Add(this.SaveProj);
			this.ProjectGroup.Controls.Add(this.TreeBox);
			this.ProjectGroup.Controls.Add(this.ProjectPathLabel);
			this.ProjectGroup.Controls.Add(this.SetProjectPathButton);
			this.ProjectGroup.Controls.Add(this.OutPathLabel);
			this.ProjectGroup.Controls.Add(this.ProjectPathBox);
			this.ProjectGroup.Controls.Add(this.OutPathBox);
			this.ProjectGroup.Controls.Add(this.OutPathSetButton);
			this.ProjectGroup.Location = new System.Drawing.Point(12, 12);
			this.ProjectGroup.Name = "ProjectGroup";
			this.ProjectGroup.Size = new System.Drawing.Size(760, 479);
			this.ProjectGroup.TabIndex = 9;
			this.ProjectGroup.TabStop = false;
			this.ProjectGroup.Text = "Project";
			// 
			// TreeBox
			// 
			this.TreeBox.Controls.Add(this.ResizeValueBox);
			this.TreeBox.Controls.Add(this.ProjectTreeView);
			this.TreeBox.Controls.Add(this.ObjName);
			this.TreeBox.Controls.Add(this.ObjResize);
			this.TreeBox.Controls.Add(this.ObjExportFlag);
			this.TreeBox.Location = new System.Drawing.Point(9, 106);
			this.TreeBox.Name = "TreeBox";
			this.TreeBox.Size = new System.Drawing.Size(739, 367);
			this.TreeBox.TabIndex = 11;
			this.TreeBox.TabStop = false;
			this.TreeBox.Text = "Files";
			// 
			// ObjName
			// 
			this.ObjName.AutoSize = true;
			this.ObjName.Location = new System.Drawing.Point(348, 19);
			this.ObjName.Name = "ObjName";
			this.ObjName.Size = new System.Drawing.Size(51, 13);
			this.ObjName.TabIndex = 7;
			this.ObjName.Text = "ObjName";
			// 
			// ObjResize
			// 
			this.ObjResize.AutoSize = true;
			this.ObjResize.Location = new System.Drawing.Point(351, 58);
			this.ObjResize.Name = "ObjResize";
			this.ObjResize.Size = new System.Drawing.Size(58, 17);
			this.ObjResize.TabIndex = 9;
			this.ObjResize.Text = "Resize";
			this.ObjResize.UseVisualStyleBackColor = true;
			this.ObjResize.CheckedChanged += new System.EventHandler(this.ObjResize_CheckedChanged);
			// 
			// ObjExportFlag
			// 
			this.ObjExportFlag.AutoSize = true;
			this.ObjExportFlag.Location = new System.Drawing.Point(351, 35);
			this.ObjExportFlag.Name = "ObjExportFlag";
			this.ObjExportFlag.Size = new System.Drawing.Size(64, 17);
			this.ObjExportFlag.TabIndex = 8;
			this.ObjExportFlag.Text = "IsExport";
			this.ObjExportFlag.UseVisualStyleBackColor = true;
			this.ObjExportFlag.CheckedChanged += new System.EventHandler(this.ObjExportFlag_CheckedChanged);
			// 
			// ExportGroup
			// 
			this.ExportGroup.Controls.Add(this.ProgressBar);
			this.ExportGroup.Controls.Add(this.ExportButton);
			this.ExportGroup.Location = new System.Drawing.Point(12, 497);
			this.ExportGroup.Name = "ExportGroup";
			this.ExportGroup.Size = new System.Drawing.Size(760, 53);
			this.ExportGroup.TabIndex = 10;
			this.ExportGroup.TabStop = false;
			this.ExportGroup.Text = "Export";
			// 
			// ImagesList
			// 
			this.ImagesList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagesList.ImageStream")));
			this.ImagesList.TransparentColor = System.Drawing.Color.Transparent;
			this.ImagesList.Images.SetKeyName(0, "1.ico");
			this.ImagesList.Images.SetKeyName(1, "2.ico");
			this.ImagesList.Images.SetKeyName(2, "3.ico");
			this.ImagesList.Images.SetKeyName(3, "4.ico");
			this.ImagesList.Images.SetKeyName(4, "5.ico");
			this.ImagesList.Images.SetKeyName(5, "6.ico");
			this.ImagesList.Images.SetKeyName(6, "7.ico");
			this.ImagesList.Images.SetKeyName(7, "8.ico");
			this.ImagesList.Images.SetKeyName(8, "9.ico");
			this.ImagesList.Images.SetKeyName(9, "10.ico");
			this.ImagesList.Images.SetKeyName(10, "11.ico");
			this.ImagesList.Images.SetKeyName(11, "12.ico");
			this.ImagesList.Images.SetKeyName(12, "13.ico");
			this.ImagesList.Images.SetKeyName(13, "14.ico");
			this.ImagesList.Images.SetKeyName(14, "15.ico");
			this.ImagesList.Images.SetKeyName(15, "16.ico");
			this.ImagesList.Images.SetKeyName(16, "17.ico");
			this.ImagesList.Images.SetKeyName(17, "18.ico");
			this.ImagesList.Images.SetKeyName(18, "19.ico");
			this.ImagesList.Images.SetKeyName(19, "20.ico");
			this.ImagesList.Images.SetKeyName(20, "21.ico");
			this.ImagesList.Images.SetKeyName(21, "22.ico");
			this.ImagesList.Images.SetKeyName(22, "23.ico");
			this.ImagesList.Images.SetKeyName(23, "24.ico");
			this.ImagesList.Images.SetKeyName(24, "25.ico");
			this.ImagesList.Images.SetKeyName(25, "26.ico");
			this.ImagesList.Images.SetKeyName(26, "27.ico");
			this.ImagesList.Images.SetKeyName(27, "28.ico");
			this.ImagesList.Images.SetKeyName(28, "29.ico");
			this.ImagesList.Images.SetKeyName(29, "30.ico");
			this.ImagesList.Images.SetKeyName(30, "31.ico");
			this.ImagesList.Images.SetKeyName(31, "32.ico");
			this.ImagesList.Images.SetKeyName(32, "33.ico");
			this.ImagesList.Images.SetKeyName(33, "34.ico");
			this.ImagesList.Images.SetKeyName(34, "35.ico");
			this.ImagesList.Images.SetKeyName(35, "36.ico");
			this.ImagesList.Images.SetKeyName(36, "37.ico");
			this.ImagesList.Images.SetKeyName(37, "38.ico");
			this.ImagesList.Images.SetKeyName(38, "39.ico");
			this.ImagesList.Images.SetKeyName(39, "40.ico");
			this.ImagesList.Images.SetKeyName(40, "41.ico");
			this.ImagesList.Images.SetKeyName(41, "42.ico");
			this.ImagesList.Images.SetKeyName(42, "42a.ico");
			this.ImagesList.Images.SetKeyName(43, "43.ico");
			this.ImagesList.Images.SetKeyName(44, "44.ico");
			this.ImagesList.Images.SetKeyName(45, "45.ico");
			this.ImagesList.Images.SetKeyName(46, "46.ico");
			this.ImagesList.Images.SetKeyName(47, "47.ico");
			this.ImagesList.Images.SetKeyName(48, "48.ico");
			this.ImagesList.Images.SetKeyName(49, "49.ico");
			this.ImagesList.Images.SetKeyName(50, "50.ico");
			this.ImagesList.Images.SetKeyName(51, "51.ico");
			this.ImagesList.Images.SetKeyName(52, "52.ico");
			this.ImagesList.Images.SetKeyName(53, "53.ico");
			this.ImagesList.Images.SetKeyName(54, "54.ico");
			this.ImagesList.Images.SetKeyName(55, "55.ico");
			this.ImagesList.Images.SetKeyName(56, "56.ico");
			this.ImagesList.Images.SetKeyName(57, "57.ico");
			this.ImagesList.Images.SetKeyName(58, "58.ico");
			this.ImagesList.Images.SetKeyName(59, "59.ico");
			this.ImagesList.Images.SetKeyName(60, "60.ico");
			this.ImagesList.Images.SetKeyName(61, "61.ico");
			this.ImagesList.Images.SetKeyName(62, "62.ico");
			this.ImagesList.Images.SetKeyName(63, "63.ico");
			this.ImagesList.Images.SetKeyName(64, "64.ico");
			this.ImagesList.Images.SetKeyName(65, "65.ico");
			this.ImagesList.Images.SetKeyName(66, "66.ico");
			this.ImagesList.Images.SetKeyName(67, "67.ico");
			this.ImagesList.Images.SetKeyName(68, "68.ico");
			this.ImagesList.Images.SetKeyName(69, "69.ico");
			this.ImagesList.Images.SetKeyName(70, "70.ico");
			this.ImagesList.Images.SetKeyName(71, "71.ico");
			this.ImagesList.Images.SetKeyName(72, "72.ico");
			this.ImagesList.Images.SetKeyName(73, "73.ico");
			this.ImagesList.Images.SetKeyName(74, "74.ico");
			this.ImagesList.Images.SetKeyName(75, "75.ico");
			this.ImagesList.Images.SetKeyName(76, "76.ico");
			this.ImagesList.Images.SetKeyName(77, "77.ico");
			this.ImagesList.Images.SetKeyName(78, "78.ico");
			this.ImagesList.Images.SetKeyName(79, "79.ico");
			this.ImagesList.Images.SetKeyName(80, "80.ico");
			this.ImagesList.Images.SetKeyName(81, "81.ico");
			this.ImagesList.Images.SetKeyName(82, "82.ico");
			this.ImagesList.Images.SetKeyName(83, "83.ico");
			this.ImagesList.Images.SetKeyName(84, "84.ico");
			this.ImagesList.Images.SetKeyName(85, "85.ico");
			this.ImagesList.Images.SetKeyName(86, "86.ico");
			this.ImagesList.Images.SetKeyName(87, "87.ico");
			this.ImagesList.Images.SetKeyName(88, "88.ico");
			this.ImagesList.Images.SetKeyName(89, "89.ico");
			this.ImagesList.Images.SetKeyName(90, "90.ico");
			this.ImagesList.Images.SetKeyName(91, "91.ico");
			this.ImagesList.Images.SetKeyName(92, "92.ico");
			this.ImagesList.Images.SetKeyName(93, "93.ico");
			this.ImagesList.Images.SetKeyName(94, "94.ico");
			this.ImagesList.Images.SetKeyName(95, "95.ico");
			this.ImagesList.Images.SetKeyName(96, "96.ico");
			// 
			// SaveProj
			// 
			this.SaveProj.Location = new System.Drawing.Point(9, 77);
			this.SaveProj.Name = "SaveProj";
			this.SaveProj.Size = new System.Drawing.Size(739, 23);
			this.SaveProj.TabIndex = 12;
			this.SaveProj.Text = "Save";
			this.SaveProj.UseVisualStyleBackColor = true;
			this.SaveProj.Click += new System.EventHandler(this.SaveProj_Click);
			// 
			// ResizeValueBox
			// 
			this.ResizeValueBox.Location = new System.Drawing.Point(421, 55);
			this.ResizeValueBox.Mask = "00000";
			this.ResizeValueBox.Name = "ResizeValueBox";
			this.ResizeValueBox.Size = new System.Drawing.Size(100, 20);
			this.ResizeValueBox.TabIndex = 10;
			this.ResizeValueBox.ValidatingType = typeof(int);
			this.ResizeValueBox.TextChanged += new System.EventHandler(this.ResizeValueBox_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Location = new System.Drawing.Point(12, 556);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(760, 244);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Log";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(9, 19);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(739, 219);
			this.textBox1.TabIndex = 0;
			// 
			// MForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 812);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ExportGroup);
			this.Controls.Add(this.ProjectGroup);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "MForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ProjectImageCompressor";
			this.Load += new System.EventHandler(this.MForm_Load);
			this.Shown += new System.EventHandler(this.MForm_Shown);
			this.ProjectGroup.ResumeLayout(false);
			this.ProjectGroup.PerformLayout();
			this.TreeBox.ResumeLayout(false);
			this.TreeBox.PerformLayout();
			this.ExportGroup.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button SetProjectPathButton;
		private System.Windows.Forms.TextBox ProjectPathBox;
		private System.Windows.Forms.Label ProjectPathLabel;
		private System.Windows.Forms.Label OutPathLabel;
		private System.Windows.Forms.TextBox OutPathBox;
		private System.Windows.Forms.Button OutPathSetButton;
		private System.Windows.Forms.TreeView ProjectTreeView;
		private System.Windows.Forms.Button ExportButton;
		private System.Windows.Forms.ProgressBar ProgressBar;
		private System.Windows.Forms.GroupBox ProjectGroup;
		private System.Windows.Forms.GroupBox ExportGroup;
		private System.Windows.Forms.CheckBox ObjResize;
		private System.Windows.Forms.CheckBox ObjExportFlag;
		private System.Windows.Forms.Label ObjName;
		private System.Windows.Forms.GroupBox TreeBox;
		private System.Windows.Forms.ImageList ImagesList;
		private System.Windows.Forms.Button SaveProj;
		private System.Windows.Forms.MaskedTextBox ResizeValueBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
	}
}

