using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5;

[Serializable]
public class ShapeCreateParameters : buSerilization5
{
	public bool Solid = false;

	public double SingX = 1.0;

	public double SingY = 1.0;

	public double SingZ = 1.0;

	public double RegenDeviation = 0.01;

	public double DepthOffset = 0.0;

	public double StartOffset = 0.0;

	public double SolidTolerance = 0.01;

	public string LayerName = "";

	public Color SolidColor = Color.Green;

	public Color SolidDisableColor = Color.Gray;

	public Color WireColor = Color.Black;

	public List<buEntity> entitiesCurve = null;

	public List<EntitiesList> entitiesCurveList = null;

	public List<Entity> entitiesEngraving = null;

	public List<double> DepthLevel = new List<double>();

	public SizeObject Size = new SizeObject();

	public ShapeCreateParameters()
	{
	}

	public ShapeCreateParameters(ShapeCreateParameters box)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(box, ref CopiedClass);
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
		buNumeric5.Copy(box.DepthLevel, ref DepthLevel);
	}

	public override string ToString()
	{
		return "SingX: " + SingX;
	}
}
