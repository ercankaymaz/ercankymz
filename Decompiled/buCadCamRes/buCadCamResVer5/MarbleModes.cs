using System.Reflection;
using buClass;

namespace buCadCamResVer5;

public class MarbleModes
{
	public bool Enable = false;

	public bool Countertop = false;

	public bool Profile = false;

	public bool ProfileArc = false;

	public bool Engraving3Axis = false;

	public bool Engraving5Axis = false;

	public bool Lathe = false;

	public bool SawMilling = false;

	public bool FileImport = false;

	public bool Camera = false;

	public bool Vacuum = false;

	public bool GCodeImport = false;

	public bool Library = false;

	public bool Columns = false;

	public bool ToolMeasure = false;

	public bool Sweep = false;

	public bool Text = false;

	public bool Hole = false;

	public bool OPMenu = false;

	public double Mode1 = 0.0;

	public double Mode2 = 0.0;

	public string Mode3 = "";

	public string Mode4 = "";

	public string Mode1Exp = "";

	public string Mode2Exp = "";

	public string Mode3Exp = "";

	public string Mode4Exp = "";

	public MarbleModes()
	{
	}

	public MarbleModes(MarbleModes data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
