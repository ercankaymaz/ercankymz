using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class EntitiesResolution : buSerilization
{
	public EntityResolution CircleResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.ByLnRadius);

	public EntityResolution ArcResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.ByLnRadius);

	public EntityResolution EllipseResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.ByLnRadius);

	public EntityResolution CurveResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.ByLnRadius);

	public EntityResolution LineResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.None);

	public EntityResolution PolylineResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.None);

	public EntityResolution OtherResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.None);

	public static List<string> Captions = new List<string>();

	public EntitiesResolution()
	{
	}

	public EntitiesResolution(EntityResolutionType LineTypes, EntityResolutionType PolylineTypes, EntityResolutionType ArcTypes, EntityResolutionType CircleTypes, EntityResolutionType EllipseTypes, EntityResolutionType CurveTypes, EntityResolutionType OtherTypes)
	{
		LineResolution.ResolutionTypes = LineTypes;
		PolylineResolution.ResolutionTypes = LineTypes;
		ArcResolution.ResolutionTypes = LineTypes;
		CircleResolution.ResolutionTypes = LineTypes;
		EllipseResolution.ResolutionTypes = LineTypes;
		CurveResolution.ResolutionTypes = LineTypes;
		OtherResolution.ResolutionTypes = LineTypes;
	}

	public EntitiesResolution(EntitiesResolution data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		ArcResolution = new EntityResolution(data.ArcResolution);
		CircleResolution = new EntityResolution(data.CircleResolution);
		EllipseResolution = new EntityResolution(data.EllipseResolution);
		CurveResolution = new EntityResolution(data.CurveResolution);
		LineResolution = new EntityResolution(data.LineResolution);
		PolylineResolution = new EntityResolution(data.PolylineResolution);
		OtherResolution = new EntityResolution(data.OtherResolution);
	}

	public override string ToString()
	{
		return "Circle Len = " + CircleResolution.GeometricLength;
	}
}
