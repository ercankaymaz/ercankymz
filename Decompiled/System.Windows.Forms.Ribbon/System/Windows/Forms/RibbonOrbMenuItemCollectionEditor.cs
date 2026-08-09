using System.ComponentModel.Design;

namespace System.Windows.Forms;

internal class RibbonOrbMenuItemCollectionEditor : CollectionEditor
{
	public RibbonOrbMenuItemCollectionEditor()
		: base(typeof(RibbonOrbMenuItemCollection))
	{
	}

	protected override Type CreateCollectionItemType()
	{
		return typeof(RibbonOrbMenuItem);
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[2]
		{
			typeof(RibbonOrbMenuItem),
			typeof(RibbonSeparator)
		};
	}
}
