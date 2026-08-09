using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TuftCircularFillVar : buSerilization
{
	public double RowDistance = 10.0;

	public double FillOffset = 2.0;

	public bool OutterEnable = true;

	public double OutterOffset = 2.0;

	public int OutterCount = 1;

	public bool InnerEnable = true;

	public int InnerCount = 1;

	public double InnerOffset = 2.0;

	public ClockDirectionType OutterDirection = ClockDirectionType.CW;

	public tuftingFillOffsetType OutterType = tuftingFillOffsetType.Contour;

	public ClockDirectionType InnerDirection = ClockDirectionType.CW;

	public tuftingFillOffsetType InnerType = tuftingFillOffsetType.Contour;

	public double OffsetCheckFilter = 2.0;

	public InOutDirection Type = InOutDirection.OutsideToInside;

	public int TargetLayerIndex = 0;

	public bool RunCommandAfterFinish = true;

	public bool AskMe = true;

	public static List<string> Captions = new List<string>();

	public TuftCircularFillVar()
	{
	}

	public TuftCircularFillVar(TuftCircularFillVar data)
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
