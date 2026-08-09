using System;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buOrdinateDim : buEntity
{
	public Point3D DefiningPoint = new Point3D();

	public Point3D DimLinePosition = new Point3D();

	public Point3D InsertionPoint = new Point3D();

	public double Height = 20.0;

	public bool isVertical = false;

	public Plane Plane = Plane.XY;

	public string TextOverride = "";

	public buOrdinateDim()
	{
	}

	public buOrdinateDim(Plane dimPlane, Point3D definingPoint, Point3D dimLinePos, bool isVertical, double textHeight)
	{
		DefiningPoint = new Point3D(definingPoint.X, definingPoint.Y, definingPoint.Z);
		DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y, dimLinePos.Z);
		Height = textHeight;
		this.isVertical = isVertical;
		Plane = (Plane)dimPlane.Clone();
		Update(buEntityUpdateType.OrdinateDim, 0.01, dimPlane);
	}

	public buOrdinateDim(Plane sketchPlane, Point2D definingPoint, Point2D dimLinePos, bool isVertical, double textHeight)
	{
		DefiningPoint = new Point3D(definingPoint.X, definingPoint.Y);
		DimLinePosition = new Point3D(dimLinePos.X, dimLinePos.Y);
		Height = textHeight;
		this.isVertical = isVertical;
		Plane = (Plane)sketchPlane.Clone();
		Update(buEntityUpdateType.OrdinateDim, 0.01, sketchPlane);
	}

	public buOrdinateDim(buOrdinateDim another)
	{
		DefiningPoint = new Point3D(another.DefiningPoint.X, another.DefiningPoint.Y, another.DefiningPoint.Z);
		DimLinePosition = new Point3D(another.DimLinePosition.X, another.DimLinePosition.Y, another.DimLinePosition.Z);
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		Height = another.Height;
		isVertical = another.isVertical;
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
		Update(buEntityUpdateType.OrdinateDim, 0.01, another.Plane);
	}

	public buOrdinateDim(OrdinateDim another)
	{
		DefiningPoint = new Point3D(another.DefiningPoint.X, another.DefiningPoint.Y, another.DefiningPoint.Z);
		DimLinePosition = new Point3D(another.DimLinePosition.X, another.DimLinePosition.Y, another.DimLinePosition.Z);
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		Height = another.Height;
		isVertical = another.IsVertical;
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
		Update(buEntityUpdateType.OrdinateDim, 0.01, another.Plane);
	}
}
