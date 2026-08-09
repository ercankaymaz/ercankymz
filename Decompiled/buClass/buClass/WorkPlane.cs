using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class WorkPlane : buSerilization
{
	public planeType PlaneType;

	public planeNames PlaneName;

	public int PerpendicularAxisDirection;

	public Pnt3D BasePoint;

	public Pnt3D MiddlePoint;

	public Pnt3D TipPoint;

	public Vec3D Normalies;

	public OrientationAngle Angles;

	public Quad3D Quad;

	public bool isReverse;

	public bool isSlope;

	public bool isCircular;

	public bool UseCenterPoint;

	public double Lenght;

	public double BaseAngle;

	public double CircularAngle;

	public Vec3D DeltaLenght;

	public List<eEntities> PlaneEntites;

	public List<Pnt3D> BoxPoints;

	public WorkPlane()
	{
		PlaneType = planeType.XY;
		PlaneName = planeNames.Top;
		PerpendicularAxisDirection = 1;
		BasePoint = new Pnt3D();
		MiddlePoint = new Pnt3D();
		TipPoint = new Pnt3D();
		Normalies = new Vec3D();
		Angles = new OrientationAngle();
		Quad = new Quad3D();
		isReverse = false;
		isSlope = false;
		isCircular = false;
		UseCenterPoint = false;
		Lenght = 0.0;
		BaseAngle = 0.0;
		CircularAngle = 0.0;
		DeltaLenght = new Vec3D();
		PlaneEntites = new List<eEntities>();
		BoxPoints = new List<Pnt3D>();
		base._002Ector();
		PlaneType = planeType.XY;
		PerpendicularAxisDirection = 1;
		Normalies = new Vec3D(0.0, 0.0, 1.0);
		BasePoint = new Pnt3D();
	}

	public WorkPlane(planeType type, int perperdicularaxisdir)
	{
		base._002Ector();
		PlaneType = type;
		PerpendicularAxisDirection = perperdicularaxisdir;
		if (PlaneType == planeType.XY)
		{
			Normalies = ((PerpendicularAxisDirection < 0) ? new Vec3D(0.0, 0.0, -1.0) : new Vec3D(0.0, 0.0, 1.0));
		}
		if (PlaneType == planeType.YX)
		{
			Normalies = ((PerpendicularAxisDirection < 0) ? new Vec3D(0.0, 0.0, 1.0) : new Vec3D(0.0, 0.0, -1.0));
		}
		if (PlaneType == planeType.XZ)
		{
			Normalies = ((PerpendicularAxisDirection < 0) ? new Vec3D(0.0, 1.0, 0.0) : new Vec3D(0.0, -1.0, 0.0));
		}
		if (PlaneType == planeType.ZX)
		{
			Normalies = ((PerpendicularAxisDirection < 0) ? new Vec3D(0.0, -1.0, 0.0) : new Vec3D(0.0, 1.0, 0.0));
		}
		if (PlaneType == planeType.YZ)
		{
			Normalies = ((PerpendicularAxisDirection < 0) ? new Vec3D(-1.0, 0.0, 0.0) : new Vec3D(1.0, 0.0, 0.0));
		}
		if (PlaneType == planeType.ZY)
		{
			Normalies = ((PerpendicularAxisDirection < 0) ? new Vec3D(1.0, 0.0, 0.0) : new Vec3D(-1.0, 0.0, 0.0));
		}
	}

	public WorkPlane(Vec3D Normalies)
	{
		PlaneType = planeType.XY;
		PlaneName = planeNames.Top;
		PerpendicularAxisDirection = 1;
		BasePoint = new Pnt3D();
		MiddlePoint = new Pnt3D();
		TipPoint = new Pnt3D();
		this.Normalies = new Vec3D();
		Angles = new OrientationAngle();
		Quad = new Quad3D();
		isReverse = false;
		isSlope = false;
		isCircular = false;
		UseCenterPoint = false;
		Lenght = 0.0;
		BaseAngle = 0.0;
		CircularAngle = 0.0;
		DeltaLenght = new Vec3D();
		PlaneEntites = new List<eEntities>();
		BoxPoints = new List<Pnt3D>();
		base._002Ector();
		PlaneType = checkPlane(Normalies);
		this.Normalies = new Vec3D(Normalies);
		BasePoint = new Pnt3D();
	}

	public WorkPlane(WorkPlane data)
	{
		PlaneType = planeType.XY;
		PlaneName = planeNames.Top;
		PerpendicularAxisDirection = 1;
		BasePoint = new Pnt3D();
		MiddlePoint = new Pnt3D();
		TipPoint = new Pnt3D();
		Normalies = new Vec3D();
		Angles = new OrientationAngle();
		Quad = new Quad3D();
		isReverse = false;
		isSlope = false;
		isCircular = false;
		UseCenterPoint = false;
		Lenght = 0.0;
		BaseAngle = 0.0;
		CircularAngle = 0.0;
		DeltaLenght = new Vec3D();
		PlaneEntites = new List<eEntities>();
		BoxPoints = new List<Pnt3D>();
		base._002Ector();
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
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
		Angles = new OrientationAngle(data.Angles);
		Quad = new Quad3D(data.Quad);
		PlaneEntites.Clear();
		eEntities.CopyEntities(data.PlaneEntites, ref PlaneEntites);
		BoxPoints.Clear();
		Pnt3D.Copy(data.BoxPoints, ref BoxPoints);
	}

	public static bool isPlaneXY(WorkPlane plane)
	{
		if ((plane.PlaneType == planeType.XY) | (plane.PlaneType == planeType.YX))
		{
			return true;
		}
		return false;
	}

	public static bool isPlaneXZ(WorkPlane plane)
	{
		if ((plane.PlaneType == planeType.XZ) | (plane.PlaneType == planeType.ZX))
		{
			return true;
		}
		return false;
	}

	public static bool isPlaneYZ(WorkPlane plane)
	{
		if ((plane.PlaneType == planeType.YZ) | (plane.PlaneType == planeType.ZY))
		{
			return true;
		}
		return false;
	}

	public static planeType checkPlane(Vec3D Normalies)
	{
		if ((Normalies.X == 0.0) & (Normalies.Y == 0.0) & (Normalies.Z == 1.0))
		{
			return planeType.XY;
		}
		if ((Normalies.X == 0.0) & (Normalies.Y == 0.0) & (Normalies.Z == -1.0))
		{
			return planeType.YX;
		}
		if ((Normalies.X == 1.0) & (Normalies.Y == 0.0) & (Normalies.Z == 0.0))
		{
			return planeType.YZ;
		}
		if ((Normalies.X == -1.0) & (Normalies.Y == 0.0) & (Normalies.Z == 0.0))
		{
			return planeType.ZY;
		}
		if ((Normalies.X == 0.0) & (Normalies.Y == -1.0) & (Normalies.Z == 0.0))
		{
			return planeType.XZ;
		}
		if ((Normalies.X == 0.0) & (Normalies.Y == 1.0) & (Normalies.Z == 0.0))
		{
			return planeType.ZX;
		}
		return planeType.Angle;
	}

	public static WorkPlane Copy(WorkPlane basePlane)
	{
		WorkPlane copiedPlane = new WorkPlane();
		Copy(basePlane, ref copiedPlane);
		return copiedPlane;
	}

	public static void Copy(WorkPlane basePlane, ref WorkPlane copiedPlane)
	{
		copiedPlane = new WorkPlane(basePlane);
	}

	public static WorkPlane XY()
	{
		return new WorkPlane();
	}

	public static WorkPlane XZ()
	{
		return new WorkPlane(new Vec3D(0.0, -1.0, 0.0));
	}

	public static WorkPlane YZ()
	{
		return new WorkPlane(new Vec3D(1.0, 0.0, 0.0));
	}

	public override string ToString()
	{
		return "Type : " + PlaneType.ToString() + " , Direction : " + PerpendicularAxisDirection;
	}
}
