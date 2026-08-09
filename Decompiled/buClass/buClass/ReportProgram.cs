using System.Reflection;

namespace buClass;

public class ReportProgram : buSerilization
{
	public string Name = "";

	public string Buy = "";

	public string email = "";

	public string Explanation = "";

	public string Company = "";

	public string Code = "";

	public ReportProgram()
	{
	}

	public ReportProgram(ReportProgram data)
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
