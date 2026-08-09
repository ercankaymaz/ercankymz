using System.Collections;
using System.Collections.Generic;

namespace MS.Internal;

internal struct Identifier
{
	private const int DEFAULT_TABLE_SIZE = 1024;

	public readonly int UniqueId;

	private static Hashtable _identifiers;

	private static List<string> _names;

	private static int _nextId;

	public static Identifier Undefined;

	public string Name => _names[UniqueId];

	public bool IsDefined => UniqueId != 0;

	private Identifier(int id)
	{
		UniqueId = id;
	}

	public static Identifier For(string name)
	{
		if (name == null)
		{
			name = string.Empty;
		}
		object obj = _identifiers[name];
		if (obj == null)
		{
			lock (_identifiers)
			{
				obj = _identifiers[name];
				if (obj == null)
				{
					obj = new Identifier(_nextId++);
					_names.Add(name);
					_identifiers[name] = obj;
				}
			}
		}
		return (Identifier)obj;
	}

	public override bool Equals(object other)
	{
		if (other is Identifier)
		{
			return UniqueId == ((Identifier)other).UniqueId;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return UniqueId;
	}

	public static bool operator ==(Identifier one, Identifier two)
	{
		return one.UniqueId == two.UniqueId;
	}

	public static bool operator !=(Identifier one, Identifier two)
	{
		return one.UniqueId != two.UniqueId;
	}

	public override string ToString()
	{
		return Name;
	}

	public static implicit operator string(Identifier identifier)
	{
		return identifier.Name;
	}

	static Identifier()
	{
		_identifiers = new Hashtable(1024);
		_names = new List<string>(1024);
		_nextId = 1;
		Undefined = default(Identifier);
		_names.Add("<Unknown>");
	}
}
