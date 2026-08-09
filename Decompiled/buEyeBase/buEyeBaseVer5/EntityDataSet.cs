using System;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class EntityDataSet : buSerilization5
{
	public string SceneName = "";

	public string EntityName = "";

	public string ActionName = "";

	public string Tags = "";

	public double Width = 0.0;

	public double Height = 0.0;

	public double Length = 0.0;

	public double Angle = 0.0;

	public double Radius = 0.0;

	public double HeadRadius = 0.0;

	public double OrientationC = 0.0;

	public int Side = 0;

	public int Degree = 1;

	public int GroupIDIndex = -1;

	public int CamID = -1;

	public bool CamSelected = false;

	public string LayerName = "";

	public string Text = "";

	public string Data = "";

	public double Direction = 0.0;

	public int RefIndex = -1;

	public entitySplineType CurveType = entitySplineType.BsplineCubic;

	public Point3D PntBase = new Point3D();

	public entitySortDirection sortDirection = entitySortDirection.Normal;

	public string fileName = Application.StartupPath;

	public entityTypeDefination Defination = entityTypeDefination.None;

	public EntityDataSet()
	{
	}

	public EntityDataSet(int groupIndex, string layerName, string sceneName, string entityName, string actionName, string tags, Point3D pntBase)
	{
		ActionName = actionName;
		EntityName = entityName;
		GroupIDIndex = groupIndex;
		LayerName = layerName;
		SceneName = sceneName;
		Tags = tags;
		PntBase = new Point3D(pntBase.X, pntBase.Y, pntBase.Z);
	}

	public EntityDataSet(Entity ent)
	{
		if (ent.EntityData != null && ent.EntityData is CustomData)
		{
			ActionName = ((CustomData)ent.EntityData).ActionName;
			Angle = ((CustomData)ent.EntityData).infoAngle;
			CamSelected = ((CustomData)ent.EntityData).CamSelected;
			Degree = ((CustomData)ent.EntityData).infoDegree;
			EntityName = ((CustomData)ent.EntityData).EntityName;
			GroupIDIndex = ((CustomData)ent.EntityData).GroupIdIndex;
			HeadRadius = ((CustomData)ent.EntityData).infoHeadRadius;
			Height = ((CustomData)ent.EntityData).infoHeight;
			LayerName = ent.LayerName;
			Length = ((CustomData)ent.EntityData).infoLength;
			OrientationC = ((CustomData)ent.EntityData).OrientationC;
			if (((CustomData)ent.EntityData).infoBasePoint != null)
			{
				PntBase = buVector5.ToPoint3D(((CustomData)ent.EntityData).infoBasePoint);
			}
			Radius = ((CustomData)ent.EntityData).infoRadius;
			SceneName = ((CustomData)ent.EntityData).SceneName;
			Side = ((CustomData)ent.EntityData).infoSide;
			Tags = ((CustomData)ent.EntityData).Tags;
			Text = ((CustomData)ent.EntityData).infoString;
			Data = ((CustomData)ent.EntityData).infoData;
			Width = ((CustomData)ent.EntityData).infoWidth;
			Defination = ((CustomData)ent.EntityData).typeDefination;
			Direction = ((CustomData)ent.EntityData).infoDirection;
			RefIndex = ((CustomData)ent.EntityData).RefIndex;
		}
	}

	public static CustomData ConvertCustomData(EntityDataSet EntData)
	{
		CustomData customData = new CustomData();
		customData.ActionName = EntData.ActionName;
		customData.CamID = EntData.CamID;
		customData.CamSelected = EntData.CamSelected;
		customData.CurveType = EntData.CurveType;
		customData.EntityName = EntData.EntityName;
		customData.GroupIdIndex = EntData.GroupIDIndex;
		customData.infoAngle = EntData.Angle;
		customData.infoBasePoint = EntData.PntBase;
		customData.infoDegree = EntData.Degree;
		customData.infoHeadRadius = EntData.HeadRadius;
		customData.infoHeight = EntData.Height;
		customData.infoLength = EntData.Length;
		customData.infoRadius = EntData.Radius;
		customData.infoSide = EntData.Side;
		customData.infoString = EntData.Text;
		customData.infoData = EntData.Data;
		customData.infoWidth = EntData.Width;
		customData.OrientationC = EntData.OrientationC;
		customData.SceneName = EntData.SceneName;
		customData.sortDirection = EntData.sortDirection;
		customData.Tags = EntData.Tags;
		customData.typeDefination = EntData.Defination;
		customData.infoDirection = EntData.Direction;
		customData.RefIndex = EntData.RefIndex;
		return customData;
	}

	public EntityDataSet(EntityDataSet data)
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
		PntBase = new Point3D(data.PntBase.X, data.PntBase.Y, data.PntBase.Z);
	}

	public EntityDataSet(int groupIndex, string layerName, string sceneName, string entityName, string actionName, string tags, Point3D pntBase, double width, double height, double length, double angle, double radius, double headRadius, int side, int degree)
	{
		ActionName = actionName;
		Angle = angle;
		Degree = degree;
		EntityName = entityName;
		GroupIDIndex = groupIndex;
		HeadRadius = headRadius;
		Height = height;
		LayerName = layerName;
		Length = length;
		Radius = radius;
		SceneName = sceneName;
		Side = side;
		Tags = tags;
		Width = width;
		PntBase = new Point3D(pntBase.X, pntBase.Y, pntBase.Z);
	}
}
