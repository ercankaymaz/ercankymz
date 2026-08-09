using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class marbleCamParameters : buSerilization
{
	public double SafeDistance = 50.0;

	public double StepUpDistance = 20.0;

	public bool AirDistanceEnable = true;

	public double AirDistance = 50.0;

	public double PlungeVelocity = 50.0;

	public double LeaveVelocity = 50.0;

	public double FirstEnterDistance = 0.0;

	public double LastOutDistance = 0.0;

	public double ForwardStepDownDistance = 5.0;

	public double BackwardStepDownDistance = 2.0;

	public double ForwardCuttingVelocity = 10.0;

	public double BackwardCuttingVelocity = 5.0;

	public bool UseCZero = false;

	public CamCuttingDirectionType CuttingDirection = CamCuttingDirectionType.Forward;

	public CamCuttingSideDirectionType CuttingSide = CamCuttingSideDirectionType.LeftToRight;

	public CamCuttingOrderDirectionType CuttingOrderDirection = CamCuttingOrderDirectionType.Region;

	public static List<string> Captions = new List<string>();

	public marbleCamParameters()
	{
	}

	public marbleCamParameters(marbleCamParameters data)
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

	public static void Copy(marbleCamParameters Source, ref marbleCamParameters Target)
	{
		Target = new marbleCamParameters(Source);
	}

	public override string ToString()
	{
		return "SafeDistance : " + SafeDistance + " , PlungeVelocity : " + PlungeVelocity;
	}
}
