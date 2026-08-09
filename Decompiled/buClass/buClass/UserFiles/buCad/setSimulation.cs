using System.Reflection;

namespace buClass.UserFiles.buCad;

public class setSimulation : buSerilization
{
	public bool ShowSimulationTool = true;

	public int SimulationInterval = 10;

	public setSimulation()
	{
	}

	public setSimulation(setSimulation data)
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
}
