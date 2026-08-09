using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class SpinPattern : buSerilization
{
	public double AutoDevideLength = 5.0;

	public double AutoReturnLength = 1.0;

	public double StepCatchLength = 5.0;

	public double StepReturnLength = 1.0;

	public double CurveOffset = 1.0;

	public double CurveFinishOffset = 0.5;

	public double ArcRadius = 60.0;

	public double IncrementalSafeDistance = 50.0;

	public double CurveStartExtend = 0.0;

	public double CurveEndExtend = 0.0;

	public int RepeatCount = 1;

	public double LeaveHeight = 50.0;

	public double LeaveOffsetX = 0.0;

	public double LeaveOffsetAngle = 0.0;

	public double LeaveYLimit = 2.0;

	public double LeaveArcCornerRadius = 5.0;

	public double LeaveArcRadiusRatioFromHeight = 0.15;

	public double LeaveArcRadiusRatioFromHeight90To100 = 0.02;

	public double LeaveArcRadiusRatioFromHeight100To110 = 0.04;

	public double LeaveArcRadiusRatioFromHeight110To120 = 0.08;

	public double LeaveArcRadiusRatioFromHeight120To130 = 0.1;

	public double LeaveArcRadiusRatioFromHeight130To150 = 0.15;

	public double LeaveArcRadiusRatioFromHeight150To180 = 0.2;

	public double LeaveMaxAngle = 135.0;

	public double LeaveMinAngle = 90.0;

	public double LeaveDeltaAngleRatio = 0.7;

	public double ReturnSameWayOffset = 0.0;

	public bool FromMaxX = false;

	public bool isLeaveArc = true;

	public bool isArcCorner = false;

	public bool HidePrevious = false;

	public bool ReturnSameWay = false;

	public bool ReturnSameWayExtraMoveForArc = false;

	public double MinY = 0.0;

	public double CamFeed = 100.0;

	public double CamLeaveFeed = 200.0;

	public double SafeDistance = 10.0;

	public static List<string> Captions = new List<string>();

	public SpinPattern()
	{
	}

	public SpinPattern(SpinPattern data)
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
