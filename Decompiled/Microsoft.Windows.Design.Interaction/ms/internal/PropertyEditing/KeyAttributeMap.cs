using System;
using Microsoft.Windows.Design.PropertyEditing;

namespace MS.Internal.PropertyEditing;

internal class KeyAttributeMap<T> where T : Attribute
{
	private KeyAttributePair<T>[] mapArray;

	public T this[string key]
	{
		get
		{
			if (mapArray != null)
			{
				for (int i = 0; i < mapArray.Length; i++)
				{
					if (string.Equals(mapArray[i].Key, key, StringComparison.Ordinal))
					{
						return mapArray[i].Value;
					}
				}
			}
			return null;
		}
	}

	internal KeyAttributeMap(KeyAttributePair<T>[] mapArray)
	{
		this.mapArray = mapArray;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is KeyAttributeMap<T> keyAttributeMap))
		{
			return false;
		}
		if (mapArray == keyAttributeMap.mapArray)
		{
			return true;
		}
		if (mapArray == null || keyAttributeMap.mapArray == null)
		{
			return false;
		}
		if (mapArray.Length != keyAttributeMap.mapArray.Length)
		{
			return false;
		}
		for (int i = 0; i < mapArray.Length; i++)
		{
			if (!mapArray[i].Equals(keyAttributeMap.mapArray[i]))
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		int num = 0;
		for (int i = 0; i < mapArray.Length; i++)
		{
			num ^= mapArray[i].GetHashCode();
		}
		return num;
	}
}
