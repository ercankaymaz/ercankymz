using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonDesignGroup : ViewDrawRibbonDesignBase
{
	private static readonly Padding _padding = new Padding(5, 0, 0, 1);

	protected override Padding PreferredPadding => _padding;

	protected override Padding LayoutPadding => Padding.Empty;

	protected override Padding OuterPadding => _padding;

	public ViewDrawRibbonDesignGroup(KryptonRibbon ribbon, NeedPaintHandler needPaint)
		: base(ribbon, needPaint)
	{
	}

	public override string ToString()
	{
		return "ViewDrawRibbonDesignGroup:" + base.Id;
	}

	public override string GetShortText()
	{
		return "Group";
	}

	protected override void OnClick(object sender, EventArgs e)
	{
		base.Ribbon.SelectedTab.OnDesignTimeAddGroup();
	}
}
