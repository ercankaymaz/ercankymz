using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class marbleProfileCut : buSerilization
{
	public double Length = 500.0;

	public double StartPosition = 0.0;

	public double BaseHeight = 50.0;

	public double Angle = 100.0;

	public double FinishStep = 10.0;

	public double RoughtOffset = 0.0;

	public double FinishOffset = 0.0;

	public double RoughtDevideLen = 2.0;

	public double FinishDevideLen = 1.0;

	public double DownDevideLen = 5.0;

	public bool RoughEnable = true;

	public bool FinishEnable = true;

	public bool MaxToMinDirection = false;

	public bool SmoothZigzagMode = false;

	public bool RoughZigzagMode = false;

	public bool MoveSafeDistanceForFinishZigzagMode = false;

	public double RotationAngle = 0.0;

	public VectorXYType Direction = VectorXYType.XVector;

	public CamAxisCountType CamTypeRough = CamAxisCountType.Axis5;

	public CamAxisCountType CamTypeFinish = CamAxisCountType.Axis5;

	public static List<string> Captions = new List<string>();

	public marbleProfileCut()
	{
	}

	public marbleProfileCut(marbleProfileCut data)
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

	public static void Copy(marbleProfileCut Source, ref marbleProfileCut Target)
	{
		Target = new marbleProfileCut(Source);
	}

	public override string ToString()
	{
		return "Length : " + Length + " , BaseHeight : " + BaseHeight;
	}
}
