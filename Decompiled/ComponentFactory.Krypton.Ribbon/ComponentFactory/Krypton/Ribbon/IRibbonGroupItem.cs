using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public interface IRibbonGroupItem
{
	KryptonRibbon Ribbon { get; set; }

	KryptonRibbonTab RibbonTab { get; set; }

	KryptonRibbonGroupContainer RibbonContainer { get; set; }

	bool Visible { get; }

	GroupItemSize ItemSizeMaximum { get; set; }

	GroupItemSize ItemSizeMinimum { get; set; }

	GroupItemSize ItemSizeCurrent { get; set; }

	int ItemGap(IRibbonGroupItem previousItem);

	ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint);
}
