using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamTempVars
{
	public bool isReverse = false;

	public bool NotCatchFound = false;

	public Point3D pntLastSelected = null;

	public string LayerGeneral = "";

	public string LayerFoam = "";

	public string Layer3DPattern = "";

	public string LayerWirePattern = "";

	public string LayerSelection = "";

	public string LayerMark = "";

	public string LayerDefault = "Default";

	public FoamTempVars()
	{
	}

	public FoamTempVars(FoamTempVars data)
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
