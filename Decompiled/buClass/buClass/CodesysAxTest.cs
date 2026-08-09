using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxTest : buSerilization
{
	public double testJogVelocity = 20.0;

	public double testMoveVelocity = 20.0;

	public double testWaitTime = 20.0;

	public double testPosition1 = 0.0;

	public double testPosition2 = 0.0;

	public double testIncrementalPosition = 0.0;

	public static List<string> Captions = new List<string>();

	public CodesysAxTest()
	{
	}

	public CodesysAxTest(CodesysAxTest data)
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
		return "testPosition1 : " + testPosition1 + " , testPosition2: " + testPosition2 + " , testJogVelocity: " + testJogVelocity + " , testMoveVelocity: " + testMoveVelocity;
	}

	public string ToFileString(int Version)
	{
		string text = "";
		text = text + testJogVelocity + ";" + testMoveVelocity + ";" + testWaitTime;
		return text + ";" + testPosition1 + ";" + testPosition2 + ";" + testIncrementalPosition;
	}
}
