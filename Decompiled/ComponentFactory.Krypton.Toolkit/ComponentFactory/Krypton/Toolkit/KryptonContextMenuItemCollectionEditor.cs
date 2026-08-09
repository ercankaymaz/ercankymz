using System;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonContextMenuItemCollectionEditor : CollectionEditor
{
	public KryptonContextMenuItemCollectionEditor()
		: base(typeof(KryptonContextMenuItemCollection))
	{
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[3]
		{
			typeof(KryptonContextMenuItem),
			typeof(KryptonContextMenuSeparator),
			typeof(KryptonContextMenuHeading)
		};
	}
}
