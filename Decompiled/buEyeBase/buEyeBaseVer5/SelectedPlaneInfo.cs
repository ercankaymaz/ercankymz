using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class SelectedPlaneInfo : buSerilization5
{
	public Plane refPlane = null;

	public Entity entityPlane = null;

	public Entity entityXVector = null;

	public Entity entityYVector = null;

	public Entity entityZVector = null;

	public Entity entityBall = null;

	public Point3D pntPlane = new Point3D();

	public string Explanation = "";

	public double Length = 0.0;

	public double Height = 0.0;

	public double Thickness = 1.0;

	public double Angle = 0.0;

	public double AngleOffset = 0.0;

	public int Index = -1;

	public ProfilePlaneDef PlaneType = ProfilePlaneDef.Top0;

	public SelectedPlaneInfo()
	{
	}

	public SelectedPlaneInfo(SelectedPlaneInfo data)
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
		if (refPlane != null)
		{
			refPlane = (Plane)data.refPlane.Clone();
		}
		if (data.entityPlane != null)
		{
			entityPlane = (Entity)data.entityPlane.Clone();
		}
		if (data.entityXVector != null)
		{
			entityXVector = (Entity)data.entityXVector.Clone();
		}
		if (data.entityYVector != null)
		{
			entityYVector = (Entity)data.entityYVector.Clone();
		}
		if (data.entityZVector != null)
		{
			entityZVector = (Entity)data.entityZVector.Clone();
		}
		if (data.entityBall != null)
		{
			entityBall = (Entity)data.entityBall.Clone();
		}
	}

	public override string ToString()
	{
		string result = "Null";
		if (refPlane != null)
		{
			result = "refPlane: " + refPlane.ToString();
		}
		return result;
	}
}
