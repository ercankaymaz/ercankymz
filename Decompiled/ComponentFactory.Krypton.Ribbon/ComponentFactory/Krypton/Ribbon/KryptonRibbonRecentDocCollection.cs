using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class KryptonRibbonRecentDocCollection : TypedCollection<KryptonRibbonRecentDoc>
{
	public override KryptonRibbonRecentDoc this[string name]
	{
		get
		{
			using (IEnumerator<KryptonRibbonRecentDoc> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KryptonRibbonRecentDoc current = enumerator.Current;
					if (current.Text == name)
					{
						return current;
					}
				}
			}
			return base[name];
		}
	}
}
