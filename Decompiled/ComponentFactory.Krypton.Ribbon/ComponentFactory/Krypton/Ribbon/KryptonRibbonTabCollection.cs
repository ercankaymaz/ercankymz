using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class KryptonRibbonTabCollection : TypedCollection<KryptonRibbonTab>
{
	public override KryptonRibbonTab this[string name]
	{
		get
		{
			using (IEnumerator<KryptonRibbonTab> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KryptonRibbonTab current = enumerator.Current;
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
