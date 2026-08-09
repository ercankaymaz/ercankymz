using System.ComponentModel.Design;

namespace System.Windows.Forms;

internal class RibbonOrbRecentItemCollectionEditor : CollectionEditor
{
	public RibbonOrbRecentItemCollectionEditor()
		: base(typeof(RibbonOrbRecentItemCollection))
	{
	}

	protected override Type CreateCollectionItemType()
	{
		return typeof(RibbonOrbRecentItem);
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[2]
		{
			typeof(RibbonOrbRecentItem),
			typeof(RibbonSeparator)
		};
	}
}
