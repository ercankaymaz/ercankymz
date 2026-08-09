using System;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class BoxSize5 : buSerilization5
{
	public Point3D MinPoint = new Point3D();

	public Point3D MidPoint = new Point3D();

	public Point3D MaxPoint = new Point3D();

	public Vector3D Delta = new Vector3D();

	public BoxSize5()
	{
	}

	public BoxSize5(BoxSize5 box)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(box, ref CopiedClass);
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

	public BoxSize5(Point3D PMin, Point3D PMax)
	{
		MinPoint = buVector5.ToPoint3D(PMin);
		MaxPoint = buVector5.ToPoint3D(PMax);
		MidPoint = new Point3D((PMin.X + PMax.X) / 2.0, (PMin.Y + PMax.Y) / 2.0, (PMin.Z + PMax.Z) / 2.0);
		Delta = new Vector3D(PMax.X - PMin.X, PMax.Y - PMin.Y, PMax.Z - PMin.Z);
	}

	public override string ToString()
	{
		return "dX: " + Delta.X.ToString("f2") + " , dY: " + Delta.Y.ToString("f2") + " , dZ: " + Delta.Z.ToString("f2") + " | MinX: " + MinPoint.X.ToString("f2") + " , MinY: " + MinPoint.Y.ToString("f2") + " , MinZ: " + MinPoint.Z.ToString("f2") + " | MaxX: " + MaxPoint.X.ToString("f2") + " , MaxY: " + MaxPoint.Y.ToString("f2") + " , MaxZ: " + MaxPoint.Z.ToString("f2");
	}
}
