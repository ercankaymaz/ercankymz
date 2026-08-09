using System;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buArc : buEntity
{
	public Point3D Center = new Point3D();

	public double Radius = 10.0;

	public double StartAngle = 10.0;

	public double EndAngle = 10.0;

	public bool Flip = false;

	public Plane Plane = Plane.XY;

	public buArc()
	{
	}

	public buArc(Point3D center, Point3D start, Point3D end)
	{
		Center = new Point3D(center.X, center.Y, center.Z);
		StartPoint = new Point3D(start.X, start.Y, start.Z);
		EndPoint = new Point3D(end.X, end.Y, end.Z);
		Plane = Plane.XY;
		Update(buEntityUpdateType.ArcCenterStartEnd);
	}

	public buArc(Point3D center, double radius, double startAngle, double endAngle)
	{
		Center = new Point3D(center.X, center.Y, center.Z);
		Radius = radius;
		StartAngle = startAngle;
		EndAngle = endAngle;
		Plane = Plane.XY;
		Update(buEntityUpdateType.ArcCenterRadiusSAEA);
	}

	public buArc(Plane arcPlane, Point2D center, Point2D start, Point2D end)
	{
		Center = new Point3D(center.X, center.Y);
		StartPoint = new Point3D(start.X, start.Y);
		EndPoint = new Point3D(end.X, end.Y);
		Plane = (Plane)arcPlane.Clone();
		Update(buEntityUpdateType.ArcCenterStartEndPlane);
	}

	public buArc(Point3D first, Point3D second, Point3D third, bool flip)
	{
		StartPoint = new Point3D(first.X, first.Y, first.Z);
		MiddlePoint = new Point3D(second.X, second.Y, second.Z);
		EndPoint = new Point3D(third.X, third.Y, third.Z);
		Flip = flip;
		Plane = Plane.XY;
		Update(buEntityUpdateType.Arc3Point3D);
	}

	public buArc(Plane arcPlane, Point3D center, double radius, double startAngle, double endAngle)
	{
		Center = new Point3D(center.X, center.Y, center.Z);
		Radius = radius;
		StartAngle = startAngle;
		EndAngle = endAngle;
		Plane = (Plane)arcPlane.Clone();
		Update(buEntityUpdateType.ArcCenterRadiusSAEAPlane);
	}

	public buArc(Plane arcPlane, Point2D first, Point2D second, Point2D third, bool flip)
	{
		StartPoint = new Point3D(first.X, first.Y);
		MiddlePoint = new Point3D(second.X, second.Y);
		EndPoint = new Point3D(third.X, third.Y);
		Flip = flip;
		Plane = (Plane)arcPlane.Clone();
		Update(buEntityUpdateType.Arc3Point2DPlane);
	}

	public buArc(Plane arcPlane, Point3D center, double radius, Point3D start, Point3D end, bool flip)
	{
		Center = new Point3D(center.X, center.Y, center.Z);
		StartPoint = new Point3D(start.X, start.Y, start.Z);
		EndPoint = new Point3D(end.X, end.Y, end.Z);
		Radius = radius;
		Flip = flip;
		Plane = (Plane)arcPlane.Clone();
		Update(buEntityUpdateType.ArcCenterStartEndRadiusPlaneFlip);
	}

	public buArc(buArc another)
	{
		Center = new Point3D(another.Center.X, another.Center.Y, another.Center.Z);
		StartPoint = new Point3D(another.StartPoint.X, another.StartPoint.Y, another.StartPoint.Z);
		EndPoint = new Point3D(another.EndPoint.X, another.EndPoint.Y, another.EndPoint.Z);
		MiddlePoint = new Point3D(another.MiddlePoint.X, another.MiddlePoint.Y, another.MiddlePoint.Z);
		StartAngle = another.StartAngle;
		EndAngle = another.EndAngle;
		Radius = another.Radius;
		Plane = new Plane(another.Plane.Origin, another.Plane.AxisX, another.Plane.AxisY);
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

	public buArc(Arc another)
	{
		Center = new Point3D(another.Center.X, another.Center.Y, another.Center.Z);
		StartPoint = new Point3D(another.StartPoint.X, another.StartPoint.Y, another.StartPoint.Z);
		EndPoint = new Point3D(another.EndPoint.X, another.EndPoint.Y, another.EndPoint.Z);
		MiddlePoint = new Point3D(another.MidPoint.X, another.MidPoint.Y, another.MidPoint.Z);
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
		Update(buEntityUpdateType.ArcCenterStartEndPlane);
	}

	public override string ToString()
	{
		string text = "Arc Center: " + buConversion5.Point3DToString(Center) + " - Rad: " + Radius.ToString("f3");
		text = text + " - SP: " + buConversion5.Point3DToString(StartPoint) + " - EP : " + buConversion5.Point3DToString(EndPoint);
		text = text + " - Dir: " + sortDirection;
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
