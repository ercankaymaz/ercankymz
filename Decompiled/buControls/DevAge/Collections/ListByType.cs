using System;
using System.Collections.Generic;

namespace DevAge.Collections;

public abstract class ListByType<T> : List<T>
{
	public T GetByType(Type searchType)
	{
		for (int i = 0; i < base.Count; i++)
		{
			if (searchType.IsAssignableFrom(base[i].GetType()))
			{
				return base[i];
			}
		}
		return default(T);
	}
}
