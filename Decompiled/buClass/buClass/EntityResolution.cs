using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class EntityResolution : buSerilization
{
	public double GeometricLength = 0.5;

	public int GeometricCount = 20;

	public double LnRatio = 200.0;

	public double dt = 0.05;

	public EntityResolutionType ResolutionTypes = EntityResolutionType.ByLnRadius;

	public int MinPointCount = 50;

	public static List<string> Captions = new List<string>();

	public EntityResolution()
	{
		GeometricLength = 0.1;
		GeometricCount = 50;
		LnRatio = 100.0;
		dt = 0.05;
		ResolutionTypes = EntityResolutionType.ByLnRadius;
	}

	public EntityResolution(EntityResolutionType type)
	{
		GeometricLength = 0.1;
		GeometricCount = 50;
		LnRatio = 100.0;
		dt = 0.05;
		ResolutionTypes = type;
	}

	public EntityResolution(EntityResolution Props)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Props, ref CopiedClass);
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

	public EntityResolution(double geometricLength, int geometricCount, double lnRatio, EntityResolutionType type, int minCount = 50)
	{
		GeometricLength = geometricLength;
		GeometricCount = geometricCount;
		LnRatio = lnRatio;
		ResolutionTypes = type;
		MinPointCount = minCount;
	}

	public override string ToString()
	{
		return ResolutionTypes.ToString() + " ; Len: " + GeometricLength + " ; Cnt: " + GeometricCount + " ; Ln: " + LnRatio + " ; dt: " + dt;
	}
}
