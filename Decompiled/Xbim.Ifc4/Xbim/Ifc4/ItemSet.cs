using System;
using Xbim.Common;
using Xbim.Common.Collections;

namespace Xbim.Ifc4;

public class ItemSet<T> : Xbim.Common.Collections.ItemSet<T>
{
	internal ItemSet(IPersistEntity entity, int capacity, int property)
		: base(entity, capacity, property)
	{
	}

	internal void InternalAdd(T value)
	{
		base.Internal.Add(value);
	}

	internal T InternalGetAt(int index)
	{
		if (index < base.Count)
		{
			return base[index];
		}
		if (index > base.Count)
		{
			throw new Exception("It is not possible to get object which is more that just the next after the last one.");
		}
		if (!typeof(IItemSet).IsAssignableFrom(typeof(T)))
		{
			return default(T);
		}
		T val = CreateNestedSet();
		InternalAdd(val);
		return val;
	}
}
