using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GJson;

namespace ProjectImageCompressor
{
	public partial class MForm : Form
	{
		private static MForm _instance;

		private Project _project;
		private string _projDescriptorFile;

		public MForm()
		{
			_instance = this;

			InitializeComponent();
		}
		
		private void MForm_Shown(object sender, EventArgs e)
		{
			SetProjectPath(Properties.Settings.Default.ProjectPath);
			SetOutPath(Properties.Settings.Default.OutPath);

			if (string.IsNullOrWhiteSpace(Properties.Settings.Default.ProjectPath))
				return;

			_project = new Project(Properties.Settings.Default.ProjectPath);

			_projDescriptorFile = Path.ChangeExtension(Path.GetFileName(Properties.Settings.Default.ProjectPath), ".json");
			if (File.Exists(_projDescriptorFile))
				_project.ValdateFromJson(JsonValue.Parse(File.ReadAllText(_projDescriptorFile)));

			ProjectTreeView.Nodes.AddRange(_project.GenerateNodes().Cast<TreeNode>().ToArray());
		}

		private void SetProjectPath(string path)
		{
			path = path.Replace("\\", "/");

			if (string.IsNullOrWhiteSpace(path)
			    || !Directory.Exists(path))
				path = string.Empty;

			ProjectPathBox.Text = path;
			Properties.Settings.Default.ProjectPath = path;
			Properties.Settings.Default.Save();
		}

		private void SetOutPath(string path)
		{
			path = path.Replace("\\", "/");

			if (string.IsNullOrWhiteSpace(path)
			    || !Directory.Exists(path))
				path = string.Empty;

			OutPathBox.Text = path;
			Properties.Settings.Default.OutPath = path;
			Properties.Settings.Default.Save();
		}

		private void SetProjectPath_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				SetProjectPath(dialog.SelectedPath);
			}
		}

		private void OutPathSetButton_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				SetOutPath(dialog.SelectedPath);
			}
		}

		private void ExportButton_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";

			var worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;

			worker.DoWork += (o, args) =>
			{
				_project.Export(Properties.Settings.Default.OutPath, worker.ReportProgress);
			};

			ProjectGroup.Enabled = false;
			ExportButton.Enabled = false;

			worker.RunWorkerCompleted += (o, args) =>
			{
				ProjectGroup.Enabled = true;
				ExportButton.Enabled = true;
			};

			worker.ProgressChanged += (o, args) => ProgressBar.Value = args.ProgressPercentage;

			worker.RunWorkerAsync();
		}

		private void ProjectTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			PreviewSelectedNode();
			SelectedNode.SelectedImageIndex = (SelectedNodeObject.IsExport) ? SelectedNodeObject.GetImageIndex() : 32;
		}

		private void PreviewSelectedNode()
		{
			var obj = SelectedNodeObject;

			ObjName.Text = obj.Name;
			ObjExportFlag.Checked = obj.IsExport;
			ObjResize.Checked = obj.ScalePercent != 100;

			if (ObjResize.Checked)
			{
				ResizeValueBox.Text = SelectedNodeObject.ScalePercent.ToString();
				ResizeValueBox.Enabled = true;
			}
			else
			{
				ResizeValueBox.Text = "100";
				ResizeValueBox.Enabled = false;
			}

			PicPreview.Image = null;
			if (obj is PImage)
				PicPreview.Image = Image.FromFile(Properties.Settings.Default.ProjectPath + obj.AbsolutePath);
		}

		private void ObjResize_CheckedChanged(object sender, EventArgs e)
		{
			if (ObjResize.Checked)
			{
				ResizeValueBox.Text = SelectedNodeObject.ScalePercent.ToString();
				ResizeValueBox.Enabled = true;
			}
			else
			{
				ResizeValueBox.Text = "100";
				ResizeValueBox.Enabled = false;
			}
		}

		private void ObjExportFlag_CheckedChanged(object sender, EventArgs e)
		{
			SelectedNodeObject.IsExport = ObjExportFlag.Checked;
			UpdateImageIndex(SelectedNode);
		}

		private void UpdateImageIndex(TreeNode node)
		{
			node.ImageIndex = (((PObject)node.Tag).IsExport) ? ((PObject)node.Tag).GetImageIndex() : 32;
			node.SelectedImageIndex = node.ImageIndex;
			foreach (TreeNode n in node.Nodes)
				UpdateImageIndex(n);
		}

		private TreeNode SelectedNode
		{
			get { return ProjectTreeView.SelectedNode; }
		}

		private PObject SelectedNodeObject
		{
			get { return (PObject)SelectedNode.Tag; }
		}

		private void SaveProj_Click(object sender, EventArgs e)
		{
			File.WriteAllText(_projDescriptorFile, _project.ExportToJson().ToStringIdent());
		}

		private void ResizeValueBox_TextChanged(object sender, EventArgs e)
		{
			int i;
			if (!int.TryParse(ResizeValueBox.Text, out i))
				i = 100;

			if (i == 100)
				SelectedNodeObject.RemoveProperty("ScalePercent");
			else
				SelectedNodeObject.ScalePercent = i;
		}

		public static void Log(string text)
		{
			_instance.Invoke(new Action(() => _instance.textBox1.Text += text + Environment.NewLine));
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ResizeValueBox.Text = button1.Text;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			ResizeValueBox.Text = button2.Text;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ResizeValueBox.Text = button3.Text;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ResizeValueBox.Text = button4.Text;
		}
	}
}
