using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class HitSurfacePointsCalculations : buSerilization5
{
	public Pnt6D normalPoint = new Pnt6D();

	public Entity normalEntities = null;

	public Vector3D NormalVector = new Vector3D();

	public HitSurfacePointsCalculations()
	{
	}

	public HitSurfacePointsCalculations(HitSurfacePointsCalculations Data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(Data, ref CopiedClass);
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
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		if (Data.normalEntities != null)
		{
			normalEntities = buVector5.CopyEntities(Data.normalEntities);
		}
		NormalVector = new Vector3D(Data.NormalVector.X, Data.NormalVector.Y, Data.NormalVector.Z);
	}
}
