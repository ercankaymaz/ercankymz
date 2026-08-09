using System;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buAngularDim : buEntity
{
	public Point3D ExtLine1 = new Point3D();

	public Point3D ExtLine2 = new Point3D();

	public Point3D DimLinePosition = new Point3D();

	public Point3D InsertionPoint = new Point3D();

	public Point3D QuadrantPoint = new Point3D();

	public Point3D Origin = new Point3D();

	public double Height = 20.0;

	public Plane Plane = Plane.XY;

	public string TextOverride = "";

	public buAngularDim()
	{
	}

	public buAngularDim(Plane dimPlane, Point3D extLine1, Point3D extLine2, Point3D dimLinePos, double textHeight)
	{
		ExtLine1 = new Point3D(extLine1.X, extLine1.Y, extLine1.Z);
		ExtLine2 = new Point3D(extLine2.X, extLine2.Y, extLine2.Z);
		DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y, dimLinePos.Z);
		Height = textHeight;
		Plane = (Plane)dimPlane.Clone();
		Update(buEntityUpdateType.AngularDim, 0.01, dimPlane);
	}

	public buAngularDim(Plane sketchPlane, Point2D origin, Point2D extLine1, Point2D extLine2, Point2D dimLinePos, double textHeight)
	{
		ExtLine1 = new Point3D(extLine1.X, extLine1.Y);
		ExtLine2 = new Point3D(extLine2.X, extLine2.Y);
		DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y);
		Origin = new Point3D(Origin.X, Origin.Y);
		Height = textHeight;
		Plane = (Plane)sketchPlane.Clone();
		Update(buEntityUpdateType.AngularDim, 0.01, sketchPlane);
	}

	public buAngularDim(AngularDim another)
	{
		ExtLine1 = new Point3D(another.ExtLine1.X, another.ExtLine1.Y, another.ExtLine1.Z);
		ExtLine2 = new Point3D(another.ExtLine2.X, another.ExtLine2.Y, another.ExtLine2.Z);
		DimLinePosition = new Point3D(another.DimLinePosition.X, another.DimLinePosition.Y, another.DimLinePosition.Z);
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		Origin = new Point3D(another.Origin.X, another.Origin.Y, another.Origin.Z);
		Height = another.Height;
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
		Update(buEntityUpdateType.LinearDim, 0.01, another.Plane);
	}

	public buAngularDim(buAngularDim another)
	{
		ExtLine1 = new Point3D(another.ExtLine1.X, another.ExtLine1.Y, another.ExtLine1.Z);
		ExtLine2 = new Point3D(another.ExtLine2.X, another.ExtLine2.Y, another.ExtLine2.Z);
		DimLinePosition = new Point3D(another.DimLinePosition.X, another.DimLinePosition.Y, another.DimLinePosition.Z);
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		QuadrantPoint = new Point3D(another.QuadrantPoint.X, another.QuadrantPoint.Y, another.QuadrantPoint.Z);
		Origin = new Point3D(another.Origin.X, another.Origin.Y, another.Origin.Z);
		Height = another.Height;
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
		Update(buEntityUpdateType.LinearDim, 0.01, another.Plane);
	}

	public override string ToString()
	{
		return "AngularDim - ExtLine1 : " + ExtLine1.ToString() + " - ExtLine2 : " + ExtLine2.ToString();
	}
}
