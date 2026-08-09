using System.Windows.Forms;

namespace buControls;

public class buTreeNode : TreeNode
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

	public string Info = "";

	public string ParentName = "";

	public int OldImageIndex = -1;

	public int NodeIndex = -1;

	public buTreeNode()
	{
	}

	public buTreeNode(string NodeText)
	{
		base.Text = NodeText;
	}
}
