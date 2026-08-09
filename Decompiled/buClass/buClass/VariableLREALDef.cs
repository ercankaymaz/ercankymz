namespace buClass;

public class VariableLREALDef
{
	public string Name = "";

	public double Value = 0.0;

	public VariableLREALDef()
	{
	}

	public VariableLREALDef(string name)
	{
		Name = name;
	}

	public VariableLREALDef(string name, double val)
	{
		Name = name;
		Value = val;
	}

	public override string ToString()
	{
		return Name + " = " + Value;
	}
}
