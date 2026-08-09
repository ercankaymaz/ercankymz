using System;
using System.Reflection;

namespace buClass;

public class cParameter
{
	public object ValueBaseClass = null;

	public object Value = null;

	public string ValueAsString = null;

	public object SubParameter = null;

	public string Name = "Par";

	public Type Types = null;

	public FieldInfo Field = null;

	public PropertyInfo Property = null;

	public cParameter()
	{
	}

	public cParameter(string name, object val)
	{
		Value = val;
		Name = name;
	}

	public override string ToString()
	{
		return Name + " = " + Value.ToString() + " | " + Types.Name;
	}
}
