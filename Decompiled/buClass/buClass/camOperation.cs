using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camOperation : buSerilization
{
	public double Height = 0.0;

	public double Depth = 0.0;

	public bool FinishEnable = false;

	public bool AreaClearanceEnable = false;

	public bool MakeCenterOffset = false;

	public bool isClosed = false;

	public ClockDirectionType Direction = ClockDirectionType.CCW;

	public InToOutType AreaClearanceDirection = InToOutType.OutToIn;

	public CamSafeForPlunge SafePlungeForFirstPoint = CamSafeForPlunge.Safe;

	public CamSafeForLeave SafeLeaveForLastPoint = CamSafeForLeave.Safe;

	public CamSafeForPlunge SafePlungeForContoutToContour = CamSafeForPlunge.Safe;

	public CamSafeForLeave SafeLeaveForContoutToContour = CamSafeForLeave.Safe;

	public CamSafeForPlunge SafePlungeForIfLastAndNextPointSameXY = CamSafeForPlunge.None;

	public CamSafeForLeave SafeLeaveForIfLastAndNextPointSameXY = CamSafeForLeave.None;

	public bool PocketStepToStepSmallSafe = true;

	public Pnt6D Point = new Pnt6D();

	public double Thickness = 0.0;

	public double TargetZ = 0.0;

	public List<double> StepHeights = new List<double>();

	public static List<string> Captions = new List<string>();

	public camOperation()
	{
	}

	public camOperation(double height, ClockDirectionType direction)
	{
		Height = height;
		Direction = direction;
	}

	public camOperation(camOperation data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		StepHeights.Clear();
		for (int j = 0; j <= data.StepHeights.Count - 1; j++)
		{
			StepHeights.Add(data.StepHeights[j]);
		}
	}

	public override string ToString()
	{
		return Height + " , Direction: " + Direction;
	}
}
