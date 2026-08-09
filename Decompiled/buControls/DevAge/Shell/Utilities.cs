using System.Diagnostics;

namespace DevAge.Shell;

public class Utilities
{
	public static void OpenFile(string p_File)
	{
		ExecCommand(p_File);
	}

	public static void ExecCommand(string p_Command)
	{
		ProcessStartInfo processStartInfo = new ProcessStartInfo(p_Command);
		processStartInfo.UseShellExecute = true;
		Process process = new Process();
		process.StartInfo = processStartInfo;
		process.Start();
	}
}
