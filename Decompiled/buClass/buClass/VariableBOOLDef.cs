namespace buClass;

public class VariableBOOLDef
{
	public string Name = "";

	public bool Value = false;

	public VariableBOOLDef()
	{
	}

	public VariableBOOLDef(string name)
	{
		Name = name;
	}

	public VariableBOOLDef(string name, bool val)
	{
		Name = name;
		Value = val;
	}

	public override string ToString()
	{
		return Name + " = " + Value;
	}
}
