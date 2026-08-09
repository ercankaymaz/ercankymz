using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingPunchTool : ToolBase
{
	public bool Pt1 = false;

	public bool Pt2 = false;

	public bool Pt3 = false;

	public bool Pt4 = false;

	public double Width = 0.0;

	public double Offset = 0.0;

	public bool Bridge12 = false;

	public bool Bridge15 = false;

	public bool Bridge18 = false;

	public int ToolNoOriginal = 0;

	public int Mode = 0;

	public double Pt = 0.0;

	public BendingToolType BendingToolType = BendingToolType.StraightCut;

	public bool Cutting = false;

	public bool Creasing = false;

	public bool Perfo = false;

	public bool Combi = false;

	public BendingPunchTool()
	{
	}

	public BendingPunchTool(BendingPunchTool data)
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
		return "No:" + Data.No + " ; Width:" + Width + " ; Offset:" + Offset + " ; " + Data.Name;
	}
}
