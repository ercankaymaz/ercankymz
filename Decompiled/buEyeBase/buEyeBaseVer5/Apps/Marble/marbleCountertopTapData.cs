using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopTapData : buSerilization5
{
	public bool Enable = true;

	public bool LocationFromCenter = false;

	public double TapDiameter = 50.0;

	public double TapDepth = 0.0;

	public double PositionX = 0.0;

	public double PositionY = 0.0;

	public bool CollapseEnable = false;

	public double CollapseOffset = 5.0;

	public double CollapseDepth = 2.0;

	public string TapName = "";

	public MarbleToolType ToolType = MarbleToolType.MillingHead;

	public marbleCountertopTapData()
	{
	}

	public marbleCountertopTapData(marbleCountertopTapData data)
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
		string text = "Tap : " + Enable + " , Dia : " + TapDiameter + " , X: " + PositionX + " , Y: " + PositionY;
		if (CollapseEnable)
		{
			text += " , Collampse: True";
		}
		return text;
	}
}
