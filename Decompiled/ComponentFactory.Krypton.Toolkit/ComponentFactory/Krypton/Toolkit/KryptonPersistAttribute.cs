using System;

namespace ComponentFactory.Krypton.Toolkit;

[Serializable]
[AttributeUsage(AttributeTargets.Property)]
public sealed class KryptonPersistAttribute : Attribute
{
	private bool _navigate;

	private bool _populate;

	public bool Navigate
	{
		get
		{
			return _navigate;
		}
		set
		{
			_navigate = value;
		}
	}

	public bool Populate
	{
		get
		{
			return _populate;
		}
		set
		{
			_populate = value;
		}
	}

	public KryptonPersistAttribute()
		: this(navigate: true, populate: true)
	{
	}

	public KryptonPersistAttribute(bool navigate)
		: this(navigate, populate: true)
	{
	}

	public KryptonPersistAttribute(bool navigate, bool populate)
	{
		_navigate = navigate;
		_populate = populate;
	}
}
