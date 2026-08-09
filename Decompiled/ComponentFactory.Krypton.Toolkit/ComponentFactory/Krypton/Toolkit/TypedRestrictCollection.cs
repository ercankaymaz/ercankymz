using System;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class TypedRestrictCollection<T> : TypedCollection<T> where T : class
{
	public abstract Type[] RestrictTypes { get; }

	protected bool IsTypeAllowed(object value)
	{
		bool result = false;
		Type[] restrictTypes = RestrictTypes;
		foreach (Type type in restrictTypes)
		{
			if (type.IsInstanceOfType(value))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public override int Add(object value)
	{
		if (value != null && !IsTypeAllowed(value))
		{
			throw new ArgumentException("Type to be added is not allowed in this collection.");
		}
		return base.Add(value);
	}

	public override void Insert(int index, object value)
	{
		if (value != null && !IsTypeAllowed(value))
		{
			throw new ArgumentException("Type to be added is not allowed in this collection.");
		}
		base.Insert(index, value);
	}

	public override void Insert(int index, T item)
	{
		if (item != null && !IsTypeAllowed(item))
		{
			throw new ArgumentException("Type to be added is not allowed in this collection.");
		}
		base.Insert(index, item);
	}

	public override void Add(T item)
	{
		if (item != null && !IsTypeAllowed(item))
		{
			throw new ArgumentException("Type to be added is not allowed in this collection.");
		}
		base.Add(item);
	}
}
