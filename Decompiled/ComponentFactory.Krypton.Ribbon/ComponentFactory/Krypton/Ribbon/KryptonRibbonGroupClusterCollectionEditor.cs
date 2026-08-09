using System;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonRibbonGroupClusterCollectionEditor : CollectionEditor
{
	public KryptonRibbonGroupClusterCollectionEditor()
		: base(typeof(KryptonRibbonGroupClusterCollection))
	{
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[2]
		{
			typeof(KryptonRibbonGroupClusterButton),
			typeof(KryptonRibbonGroupClusterColorButton)
		};
	}
}
