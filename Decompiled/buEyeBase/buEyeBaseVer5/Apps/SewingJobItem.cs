using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingJobItem : buSerilization5
{
	public double PositionX = 0.0;

	public double PositionY = 0.0;

	public double PositionA = 0.0;

	public double StitchStep = 0.0;

	public double HeadSpeed = 0.0;

	public double FootHeight = 0.0;

	public bool StitchedWay = false;

	public int StitchCount = 0;

	public int Style = 0;

	public int Code0 = 0;

	public int Code1 = 0;

	public int Code2 = 0;

	public int Code3 = 0;

	public int Code4 = 0;

	public int Code5 = 0;

	public SewingJobItem()
	{
	}

	public SewingJobItem(SewingJobItem data)
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
		return "PositionX : " + PositionX.ToString("f2") + ", PositionY : " + PositionY.ToString("f2") + ", PositionA : " + PositionA.ToString("f2") + ", StitchStep : " + StitchStep.ToString("f2") + ", HeadSpeed : " + HeadSpeed.ToString("f2") + ", StitchedWay : " + StitchedWay + ", StitchCount : " + StitchCount.ToString("f0") + ", Style : " + Style.ToString("f0") + ", Code1 : " + Code1.ToString("f0") + ", Code2 : " + Code2.ToString("f0") + ", Code3 : " + Code3.ToString("f0") + ", Code4 : " + Code4.ToString("f0") + ", Code5 : " + Code5.ToString("f0");
	}
}
