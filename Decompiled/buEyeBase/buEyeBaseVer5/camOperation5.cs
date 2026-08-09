using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class camOperation5 : buSerilization5
{
	public double Height = 0.0;

	public double Depth = 0.0;

	public double DepthUp = 0.0;

	public double Width = 0.0;

	public double BaseThickness = 0.0;

	public double Overlap = 0.0;

	public double Stepover = 0.0;

	public double SurfaceOffset = 0.0;

	public bool FinishEnable = false;

	public bool AreaClearanceEnable = false;

	public bool MakeCenterOffset = false;

	public bool isClosed = false;

	public bool SpiralMode = false;

	public bool isCircularCam = false;

	public Point3D BorderMinOffset = new Point3D();

	public Point3D BorderMaxOffset = new Point3D();

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

	public camOperation5()
	{
	}

	public camOperation5(double height, ClockDirectionType direction)
	{
		Height = height;
		Direction = direction;
	}

	public camOperation5(camOperation5 data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
