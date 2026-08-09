using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamCalcVars : buSerilization5
{
	public double BlockTrimedHeight = 0.0;

	public double BlockTrimedWidth = 0.0;

	public double PatternHeight = 0.0;

	public double PatternWidth = 0.0;

	public double XOffset = 0.0;

	public double YOffset = 0.0;

	public double ZOffset = 0.0;

	public double XRatio = 0.0;

	public double YRatio = 0.0;

	public double XMax = 0.0;

	public double YMax = 0.0;

	public int XCountActual = 1;

	public int YCountActual = 1;

	public double BlockIdealWidth = 0.0;

	public double BlockIdealHeight = 0.0;

	public bool isVertical = false;

	public double MaterialWidth = 2000.0;

	public double MaterialHeight = 1000.0;

	public double MaterialDepth = 500.0;

	public FoamPlaneType planeNames = FoamPlaneType.XZ;

	public FoamType TypeFoam = FoamType.VForm;

	public FoamOperationType Operation = FoamOperationType.Pattern;

	public FoamCalcVars()
	{
	}

	public FoamCalcVars(FoamCalcVars data)
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
