using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataCut : buSerilization
{
	public double CutWidth = 10.0;

	public double CutHeigth = 50.0;

	public double CutDepth = 10.0;

	public double CutAngle = 0.0;

	public Color CutColor = Color.Blue;

	public double CutThickness = 1.0;

	public ProfileOperationDataCut()
	{
	}

	public ProfileOperationDataCut(ProfileOperationDataCut data)
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
		return "Width : " + CutWidth + " - H : " + CutHeigth;
	}
}
