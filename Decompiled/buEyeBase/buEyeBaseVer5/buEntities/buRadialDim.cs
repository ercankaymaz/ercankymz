using System;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buRadialDim : buEntity
{
	public Point3D DimLinePosition = new Point3D();

	public Point3D InsertionPoint = new Point3D();

	public Point3D Origin = new Point3D();

	public double Height = 20.0;

	public double Radius = 20.0;

	public Plane Plane = Plane.XY;

	public string TextOverride = "";

	public buRadialDim()
	{
	}

	public buRadialDim(Plane dimPlane, Point3D origin, double radius, Point3D dimLinePos, double textHeight)
	{
		DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y, dimLinePos.Z);
		Origin = new Point3D(Origin.X, Origin.Y, Origin.Z);
		Height = textHeight;
		Radius = radius;
		Plane = (Plane)dimPlane.Clone();
		Update(buEntityUpdateType.RadialDim, 0.01, dimPlane);
	}

	public buRadialDim(Plane sketchPlane, Point3D origin, double radius, Point2D dimLinePos, double textHeight)
	{
		DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y);
		Origin = new Point3D(Origin.X, Origin.Y);
		Height = textHeight;
		Radius = radius;
		Plane = (Plane)sketchPlane.Clone();
		Update(buEntityUpdateType.RadialDim, 0.01, sketchPlane);
	}

	public buRadialDim(RadialDim another)
	{
		DimLinePosition = new Point3D(another.DimLinePosition.X, another.DimLinePosition.Y, another.DimLinePosition.Z);
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		Origin = new Point3D(another.Plane.Origin.X, another.Plane.Origin.Y, another.Plane.Origin.Z);
		Height = another.Height;
		Radius = another.Radius;
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
		Update(buEntityUpdateType.RadialDim, 0.01, another.Plane);
	}

	public buRadialDim(buRadialDim another)
	{
		DimLinePosition = new Point3D(another.DimLinePosition.X, another.DimLinePosition.Y, another.DimLinePosition.Z);
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		Origin = new Point3D(another.Origin.X, another.Origin.Y, another.Origin.Z);
		Height = another.Height;
		Radius = another.Radius;
		Plane = (Plane)another.Plane.Clone();
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
		ToolName = another.ToolName;
		LayerName = another.LayerName;
		LayerIndex = another.LayerIndex;
		Color = another.Color;
		Update(buEntityUpdateType.RadialDim, 0.01, another.Plane);
	}

	public override string ToString()
	{
		return "RadisDim - Origin : " + Origin.ToString() + " - Radius : " + Radius;
	}
}
