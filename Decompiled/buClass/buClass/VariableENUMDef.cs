using System;

namespace buClass;

public class VariableENUMDef
{
	public string Name = "";

	public Enum Value = null;

	public VariableENUMDef()
	{
	}

	public VariableENUMDef(string name)
	{
		Name = name;
	}

	public VariableENUMDef(string name, Enum val)
	{
		Name = name;
		Value = val;
	}

	public override string ToString()
	{
		return Name + " = " + Value.ToString();
	}
}
