using System;
using System.Collections.Generic;

namespace SourceGrid;

[Serializable]
public class RangeCollection : List<Range>
{
	public bool ContainsCell(Position p_Position)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Contains(p_Position))
				{
					return true;
				}
			}
		}
		return false;
	}
}
