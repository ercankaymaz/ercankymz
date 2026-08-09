using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace Xbim.Ifc4.IfcFunctions;

internal class TypesArray
{
	private readonly IPersist _instance;

	private readonly string[] _args;

	public TypesArray(IPersist instance)
	{
		_instance = instance;
	}

	public TypesArray(string[] args)
	{
		_args = args;
	}

	public static TypesArray operator *(TypesArray c1, TypesArray c2)
	{
		IEnumerable<string> first = c1.ToList();
		IEnumerable<string> second = c2.ToList();
		return new TypesArray(first.Intersect(second).ToArray());
	}

	private IEnumerable<string> ToList()
	{
		if (_args != null)
		{
			string[] args = _args;
			for (int i = 0; i < args.Length; i++)
			{
				yield return args[i];
			}
		}
		else if (_instance != null)
		{
			Type tp = _instance.GetType();
			string[] array = tp.FullName.Split(new string[1] { "." }, StringSplitOptions.None);
			string schema = array[1];
			while (tp != null)
			{
				yield return $"{schema}.{tp.Name}".ToUpperInvariant();
				tp = tp.BaseType;
			}
		}
	}

	public bool Contains(string content)
	{
		_ = _instance;
		return ToList().Contains(content);
	}

	public int Count()
	{
		return ToList().Count();
	}

	public override int GetHashCode()
	{
		if (_instance != null)
		{
			return _instance.GetType().GetHashCode();
		}
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		TypesArray typesArray = obj as TypesArray;
		if (typesArray == null)
		{
			return false;
		}
		if (typesArray._instance != null && _instance != null)
		{
			return _instance.GetType().Equals(typesArray._instance.GetType());
		}
		return base.Equals(obj);
	}

	public static bool operator ==(TypesArray c1, TypesArray c2)
	{
		if ((object)c1 == c2)
		{
			return true;
		}
		if ((object)c1 == null)
		{
			return false;
		}
		if ((object)c2 == null)
		{
			return false;
		}
		return c1.Equals(c2);
	}

	public static bool operator !=(TypesArray c1, TypesArray c2)
	{
		return !(c1 == c2);
	}
}
