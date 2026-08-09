using System.Windows.Forms;

namespace buClass;

public class TreeViewNodeSettings : TreeNode
{
	public int ClassIndex = -1;

	public int ClassSubIndex = -1;

	public int ClassSubSubIndex = -1;

	public string Command = "";

	public TreeViewNodeSettings()
	{
	}

	public TreeViewNodeSettings(string name)
	{
		base.Name = name;
	}
}
