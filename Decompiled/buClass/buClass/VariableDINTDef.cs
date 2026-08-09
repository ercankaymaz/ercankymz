namespace buClass;

public class VariableDINTDef
{
	public string Name = "";

	public int Value = 0;

	public VariableDINTDef()
	{
	}

	public VariableDINTDef(string name)
	{
		Name = name;
	}

	public VariableDINTDef(string name, int val)
	{
		Name = name;
		Value = val;
	}

	public override string ToString()
	{
		return Name + " = " + Value;
	}
}
