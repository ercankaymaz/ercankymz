using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xbim.Common;

namespace Xbim.Ifc4.IfcFunctions;

internal class ValuesArray<T> where T : class
{
	private readonly IPersist _instance;

	private readonly T[] _args;

	public ValuesArray(IPersist instance)
	{
		_instance = instance;
	}

	public ValuesArray(T[] args)
	{
		_args = args;
	}

	public static ValuesArray<T> operator *(ValuesArray<T> c1, ValuesArray<T> c2)
	{
		IEnumerable<T> first = c1.ToList();
		IEnumerable<T> second = c2.ToList();
		return new ValuesArray<T>(first.Intersect(second).ToArray());
	}

	private IEnumerable<T> ToList()
	{
		if (_args != null)
		{
			T[] args = _args;
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
				yield return $"{schema}.{tp.Name}".ToUpperInvariant() as T;
				tp = tp.GetTypeInfo().BaseType;
			}
		}
	}

	public bool Contains(T content)
	{
		_ = _instance;
		return ToList().Contains(content);
	}

	public int Count()
	{
		return ToList().Count();
	}
}
