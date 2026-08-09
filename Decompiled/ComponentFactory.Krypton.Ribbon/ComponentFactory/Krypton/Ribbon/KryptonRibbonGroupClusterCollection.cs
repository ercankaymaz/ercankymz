using System;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class KryptonRibbonGroupClusterCollection : TypedRestrictCollection<KryptonRibbonGroupItem>
{
	private static readonly Type[] _types = new Type[2]
	{
		typeof(KryptonRibbonGroupClusterButton),
		typeof(KryptonRibbonGroupClusterColorButton)
	};

	public override Type[] RestrictTypes => _types;
}
