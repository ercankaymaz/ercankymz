using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataText : buSerilization
{
	public double TextWidth = 0.0;

	public double TextHeight = 0.0;

	public double TextAngle = 0.0;

	public string TextString = "";

	public Font TextFont = new Font("Arial", 12f);

	public ProfileScaleCenterType TextScaleCenter = ProfileScaleCenterType.Center;

	public Color TextColor = Color.Blue;

	public double TextThickness = 1.0;

	public ProfileOperationDataText()
	{
	}

	public ProfileOperationDataText(ProfileOperationDataText data)
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
		return TextString + " - Width : " + TextWidth + " - TextHeight : " + TextHeight;
	}
}
