using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;

namespace buMotion;

public class DefaultParameter
{
	public object Parameter = null;

	public string Defination = _0094(107397102);

	[NonSerialized]
	internal static GetString _0094;

	public DefaultParameter()
	{
	}

	public DefaultParameter(object Par, string defination)
	{
		Parameter = Par;
		Defination = defination;
	}

	static DefaultParameter()
	{
		Strings.CreateGetStringDelegate(typeof(DefaultParameter));
	}
}
