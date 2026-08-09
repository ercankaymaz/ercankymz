using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataFreeDraw : buSerilization
{
	public double FreeDrawWidth = 0.0;

	public double FreeDrawHeight = 0.0;

	public double FreeDrawAngle = 0.0;

	public ProfileScaleCenterType FreeDrawScaleCenter = ProfileScaleCenterType.Center;

	public Color FreeDrawColor = Color.Blue;

	public double FreeDrawThickness = 1.0;

	public ProfileOperationDataFreeDraw()
	{
	}

	public ProfileOperationDataFreeDraw(ProfileOperationDataFreeDraw data)
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
		return "Width : " + FreeDrawWidth + " - EllipseHeight : " + FreeDrawHeight;
	}
}
