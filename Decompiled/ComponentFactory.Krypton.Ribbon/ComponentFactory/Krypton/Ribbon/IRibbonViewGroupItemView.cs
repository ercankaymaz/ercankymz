using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal interface IRibbonViewGroupItemView
{
	void SetGroupItemSize(GroupItemSize size);

	void ResetGroupItemSize();

	ViewBase GetFirstFocusItem();

	ViewBase GetLastFocusItem();

	ViewBase GetNextFocusItem(ViewBase current, ref bool matched);

	ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched);

	void GetGroupKeyTips(KeyTipInfoList keyTipList, int lineHint);
}
