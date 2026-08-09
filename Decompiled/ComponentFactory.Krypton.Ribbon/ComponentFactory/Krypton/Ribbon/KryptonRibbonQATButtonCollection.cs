using System;
using System.ComponentModel;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class KryptonRibbonQATButtonCollection : TypedRestrictCollection<Component>
{
	private static readonly Type[] _types = new Type[1] { typeof(IQuickAccessToolbarButton) };

	public override Type[] RestrictTypes => _types;
}
