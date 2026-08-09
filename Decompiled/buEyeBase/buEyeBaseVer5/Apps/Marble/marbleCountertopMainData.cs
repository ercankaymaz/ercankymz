using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopMainData : buSerilization5
{
	public MarbleCountertopTypes CountertopType = MarbleCountertopTypes.RectangleType1;

	public double Width = 2200.0;

	public double Height = 2000.0;

	public double TopWidth = 1800.0;

	public double BottomWidth = 2000.0;

	public double TopLegWidth = 600.0;

	public double BottomLegHeight = 600.0;

	public double Rotation = 0.0;

	public double Radius = 0.0;

	public double Chamfer = 0.0;

	public double Thickness = 20.0;

	public double TargetZ = 0.0;

	public bool CollapseTopEnable = false;

	public double CollapseTopOffset = 5.0;

	public double CollapseTopDepth = 2.0;

	public bool CollapseBottomEnable = false;

	public double CollapseBottomOffset = 5.0;

	public double CollapseBottomDepth = 2.0;

	public MarbleToolType ToolType = MarbleToolType.Saw;

	public static List<string> Captions = new List<string>();

	public marbleCountertopMainData()
	{
	}

	public marbleCountertopMainData(marbleCountertopMainData data)
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
		return "Width : " + Width + " , Height : " + Height + " , Thickness : " + Thickness + " , Rotation : " + Rotation;
	}
}
