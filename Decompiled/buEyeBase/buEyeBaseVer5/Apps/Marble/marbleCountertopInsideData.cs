using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopInsideData : buSerilization5
{
	public bool Enable = true;

	public bool LocationFromCenter = false;

	public double Thickness = 0.0;

	public double Rotation = 0.0;

	public double InsideWidth = 400.0;

	public double InsideHeight = 400.0;

	public double InsideDepth = 0.0;

	public double PositionX = 50.0;

	public double PositionY = 50.0;

	public double Radius = 0.0;

	public double Chamfer = 0.0;

	public bool CollapseEnable = false;

	public double CollapseOffset = 5.0;

	public double CollapseDepth = 2.0;

	public string SinkName = "";

	public MarbleToolType CollapseToolType = MarbleToolType.Milling;

	public MarbleCountertopInsideTypes InsideType = MarbleCountertopInsideTypes.Rectangle;

	public MarbleToolType ToolType = MarbleToolType.Saw;

	public marbleCountertopInsideData()
	{
	}

	public marbleCountertopInsideData(marbleCountertopInsideData data)
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
		string text = "Type : " + InsideType.ToString() + " " + Enable + " , Width : " + InsideWidth + " , Height : " + InsideHeight + " , X: " + PositionX + " , Y: " + PositionY;
		if (Radius > 0.0)
		{
			text = text + " , Rad: " + Radius;
		}
		if (Chamfer > 0.0)
		{
			text = text + " , Chamfer: " + Chamfer;
		}
		if (Rotation != 0.0)
		{
			text = text + " , Rot: " + Rotation;
		}
		if (CollapseEnable)
		{
			text += " , Collampse: True";
		}
		return text;
	}
}
