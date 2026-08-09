using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camHatch5 : buSerilization5
{
	public double CutStep = 5.0;

	public double XDirectionLength = 1000.0;

	public double YDirectionWidth = 500.0;

	public Pnt3D CornerPoint = new Pnt3D();

	public CamHatchCuttingDirection CuttingDirection = CamHatchCuttingDirection.XDirection;

	public CamHatchCuttingMode CuttingModes = CamHatchCuttingMode.ForwardNextBackward;

	public static List<string> Captions = new List<string>();

	public camHatch5()
	{
	}

	public camHatch5(camHatch5 Data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(Data, ref CopiedClass);
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

	public override string ToString()
	{
		return "XDirectionLength: " + XDirectionLength + " , CutStep: " + CutStep + " , YDirectionWidth: " + YDirectionWidth;
	}
}
