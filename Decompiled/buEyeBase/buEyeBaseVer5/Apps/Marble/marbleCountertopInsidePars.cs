using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopInsidePars : buSerilization5
{
	public marbleCountertopInsideData DataInside = new marbleCountertopInsideData();

	public buEntityList Outside = new buEntityList();

	public List<List<buEntity>> CollapseContourEntities = null;

	public Entity ContourEntity = null;

	public buEntity CollapseEntity = null;

	public List<marbleEdgeItem> Edges = new List<marbleEdgeItem>();

	public List<Point3D> EntityPoints = new List<Point3D>();

	public List<Entity> EntityAngleText = new List<Entity>();

	public List<Entity> EntityDimension = new List<Entity>();

	public List<Entity> EntityLocation = new List<Entity>();

	public Entity EntityCollapse = null;

	public static List<string> Captions = new List<string>();

	public marbleCountertopInsidePars()
	{
	}

	public marbleCountertopInsidePars(marbleCountertopInsidePars data)
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
		DataInside = new marbleCountertopInsideData(data.DataInside);
		if (data.ContourEntity != null)
		{
			buEntity.Copy(data.ContourEntity, ref ContourEntity);
		}
		marbleEdgeItem.Copy(data.Edges, ref Edges);
		buVector5.Copy(data.EntityPoints, ref EntityPoints);
	}

	public override string ToString()
	{
		string text = "Type : " + DataInside.InsideType.ToString() + " " + DataInside.Enable + " , Width : " + DataInside.InsideWidth + " , Height : " + DataInside.InsideHeight + " , X: " + DataInside.PositionX + " , Y: " + DataInside.PositionY + " , Tool : " + DataInside.ToolType;
		if (DataInside.Radius > 0.0)
		{
			text = text + " , Rad: " + DataInside.Radius;
		}
		if (DataInside.Chamfer > 0.0)
		{
			text = text + " , Chamfer: " + DataInside.Chamfer;
		}
		if (DataInside.Rotation != 0.0)
		{
			text = text + " , Rot: " + DataInside.Rotation;
		}
		if (DataInside.CollapseEnable)
		{
			text = text + " , Collapse: " + DataInside.CollapseEnable;
		}
		return text;
	}
}
