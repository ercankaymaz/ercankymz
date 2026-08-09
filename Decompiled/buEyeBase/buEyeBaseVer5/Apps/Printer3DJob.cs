using System;
using System.Collections.Generic;
using System.Reflection;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class Printer3DJob : buSerilization5
{
	public string ItemName = "";

	public string FileName = "";

	public string FileNameFull = "";

	public bool isError = false;

	public bool isGCodeCreated = false;

	public int Transparency = 120;

	public Point3D MinPoint = new Point3D();

	public Point3D MaxPoint = new Point3D();

	public Entity entOriginal = null;

	public Entity entTessellenation = null;

	public List<Printer3DLayer> Layers = new List<Printer3DLayer>();

	public Printer3DJob()
	{
	}

	public Printer3DJob(Printer3DJob data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null)
		{
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
			MinPoint = new Point3D(data.MinPoint.X, data.MinPoint.Y, data.MinPoint.Z);
			MaxPoint = new Point3D(data.MaxPoint.X, data.MaxPoint.Y, data.MaxPoint.Z);
			for (int j = 0; j <= data.Layers.Count - 1; j++)
			{
				Layers.Add(new Printer3DLayer(data.Layers[j]));
			}
		}
		if (data.entOriginal != null)
		{
			entOriginal = buVector5.CopyEntities(data.entOriginal);
		}
		if (data.entTessellenation != null)
		{
			entTessellenation = buVector5.CopyEntities(data.entTessellenation);
		}
	}

	public override string ToString()
	{
		return ItemName.ToString();
	}
}
