using System;
using System.Drawing;
using System.Reflection;
using buClass;
using buControls.Controls;

namespace buEyeBaseVer5;

[Serializable]
public class hmiUIBasicPars : buSerilization
{
	public ContentAlignment ImageAlignment = ContentAlignment.MiddleLeft;

	public ShapeType GeometryType = ShapeType.Arc;

	public int GeometryArcDiameer = 10;

	public hmiUIBasicPars()
	{
	}

	public hmiUIBasicPars(hmiUIBasicPars data)
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
		return GeometryType.ToString() + " - " + GeometryArcDiameer;
	}
}
