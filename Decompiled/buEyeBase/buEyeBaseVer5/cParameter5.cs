using System;
using System.Reflection;

namespace buEyeBaseVer5;

public class cParameter5
{
	public object ValueBaseClass = null;

	public object Value = null;

	public string ValueAsString = null;

	public object SubParameter = null;

	public string Name = "Par";

	public Type Types = null;

	public FieldInfo Field = null;

	public cParameter5()
	{
	}

	public cParameter5(string name)
	{
		Name = name;
	}

	public cParameter5(string name, object val)
	{
		Value = val;
		Name = name;
	}

	public override string ToString()
	{
		return Name + " = " + Value.ToString() + " | " + Types.Name;
	}
}
