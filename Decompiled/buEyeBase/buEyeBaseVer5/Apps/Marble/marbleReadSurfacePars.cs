using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleReadSurfacePars : buSerilization5
{
	public bool ApplySurfaceReadData = false;

	public double SurfaceReadDevideLength = 5.0;

	public static List<string> Captions = new List<string>();

	public marbleReadSurfacePars()
	{
	}

	public marbleReadSurfacePars(marbleReadSurfacePars data)
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

	public static void Copy(marbleReadSurfacePars Source, ref marbleReadSurfacePars Target)
	{
		Target = new marbleReadSurfacePars(Source);
	}

	public override string ToString()
	{
		return "ApplySurfaceReadData : " + ApplySurfaceReadData + " , SurfaceReadDevideLength : " + SurfaceReadDevideLength;
	}
}
