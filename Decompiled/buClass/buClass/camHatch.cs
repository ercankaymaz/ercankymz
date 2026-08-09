using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camHatch : buSerilization
{
	public double OperationZ = 0.0;

	public double CutLength = 1000.0;

	public double CutStep = 5.0;

	public double TotalWidth = 100.0;

	public Pnt3D CornerPoint = new Pnt3D();

	public CamHatchCuttingDirection CuttingDirection = CamHatchCuttingDirection.XDirection;

	public CamHatchCuttingMode CuttingModes = CamHatchCuttingMode.ForwardNextBackward;

	public static List<string> Captions = new List<string>();

	public camHatch()
	{
	}

	public camHatch(double operationZ, double cutLength, double cutStep, double totalWidth, CamHatchCuttingDirection cuttingDirection, CamHatchCuttingMode cuttingModes, Pnt3D CornerPnt)
	{
		OperationZ = operationZ;
		CutLength = cutLength;
		CutStep = cutStep;
		TotalWidth = totalWidth;
		CuttingDirection = cuttingDirection;
		CuttingModes = cuttingModes;
		CornerPoint = new Pnt3D(CornerPnt);
	}

	public camHatch(camHatch Data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Data, ref CopiedClass);
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

	public override string ToString()
	{
		return "OperationZ: " + OperationZ + " , CutLength: " + CutLength + " , CutStep: " + CutStep + " , TotalWidth: " + TotalWidth;
	}
}
