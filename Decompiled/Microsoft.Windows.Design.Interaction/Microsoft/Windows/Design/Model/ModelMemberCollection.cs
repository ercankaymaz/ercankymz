using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Windows.Design.Model;

public abstract class ModelMemberCollection<TItemType, TKeyType> : IEnumerable<TItemType>, IEnumerable where TKeyType : IEquatable<TKeyType>
{
	public TItemType this[string name]
	{
		get
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return Find(name, throwOnError: true);
		}
	}

	public TItemType this[TKeyType value]
	{
		get
		{
			Validate(value);
			return Find(value, throwOnError: true);
		}
	}

	internal ModelMemberCollection()
	{
	}

	public TItemType Find(string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		return Find(name, throwOnError: false);
	}

	protected abstract TItemType Find(string name, bool throwOnError);

	public TItemType Find(TKeyType value)
	{
		Validate(value);
		return Find(value, throwOnError: false);
	}

	protected abstract TItemType Find(TKeyType value, bool throwOnError);

	public abstract IEnumerator<TItemType> GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private static void Validate(TKeyType value)
	{
		if (typeof(TKeyType).IsValueType)
		{
			IEquatable<TKeyType> equatable = value;
			if (equatable.Equals(default(TKeyType)))
			{
				throw new ArgumentNullException("value");
			}
		}
		else if (value == null)
		{
			throw new ArgumentNullException("value");
		}
	}
}
