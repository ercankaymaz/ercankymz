using System;
using System.Collections.Generic;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buCurve : buEntity
{
	public List<Point4D> ControlPoints = new List<Point4D>();

	public List<double> KnotVector = new List<double>();

	public int Degree = 2;

	public bool isRational = false;

	public buCurve(int degree, Point3D[] ctrlPoints)
	{
		Degree = degree;
		for (int i = 0; i <= ctrlPoints.Length - 1; i++)
		{
			ControlPoints.Add(new Point4D(ctrlPoints[i].X, ctrlPoints[i].Y, ctrlPoints[i].Z));
		}
		Update(buEntityUpdateType.CurveControlPoint);
	}

	public buCurve(int degree, List<Point3D> ctrlPoints)
	{
		Degree = degree;
		for (int i = 0; i <= ctrlPoints.Count - 1; i++)
		{
			ControlPoints.Add(new Point4D(ctrlPoints[i].X, ctrlPoints[i].Y, ctrlPoints[i].Z));
		}
		Update(buEntityUpdateType.CurveControlPoint);
	}

	public buCurve(int degree, double[] knotVector, Point4D[] ctrlPoints, bool checkKnotsAndCtrlPts = true)
	{
		Degree = degree;
		for (int i = 0; i <= ctrlPoints.Length - 1; i++)
		{
			ControlPoints.Add(new Point4D(ctrlPoints[i].X, ctrlPoints[i].Y, ctrlPoints[i].Z, ctrlPoints[i].W));
		}
		for (int j = 0; j <= knotVector.Length - 1; j++)
		{
			KnotVector.Add(knotVector[j]);
		}
		isRational = true;
		Update(buEntityUpdateType.CurveControlPoint4D);
	}

	public buCurve(buCurve another)
	{
		if (another.ControlPoints != null)
		{
			if (!another.isRational)
			{
				for (int i = 0; i <= another.ControlPoints.Count - 1; i++)
				{
					ControlPoints.Add(new Point4D(another.ControlPoints[i].X, another.ControlPoints[i].Y, another.ControlPoints[i].Z, another.ControlPoints[i].W));
				}
			}
			else
			{
				for (int j = 0; j <= another.KnotVector.Count - 1; j++)
				{
					KnotVector.Add(another.KnotVector[j]);
				}
				for (int k = 0; k <= another.ControlPoints.Count - 1; k++)
				{
					ControlPoints.Add(new Point4D(another.ControlPoints[k].X, another.ControlPoints[k].Y, another.ControlPoints[k].Z, another.ControlPoints[k].W));
				}
			}
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
		for (int l = 0; l <= another.Vertices.Count - 1; l++)
		{
			Vertices.Add(new Point3D(another.Vertices[l].X, another.Vertices[l].Y, another.Vertices[l].Z));
		}
	}

	public buCurve(Curve another)
	{
		Degree = another.Degree;
		if (another.IsRational)
		{
			for (int i = 0; i <= another.ControlPoints.Length - 1; i++)
			{
				ControlPoints.Add(new Point4D(another.ControlPoints[i].X, another.ControlPoints[i].Y, another.ControlPoints[i].Z, another.ControlPoints[i].W));
			}
			for (int j = 0; j <= another.KnotVector.Length - 1; j++)
			{
				KnotVector.Add(another.KnotVector[j]);
			}
		}
		else
		{
			for (int k = 0; k <= another.ControlPoints.Length - 1; k++)
			{
				ControlPoints.Add(new Point4D(another.ControlPoints[k].X, another.ControlPoints[k].Y, another.ControlPoints[k].Z, another.ControlPoints[k].W));
			}
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
		Update(buEntityUpdateType.CurveDerivate);
	}

	public override string ToString()
	{
		string text = "Curve ";
		if (ControlPoints.Count > 0)
		{
			text = text + "SP: " + buConversion5.Point3DToString(ControlPoints[0]) + " - EP: " + buConversion5.Point3DToString(ControlPoints[ControlPoints.Count - 1]) + " - Dir: " + sortDirection;
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
