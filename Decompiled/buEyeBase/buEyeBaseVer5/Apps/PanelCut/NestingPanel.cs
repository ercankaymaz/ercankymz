using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class NestingPanel : buSerilization5
{
	public List<NestingPanelNode> Nodes = new List<NestingPanelNode>();

	public List<Rectangle2D> CalculatedRectangles = new List<Rectangle2D>();

	public List<string> PanelCodes = new List<string>();

	public int Count = 0;

	public int PartCount = 0;

	public double PanelArea = 0.0;

	public double PartsArea = 0.0;

	public double TotalCutLength = 0.0;

	public double Waste = 0.0;

	public double Width = 0.0;

	public double Height = 0.0;

	public double Depth = 18.0;

	public string Explanation = "";

	public string Material = "Default";

	public NestingPanel()
	{
	}

	public NestingPanel(NestingPanel data)
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
