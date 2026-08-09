using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Windows.Design.Interaction;

public class RelativeValueCollection : Collection<RelativeValue>
{
	public RelativeValue Find(RelativePosition position)
	{
		if (position == null)
		{
			throw new ArgumentNullException("position");
		}
		using (IEnumerator<RelativeValue> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				RelativeValue current = enumerator.Current;
				if (current.Position == position)
				{
					return current;
				}
			}
		}
		return default(RelativeValue);
	}
}
