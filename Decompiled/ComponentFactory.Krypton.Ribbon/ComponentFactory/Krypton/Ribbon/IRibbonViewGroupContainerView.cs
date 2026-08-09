using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal interface IRibbonViewGroupContainerView
{
	ItemSizeWidth[] GetPossibleSizes(ViewLayoutContext context);

	void SetSolutionSize(ItemSizeWidth size);

	void ResetSolutionSize();

	ViewBase GetFirstFocusItem();

	ViewBase GetLastFocusItem();

	ViewBase GetNextFocusItem(ViewBase current, ref bool matched);

	ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched);

	void GetGroupKeyTips(KeyTipInfoList keyTipList);
}
