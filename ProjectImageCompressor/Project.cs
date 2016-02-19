using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GJson;

namespace ProjectImageCompressor
{
	abstract class PObject
	{
		public string AbsolutePath { get; set; }
		public string Name { get; set; }

		public PObject Parent;
		public List<PObject> Childs { get; set; }
		public Dictionary<string, object> Properties { get; set; }

		protected PObject(PObject parent)
		{
			Parent = parent;
			Childs = new List<PObject>();
			Properties = new Dictionary<string, object>();
		}

		protected PObject(string absolutePath, PObject parent) :this(parent)
		{
			AbsolutePath = absolutePath.Replace("\\", "/");
			Name = GetNameFromAbsolutePath(AbsolutePath);
		}

		public static string GetNameFromAbsolutePath(string absolutePath)
		{
			return Path.GetFileName(absolutePath);
		}

		public bool HasProperty(string name)
		{
			if (Properties.ContainsKey(name))
				return true;

			return Parent != null && Parent.HasProperty(name);
		}

		public object GetPropertyMyselfPriority(string name)
		{
			return Properties.ContainsKey(name) ? Properties[name] : Parent?.GetPropertyMyselfPriority(name);
		}

		//public object GetPropertyParentPriority(string name)
		//{
		//	return (Parent != null) ? Parent.GetPropertyParentPriority(name) : (Properties.ContainsKey(name) ? Properties[name] : null);
		//}

		public void SetProperty(string name, object value)
		{
			Properties[name] = value;

			//bool setMy = false;
			//
			//setMy = true;
			////if (Parent == null)
			////{
			////	setMy = true;
			////}
			////else
			////{
			////	if (Parent.HasProperty(name))
			////	{
			////		if (Parent.GetProperty(name) != value)
			////			setMy = true;
			////		else
			////		{
			////			if (Properties.ContainsKey(name))
			////				Properties.Remove(name);
			////		}
			////	}
			////	else
			////	{
			////		setMy = true;
			////	}
			////}
			//
			//if (setMy)
			//{
			//	Properties[name] = value;
			//
			//	foreach (var child in Childs)
			//	{
			//		child.SetProperty(name, value);
			//	}
			//}
		}

		public void RemoveProperty(string name)
		{
			Properties.Remove(name);
		}

		//public virtual bool SetPropertyAbsolute(string absolutePath, string name, object value)
		//{
		//	if (AbsolutePath == absolutePath)
		//	{
		//		SetProperty(name,value);
		//		return true;
		//	}
		//
		//	foreach (var child in Childs)
		//	{
		//		if (child.SetPropertyAbsolute(absolutePath, name, value))
		//			return true;
		//	}
		//
		//	return false;
		//}
		
		public bool IsExport
		{
			get { return (bool)GetPropertyMyselfPriority("IsExport"); }
			set { SetProperty("IsExport", value); }
		}

		public int ScalePercent
		{
			get { return (int)GetPropertyMyselfPriority("ScalePercent"); }
			set { SetProperty("ScalePercent", value); }
		}

		private static readonly List<string> IgnoringNames = new List<string>
		{
			".git",
			".vs"
		};
		
		public static bool IsIgnoring(string name)
		{
			return IgnoringNames.Contains(name);
		}

		public void Export(List<ExportCommand> commands)
		{
			if (!IsExport)
				return;

			var cmd = GetExportCommand();
			if (cmd != null)
			{
				cmd.Object = this;
				commands.Add(cmd);
			}

			foreach (var child in Childs)
			{
				child.Export(commands);
			}
		}

		protected virtual ExportCommand GetExportCommand()
		{
			return null;
		}

		public virtual int GetImageIndex()
		{
			return 0;
		}

		public void ValdateFromJson(JsonValue arr)
		{
			if (arr.AsObject.ContainsKey(AbsolutePath))
			{
				Properties.Clear();
				foreach (var jsonValue in arr[AbsolutePath].AsArray)
				{
					if (jsonValue["value"].JsonType == JsonType.Boolean)
					{
						Properties[jsonValue["key"]] = (bool)jsonValue["value"];
					}
					else if (jsonValue["value"].JsonType == JsonType.Number)
					{
						Properties[jsonValue["key"]] = (int)jsonValue["value"];
					}
					else if (jsonValue["value"].JsonType == JsonType.String)
					{
						Properties[jsonValue["key"]] = (string)jsonValue["value"];
					}
				}
			}

			foreach (var child in Childs)
				child.ValdateFromJson(arr);
		}
	}

	class PDirectory : PObject
	{
		public PDirectory():base(null)
		{
		}

		public PDirectory(string absolutePath, PObject parent) :base(absolutePath, parent)
		{
			foreach (var childDirectory in Directory.GetDirectories(AbsolutePath))
			{
				var name = GetNameFromAbsolutePath(childDirectory);
				if (!IsIgnoring(name))
				{
					var dir = new PDirectory(childDirectory, this);
					Childs.Add(dir);
				}
			}

			foreach (var file in Directory.GetFiles(AbsolutePath))
			{
				var fileObj = PFile.CreateFile(file, this);
				if (fileObj != null)
				{
					Childs.Add(fileObj);
				}
			}
		}

