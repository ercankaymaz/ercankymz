#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonGroupsArea : ViewDrawPanel
{
	private static readonly Padding _preferredNormalPadding = new Padding(0, 0, 1, 0);

	private static readonly Padding _preferredMinimizedPadding = new Padding(0, 1, 1, 0);

	private static readonly Padding _layoutNormalPadding = new Padding(0, -1, 1, 1);

	private static readonly Padding _layoutMinimizedPadding = new Padding(0, 0, 1, 1);

	private KryptonRibbon _ribbon;

	private ViewDrawRibbonGroupsBorderSynch _viewGroups;

	private PaletteBackInheritRedirect _backInherit;

	public ViewDrawRibbonGroupsBorderSynch ViewGroups => _viewGroups;

	public PaletteBackStyle BackStyle
	{
		get
		{
			return _backInherit.Style;
		}
		set
		{
			_backInherit.Style = value;
		}
	}

	public ViewLayoutRibbonGroupsArea(KryptonRibbon ribbon, PaletteRedirect redirect, NeedPaintHandler needPaintDelegate)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(redirect != null);
		Debug.Assert(needPaintDelegate != null);
		_ribbon = ribbon;
		_backInherit = new PaletteBackInheritRedirect(redirect, PaletteBackStyle.PanelClient);
		SetPalettes(_backInherit);
		_viewGroups = new ViewDrawRibbonGroupsBorderSynch(ribbon, needPaintDelegate);
		Add(_viewGroups);
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonGroupsArea:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size size = new Size(0, _ribbon.CalculatedValues.GroupsHeight);
		if (_ribbon.RealMinimizedMode)
		{
			return new Size(size.Width + _preferredMinimizedPadding.Horizontal, size.Height + _preferredMinimizedPadding.Vertical);
		}
		return new Size(size.Width + _preferredNormalPadding.Horizontal, size.Height + _preferredNormalPadding.Vertical);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		Padding padding = (_ribbon.RealMinimizedMode ? _layoutMinimizedPadding : _layoutNormalPadding);
		context.DisplayRectangle = new Rectangle(ClientLocation.X + padding.Left, ClientLocation.Y + padding.Top, ClientWidth - padding.Horizontal, ClientHeight - padding.Vertical);
		base.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}
}
