using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ClamperInsideCalc : buSerilization5
{
	public double minXClamper = 0.0;

	public double maxXClamper = 0.0;

	public double minXClamperLessSafe = 0.0;

	public double maxXClamperLessSafe = 0.0;

	public double XMovePlus = 0.0;

	public double XMoveMinus = 0.0;

	public double XMovePlusLessSafe = 0.0;

	public double XMoveMinusLessSafe = 0.0;

	public bool DrillInClamper = false;

	public bool DrillInClamperLassSafe = false;

	public ClamperInsideCalc()
	{
	}

	public ClamperInsideCalc(ClamperInsideCalc data)
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

	public override string ToString()
	{
		return "DrillInClamper: " + DrillInClamper + "minXClamper: " + minXClamper.ToString("f2") + " - maxXClamper: " + maxXClamper.ToString("f2") + " - XMoveMinus: " + XMoveMinus.ToString("f2") + " - XMovePlus: " + XMovePlus.ToString("f2");
	}
}
