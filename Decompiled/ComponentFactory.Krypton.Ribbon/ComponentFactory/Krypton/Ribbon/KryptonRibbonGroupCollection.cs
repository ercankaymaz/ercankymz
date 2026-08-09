using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class KryptonRibbonGroupCollection : TypedCollection<KryptonRibbonGroup>
{
	public override KryptonRibbonGroup this[string name]
	{
		get
		{
			using (IEnumerator<KryptonRibbonGroup> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KryptonRibbonGroup current = enumerator.Current;
					if (current.TextLine1 == name || current.TextLine2 == name || current.TextLine1 + " " + current.TextLine2 == name)
					{
						return current;
					}
				}
			}
			return base[name];
		}
	}
}
