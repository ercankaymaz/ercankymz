using System;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buUpperLine : buEntity
{
	public buUpperLine()
	{
	}

	public buUpperLine(Point3D start, Point3D end)
	{
		StartPoint = new Point3D(start.X, start.Y, start.Z);
		EndPoint = new Point3D(end.X, end.Y, end.Z);
		Update(buEntityUpdateType.UpperLine);
	}

	public buUpperLine(double x1, double y1, double x2, double y2)
	{
		StartPoint = new Point3D(x1, y1, 0.0);
		EndPoint = new Point3D(x1, y1, 0.0);
		Update(buEntityUpdateType.UpperLine);
	}

	public buUpperLine(double x1, double y1, double z1, double x2, double y2, double z2)
	{
		StartPoint = new Point3D(x1, y1, z1);
		EndPoint = new Point3D(x1, y1, z2);
		Update(buEntityUpdateType.UpperLine);
	}

	public buUpperLine(buUpperLine another)
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

	public buUpperLine(Line another)
	{
		StartPoint = new Point3D(another.StartPoint.X, another.StartPoint.Y, another.StartPoint.Z);
		EndPoint = new Point3D(another.EndPoint.X, another.EndPoint.Y, another.EndPoint.Z);
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
		Update(buEntityUpdateType.UpperLine);
	}

	public override string ToString()
	{
		string text = "buUpperLine SP: " + buConversion5.Point3DToString(StartPoint) + " - EP: " + buConversion5.Point3DToString(EndPoint) + " " + sortDirection;
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
