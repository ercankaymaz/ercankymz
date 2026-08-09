using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal interface IRibbonViewGroupSize
{
	GroupSizeWidth[] GetPossibleSizes(ViewLayoutContext context);

	void SetSolutionSize(ItemSizeWidth[] size);
}
