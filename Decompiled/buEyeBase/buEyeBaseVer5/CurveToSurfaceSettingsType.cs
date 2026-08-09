using System.Reflection;

namespace buEyeBaseVer5;

public class CurveToSurfaceSettingsType : buSerilization5
{
	public double SurfaceOffset = 0.0;

	public double MinDistance = 0.0;

	public double MaxDistance = 0.0;

	public double MaxZ = 0.0;

	public double MinZ = 0.0;

	public double InsideOffset = 0.0;

	public double OutsideOffset = 0.0;

	public bool SilhouetteToPartEnd = false;

	public bool isVertical = false;

	public CurveToSurfaceSettingsType()
	{
	}

	public CurveToSurfaceSettingsType(double surfaceOffset, double minDistance, double maxDistance, bool silhouetteToPartEnd)
	{
		SurfaceOffset = surfaceOffset;
		MinDistance = minDistance;
		MaxDistance = maxDistance;
		SilhouetteToPartEnd = silhouetteToPartEnd;
	}

	public CurveToSurfaceSettingsType(CurveToSurfaceSettingsType data)
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
		return "SurfaceOffset: " + SurfaceOffset;
	}
}
