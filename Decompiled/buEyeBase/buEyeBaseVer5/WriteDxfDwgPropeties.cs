using System;
using System.Reflection;
using devDept.Eyeshot.Translators;

namespace buEyeBaseVer5;

[Serializable]
public class WriteDxfDwgPropeties : buSerilization5
{
	public autodeskVersionType Version = autodeskVersionType.Acad2000;

	public double Deviation = 0.0;

	public bool ExplodeViews = false;

	public string Password = "";

	public bool CurveAsFitSpline = false;

	public bool AciColors = true;

	public bool Purge = false;

	public bool SelectedOnly = false;

	public bool Convert2PointLinearPathToLine = false;

	public WriteDxfDwgPropeties()
	{
	}

	public WriteDxfDwgPropeties(WriteDxfDwgPropeties data)
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
