using System;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class KryptonRibbonGroupContainerCollection : TypedRestrictCollection<KryptonRibbonGroupContainer>
{
	private static readonly Type[] _types = new Type[4]
	{
		typeof(KryptonRibbonGroupLines),
		typeof(KryptonRibbonGroupTriple),
		typeof(KryptonRibbonGroupSeparator),
		typeof(KryptonRibbonGroupGallery)
	};

	public override Type[] RestrictTypes => _types;
}
