using System.Collections.Generic;
using System.Reflection;

namespace buClass;

public class MoveHeightEventVar : buSerilization
{
	public AxesXYZ Axis = AxesXYZ.Z;

	public double MoveToPosition = 0.0;

	public TopBottomType ZType = TopBottomType.Top;

	public LeftRightType XType = LeftRightType.Left;

	public FrontBackType YType = FrontBackType.Front;

	public static List<string> Captions = new List<string>();

	public MoveHeightEventVar()
	{
	}

	public MoveHeightEventVar(MoveHeightEventVar data)
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
