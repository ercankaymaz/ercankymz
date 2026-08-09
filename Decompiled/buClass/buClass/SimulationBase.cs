using System.Reflection;

namespace buClass;

public class SimulationBase : buSerilization
{
	public bool ShowSimulationTool = true;

	public bool DevideG0Movement = true;

	public double G0DevideLength = 2.0;

	public bool DevideG1Movement = true;

	public double G1DevideLength = 2.0;

	public bool UseG1Filter = true;

	public double G1FilterLength = 2.0;

	public SimulationBase()
	{
	}

	public SimulationBase(SimulationBase data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "G0DevideLength: " + G0DevideLength + " - G1DevideLength: " + G1DevideLength;
	}
}
