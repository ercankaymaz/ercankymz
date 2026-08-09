using System.Collections.Generic;

namespace ModuleWorks;

public class DualDictionary<Type1, Type2>
{
	private readonly Dictionary<Type1, Type2> dict1 = new Dictionary<Type1, Type2>();

	private readonly Dictionary<Type2, Type1> dict2 = new Dictionary<Type2, Type1>();

	public Type2 this[Type1 key]
	{
		get
		{
			return dict1[key];
		}
		set
		{
			dict1[key] = value;
			dict2[value] = key;
		}
	}

	public Type1 this[Type2 key]
	{
		get
		{
			return dict2[key];
		}
		set
		{
			dict2[key] = value;
			dict1[value] = key;
		}
	}

	public int Count => dict1.Count;

	public Dictionary<Type1, Type2>.KeyCollection Keys1 => dict1.Keys;

	public Dictionary<Type1, Type2>.ValueCollection Values1 => dict1.Values;

	public Dictionary<Type2, Type1>.KeyCollection Keys2 => dict2.Keys;

	public Dictionary<Type2, Type1>.ValueCollection Values2 => dict2.Values;

	public void Add(Type1 object1, Type2 object2)
	{
		dict1.Add(object1, object2);
		dict2.Add(object2, object1);
	}

	public bool Remove(Type1 key)
	{
		if (dict1.TryGetValue(key, out var value))
		{
			dict2.Remove(value);
			dict1.Remove(key);
			return true;
		}
		return false;
	}

	public bool Remove(Type2 key)
	{
		if (dict2.TryGetValue(key, out var value))
		{
			dict1.Remove(value);
			dict2.Remove(key);
			return true;
		}
		return false;
	}

	public bool TryGetValue(Type1 key, out Type2 value)
	{
		return dict1.TryGetValue(key, out value);
	}

	public bool TryGetValue(Type2 key, out Type1 value)
	{
		return dict2.TryGetValue(key, out value);
	}

	public Dictionary<Type1, Type2>.Enumerator GetEnumerator1()
	{
		return dict1.GetEnumerator();
	}

	public Dictionary<Type2, Type1>.Enumerator GetEnumerator2()
	{
		return dict2.GetEnumerator();
	}

	public override int GetHashCode()
	{
		return dict1.GetHashCode() | dict2.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is DualDictionary<Type1, Type2> dualDictionary)
		{
			if (dict1.Equals(dualDictionary.dict1))
			{
				return dict2.Equals(dualDictionary.dict2);
			}
			return false;
		}
		return false;
	}

	public bool ContainsKey(Type1 key)
	{
		return dict1.ContainsKey(key);
	}

	public bool ContainsKey(Type2 key)
	{
		return dict2.ContainsKey(key);
	}

	public void Clear()
	{
		dict1.Clear();
		dict2.Clear();
	}
}
