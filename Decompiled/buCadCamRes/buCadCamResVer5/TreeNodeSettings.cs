using System.Windows.Forms;

namespace buCadCamResVer5;

public class TreeNodeSettings : TreeNode
{
	public int ClassIndex = -1;

	public int ClassSubIndex = -1;

	public int ClassSubSubIndex = -1;

	public int ClassSubSubSubIndex = -1;

	public int ClassSubSubSubSubIndex = -1;

	public int ClassSubSubSubSubSubIndex = -1;

	public int ClassSubSubSubSubSubSubIndex = -1;

	public int ClassSubSubSubSubSubSubSubIndex = -1;

	public int ClassSubSubSubSubSubSubSubSubIndex = -1;

	public int ClassSubSubSubSubSubSubSubSubSubIndex = -1;

	public string Command = "";

	public new string Name = "";

	public string Info = "";

	public new int Index = -1;

	public int OldImageIndex = -1;

	public TreeNodeSettings()
	{
	}

	public TreeNodeSettings(string NodeText)
	{
		base.Text = NodeText;
	}
}
