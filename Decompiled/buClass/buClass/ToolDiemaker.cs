using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolDiemaker : buSerilization
{
	public double Width = 2.0;

	public double NickDiameter = 0.0;

	public double ID = 0.0;

	public double PositionOffset = 0.0;

	public double BridgeHeight = 0.0;

	public bool Pt1 = false;

	public bool Pt2 = true;

	public bool Pt3 = false;

	public bool Pt4 = false;

	public bool Pt6 = false;

	public bool Cutting = false;

	public bool Creasing = false;

	public bool Perfo = false;

	public bool CutCrease = false;

	public DiemakerToolModeType Mode = DiemakerToolModeType.StraightCut;

	public ToolDiemaker()
	{
	}

	public ToolDiemaker(ToolDiemaker geo)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(geo, ref CopiedClass);
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
		return "Pt2: " + Pt2 + " - Pt3: " + Pt3 + " - Cutting: " + Cutting + " - Creasing: " + Creasing + " - Perfo: " + Perfo + " - Cut Crease: " + CutCrease + " - Mode: " + Mode.ToString() + " - Width: " + Width.ToString("f2");
	}
}
