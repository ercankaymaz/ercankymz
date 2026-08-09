using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camNotch5 : buSerilization5
{
	public double NotchCutPersentage = 90.0;

	public UpDownDirectionType CutDirection = UpDownDirectionType.UpToDown;

	public ProfileNotchCutType NotchCutType = ProfileNotchCutType.BySawAndMilling;

	public CamCuttingWayDirectionType NotchCutDirection = CamCuttingWayDirectionType.TwoWayDirection;

	public camNotch5()
	{
	}

	public camNotch5(camNotch5 Data)
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
		return "CutDirection: " + CutDirection.ToString() + " , NotchCutType: " + NotchCutType.ToString() + " , NotchCutDirection: " + NotchCutDirection;
	}
}
