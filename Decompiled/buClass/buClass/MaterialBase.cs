using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class MaterialBase : buSerilization
{
	public string Name = "Material";

	public List<Pnt3D> Points = new List<Pnt3D>();

	public SolidItemDisplay Display = new SolidItemDisplay(Color.Linen, 100, Color.Brown, 200);

	public Pnt3D StartPoint = new Pnt3D();

	public SizeObject Size = new SizeObject(400.0, 200.0, 25.0);

	public MaterialShapes Shapes = MaterialShapes.Rectangle;

	public bool Enable = true;

	public double Width = 200.0;

	public double Height = 100.0;

	public double Thickness = 10.0;

	public double Angle = 0.0;

	public double Radius = 100.0;

	public double MajorRadius = 100.0;

	public double MinorRadius = 50.0;

	public bool TopIsZeroPosition = false;

	public List<eEntities> Entities = new List<eEntities>();

	public MaterialBase()
	{
	}

	public MaterialBase(MaterialBase mat)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(mat, ref CopiedClass);
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
		Display = new SolidItemDisplay(mat.Display);
		Size = new SizeObject(mat.Size);
		Points.Clear();
		Pnt3D.Copy(mat.Points, ref Points);
		Entities.Clear();
		Entities = new List<eEntities>();
		eEntities.CopyEntities(mat.Entities, ref Entities);
	}

	public MaterialBase(SizeObject size)
	{
		Size = new SizeObject(size);
	}

	public override string ToString()
	{
		return Name + " , Color: " + Display.SkinColor.ToString() + ", Size: " + Size.ToString();
	}
}
