using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class HalfBridgeItem : buSerilization
{
	public bool LeftEnable;

	public double LeftWidth;

	public double LeftHeight;

	public Pnt3D LeftExtractPosition = new Pnt3D();

	public ToolBase LeftTool = new ToolBase();

	public List<Pnt3D> LeftCamPoints = new List<Pnt3D>();

	public bool RightEnable;

	public double RightWidth;

	public double RightHeight;

	public Pnt3D RightExtractPosition = new Pnt3D();

	public ToolBase RightTool = new ToolBase();

	public List<Pnt3D> RightCamPoints = new List<Pnt3D>();

	public HalfBridgeItem()
	{
	}

	public HalfBridgeItem(bool LeftEnable_, double LeftWidth_, double LeftHeight_, Pnt3D LeftExtractPosition_, bool RightEnable_, double RightWidth_, double RightHeight_, Pnt3D RightExtractPosition_)
	{
		LeftEnable = LeftEnable_;
		LeftWidth = LeftWidth_;
		LeftHeight = LeftHeight_;
		LeftExtractPosition = LeftExtractPosition_;
		RightEnable = RightEnable_;
		RightWidth = RightWidth_;
		RightHeight = RightHeight_;
		RightExtractPosition = RightExtractPosition_;
	}

	public HalfBridgeItem(HalfBridgeItem data)
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
		return "LeftEnable : " + LeftEnable + " ; RightEnable : " + RightEnable;
	}
}
