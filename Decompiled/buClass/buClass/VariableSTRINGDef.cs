namespace buClass;

public class VariableSTRINGDef
{
	public string Name = "";

	public string Value = "";

	public VariableSTRINGDef()
	{
	}

	public VariableSTRINGDef(string name)
	{
		Name = name;
	}

	public VariableSTRINGDef(string name, string val)
	{
		Name = name;
		Value = val;
	}

	public override string ToString()
	{
		return Name + " = " + Value.ToString();
	}
}
