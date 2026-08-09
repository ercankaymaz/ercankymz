using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonDesignTab : ViewDrawRibbonDesignBase
{
	private static readonly Padding _padding = new Padding(2, 4, 2, 0);

	protected override Padding PreferredPadding => _padding;

	protected override Padding LayoutPadding => _padding;

	protected override Padding OuterPadding => Padding.Empty;

	public ViewDrawRibbonDesignTab(KryptonRibbon ribbon, NeedPaintHandler needPaint)
		: base(ribbon, needPaint)
	{
	}

	public override string ToString()
	{
		return "ViewDrawRibbonDesignTab:" + base.Id;
	}

	public override string GetShortText()
	{
		return "Tab";
	}

	protected override void OnClick(object sender, EventArgs e)
	{
		base.Ribbon.OnDesignTimeAddTab();
	}
}
