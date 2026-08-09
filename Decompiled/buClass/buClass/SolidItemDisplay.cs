using System;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class SolidItemDisplay : buSerilization
{
	public Color BorderColor = Color.Brown;

	public int BorderTransperancy = 200;

	public Color SkinColor = Color.Linen;

	public int SkinTransperancy = 100;

	public SolidItemDisplay()
	{
	}

	public SolidItemDisplay(Color skinColor, int skinTransperancy, Color borderColor, int borderTransperancy)
	{
		BorderColor = borderColor;
		BorderTransperancy = borderTransperancy;
		SkinColor = skinColor;
		SkinTransperancy = skinTransperancy;
	}

	public SolidItemDisplay(SolidItemDisplay disp)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(disp, ref CopiedClass);
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
		return "Skin Color : " + SkinColor.ToString() + " - Tranparancy: " + SkinTransperancy;
	}
}
