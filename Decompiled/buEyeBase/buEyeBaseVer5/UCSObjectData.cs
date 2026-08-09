using System;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class UCSObjectData : buSerilization5
{
	public double ArrowTotalLen = 30.0;

	public double ArrowDiameter = 4.0;

	public double ArrowConeDiameter = 6.0;

	public double ArrowConeLen = 9.0;

	public double BallDiameter = 6.0;

	public Color XAxisColor = Color.Red;

	public Color YAxisColor = Color.Blue;

	public Color ZAxisColor = Color.Green;

	public Color BallColor = Color.Gray;

	public UCSObjectData()
	{
	}

	public UCSObjectData(UCSObjectData data)
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

	public static void CreateUCSDataFromLength(double Length, ref UCSObjectData UcsData)
	{
		UcsData.ArrowTotalLen = Length;
		UcsData.ArrowConeLen = Length * 0.3;
		UcsData.ArrowDiameter = Length * 0.2;
		UcsData.ArrowConeDiameter = UcsData.ArrowDiameter * 1.3;
		UcsData.BallDiameter = UcsData.ArrowDiameter * 1.2;
	}
}
