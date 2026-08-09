using System;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buShapeVisualition : buSerilization5
{
	public ColorType colorHole = new ColorType(Color.Blue, 220);

	public ColorType colorShape = new ColorType(Color.Orange, 220);

	public ColorType colorCut = new ColorType(Color.Green, 220);

	public ColorType colorProfiling = new ColorType(Color.Cyan, 220);

	public ColorType colorJunktion = new ColorType(Color.Purple, 220);

	public ColorType colorEngraving = new ColorType(Color.Silver, 220);

	public ColorType colorText = new ColorType(Color.Magenta, 220);

	public ColorType colorOnline = new ColorType(Color.Lime, 220);

	public ColorType colorOperation = new ColorType(Color.Pink, 220);

	public ColorType colorOperationSelected = new ColorType(Color.Gold, 220);

	public ColorType colorOperationDisable = new ColorType(Color.MediumVioletRed, 220);

	public ColorType colorOperationDisableSelected = new ColorType(Color.DarkGray, 220);

	public ColorType colorCam = new ColorType(Color.Red, 255);

	public buShapeVisualition()
	{
	}

	public buShapeVisualition(buShapeVisualition data)
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
