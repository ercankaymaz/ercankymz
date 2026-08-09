using System.Reflection;
using buClass;

namespace buCadCamResVer5;

public class FileOpenModesOptions
{
	public bool buCadVer5 = false;

	public bool buCadVer4 = false;

	public bool DrawWorks = false;

	public bool Dxf = false;

	public bool Dwg = false;

	public bool Dwf = false;

	public bool Asc = false;

	public bool cf2 = false;

	public bool cnc = false;

	public bool Iges = false;

	public bool Icf = false;

	public bool Jt = false;

	public bool Las = false;

	public bool Lucas = false;

	public bool Nastran = false;

	public bool Obj = false;

	public bool Pdf = false;

	public bool Ply = false;

	public bool Rcp = false;

	public bool Rcs = false;

	public bool Step = false;

	public bool Stl = false;

	public bool Xyz = false;

	public bool Medit = false;

	public bool _3DS = false;

	public double Mode1 = 0.0;

	public double Mode2 = 0.0;

	public string Mode3 = "";

	public string Mode4 = "";

	public string Mode1Exp = "";

	public string Mode2Exp = "";

	public string Mode3Exp = "";

	public string Mode4Exp = "";

	public FileOpenModesOptions()
	{
	}

	public FileOpenModesOptions(FileOpenModesOptions data)
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
