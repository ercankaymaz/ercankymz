using System;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class RoboticSurfacePoint : buSerilization5
{
	public Point3D pntBase = new Point3D();

	public Point3D pntPre = new Point3D();

	public Point3D pntNext = new Point3D();

	public Pnt6D pntNormal = new Pnt6D();

	public Pnt6D pntTangent = new Pnt6D();

	public Entity entNormal = null;

	public Entity entTangent = null;

	public Entity entContour = null;

	public Entity entLeadIn = null;

	public Entity entLeadOut = null;

	public Entity entSafeIn = null;

	public Entity entSafeOut = null;

	public Vector3D vecNormal = new Vector3D();

	public bool Enable = true;

	public bool isLast = false;

	public RoboticSurfacePoint()
	{
	}

	public RoboticSurfacePoint(RoboticSurfacePoint data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		if (data.pntBase != null)
		{
			pntBase = new Point3D(data.pntBase.X, data.pntBase.Y, data.pntBase.Z);
		}
		if (data.pntNext != null)
		{
			pntNext = new Point3D(data.pntNext.X, data.pntNext.Y, data.pntNext.Z);
		}
		if (data.pntPre != null)
		{
			pntPre = new Point3D(data.pntPre.X, data.pntPre.Y, data.pntPre.Z);
		}
		vecNormal = (Vector3D)data.vecNormal.Clone();
		if (data.entContour != null)
		{
			entContour = (Entity)data.entContour.Clone();
			if (data.entContour.EntityData == null)
			{
				entContour.EntityData = new CustomData();
			}
			else if (!(data.entContour.EntityData.GetType() == typeof(CustomData)))
			{
				entContour.EntityData = new CustomData();
			}
			else
			{
				entContour.EntityData = new CustomData((CustomData)data.entContour.EntityData);
			}
		}
		if (data.entNormal != null)
		{
			entNormal = (Entity)data.entNormal.Clone();
			if (data.entNormal.EntityData == null)
			{
				entNormal.EntityData = new CustomData();
			}
			else if (!(data.entNormal.EntityData.GetType() == typeof(CustomData)))
			{
				entNormal.EntityData = new CustomData();
			}
			else
			{
				entNormal.EntityData = new CustomData((CustomData)data.entNormal.EntityData);
			}
		}
		if (data.entTangent != null)
		{
			entTangent = (Entity)data.entTangent.Clone();
			if (data.entTangent.EntityData == null)
			{
				entTangent.EntityData = new CustomData();
			}
			else if (!(data.entTangent.EntityData.GetType() == typeof(CustomData)))
			{
				entTangent.EntityData = new CustomData();
			}
			else
			{
				entTangent.EntityData = new CustomData((CustomData)data.entTangent.EntityData);
			}
		}
		if (data.entLeadIn != null)
		{
			entLeadIn = buVector5.CopyEntities(data.entLeadIn);
		}
		if (data.entLeadOut != null)
		{
			entLeadOut = buVector5.CopyEntities(data.entLeadOut);
		}
		if (data.entSafeIn != null)
		{
			entSafeIn = buVector5.CopyEntities(data.entSafeIn);
		}
		if (data.entSafeOut != null)
		{
			entSafeOut = buVector5.CopyEntities(data.entSafeOut);
		}
	}

	public static void Copy(RoboticSurfacePoint Source, ref RoboticSurfacePoint Target)
	{
		Target = new RoboticSurfacePoint(Source);
	}

	public override string ToString()
	{
		return "Normal : " + pntNormal.ToString();
	}
}
