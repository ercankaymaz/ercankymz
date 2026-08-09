using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleEntityData : buSerilization5
{
	public double PlungeSpeed = 10.0;

	public double PlungeFirstSpeed = 5.0;

	public double CuttingSpeed = 20.0;

	public double CuttingFirstSpeed = 10.0;

	public double TargetZ = 0.0;

	public double CuttingStep = 20.0;

	public double CuttingFirstStep = 20.0;

	public int CollapseID = -1;

	public MarbleToolType ToolType = MarbleToolType.Saw;

	public marbleEntityData()
	{
	}

	public marbleEntityData(marbleEntityData data)
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

	public marbleEntityData(double plungespeed, double plungefirstspeed, double cuttingspeed, double cuttingfirstspeed, double cuttingstep, double cuttingfirststep, double targetz, MarbleToolType tooltype)
	{
		PlungeSpeed = plungespeed;
		CuttingStep = cuttingstep;
		CuttingSpeed = cuttingspeed;
		PlungeFirstSpeed = plungefirstspeed;
		CuttingFirstStep = cuttingfirststep;
		CuttingFirstSpeed = cuttingfirstspeed;
		TargetZ = targetz;
		ToolType = tooltype;
	}

	public override string ToString()
	{
		return "TargetZ: " + TargetZ + " - CuttingStep: " + CuttingStep + " - CuttingSpeed: " + CuttingSpeed;
	}
}
