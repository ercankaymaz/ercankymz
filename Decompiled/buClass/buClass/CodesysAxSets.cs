using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxSets : buSerilization
{
	public double setUnit = 5.0;

	public double setPulse = 50001.0;

	public double setGearRatio = 1.0;

	public bool setReverseDirection = false;

	public double setEmergencyDec = 50000.0;

	public double setMaxVelocity = 100.0;

	public double setMaxAcc = 10000.0;

	public double setMaxDec = 10000.0;

	public double setMaxJerk = 20000.0;

	public CodesysRampType setRampType = CodesysRampType.QuadraticRamp;

	public bool setSoftLimitEnable = false;

	public bool setSoftLimitControlFromPLC = false;

	public double setSoftLimitPositive = 0.0;

	public double setSoftLimitNegative = 0.0;

	public bool setSoftLimitErrorDecEnable = false;

	public double setSoftLimitErrorDec = 10000.0;

	public double setSoftLimitErrorMaxDistance = 1.0;

	public bool setHardLimitEnable = false;

	public double setDataLimitPositive = 0.0;

	public double setDataLimitNegative = 0.0;

	public double setParkPosition = 0.0;

	public bool setGantryEnable = false;

	public int setGantryNumerator = 1;

	public int setGantryDenumerator = 1;

	public double setPositionDoneLimit = 0.002;

	public CodesysMovementType setAxesType = CodesysMovementType.Linear;

	public static List<string> Captions = new List<string>();

	public CodesysAxSets()
	{
	}

	public CodesysAxSets(CodesysAxSets data)
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

	public override string ToString()
	{
		return "Unit: " + setUnit + " ; setPulse: " + setPulse;
	}

	public string ToFileString(int Version)
	{
		string text = "";
		text = text + setUnit + ";" + setPulse + ";" + setGearRatio;
		text = text + ";" + buSerilization.BoolToString(setReverseDirection) + ";" + setEmergencyDec + ";" + setMaxVelocity;
		text = text + ";" + setMaxAcc + ";" + setMaxDec + ";" + setMaxJerk;
		text = text + ";" + Convert.ToInt32(setRampType) + ";" + buSerilization.BoolToString(setSoftLimitEnable) + ";" + buSerilization.BoolToString(setSoftLimitControlFromPLC);
		text = text + ";" + setSoftLimitPositive + ";" + setSoftLimitNegative + ";" + buSerilization.BoolToString(setSoftLimitErrorDecEnable);
		text = text + ";" + setSoftLimitErrorDec + ";" + setSoftLimitErrorMaxDistance + ";" + buSerilization.BoolToString(setHardLimitEnable);
		text = text + ";" + setDataLimitPositive + ";" + setDataLimitNegative + ";" + setParkPosition;
		return text + ";" + buSerilization.BoolToString(setGantryEnable) + ";" + setGantryNumerator + ";" + setGantryDenumerator + ";" + setPositionDoneLimit;
	}
}
