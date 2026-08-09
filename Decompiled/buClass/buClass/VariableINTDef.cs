namespace buClass;

public class VariableINTDef
{
	public string Name = "";

	public short Value = 0;

	public VariableINTDef()
	{
	}

	public VariableINTDef(string name)
	{
		Name = name;
	}

	public VariableINTDef(string name, short val)
	{
		Name = name;
		Value = val;
	}

	public override string ToString()
	{
		return Name + " = " + Value;
	}
}
