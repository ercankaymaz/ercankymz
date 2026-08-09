using System.Collections;

namespace DevAge.Configuration;

public class PersistableItemDictionary : DictionaryBase
{
	public virtual PersistableItem this[string key]
	{
		get
		{
			return (PersistableItem)base.Dictionary[key];
		}
		set
		{
			base.Dictionary[key] = value;
		}
	}

	public virtual ICollection Keys => base.Dictionary.Keys;

	public virtual ICollection Values => base.Dictionary.Values;

	public virtual void Add(string key, PersistableItem value)
	{
		base.Dictionary.Add(key, value);
	}

	public virtual bool Contains(string key)
	{
		return base.Dictionary.Contains(key);
	}

	public virtual bool ContainsKey(string key)
	{
		return base.Dictionary.Contains(key);
	}

	public virtual bool ContainsValue(PersistableItem value)
	{
		foreach (PersistableItem value2 in base.Dictionary.Values)
		{
			if (value2 == value)
			{
				return true;
			}
		}
		return false;
	}

	public virtual void Remove(string key)
	{
		base.Dictionary.Remove(key);
	}
}
