using System;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buEllipse : buEntity
{
	public Point3D Center = new Point3D();

	public double RadiusX = 20.0;

	public double RadiusY = 10.0;

	public double Angle = 0.0;

	public Plane Plane = Plane.XY;

	public buEllipse(buEllipse another)
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
		Center = new Point3D(another.Center.X, another.Center.Y, another.Center.Z);
		RadiusX = another.RadiusX;
		RadiusY = another.RadiusY;
		Angle = another.Angle;
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
		Update(buEntityUpdateType.EllipseDerivate);
	}

	public buEllipse(Ellipse another)
	{
		Center = new Point3D(another.Center.X, another.Center.Y, another.Center.Z);
		RadiusX = another.RadiusX;
		RadiusY = another.RadiusY;
		Plane = (Plane)another.Plane.Clone();
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
		Update(buEntityUpdateType.EllipseDerivate);
	}

	public buEllipse(Point3D center, double rx, double ry)
	{
		Center = new Point3D(center.X, center.Y, center.Z);
		RadiusX = rx;
		RadiusY = ry;
		Plane = Plane.XY;
		Update(buEntityUpdateType.EllipseCenterRadius);
	}

	public buEllipse(Plane ellipsePlane, double rx, double ry)
	{
		RadiusX = rx;
		RadiusY = ry;
		Plane = (Plane)ellipsePlane.Clone();
		Update(buEntityUpdateType.EllipseCenter2DRadiusPlane);
	}

	public buEllipse(Plane ellipsePlane, Point2D center, double rx, double ry)
	{
		Center = new Point3D(center.X, center.Y);
		RadiusX = rx;
		RadiusY = ry;
		Plane = (Plane)ellipsePlane.Clone();
		Update(buEntityUpdateType.EllipseCenter2DRadiusPlane);
	}

	public buEllipse(Plane ellipsePlane, Point3D center, double rx, double ry)
	{
		Center = new Point3D(center.X, center.Y, center.Z);
		RadiusX = rx;
		RadiusY = ry;
		Plane = (Plane)ellipsePlane.Clone();
		Update(buEntityUpdateType.EllipseCenterRadiusPlane);
	}

	public override string ToString()
	{
		string text = "Ellipse Center: " + buConversion5.Point3DToString(Center) + " - RadX: " + RadiusY + " - RadY: " + RadiusX + " - Dir: " + sortDirection;
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
