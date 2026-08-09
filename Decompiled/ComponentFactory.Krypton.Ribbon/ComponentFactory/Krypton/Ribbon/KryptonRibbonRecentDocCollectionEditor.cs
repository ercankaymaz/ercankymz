using System;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonRibbonRecentDocCollectionEditor : CollectionEditor
{
	public KryptonRibbonRecentDocCollectionEditor()
		: base(typeof(KryptonRibbonRecentDocCollection))
	{
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[1] { typeof(KryptonRibbonRecentDoc) };
	}
}
