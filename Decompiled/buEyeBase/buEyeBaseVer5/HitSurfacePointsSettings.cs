using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

public class HitSurfacePointsSettings : buSerilization5
{
	public HitSurfacePointsGetType PointGetType = HitSurfacePointsGetType.Top;

	public double TangentAngleFromNormal = -90.0;

	public double SurfaceNormalLength = 30.0;

	public HitSurfacePointsSettings()
	{
	}

	public HitSurfacePointsSettings(HitSurfacePointsSettings Data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(Data, ref CopiedClass);
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
