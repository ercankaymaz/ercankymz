using System;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class ObjectSize3D : buSerilization5
{
	public Point3D MinPoint = new Point3D();

	public Point3D MidPoint = new Point3D();

	public Point3D MaxPoint = new Point3D();

	public double Width = 0.0;

	public double Height = 0.0;

	public double Depth = 0.0;

	public ObjectSize3D()
	{
	}

	public ObjectSize3D(ObjectSize3D box)
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

	public ObjectSize3D(Point3D PMin, Point3D PMax)
	{
		MinPoint = buVector5.ToPoint3D(PMin);
		MaxPoint = buVector5.ToPoint3D(PMax);
		MidPoint = new Point3D((PMin.X + PMax.X) / 2.0, (PMin.Y + PMax.Y) / 2.0, (PMin.Z + PMax.Z) / 2.0);
		Width = PMax.X - PMin.X;
		Height = PMax.Y - PMin.Y;
		Depth = PMax.Z - PMin.Z;
	}

	public static void CalculateSize(ref ObjectSize3D Obj, int Round = 5)
	{
		if (Round <= 0)
		{
			Obj.Width = Obj.MaxPoint.X - Obj.MinPoint.X;
			Obj.Height = Obj.MaxPoint.Y - Obj.MinPoint.Y;
			Obj.Depth = Obj.MaxPoint.Z - Obj.MinPoint.Z;
			Obj.MidPoint.X = (Obj.MinPoint.X + Obj.MaxPoint.X) / 2.0;
			Obj.MidPoint.Y = (Obj.MinPoint.Y + Obj.MaxPoint.Y) / 2.0;
			Obj.MidPoint.Z = (Obj.MinPoint.Z + Obj.MaxPoint.Z) / 2.0;
			return;
		}
		Obj.MinPoint.X = Math.Round(Obj.MinPoint.X, Round);
		Obj.MinPoint.Y = Math.Round(Obj.MinPoint.Y, Round);
		Obj.MinPoint.Z = Math.Round(Obj.MinPoint.Z, Round);
		Obj.MaxPoint.X = Math.Round(Obj.MaxPoint.X, Round);
		Obj.MaxPoint.Y = Math.Round(Obj.MaxPoint.Y, Round);
		Obj.MaxPoint.Z = Math.Round(Obj.MaxPoint.Z, Round);
		Obj.Width = Math.Round(Obj.MaxPoint.X - Obj.MinPoint.X, Round);
		Obj.Height = Math.Round(Obj.MaxPoint.Y - Obj.MinPoint.Y, Round);
		Obj.Depth = Math.Round(Obj.MaxPoint.Z - Obj.MinPoint.Z, Round);
		Obj.MidPoint.X = Math.Round((Obj.MinPoint.X + Obj.MaxPoint.X) / 2.0, Round);
		Obj.MidPoint.Y = Math.Round((Obj.MinPoint.Y + Obj.MaxPoint.Y) / 2.0, Round);
		Obj.MidPoint.Z = Math.Round((Obj.MinPoint.Z + Obj.MaxPoint.Z) / 2.0, Round);
	}

	public override string ToString()
	{
		string text = "Width: " + Width.ToString("f2") + " , Height: " + Height.ToString("f2");
		if (Depth != 0.0)
		{
			text = text + " , Depth: " + Depth.ToString("f2");
		}
		text = text + " | MinX: " + MinPoint.X.ToString("f2") + " , MinY: " + MinPoint.Y.ToString("f2");
		if (MinPoint.Z != MaxPoint.Z)
		{
			text = text + " , MinZ: " + MinPoint.Z.ToString("f2");
		}
		text = text + " | MaxX: " + MaxPoint.X.ToString("f2") + " , MaxY: " + MaxPoint.Y.ToString("f2");
		if (MinPoint.Z != MaxPoint.Z)
		{
			text = text + " , MaxZ: " + MaxPoint.Z.ToString("f2");
		}
		return text;
	}
}
