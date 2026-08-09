using System.IO;
using System.Windows.Forms;

namespace buClass;

public class FileEventArg
{
	public string FileName = Application.StartupPath;

	public string FilePath = Application.StartupPath;

	public string JustFileName = "";

	public string JustFileNameWithoutExtension = "";

	public string Extension = "";

	public int Count = 1;

	public FileEventArg()
	{
	}

	public FileEventArg(string FileName)
	{
		this.FileName = FileName;
		JustFileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileName);
		JustFileName = Path.GetFileName(FileName);
		FilePath = Path.GetDirectoryName(FileName);
	}

	public override string ToString()
	{
		return JustFileName;
	}
}
