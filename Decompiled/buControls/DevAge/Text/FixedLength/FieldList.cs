using System.Collections;

namespace DevAge.Text.FixedLength;

public class FieldList : DictionaryBase
{
	public virtual IField this[string key]
	{
		get
		{
			return (IField)base.Dictionary[key];
		}
		set
		{
			base.Dictionary[key] = value;
		}
	}

	public virtual ICollection Keys => base.Dictionary.Keys;

	public virtual ICollection Values => base.Dictionary.Values;

	public virtual void Add(IField value)
	{
		base.Dictionary.Add(value.Name, value);
	}

	public virtual bool Contains(string fieldName)
	{
		return base.Dictionary.Contains(fieldName);
	}

	public virtual bool ContainsKey(string fieldName)
	{
		return base.Dictionary.Contains(fieldName);
	}

	public virtual bool ContainsValue(IField value)
	{
		foreach (IField value2 in base.Dictionary.Values)
		{
			if (value2 == value)
			{
				return true;
			}
		}
		return false;
	}

	public virtual void Remove(string fieldName)
	{
		base.Dictionary.Remove(fieldName);
	}

	public IField[] GetSortedList()
	{
		IField[] array = new IField[base.Count];
		for (int i = 0; i < array.Length; i++)
		{
			foreach (IField value in Values)
			{
				if (value.Index == i)
				{
					array[i] = value;
					break;
				}
			}
			if (array[i] == null)
			{
				throw new FieldNotDefinedException(i);
			}
		}
		return array;
	}
}
