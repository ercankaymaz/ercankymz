using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class CamStock : buSerilization5
{
	public string StockName = "Cam";

	public bool isError = false;

	public ColorType colorStock = new ColorType(Color.BurlyWood, 150);

	public Point3D MinPoint = new Point3D();

	public Point3D MaxPoint = new Point3D();

	public SizeObject SizeStock = new SizeObject();

	public List<buEntity> StockEntities = new List<buEntity>();

	public CamStock()
	{
	}

	public CamStock(CamStock data)
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
		colorStock = new ColorType(data.colorStock);
		buEntity.Copy(data.StockEntities, ref StockEntities);
	}

	public static void Decode(List<string> AL, ref CamStock Item)
	{
	}

	public static ArrayList ToDef(CamStock refItem, int Space)
	{
		return new ArrayList();
	}

	public override string ToString()
	{
		return "Size: " + SizeStock.ToString();
	}
}
