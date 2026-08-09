namespace buClass;

public class VariableDef
{
	public string Name = "";

	public object Value = null;

	public VariableDef()
	{
	}

	public VariableDef(string name)
	{
		Name = name;
	}

	public VariableDef(string name, object val)
	{
		Name = name;
		Value = val;
	}

	public override string ToString()
	{
		return Name + " = " + Value.ToString();
	}
}
