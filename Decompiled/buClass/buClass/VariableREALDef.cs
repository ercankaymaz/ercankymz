namespace buClass;

public class VariableREALDef
{
	public string Name = "";

	public float Value = 0f;

	public VariableREALDef()
	{
	}

	public VariableREALDef(string name)
	{
		Name = name;
	}

	public VariableREALDef(string name, float val)
	{
		Name = name;
		Value = val;
	}

	public override string ToString()
	{
		return Name + " = " + Value;
	}
}
