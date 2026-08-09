using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class LineerHatchVar : buSerilization
{
	public double Distance = 10.0;

	public double OffsetOutter = 2.0;

	public double OffsetInner = 2.0;

	public double Angle = 0.0;

	public double ConnectionLimitAngle = -1.0;

	public double LengthFilter = 2.0;

	public double OffsetCheckFilter = 2.0;

	public HatchType Type = HatchType.Horizontal;

	public VerticalDirectionType VerticalMoveDirection = VerticalDirectionType.DownToUp;

	public HorizontalDirectionType HorizontalMoveDirection = HorizontalDirectionType.LeftToRight;

	public HatchSortType Sort = HatchSortType.ByClosestLength;

	public HatchAreaType AreaType = HatchAreaType.Region;

	public bool SingleDirection = false;

	public int TargetLayerIndex = 0;

	public static List<string> Captions = new List<string>();

	public LineerHatchVar()
	{
	}

	public LineerHatchVar(LineerHatchVar data)
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
