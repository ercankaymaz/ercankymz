using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ContextTabSetCollection : TypedCollection<ContextTabSet>
{
	public override ContextTabSet this[string name]
	{
		get
		{
			using (IEnumerator<ContextTabSet> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ContextTabSet current = enumerator.Current;
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
