using System.Reflection;
using buClass;

namespace buCadCamResVer5;

public class JewelModes
{
	public bool Enable = false;

	public bool FreeForm = false;

	public bool EllipseForm = false;

	public bool Lathe = false;

	public bool FlatMode = false;

	public bool RectangleForm = false;

	public bool Drawing = false;

	public double Mode1 = 0.0;

	public double Mode2 = 0.0;

	public string Mode3 = "";

	public string Mode4 = "";

	public string Mode1Exp = "";

	public string Mode2Exp = "";

	public string Mode3Exp = "";

	public string Mode4Exp = "";

	public JewelModes()
	{
	}

	public JewelModes(JewelModes data)
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
