#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBackInheritNode : PaletteBackInherit
{
	private IPaletteBack _inherit;

	private TreeNode _node;

	public TreeNode TreeNode
	{
		get
		{
			return _node;
		}
		set
		{
			_node = value;
		}
	}

	public PaletteBackInheritNode(IPaletteBack inherit)
	{
		Debug.Assert(inherit != null);
		_inherit = inherit;
	}

	public override InheritBool GetBackDraw(PaletteState state)
	{
		if (TreeNode != null && TreeNode.BackColor != Color.Empty)
		{
			return InheritBool.True;
		}
		return _inherit.GetBackDraw(state);
	}

	public override PaletteGraphicsHint GetBackGraphicsHint(PaletteState state)
	{
		return _inherit.GetBackGraphicsHint(state);
	}

	public override Color GetBackColor1(PaletteState state)
	{
		if (TreeNode != null && TreeNode.BackColor != Color.Empty)
		{
			return TreeNode.BackColor;
		}
		return _inherit.GetBackColor1(state);
	}

	public override Color GetBackColor2(PaletteState state)
	{
		if (TreeNode != null && TreeNode.BackColor != Color.Empty)
		{
			return TreeNode.BackColor;
		}
		return _inherit.GetBackColor2(state);
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteState state)
	{
		return _inherit.GetBackColorStyle(state);
	}

	public override PaletteRectangleAlign GetBackColorAlign(PaletteState state)
	{
		return _inherit.GetBackColorAlign(state);
	}

	public override float GetBackColorAngle(PaletteState state)
	{
		return _inherit.GetBackColorAngle(state);
	}

	public override Image GetBackImage(PaletteState state)
	{
		return _inherit.GetBackImage(state);
	}

	public override PaletteImageStyle GetBackImageStyle(PaletteState state)
	{
		return _inherit.GetBackImageStyle(state);
	}

	public override PaletteRectangleAlign GetBackImageAlign(PaletteState state)
	{
		return _inherit.GetBackImageAlign(state);
	}
}
