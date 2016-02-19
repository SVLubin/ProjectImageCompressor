using System.Diagnostics;

namespace ProjectImageCompressor
{
	static class Nconvert
	{
		private static readonly ProcessStartInfo Info = new ProcessStartInfo
		{
			FileName = "nconvert.exe",
			RedirectStandardOutput = true,
			UseShellExecute = false,
			CreateNoWindow = true
		};

		public static void Convert(string filePath, string outPath, int resizePercent)
		{
			Info.Arguments = string.Format("-resize {0}% {0}% -o {1} {2}", resizePercent,
				"\"" + outPath + "\"",
				"\"" + filePath + "\"");
			Process.Start(Info);
		}
	}
}
