using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutMenuSepGap : ViewLayoutSeparator
{
	private PaletteContextMenuRedirect _stateCommon;

	private bool _standardStyle;

	public ViewLayoutMenuSepGap(PaletteContextMenuRedirect stateCommon, bool standardStyle)
		: base(0)
	{
		_stateCommon = stateCommon;
		_standardStyle = standardStyle;
	}

	public override string ToString()
	{
		return "ViewLayoutMenuSepGap:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Padding empty = Padding.Empty;
		empty = ((!_standardStyle) ? _stateCommon.ItemTextAlternate.GetContentPadding(PaletteState.Normal) : _stateCommon.ItemTextStandard.GetContentPadding(PaletteState.Normal));
		base.SeparatorSize = new Size(context.Renderer.RenderStandardBorder.GetBorderDisplayPadding(_stateCommon.ItemHighlight.Border, PaletteState.Normal, VisualOrientation.Top).Left + empty.Left, 0);
		return base.GetPreferredSize(context);
	}
}
