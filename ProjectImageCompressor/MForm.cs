using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GJson;

namespace ProjectImageCompressor
{
	public partial class MForm : Form
	{
		private Project _project;
		private static MForm instance;

		public MForm()
		{
			InitializeComponent();
			instance = this;
		}

		private void MForm_Load(object sender, EventArgs e)
		{

		}

		private void MForm_Shown(object sender, EventArgs e)
		{
			SetProjectPath(Properties.Settings.Default.ProjectPath);
			SetOutPath(Properties.Settings.Default.OutPath);

			//_project = (Project)Serializator.DeserializeFromXml(File.ReadAllText("proj.xml"));

			_project = new Project(Properties.Settings.Default.ProjectPath);

			if (File.Exists("proj.json"))
				_project.ValdateFromJson(JsonValue.Parse(File.ReadAllText("proj.json")));

			ProjectTreeView.Nodes.AddRange(_project.GenerateNodes().Cast<TreeNode>().ToArray());

			//PRBox.Lines = Properties.Settings.Default.ProjectLines.OfType<string>().ToArray();

			//_project.SetPropertyAbsolute(@".\Assets", "ScalePercent", 50);

			//ProjectTreeView.SelectedNode = ProjectTreeView.Nodes[0];

			//File.WriteAllText("proj.xml", Serializator.SerializeToXml(_project));
		}

		void SetProjectPath(string path)
		{
			path = path.Replace("\\", "/");

			if (string.IsNullOrWhiteSpace(path)
			    || !Directory.Exists(path))
				path = string.Empty;

			ProjectPathBox.Text = path;
			Properties.Settings.Default.ProjectPath = path;
			Properties.Settings.Default.Save();
		}

		void SetOutPath(string path)
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
			//SetImagePercents();

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

		//private void SetImagePercents()
		//{
		//	foreach (var line in Properties.Settings.Default.ProjectLines)
		//	{
		//		var s = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
		//		int p = int.Parse(s[s.Length - 1]);
		//		if (p != 100)
		//		{
		//			var path = string.Join("",s.Take(s.Length - 1));
		//			_project.SetPropertyAbsolute(path, "ScalePercent", p);
		//		}
		//	}
		//}

		private void ProjectTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			PreviewSelectedNode();
			SelectedNode.SelectedImageIndex = (SelectedNodeObject.IsExport) ? SelectedNodeObject.GetImageIndex() : 32;
		}

		void PreviewSelectedNode()
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

		//private void ProjectTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		//{
		//	if (Color.Gray == e.Node.ForeColor)
		//		e.Cancel = true;
		//}

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

		TreeNode SelectedNode { get { return ProjectTreeView.SelectedNode; } }
		PObject SelectedNodeObject { get { return (PObject)SelectedNode.Tag; } }

		private void SaveProj_Click(object sender, EventArgs e)
		{
			File.WriteAllText("proj.json", _project.ExportToJson().ToStringIdent());
		}

		private void ResizeValueBox_TextChanged(object sender, EventArgs e)
		{
			int i;
			if (int.TryParse(ResizeValueBox.Text, out i))
			{
				SelectedNodeObject.ScalePercent = i;
			}
			else
			{
				SelectedNodeObject.ScalePercent = 100;
			}
		}

		public static void Log(string text)
		{
			instance.Invoke(new Action(() => instance.textBox1.Text += text + Environment.NewLine));
		}

		//private void PRBox_TextChanged(object sender, EventArgs e)
		//{
		//	Properties.Settings.Default.ProjectLines = new StringCollection();
		//	Properties.Settings.Default.ProjectLines.AddRange(PRBox.Lines);
		//	Properties.Settings.Default.Save();
		//}
	}
}
