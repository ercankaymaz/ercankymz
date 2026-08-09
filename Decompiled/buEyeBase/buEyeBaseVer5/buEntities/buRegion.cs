using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buRegion : buEntity
{
	public List<buEntity> CurveList = new List<buEntity>();

	public bool SortAndOrient = true;

	public Plane Plane = Plane.XY;

	public buRegion()
	{
	}

	public buRegion(devDept.Eyeshot.Entities.Region another)
	{
		for (int i = 0; i <= another.ContourList.Count - 1; i++)
		{
			CurveList.Add(buEntityUtilities.convEntity(another.ContourList[i]));
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
		Update(buEntityUpdateType.RegionDerivate);
	}

	public buRegion(buRegion another)
	{
		buEntity.Copy(another.CurveList, ref CurveList);
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
		Plane = new Plane(another.Plane.Origin, another.Plane.AxisX, another.Plane.AxisY);
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

	public buRegion(buEntity outer)
	{
		CurveList.Add(buEntity.Copy(outer));
		Orientation = new OrientationAngle(outer.Orientation);
		Update(buEntityUpdateType.RegionCurveList);
	}

	public buRegion(buEntity[] contours)
	{
		buEntity.Copy(contours.ToList(), ref CurveList);
		Update(buEntityUpdateType.RegionCurveList);
	}

	public buRegion(List<buEntity> contours)
	{
		buEntity.Copy(contours, ref CurveList);
		Update(buEntityUpdateType.RegionCurveList);
	}

	public buRegion(buEntity outer, Plane pln, bool sortAndOrient = true)
	{
		CurveList.Add(buEntity.Copy(outer));
		Orientation = new OrientationAngle(outer.Orientation);
		Plane = (Plane)pln.Clone();
		Update(buEntityUpdateType.RegionCurveList);
	}

	public buRegion(List<buEntity> contours, Plane pln, bool sortAndOrient = true)
	{
		SortAndOrient = sortAndOrient;
		buEntity.Copy(contours, ref CurveList);
		Plane = (Plane)pln.Clone();
		Update(buEntityUpdateType.RegionCurveListSort);
	}

	public override string ToString()
	{
		string text = "Region ";
		text = text + "Cnt: " + CurveList.Count + " - Dir: " + sortDirection;
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
