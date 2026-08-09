using System;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonRibbonGroupContainerCollectionEditor : CollectionEditor
{
	public KryptonRibbonGroupContainerCollectionEditor()
		: base(typeof(KryptonRibbonGroupContainerCollection))
	{
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[3]
		{
			typeof(KryptonRibbonGroupLines),
			typeof(KryptonRibbonGroupTriple),
			typeof(KryptonRibbonGroupSeparator)
		};
	}
}
