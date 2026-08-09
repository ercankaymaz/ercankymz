using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

public class camJewelContaurData : buSerilization
{
	public double Depth = 0.0;

	public CamClosedContourType Flow = CamClosedContourType.Inner;

	public double StepDownDistance = 1.0;

	public int StepDownCount = 1;

	public ClockDirectionType Direction = ClockDirectionType.CW;

	public CamMachiningSequenceType Sort = CamMachiningSequenceType.Region;

	public static List<string> Captions = new List<string>();

	public camJewelContaurData()
	{
	}

	public camJewelContaurData(camJewelContaurData data)
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
		return "( Jewel5AxContaur ->  )";
	}
}