		protected override ExportCommand GetExportCommand()
		{
			return new PDirectoryExportCommand();
		}

		class PDirectoryExportCommand : ExportCommand
		{
			public override void Process(IExportProvider provider)
			{
				Directory.CreateDirectory(Object.AbsolutePath);
			}
		}

		public override int GetImageIndex()
		{
			return 52;
		}
	}

	class PFile : PObject
	{
		public PFile(string absolutePath, PObject parent) :base(absolutePath, parent)
		{
		}

		public static PFile CreateFile(string absolutePath, PObject parent)
		{
			var name = GetNameFromAbsolutePath(absolutePath);
			if (IsIgnoring(name))
				return null;

			var ext = Path.GetExtension(absolutePath).ToLowerInvariant();
			if (ext == ".png")
				return new PImage(absolutePath, parent);

			return new PFile(absolutePath, parent);
		}

		protected override ExportCommand GetExportCommand()
		{
			return new PFileExportCommand();
		}

		class PFileExportCommand : ExportCommand
		{
			public override void Process(IExportProvider provider)
			{
				File.Copy(provider.ProjectPath + "\\" + Object.AbsolutePath, provider.OutPath + "\\" + Object.AbsolutePath);
			}
		}
	}

	class PImage : PFile
	{
		//[Ignore]
		//public FileInfo Info { get; set; }

		public PImage(string absolutePath, PObject parent) :base(absolutePath, parent)
		{
			//Info = new FileInfo(absolutePath);
		}

		protected override ExportCommand GetExportCommand()
		{
			return new PImageExportCommand();
		}

		class PImageExportCommand : ExportCommand
		{
			public override void Process(IExportProvider provider)
			{
				var oldp = provider.ProjectPath + "\\" + Object.AbsolutePath;
				var newp = provider.OutPath + "\\" + Object.AbsolutePath;

				var scale = ((PImage)Object).ScalePercent;
				if (scale != 100)
				{
					MForm.Log(Object.AbsolutePath + " " + scale);
					Nconvert.Convert(oldp, newp, scale);
				}
				else
				{
					File.Copy(oldp, newp);
				}
			}
		}

		public override int GetImageIndex()
		{
			return 69;
		}
	}

	class Project : IExportProvider
	{
		public PDirectory RootDirectory { get; set; }

		public Project()
		{
			ProjectPath = "";
			OutPath = "";
		}

		public Project(string path):this()
		{
			ProjectPath = path;

			var curDir = Directory.GetCurrentDirectory();
			Directory.SetCurrentDirectory(path);

			RootDirectory = new PDirectory(".", null);

			// дефолтные свойства чтобы наследовались
			RootDirectory.IsExport = true;
			RootDirectory.ScalePercent = 100;

			Directory.SetCurrentDirectory(curDir);
		}

		public TreeNodeCollection GenerateNodes()
		{
			return GenerateNode(RootDirectory).Nodes;
		}

		public void Export(string newProject, Action<int> progressDelegate)
		{
			OutPath = newProject;

			var curDir = Directory.GetCurrentDirectory();

			DeleteDirectory(newProject);
			Directory.CreateDirectory(newProject);
			Directory.SetCurrentDirectory(newProject);

			var exportCommands = new List<ExportCommand>();
			RootDirectory.Export(exportCommands);

			for (int i = 0; i < exportCommands.Count; i++)
			{
				exportCommands[i].Process(this);
				progressDelegate((int)(100 * (i + 1) / (double) exportCommands.Count));
			}

			Directory.SetCurrentDirectory(curDir);
		}

		public static void DeleteDirectory(string path)
		{
			foreach (string directory in Directory.GetDirectories(path))
			{
				DeleteDirectory(directory);
			}

			try
			{
				Directory.Delete(path, true);
			}
			catch (IOException)
			{
				Directory.Delete(path, true);
			}
			catch (UnauthorizedAccessException)
			{
				Directory.Delete(path, true);
			}
		}

		static TreeNode GenerateNode(PObject obj)
		{
			var node = new TreeNode(obj.Name);
			node.Tag = obj;
			node.ImageIndex = (obj.IsExport) ? obj.GetImageIndex() : 32;
			node.SelectedImageIndex = node.ImageIndex;
			obj.Childs.ForEach(x =>
			{
				if (x is PDirectory || x is PImage)
					node.Nodes.Add(GenerateNode(x));
			});
			return node;
		}
		
		public string ProjectPath { get; private set; }
		public string OutPath { get; private set; }

		public JsonValue ExportToJson()
		{
			var arr = new JsonValue();
			ExportToJson(arr, RootDirectory);
			arr.AsObject.Remove(".");
			return arr;
		}

		static void ExportToJson(JsonValue arr, PObject obj)
		{
			arr[obj.AbsolutePath] = Serializator.Serialize(obj.Properties);

			obj.Childs.ForEach( x => ExportToJson(arr, x ));
		}

		public void ValdateFromJson(JsonValue arr)
		{
			RootDirectory.ValdateFromJson(arr);
		}
	}
}
