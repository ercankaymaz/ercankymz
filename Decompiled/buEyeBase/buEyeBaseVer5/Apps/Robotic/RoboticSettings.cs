using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class RoboticSettings : buSerilization5
{
	public int ToolFrame = 1;

	public int WorkFrame = 1;

	public int RobotFrame = 1;

	public double FeedOverride = 40.0;

	public double PlungeMoveDevideLength = 2.0;

	public double CuttingMoveDevideLength = 4.0;

	public double AngleMoveDevideLength = 5.0;

	public double FilterLength = 5.0;

	public bool UseSpline = false;

	public double Splinedt = 0.1;

	public double TangentAngle = -90.0;

	public bool UseLeadIn = true;

	public double LeadInLength = 100.0;

	public bool UseLeadOut = true;

	public double LeadOutLength = 100.0;

	public double SafeDistance = 100.0;

	public double ExtraDepth = 0.0;

	public RoboticSettings()
	{
	}

	public RoboticSettings(RoboticSettings data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
