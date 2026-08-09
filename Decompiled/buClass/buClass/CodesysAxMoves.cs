using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxMoves : buSerilization
{
	public double moveVelocity = 20.0;

	public double moveAcc = 1000.0;

	public double moveDec = 1000.0;

	public double moveJerk = 2500.0;

	public bool moveOverrideEnable = true;

	public bool moveDynamicVelocityFromFeed = false;

	public static List<string> Captions = new List<string>();

	public CodesysAxMoves()
	{
	}

	public CodesysAxMoves(CodesysAxMoves data)
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
		return "Vel : " + moveVelocity + " , Acc: " + moveAcc + " , Dec: " + moveDec + " , Jerk: " + moveJerk;
	}

	public string ToFileString(int Version)
	{
		string text = "";
		text = text + moveVelocity + ";" + moveAcc + ";" + moveDec;
		text = text + ";" + moveJerk;
		return text + ";" + buSerilization.BoolToString(moveOverrideEnable) + ";" + buSerilization.BoolToString(moveDynamicVelocityFromFeed);
	}
}
