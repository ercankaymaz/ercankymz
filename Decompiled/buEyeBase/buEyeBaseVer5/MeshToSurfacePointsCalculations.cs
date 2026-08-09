using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class MeshToSurfacePointsCalculations : buSerilization5
{
	public Pnt6D normalPoint = new Pnt6D();

	public Pnt6D tangentPoint = new Pnt6D();

	public Entity normalEntities = null;

	public Entity tangentEntities = null;

	public Entity LeadInEntities = null;

	public Entity LeadOutEntities = null;

	public Entity SafeInEntities = null;

	public Entity SafeOutEntities = null;

	public Vector3D NormalVector = new Vector3D();

	public Vector3D TangentVector = new Vector3D();

	public MeshToSurfacePointsCalculations()
	{
	}

	public MeshToSurfacePointsCalculations(MeshToSurfacePointsCalculations Data)
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
		if (Data.tangentEntities != null)
		{
			tangentEntities = buVector5.CopyEntities(Data.tangentEntities);
		}
		NormalVector = new Vector3D(Data.NormalVector.X, Data.NormalVector.Y, Data.NormalVector.Z);
		TangentVector = new Vector3D(Data.TangentVector.X, Data.TangentVector.Y, Data.TangentVector.Z);
	}
}
