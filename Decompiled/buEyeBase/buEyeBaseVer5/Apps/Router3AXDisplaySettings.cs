using System;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXDisplaySettings : buSerilization5
{
	public ColorType colorStock = new ColorType(Color.BurlyWood, 150);

	public ColorType colorPlaneTop = new ColorType(Color.DarkOrange, 180);

	public ColorType colorPlaneBottom = new ColorType(Color.LightBlue, 180);

	public ColorType colorPlaneClearance = new ColorType(Color.MediumVioletRed, 180);

	public ColorType colorPlaneRetract = new ColorType(Color.ForestGreen, 180);

	public ColorType colorPlaneText = new ColorType(Color.Black, 200);

	public ColorDrawType colorCamBase = new ColorDrawType(Color.Black, 255, 1.0);

	public ColorDrawType colorCamG1 = new ColorDrawType(Color.Red, 255, 2.0);

	public ColorDrawType colorCamG0 = new ColorDrawType(Color.Blue, 255, 2.0);

	public ColorDrawType colorCamPlunge = new ColorDrawType(Color.Lime, 255, 2.0);

	public ColorDrawType colorCamLeave = new ColorDrawType(Color.Cyan, 255, 2.0);

	public ColorDrawType colorCamLeadIn = new ColorDrawType(Color.Purple, 255, 2.0);

	public ColorDrawType colorCamLeadOut = new ColorDrawType(Color.Purple, 255, 2.0);

	public Router3AXDisplaySettings()
	{
	}

	public Router3AXDisplaySettings(Router3AXDisplaySettings data)
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
}
