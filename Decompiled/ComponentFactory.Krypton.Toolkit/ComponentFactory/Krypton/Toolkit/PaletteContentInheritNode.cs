using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContentInheritNode : PaletteContentInherit
{
	private IPaletteContent _inherit;

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

	public PaletteContentInheritNode(IPaletteContent inherit)
	{
		_inherit = inherit;
	}

	public override InheritBool GetContentDraw(PaletteState state)
	{
		return _inherit.GetContentDraw(state);
	}

	public override InheritBool GetContentDrawFocus(PaletteState state)
	{
		return _inherit.GetContentDrawFocus(state);
	}

	public override PaletteRelativeAlign GetContentImageH(PaletteState state)
	{
		return _inherit.GetContentImageH(state);
	}

	public override PaletteRelativeAlign GetContentImageV(PaletteState state)
	{
		return _inherit.GetContentImageV(state);
	}

	public override PaletteImageEffect GetContentImageEffect(PaletteState state)
	{
		return _inherit.GetContentImageEffect(state);
	}

	public override Color GetContentImageColorMap(PaletteState state)
	{
		return _inherit.GetContentImageColorMap(state);
	}

	public override Color GetContentImageColorTo(PaletteState state)
	{
		return _inherit.GetContentImageColorTo(state);
	}

	public override Font GetContentShortTextFont(PaletteState state)
	{
		if (TreeNode != null && TreeNode.NodeFont != null)
		{
			return TreeNode.NodeFont;
		}
		return _inherit.GetContentShortTextFont(state);
	}

	public override Font GetContentShortTextNewFont(PaletteState state)
	{
		if (TreeNode != null && TreeNode.NodeFont != null)
		{
			return TreeNode.NodeFont;
		}
		return _inherit.GetContentShortTextNewFont(state);
	}

	public override PaletteTextHint GetContentShortTextHint(PaletteState state)
	{
		return _inherit.GetContentShortTextHint(state);
	}

	public override PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state)
	{
		return _inherit.GetContentShortTextPrefix(state);
	}

	public override InheritBool GetContentShortTextMultiLine(PaletteState state)
	{
		return _inherit.GetContentShortTextMultiLine(state);
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		return _inherit.GetContentShortTextTrim(state);
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		return _inherit.GetContentShortTextH(state);
	}

	public override PaletteRelativeAlign GetContentShortTextV(PaletteState state)
	{
		return _inherit.GetContentShortTextV(state);
	}

	public override PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteState state)
	{
		return _inherit.GetContentShortTextMultiLineH(state);
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		if (TreeNode != null && TreeNode.ForeColor != Color.Empty)
		{
			return TreeNode.ForeColor;
		}
		return _inherit.GetContentShortTextColor1(state);
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		if (TreeNode != null && TreeNode.ForeColor != Color.Empty)
		{
			return TreeNode.ForeColor;
		}
		return _inherit.GetContentShortTextColor2(state);
	}

	public override PaletteColorStyle GetContentShortTextColorStyle(PaletteState state)
	{
		return _inherit.GetContentShortTextColorStyle(state);
	}

	public override PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state)
	{
		return _inherit.GetContentShortTextColorAlign(state);
	}

	public override float GetContentShortTextColorAngle(PaletteState state)
	{
		return _inherit.GetContentShortTextColorAngle(state);
	}

	public override Image GetContentShortTextImage(PaletteState state)
	{
		return _inherit.GetContentShortTextImage(state);
	}

	public override PaletteImageStyle GetContentShortTextImageStyle(PaletteState state)
	{
		return _inherit.GetContentShortTextImageStyle(state);
	}

	public override PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state)
	{
		return _inherit.GetContentShortTextImageAlign(state);
	}

	public override Font GetContentLongTextFont(PaletteState state)
	{
		if (!(TreeNode is KryptonTreeNode { LongNodeFont: not null, LongNodeFont: var longNodeFont }))
		{
			return _inherit.GetContentLongTextFont(state);
		}
		return longNodeFont;
	}

	public override Font GetContentLongTextNewFont(PaletteState state)
	{
		return _inherit.GetContentLongTextNewFont(state);
	}

	public override PaletteTextHint GetContentLongTextHint(PaletteState state)
	{
		return _inherit.GetContentLongTextHint(state);
	}

	public override PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteState state)
	{
		return _inherit.GetContentLongTextPrefix(state);
	}

	public override InheritBool GetContentLongTextMultiLine(PaletteState state)
	{
		return _inherit.GetContentLongTextMultiLine(state);
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		return _inherit.GetContentLongTextTrim(state);
	}

	public override PaletteRelativeAlign GetContentLongTextH(PaletteState state)
	{
		return _inherit.GetContentLongTextH(state);
	}

	public override PaletteRelativeAlign GetContentLongTextV(PaletteState state)
	{
		return _inherit.GetContentLongTextV(state);
	}

	public override PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteState state)
	{
		return _inherit.GetContentLongTextMultiLineH(state);
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		if (TreeNode is KryptonTreeNode kryptonTreeNode && kryptonTreeNode.LongForeColor != Color.Empty)
		{
			return kryptonTreeNode.LongForeColor;
		}
		return _inherit.GetContentLongTextColor1(state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		if (TreeNode is KryptonTreeNode kryptonTreeNode && kryptonTreeNode.LongForeColor != Color.Empty)
		{
			return kryptonTreeNode.LongForeColor;
		}
		return _inherit.GetContentLongTextColor2(state);
	}

	public override PaletteColorStyle GetContentLongTextColorStyle(PaletteState state)
	{
		return _inherit.GetContentLongTextColorStyle(state);
	}

	public override PaletteRectangleAlign GetContentLongTextColorAlign(PaletteState state)
	{
		return _inherit.GetContentLongTextColorAlign(state);
	}

	public override float GetContentLongTextColorAngle(PaletteState state)
	{
		return _inherit.GetContentLongTextColorAngle(state);
	}

	public override Image GetContentLongTextImage(PaletteState state)
	{
		return _inherit.GetContentLongTextImage(state);
	}

	public override PaletteImageStyle GetContentLongTextImageStyle(PaletteState state)
	{
		return _inherit.GetContentLongTextImageStyle(state);
	}

	public override PaletteRectangleAlign GetContentLongTextImageAlign(PaletteState state)
	{
		return _inherit.GetContentLongTextImageAlign(state);
	}

	public override Padding GetContentPadding(PaletteState state)
	{
		return _inherit.GetContentPadding(state);
	}

	public override int GetContentAdjacentGap(PaletteState state)
	{
		return _inherit.GetContentAdjacentGap(state);
	}

	public override PaletteContentStyle GetContentStyle()
	{
		return _inherit.GetContentStyle();
	}
}
