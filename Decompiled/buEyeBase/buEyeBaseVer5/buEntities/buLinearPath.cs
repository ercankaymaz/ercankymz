using System;
using System.Collections.Generic;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buLinearPath : buEntity
{
	public buLinearPath(buLinearPath another)
	{
		if (another.Shape != null)
		{
			Shape = new EntityShapeInfo(another.Shape);
		}
		if (another.Info != null)
		{
			Info = new EntityInfo(another.Info);
		}
		if (another.Cutter != null)
		{
			Cutter = new CutterInfo(another.Cutter);
		}
		if (another.Sewing != null)
		{
			Sewing = new SewingInfo(another.Sewing);
		}
		if (another.Marble != null)
		{
			Marble = new MarbleInfo(another.Marble);
		}
		if (another.Dimension != null)
		{
			Dimension = new DimensionInfo(another.Dimension);
		}
		StartPoint = new Point3D(another.StartPoint.X, another.StartPoint.Y, another.StartPoint.Z);
		MiddlePoint = new Point3D(another.MiddlePoint.X, another.MiddlePoint.Y, another.MiddlePoint.Z);
		EndPoint = new Point3D(another.EndPoint.X, another.EndPoint.Y, another.EndPoint.Z);
		BoxMin = new Point3D(another.BoxMin.X, another.BoxMin.Y, another.BoxMin.Z);
		BoxMax = new Point3D(another.BoxMax.X, another.BoxMax.Y, another.BoxMax.Z);
		sortDirection = another.sortDirection;
		typeDefination = another.typeDefination;
		Orientation = new OrientationAngle(another.Orientation);
		ToolName = another.ToolName;
		LayerName = another.LayerName;
		LayerIndex = another.LayerIndex;
		Color = another.Color;
		Thickness = another.Thickness;
		for (int i = 0; i <= another.Vertices.Count - 1; i++)
		{
			Vertices.Add(new Point3D(another.Vertices[i].X, another.Vertices[i].Y, another.Vertices[i].Z));
		}
	}

	public buLinearPath(LinearPath another)
	{
		for (int i = 0; i <= another.Vertices.Length - 1; i++)
		{
			Vertices.Add(new Point3D(another.Vertices[i].X, another.Vertices[i].Y, another.Vertices[i].Z));
		}
		if (another.EntityData != null && another.EntityData is CustomData)
		{
			Orientation = new OrientationAngle(((CustomData)another.EntityData).OrientationA, ((CustomData)another.EntityData).OrientationB, ((CustomData)another.EntityData).OrientationC);
		}
		LayerName = another.LayerName;
		if (buCall.list_0 != null && buCall.list_0.Count > 0)
		{
			Color colorLayer = another.Color;
			if (buEyeShotFunctions.GetLayerColorFromName(another.LayerName, ref colorLayer))
			{
				Color = colorLayer;
			}
		}
		Update(buEntityUpdateType.LinearPath);
	}

	public buLinearPath(List<Point3D> points)
	{
		for (int i = 0; i <= points.Count - 1; i++)
		{
			Vertices.Add(new Point3D(points[i].X, points[i].Y, points[i].Z));
		}
		Update(buEntityUpdateType.LinearPath);
	}

	public buLinearPath(Point3D[] points)
	{
		for (int i = 0; i <= points.Length - 1; i++)
		{
			Vertices.Add(new Point3D(points[i].X, points[i].Y, points[i].Z));
		}
		Update(buEntityUpdateType.LinearPath);
	}

	public buLinearPath(Plane plane, List<Point3D> points)
	{
		for (int i = 0; i <= points.Count - 1; i++)
		{
			Vertices.Add(new Point3D(points[i].X, points[i].Y, points[i].Z));
		}
		Update(buEntityUpdateType.LinearPathPlane, 0.01, plane);
	}

	public override string ToString()
	{
		string text = "LinearPath ";
		if (Vertices.Count > 0)
		{
			text = text + "SP: " + buConversion5.Point3DToString(Vertices[0]) + " - EP: " + buConversion5.Point3DToString(Vertices[Vertices.Count - 1]) + " - Dir: " + sortDirection;
		}
		if (typeDefination != entityTypeDefination.None)
		{
			text = text + " Type: " + typeDefination;
		}
		if (Info.CamSelected)
		{
			text = text + " CamSelected: " + Info.CamSelected;
		}
		if (Info.Calculated)
		{
			text = text + " Calculated: " + Info.Calculated;
		}
		if (Info.RefIndex >= 0)
		{
			text = text + " Ref Index: " + Info.RefIndex;
		}
		return text;
	}
}
