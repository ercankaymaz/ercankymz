using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;

namespace buHandler;

public class buHandleVariableType
{
	public string VarName = _0093(107397128);

	public Type VarType = null;

	public object VarValue = null;

	[NonSerialized]
	internal static GetString _0093;

	public buHandleVariableType()
	{
	}

	public buHandleVariableType(string Name, Type type)
	{
		VarName = Name;
		VarType = type;
	}

	static buHandleVariableType()
	{
		Strings.CreateGetStringDelegate(typeof(buHandleVariableType));
	}
}
