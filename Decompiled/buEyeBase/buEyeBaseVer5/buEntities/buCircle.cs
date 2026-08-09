using System;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buCircle : buEntity
{
	public Point3D Center = new Point3D();

	public double Radius = 10.0;

	public Plane Plane = Plane.XY;

	public buCircle(Point3D center, double radius)
	{
		Center = new Point3D(center.X, center.Y, center.Z);
		Radius = radius;
		Plane = Plane.XY;
		Update(buEntityUpdateType.CircleCenterRadius);
	}

	public buCircle(Plane plane, double radius)
	{
		Radius = radius;
		Plane = (Plane)plane.Clone();
		Update(buEntityUpdateType.CircleCenterRadiusPlane);
	}

	public buCircle(Plane plane, Point3D center, double radius)
	{
		Center = new Point3D(center.X, center.Y, center.Z);
		Radius = radius;
		Plane = (Plane)plane.Clone();
		Update(buEntityUpdateType.CircleCenterRadiusPlane);
	}

	public buCircle(Plane plane, Point2D center, double radius)
	{
		Center = new Point3D(center.X, center.Y);
		Radius = radius;
		Plane = (Plane)plane.Clone();
		Update(buEntityUpdateType.CircleCenter2DRadiusPlane);
	}

	public buCircle(Point3D first, Point3D second, Point3D third)
	{
		StartPoint = new Point3D(first.X, first.Y, first.Z);
		MiddlePoint = new Point3D(second.X, second.Y, second.Z);
		EndPoint = new Point3D(third.X, third.Y, third.Z);
		Plane = Plane.XY;
		Update(buEntityUpdateType.Circle3Point);
	}

	public buCircle(Plane plane, Point2D first, Point2D second, Point2D third)
	{
		StartPoint = new Point3D(first.X, first.Y);
		MiddlePoint = new Point3D(second.X, second.Y);
		EndPoint = new Point3D(third.X, third.Y);
		Plane = (Plane)plane.Clone();
		Update(buEntityUpdateType.Circle3Point2D);
	}

	public buCircle(buCircle another)
	{
		Center = new Point3D(another.Center.X, another.Center.Y, another.Center.Z);
		Radius = another.Radius;
		Plane = new Plane(another.Plane.Origin, another.Plane.AxisX, another.Plane.AxisY);
		BoxMin = new Point3D(another.BoxMin.X, another.BoxMin.Y, another.BoxMin.Z);
		BoxMax = new Point3D(another.BoxMax.X, another.BoxMax.Y, another.BoxMax.Z);
		StartPoint = new Point3D(another.StartPoint.X, another.StartPoint.Y, another.StartPoint.Z);
		MiddlePoint = new Point3D(another.MiddlePoint.X, another.MiddlePoint.Y, another.MiddlePoint.Z);
		EndPoint = new Point3D(another.EndPoint.X, another.EndPoint.Y, another.EndPoint.Z);
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
	}

	public buCircle(Circle another)
	{
		Center = new Point3D(another.Center.X, another.Center.Y, another.Center.Z);
		Radius = another.Radius;
		Plane = new Plane(another.Plane.Origin, another.Plane.AxisX, another.Plane.AxisY);
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
		Update(buEntityUpdateType.CircleDerivate);
	}

	public override string ToString()
	{
		string text = "Circle Center: " + buConversion5.Point3DToString(Center) + " - Rad: " + Radius + " - Dir: " + sortDirection;
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
