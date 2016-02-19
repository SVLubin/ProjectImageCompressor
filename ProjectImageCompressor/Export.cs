namespace ProjectImageCompressor
{
	interface IExportProvider
	{
		string ProjectPath { get; }
		string OutPath { get; }
	}

	class ExportCommand
	{
		public PObject Object;

		public virtual void Process(IExportProvider provider)
		{
		} 
	}
}
