using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopMainPars : buSerilization5
{
	public marbleCountertopMainData Data = new marbleCountertopMainData();

	public buEntitiesGroup EntGroup = new buEntitiesGroup();

	public Entity ContourEntity = null;

	public buEntity CollapseTopEntity = null;

	public buEntity CollapseBottomEntity = null;

	public List<buEntityList> SawEntities = null;

	public List<buEntityList> MillingEntities = null;

	public List<buEntityList> WaterJetEntities = null;

	public List<buEntityList> ConcaveEntities = null;

	public List<marbleEdgeItem> Edges = new List<marbleEdgeItem>();

	public List<marbleCountertopCornerPars> Corners = new List<marbleCountertopCornerPars>();

	public List<Point3D> EntityPoints = new List<Point3D>();

	public List<Entity> EntityAngleText = new List<Entity>();

	public List<Entity> EntityDimension = new List<Entity>();

	public static List<string> Captions = new List<string>();

	public marbleCountertopMainPars()
	{
	}

	public marbleCountertopMainPars(marbleCountertopMainPars data)
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
		Data = new marbleCountertopMainData(data.Data);
		if (data.ContourEntity != null)
		{
			buEntity.Copy(data.ContourEntity, ref ContourEntity);
		}
		marbleEdgeItem.Copy(data.Edges, ref Edges);
		buVector5.Copy(data.EntityPoints, ref EntityPoints);
	}

	public override string ToString()
	{
		string text = "Type : " + Data.CountertopType.ToString() + " , Width : " + Data.Width + " , Height : " + Data.Height + " , Tool : " + Data.ToolType;
		if (Data.Radius > 0.0)
		{
			text = text + " , Rad: " + Data.Radius;
		}
		if (Data.Chamfer > 0.0)
		{
			text = text + " , Chamfer: " + Data.Chamfer;
		}
		if (Data.Rotation != 0.0)
		{
			text = text + " , Rot: " + Data.Rotation;
		}
		return text;
	}
}
