using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleMatrialCleanPars : buSerilization5
{
	public double StartX = 0.0;

	public double StartY = 0.0;

	public double BaseWidth = 1000.0;

	public double BaseHegiht = 500.0;

	public double OperationZ = 0.0;

	public double SafeDistance = 50.0;

	public double RapidDistance = 20.0;

	public double StepDistance = 5.0;

	public double StartHeight = 0.0;

	public double ZDownStep = 10.0;

	public double PlungeFeed = 20.0;

	public double CuttingFeed = 50.0;

	public double SpindleSpeed = 3000.0;

	public double CAxisAngle = 0.0;

	public bool ZigzagMode = true;

	public static List<string> Captions = new List<string>();

	public marbleMatrialCleanPars()
	{
	}

	public marbleMatrialCleanPars(marbleMatrialCleanPars data)
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

	public static void Copy(marbleMatrialCleanPars Source, ref marbleMatrialCleanPars Target)
	{
		Target = new marbleMatrialCleanPars(Source);
	}

	public override string ToString()
	{
		return "X : " + StartX + " , Y : " + StartY + " , BaseWidth : " + BaseWidth + " , BaseHegiht : " + BaseHegiht + " , OperationZ : " + OperationZ + " , StepDistance : " + StepDistance;
	}
}
