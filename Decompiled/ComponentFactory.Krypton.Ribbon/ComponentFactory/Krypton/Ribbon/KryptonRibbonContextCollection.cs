using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class KryptonRibbonContextCollection : TypedCollection<KryptonRibbonContext>
{
	public override KryptonRibbonContext this[string name]
	{
		get
		{
			using (IEnumerator<KryptonRibbonContext> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KryptonRibbonContext current = enumerator.Current;
					if (current.ContextName == name)
					{
						return current;
					}
				}
			}
			return base[name];
		}
	}
}
