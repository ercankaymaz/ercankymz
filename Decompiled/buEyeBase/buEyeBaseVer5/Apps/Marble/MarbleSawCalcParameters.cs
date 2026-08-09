using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleSawCalcParameters
{
	public double PlungeSpeed = 40.0;

	public double ForwardCutSpeed = 40.0;

	public double BackwardCutSpeed = 40.0;

	public double SafeDistanceZ = 100.0;

	public double SafeDistanceXY = 100.0;

	public double RapidDistance = 50.0;

	public bool SplineEnable = false;

	public double Splinedt = 0.1;

	public bool ZigzagMode = true;

	public bool MoveUpSafe = true;

	public MarbleCamAreaMode RoughAreaMode = MarbleCamAreaMode.Level;

	public bool isRough = false;

	public bool isFinish = false;

	public bool isOffset = false;

	public bool UseKinematic = true;

	public double DevideLength = 0.0;

	public Point3D ShiftPoint = new Point3D();

	public bool ShiftEnable = false;

	public bool UseClockDirection = false;

	public bool UseContantAngle = false;

	public double ConstantAngle = 0.0;

	public ClockDirectionType SetClockDir = ClockDirectionType.CCW;

	public bool UseLeadIn = false;

	public bool UseLeadOut = false;

	public double LeadInDistance = 0.0;

	public double LeadOutDistance = 0.0;

	public bool isFirst = false;

	public bool MoveSafeZDistance = false;

	public MarbleSawCalcParameters()
	{
	}

	public MarbleSawCalcParameters(MarbleSawCalcParameters data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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

	public MarbleSawCalcParameters(double plungespeed, double fwdcutspeed, double bwdcutspeed, double safedis, double rapiddis, bool zigzagmode, MarbleCamAreaMode areamode, bool moveupsafedis, bool isrough, bool isfinish, bool isoffset)
	{
		isOffset = isoffset;
		isFinish = isfinish;
		isOffset = isoffset;
		PlungeSpeed = plungespeed;
		ForwardCutSpeed = fwdcutspeed;
		BackwardCutSpeed = bwdcutspeed;
		SafeDistanceZ = safedis;
		RapidDistance = rapiddis;
		ZigzagMode = zigzagmode;
		RoughAreaMode = areamode;
		MoveUpSafe = moveupsafedis;
	}
}
