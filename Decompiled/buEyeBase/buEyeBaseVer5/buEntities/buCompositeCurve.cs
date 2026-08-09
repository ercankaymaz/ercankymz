using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buCompositeCurve : buEntity
{
	public List<buEntity> CurveList = new List<buEntity>();

	internal bool sortAndOrient = true;

	internal double closureTol;

	public buCompositeCurve(buCompositeCurve another)
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

	public buCompositeCurve(CompositeCurve another)
	{
		for (int i = 0; i <= another.CurveList.Count - 1; i++)
		{
			CurveList.Add(buEntityUtilities.convEntity(another.CurveList[i]));
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
		Update(buEntityUpdateType.CompositeCurveDerivate);
	}

	public buCompositeCurve(List<buEntity> curveList)
	{
		buEntity.Copy(curveList, ref CurveList);
		Update(buEntityUpdateType.CompositeCurveCurveList);
	}

	public buCompositeCurve(buEntity[] curveList)
	{
		buEntity.Copy(curveList.ToList(), ref CurveList);
		Update(buEntityUpdateType.CompositeCurveCurveList);
	}

	public buCompositeCurve(buEntity another)
	{
		CurveList.Add(buEntity.Copy(another));
		Orientation = new OrientationAngle(another.Orientation);
		Update(buEntityUpdateType.CompositeCurveCurveList);
	}

	public buCompositeCurve(List<buEntity> curveList, bool sortAndOrient)
	{
		this.sortAndOrient = sortAndOrient;
		buEntity.Copy(curveList, ref CurveList);
		Update(buEntityUpdateType.CompositeCurveCurveListSort);
	}

	public buCompositeCurve(List<buEntity> curveList, double closureTol)
	{
		this.closureTol = closureTol;
		buEntity.Copy(curveList, ref CurveList);
		Update(buEntityUpdateType.CompositeCurveCurveListClosure);
	}

	public buCompositeCurve(List<buEntity> curveList, double closureTol, bool sortAndOrient)
	{
		this.sortAndOrient = sortAndOrient;
		this.closureTol = closureTol;
		buEntity.Copy(curveList, ref CurveList);
		Update(buEntityUpdateType.CompositeCurveCurveListSortClosure);
	}

	public override string ToString()
	{
		string text = "CompositeCurve ";
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
