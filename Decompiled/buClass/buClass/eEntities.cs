using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class eEntities : buSerilization
{
	public float dispThickness = 1f;

	public Color dispColor = Color.Black;

	public string dispPatternType = "";

	public drawingSourceType dispSourceMethod = drawingSourceType.Layer;

	public planeType OperationPlane = planeType.XY;

	public EntityPurposeType Purpose = EntityPurposeType.None;

	public int LayerIndex = 0;

	public int GroupIndex = 0;

	public string Tag = "";

	public int Mode = 0;

	public double auxValue = 0.0;

	public string auxText = null;

	public DrawSource EntityData = null;

	public int EntityIndex = 0;

	public int EntityID = 0;

	public int CamID = 0;

	public double geoLength = 0.0;

	public double geoAngleXY = 0.0;

	public Pnt3D geoMinPoint = new Pnt3D();

	public Pnt3D geoMaxPoint = new Pnt3D();

	public OrientationAngle Orientation = new OrientationAngle();

	public int camToolNo = 1;

	public string camCode = "";

	public camPathDirectionType camDirections = camPathDirectionType.Normal;

	public entityTypeDefination TypeDefination = entityTypeDefination.None;

	public bool bSelected = false;

	public bool bCamSelected = false;

	public bool bVisible = true;

	public bool bClosed = false;

	public bool bSelectable = true;

	public object Object = null;

	public TuftData Tuft = null;

	public ShapeData Shape = null;

	public DiemakerData Diemaker = null;

	public AdditionalData Additional = null;

	public List<Pnt3D> Vertice = new List<Pnt3D>();

	public List<Triangle3D> Triangles = null;

	public List<Pnt3D> Normals = null;

	public static void CopyBase(eEntities baseEnt, eEntities copiedEnt)
	{
		string text = baseEnt.GetType().BaseType.ToString();
		if (baseEnt.GetType().BaseType != null && baseEnt.GetType().BaseType == typeof(ePlaneEntities))
		{
			ePlaneEntities ePlaneEntities2 = new ePlaneEntities();
			ePlaneEntities.CopyPlaneBase(baseEnt, ref copiedEnt);
		}
		copiedEnt.bCamSelected = baseEnt.bCamSelected;
		copiedEnt.bClosed = baseEnt.bClosed;
		copiedEnt.bSelectable = baseEnt.bSelectable;
		copiedEnt.bSelected = baseEnt.bSelected;
		copiedEnt.bVisible = baseEnt.bVisible;
		copiedEnt.camCode = baseEnt.camCode;
		copiedEnt.camDirections = baseEnt.camDirections;
		copiedEnt.camToolNo = baseEnt.camToolNo;
		copiedEnt.TypeDefination = baseEnt.TypeDefination;
		copiedEnt.dispColor = baseEnt.dispColor;
		copiedEnt.dispSourceMethod = baseEnt.dispSourceMethod;
		copiedEnt.dispThickness = baseEnt.dispThickness;
		copiedEnt.dispPatternType = baseEnt.dispPatternType;
		copiedEnt.EntityData = baseEnt.EntityData;
		copiedEnt.EntityIndex = baseEnt.EntityIndex;
		copiedEnt.EntityID = baseEnt.EntityID;
		copiedEnt.CamID = baseEnt.CamID;
		copiedEnt.OperationPlane = baseEnt.OperationPlane;
		copiedEnt.Purpose = baseEnt.Purpose;
		copiedEnt.geoLength = baseEnt.geoLength;
		copiedEnt.geoMaxPoint = new Pnt3D(baseEnt.geoMaxPoint);
		copiedEnt.geoMinPoint = new Pnt3D(baseEnt.geoMinPoint);
		copiedEnt.Orientation = new OrientationAngle(baseEnt.Orientation);
		if (baseEnt.Tuft != null)
		{
			copiedEnt.Tuft = new TuftData(baseEnt.Tuft);
		}
		if (baseEnt.Diemaker != null)
		{
			copiedEnt.Diemaker = new DiemakerData(baseEnt.Diemaker);
		}
		if (baseEnt.Additional != null)
		{
			copiedEnt.Additional = new AdditionalData(baseEnt.Additional);
		}
		if (baseEnt.Shape != null)
		{
			copiedEnt.Shape = new ShapeData();
			ShapeData.Copy(baseEnt.Shape, ref copiedEnt.Shape);
		}
		copiedEnt.GroupIndex = baseEnt.GroupIndex;
		copiedEnt.LayerIndex = baseEnt.LayerIndex;
		copiedEnt.Mode = baseEnt.Mode;
		copiedEnt.Tag = baseEnt.Tag;
		copiedEnt.auxValue = baseEnt.auxValue;
		copiedEnt.auxText = baseEnt.auxText;
		copiedEnt.Vertice.Clear();
		for (int i = 0; i <= baseEnt.Vertice.Count - 1; i++)
		{
			copiedEnt.Vertice.Add(new Pnt3D(baseEnt.Vertice[i]));
		}
		if (baseEnt.Triangles != null)
		{
			copiedEnt.Triangles = new List<Triangle3D>();
			for (int j = 0; j <= baseEnt.Triangles.Count - 1; j++)
			{
				copiedEnt.Triangles.Add(new Triangle3D(baseEnt.Triangles[j]));
			}
		}
		if (baseEnt.Normals != null)
		{
			copiedEnt.Normals = new List<Pnt3D>();
			for (int k = 0; k <= baseEnt.Normals.Count - 1; k++)
			{
				copiedEnt.Normals.Add(new Pnt3D(baseEnt.Normals[k]));
			}
		}
	}

	public static void CopyCommonPorperties(eEntities baseEnt, ref eArc copiedEnt)
	{
		copiedEnt.bCamSelected = baseEnt.bCamSelected;
		copiedEnt.bClosed = baseEnt.bClosed;
		copiedEnt.bSelectable = baseEnt.bSelectable;
		copiedEnt.bSelected = baseEnt.bSelected;
		copiedEnt.bVisible = baseEnt.bVisible;
		copiedEnt.Purpose = baseEnt.Purpose;
		copiedEnt.camCode = baseEnt.camCode;
		copiedEnt.camDirections = baseEnt.camDirections;
		copiedEnt.camToolNo = baseEnt.camToolNo;
		copiedEnt.TypeDefination = baseEnt.TypeDefination;
		copiedEnt.dispColor = baseEnt.dispColor;
		copiedEnt.dispSourceMethod = baseEnt.dispSourceMethod;
		copiedEnt.dispThickness = baseEnt.dispThickness;
		copiedEnt.dispPatternType = baseEnt.dispPatternType;
		copiedEnt.OperationPlane = baseEnt.OperationPlane;
		copiedEnt.EntityData = baseEnt.EntityData;
		copiedEnt.EntityIndex = baseEnt.EntityIndex;
		copiedEnt.EntityID = baseEnt.EntityID;
		copiedEnt.CamID = baseEnt.CamID;
		if (baseEnt.Tuft != null)
		{
			copiedEnt.Tuft = new TuftData(baseEnt.Tuft);
		}
		if (baseEnt.Diemaker != null)
		{
			copiedEnt.Diemaker = new DiemakerData(baseEnt.Diemaker);
		}
		if (baseEnt.Additional != null)
		{
			copiedEnt.Additional = new AdditionalData(baseEnt.Additional);
		}
		if (baseEnt.Shape != null)
		{
			copiedEnt.Shape = new ShapeData();
			ShapeData.Copy(baseEnt.Shape, ref copiedEnt.Shape);
		}
		copiedEnt.geoLength = baseEnt.geoLength;
		copiedEnt.geoMaxPoint = new Pnt3D(baseEnt.geoMaxPoint);
		copiedEnt.geoMinPoint = new Pnt3D(baseEnt.geoMinPoint);
		copiedEnt.Orientation = new OrientationAngle(baseEnt.Orientation);
		copiedEnt.GroupIndex = baseEnt.GroupIndex;
		copiedEnt.LayerIndex = baseEnt.LayerIndex;
		copiedEnt.Mode = baseEnt.Mode;
		copiedEnt.Tag = baseEnt.Tag;
		copiedEnt.auxValue = baseEnt.auxValue;
		copiedEnt.auxText = baseEnt.auxText;
	}

	public static void CopyCommonPorperties(eEntities baseEnt, ref eEntities copiedEnt)
	{
		copiedEnt.bCamSelected = baseEnt.bCamSelected;
		copiedEnt.bClosed = baseEnt.bClosed;
		copiedEnt.bSelectable = baseEnt.bSelectable;
		copiedEnt.bSelected = baseEnt.bSelected;
		copiedEnt.bVisible = baseEnt.bVisible;
		copiedEnt.Purpose = baseEnt.Purpose;
		copiedEnt.camCode = baseEnt.camCode;
		copiedEnt.camDirections = baseEnt.camDirections;
		copiedEnt.camToolNo = baseEnt.camToolNo;
		copiedEnt.TypeDefination = baseEnt.TypeDefination;
		copiedEnt.dispColor = baseEnt.dispColor;
		copiedEnt.dispSourceMethod = baseEnt.dispSourceMethod;
		copiedEnt.dispThickness = baseEnt.dispThickness;
		copiedEnt.dispPatternType = baseEnt.dispPatternType;
		copiedEnt.OperationPlane = baseEnt.OperationPlane;
		copiedEnt.EntityData = baseEnt.EntityData;
		copiedEnt.EntityIndex = baseEnt.EntityIndex;
		copiedEnt.EntityID = baseEnt.EntityID;
		copiedEnt.CamID = baseEnt.CamID;
		if (baseEnt.Tuft != null)
		{
			copiedEnt.Tuft = new TuftData(baseEnt.Tuft);
		}
		if (baseEnt.Diemaker != null)
		{
			copiedEnt.Diemaker = new DiemakerData(baseEnt.Diemaker);
		}
		if (baseEnt.Additional != null)
		{
			copiedEnt.Additional = new AdditionalData(baseEnt.Additional);
		}
		if (baseEnt.Shape != null)
		{
			copiedEnt.Shape = new ShapeData();
			ShapeData.Copy(baseEnt.Shape, ref copiedEnt.Shape);
		}
		copiedEnt.geoLength = baseEnt.geoLength;
		copiedEnt.geoMaxPoint = new Pnt3D(baseEnt.geoMaxPoint);
		copiedEnt.geoMinPoint = new Pnt3D(baseEnt.geoMinPoint);
		copiedEnt.Orientation = new OrientationAngle(baseEnt.Orientation);
		copiedEnt.GroupIndex = baseEnt.GroupIndex;
		copiedEnt.LayerIndex = baseEnt.LayerIndex;
		copiedEnt.Mode = baseEnt.Mode;
		copiedEnt.Tag = baseEnt.Tag;
		copiedEnt.auxValue = baseEnt.auxValue;
		copiedEnt.auxText = baseEnt.auxText;
	}

	public static void CopyCommonPorperties(eEntities baseEnt, bool GeometryThings, bool DisplayThings, bool CamThings, ref eEntities copiedEnt)
	{
		copiedEnt.bClosed = baseEnt.bClosed;
		copiedEnt.bSelectable = baseEnt.bSelectable;
		copiedEnt.bSelected = baseEnt.bSelected;
		copiedEnt.bVisible = baseEnt.bVisible;
		copiedEnt.Purpose = baseEnt.Purpose;
		copiedEnt.OperationPlane = baseEnt.OperationPlane;
		copiedEnt.TypeDefination = baseEnt.TypeDefination;
		if (CamThings)
		{
			copiedEnt.bCamSelected = baseEnt.bCamSelected;
			copiedEnt.camCode = baseEnt.camCode;
			copiedEnt.camDirections = baseEnt.camDirections;
			copiedEnt.camToolNo = baseEnt.camToolNo;
		}
		if (DisplayThings)
		{
			copiedEnt.dispColor = baseEnt.dispColor;
			copiedEnt.dispSourceMethod = baseEnt.dispSourceMethod;
			copiedEnt.dispThickness = baseEnt.dispThickness;
			copiedEnt.dispPatternType = baseEnt.dispPatternType;
		}
		copiedEnt.EntityData = baseEnt.EntityData;
		copiedEnt.EntityIndex = baseEnt.EntityIndex;
		copiedEnt.EntityID = baseEnt.EntityID;
		copiedEnt.CamID = baseEnt.CamID;
		if (baseEnt.Tuft != null)
		{
			copiedEnt.Tuft = new TuftData(baseEnt.Tuft);
		}
		if (baseEnt.Diemaker != null)
		{
			copiedEnt.Diemaker = new DiemakerData(baseEnt.Diemaker);
		}
		if (baseEnt.Additional != null)
		{
			copiedEnt.Additional = new AdditionalData(baseEnt.Additional);
		}
		if (baseEnt.Shape != null)
		{
			copiedEnt.Shape = new ShapeData();
			ShapeData.Copy(baseEnt.Shape, ref copiedEnt.Shape);
		}
		if (GeometryThings)
		{
			copiedEnt.geoLength = baseEnt.geoLength;
			copiedEnt.geoMaxPoint = new Pnt3D(baseEnt.geoMaxPoint);
			copiedEnt.geoMinPoint = new Pnt3D(baseEnt.geoMinPoint);
		}
		copiedEnt.Orientation = new OrientationAngle(baseEnt.Orientation);
		copiedEnt.GroupIndex = baseEnt.GroupIndex;
		copiedEnt.LayerIndex = baseEnt.LayerIndex;
		copiedEnt.Mode = baseEnt.Mode;
		copiedEnt.Tag = baseEnt.Tag;
		copiedEnt.auxValue = baseEnt.auxValue;
		copiedEnt.auxText = baseEnt.auxText;
	}

	public static void CopyEntity(eEntities baseEnt, ref eEntities copiedEnt)
	{
		copiedEnt = new eEntities();
		if (baseEnt == null)
		{
			copiedEnt = null;
			return;
		}
		if (baseEnt.GetType() == typeof(ePoint))
		{
			copiedEnt = new ePoint(baseEnt);
		}
		if (baseEnt.GetType() == typeof(ePointGroup))
		{
			copiedEnt = new ePointGroup(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eLine))
		{
			copiedEnt = new eLine(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eCircle))
		{
			copiedEnt = new eCircle(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eArc))
		{
			copiedEnt = new eArc(baseEnt);
		}
		if (baseEnt.GetType() == typeof(ePolyline))
		{
			copiedEnt = new ePolyline(baseEnt);
		}
		if (baseEnt.GetType() == typeof(ePolylineGroup))
		{
			copiedEnt = new ePolylineGroup(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eEllipse))
		{
			copiedEnt = new eEllipse(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eEllipseArc))
		{
			copiedEnt = new eEllipseArc(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eBSpline))
		{
			copiedEnt = new eBSpline(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eBezeir))
		{
			copiedEnt = new eBezeir(baseEnt);
		}
		if (baseEnt.GetType() == typeof(ePicture))
		{
			copiedEnt = new ePicture(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eText))
		{
			copiedEnt = new eText(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eCam))
		{
			copiedEnt = new eCam(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eUpperLine))
		{
			copiedEnt = new eUpperLine(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eSolid3D))
		{
			copiedEnt = new eSolid3D(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eDimLineer))
		{
			copiedEnt = new eDimLineer(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eDimRadial))
		{
			copiedEnt = new eDimRadial(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eDimDiametric))
		{
			copiedEnt = new eDimDiametric(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eDimAngular))
		{
			copiedEnt = new eDimAngular(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eSurface))
		{
			copiedEnt = new eSurface(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eMesh))
		{
			copiedEnt = new eMesh(baseEnt);
		}
		if (baseEnt.GetType() == typeof(eSurfaceNull))
		{
			copiedEnt = new eSurfaceNull(baseEnt);
		}
	}

	public static void CopyEntityKeepIDAndIndex(eEntities baseEnt, ref eEntities copiedEnt)
	{
		int entityID = copiedEnt.EntityID;
		int entityIndex = copiedEnt.EntityIndex;
		CopyEntity(baseEnt, ref copiedEnt);
		copiedEnt.EntityID = entityID;
		copiedEnt.EntityIndex = entityIndex;
	}

	public static eEntities CopyEntityKeepIDAndIndex(eEntities baseEnt, eEntities copiedEnt)
	{
		int entityID = copiedEnt.EntityID;
		int entityIndex = copiedEnt.EntityIndex;
		CopyEntity(baseEnt, ref copiedEnt);
		copiedEnt.EntityID = entityID;
		copiedEnt.EntityIndex = entityIndex;
		return copiedEnt;
	}

	public static eEntities CopyEntity(eEntities baseEnt)
	{
		eEntities copiedEnt = new eEntities();
		CopyEntity(baseEnt, ref copiedEnt);
		return copiedEnt;
	}

	public static void CopyEntities(List<eEntities> baseEnt, ref List<eEntities> CopiedEnt)
	{
		if (CopiedEnt == null)
		{
			CopiedEnt = new List<eEntities>();
		}
		CopiedEnt.Clear();
		for (int i = 0; i <= baseEnt.Count - 1; i++)
		{
			eEntities copiedEnt = new eEntities();
			CopyEntity(baseEnt[i], ref copiedEnt);
			CopiedEnt.Add(copiedEnt);
		}
	}

	public static void CopyEntities(List<eEntities> baseEnt, List<eEntities> CopiedEnt)
	{
		if (CopiedEnt == null)
		{
			CopiedEnt = new List<eEntities>();
		}
		CopiedEnt.Clear();
		for (int i = 0; i <= baseEnt.Count - 1; i++)
		{
			eEntities copiedEnt = new eEntities();
			CopyEntity(baseEnt[i], ref copiedEnt);
			CopiedEnt.Add(copiedEnt);
		}
	}

	public static void CopyEntities(List<List<eEntities>> baseEnt, ref List<List<eEntities>> CopiedEnt)
	{
		if (CopiedEnt == null)
		{
			CopiedEnt = new List<List<eEntities>>();
		}
		CopiedEnt.Clear();
		for (int i = 0; i <= baseEnt.Count - 1; i++)
		{
			List<eEntities> CopiedEnt2 = new List<eEntities>();
			CopyEntities(baseEnt[i], ref CopiedEnt2);
			CopiedEnt.Add(CopiedEnt2);
		}
	}

	public static List<eEntities> CopyEntities(List<eEntities> baseEnt)
	{
		List<eEntities> CopiedEnt = new List<eEntities>();
		CopyEntities(baseEnt, ref CopiedEnt);
		return CopiedEnt;
	}

	public static void AddEntity(eEntities baseEnt, ref List<eEntities> listEnt)
	{
		eEntities copiedEnt = new eEntities();
		CopyEntity(baseEnt, ref copiedEnt);
		listEnt.Add(copiedEnt);
		copiedEnt.Vertice.Clear();
	}

	public static void AddEntities(List<eEntities> baseEnt, ref List<eEntities> CopiedEnt)
	{
		for (int i = 0; i <= baseEnt.Count - 1; i++)
		{
			eEntities copiedEnt = new eEntities();
			CopyEntity(baseEnt[i], ref copiedEnt);
			CopiedEnt.Add(copiedEnt);
		}
	}

	public static void AddEntities(List<List<eEntities>> baseEnt, ref List<List<eEntities>> CopiedEnt)
	{
		for (int i = 0; i <= baseEnt.Count - 1; i++)
		{
			List<eEntities> CopiedEnt2 = new List<eEntities>();
			CopyEntities(baseEnt[i], ref CopiedEnt2);
			CopiedEnt.Add(CopiedEnt2);
		}
	}

	public static void SetAuxText(string Text, ref eEntities Entity)
	{
		Entity.auxText = Text;
	}

	public static void SetAuxValue(double Value, ref eEntities Entity)
	{
		Entity.auxValue = Value;
	}

	public static void ResetCamSelected(ref eEntities Ent)
	{
		Ent.bCamSelected = false;
	}

	public static void ResetCamSelected(ref List<eEntities> Ent)
	{
		for (int i = 0; i <= Ent.Count - 1; i++)
		{
			Ent[i].bCamSelected = false;
		}
	}

	public void Update()
	{
		if (GetType() == typeof(ePoint))
		{
			Vertice.Clear();
			Vertice.Add(new Pnt3D(((ePoint)this).StartPoint));
			geoMinPoint = new Pnt3D(((ePoint)this).StartPoint);
			geoMaxPoint = new Pnt3D(((ePoint)this).StartPoint);
		}
		if (GetType() == typeof(ePointGroup))
		{
			geoLength = 0.0;
			geoAngleXY = 0.0;
		}
		if (GetType() == typeof(eLine))
		{
			Vertice.Clear();
			Vertice.Add(new Pnt3D(((eLine)this).StartPoint));
			Vertice.Add(new Pnt3D(((eLine)this).EndPoint));
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
			geoLength = buStatics.Length3D(Vertice);
			geoAngleXY = buStatics.PointAngle(((eLine)this).EndPoint, ((eLine)this).StartPoint);
		}
		if (GetType() == typeof(eUpperLine))
		{
			Vertice.Clear();
			Vertice.Add(new Pnt3D(((eUpperLine)this).StartPoint));
			Vertice.Add(new Pnt3D(((eUpperLine)this).EndPoint));
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
			geoLength = buStatics.Length3D(Vertice);
			geoAngleXY = buStatics.PointAngle(((eUpperLine)this).EndPoint, ((eUpperLine)this).StartPoint);
		}
		if (GetType() == typeof(eCircle))
		{
			Vertice.Clear();
			int num = buStatics.ArcVerticeCountByResolution(((eCircle)this).Radius, 0.0, 360.0, buSystem.EntitiesResolution);
			if (num < 50)
			{
				num = 50;
			}
			buStatics.ArcToLineerByCount(((eCircle)this).CenterPoint, ((eCircle)this).Radius, 0.0, 360.0, num, ((eCircle)this).Plane, ref ((eCircle)this).Vertice);
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
			geoLength = Math.PI * 2.0 * ((eCircle)this).Radius;
			geoAngleXY = 0.0;
		}
		if (GetType() == typeof(eArc))
		{
			Vertice.Clear();
			int count = buStatics.ArcVerticeCountByResolution(((eArc)this).Radius, ((eArc)this).StartAngle, ((eArc)this).EndAngle, buSystem.EntitiesResolution);
			Pnt3D StartPoint = new Pnt3D();
			Pnt3D MiddlePoint = new Pnt3D();
			Pnt3D EndPoint = new Pnt3D();
			buStatics.ArcStartMiddleEndPoint(((eArc)this).CenterPoint, ((eArc)this).Radius, ((eArc)this).StartAngle, ((eArc)this).EndAngle, ((eArc)this).Plane, ref StartPoint, ref MiddlePoint, ref EndPoint);
			buStatics.ArcToLineerByCount(((eArc)this).CenterPoint, ((eArc)this).Radius, ((eArc)this).StartAngle, ((eArc)this).EndAngle, count, ((eArc)this).Plane, ref ((eArc)this).Vertice);
			if (((eArc)this).Vertice.Count > 0)
			{
				((eArc)this).StartPoint = new Pnt3D(Vertice[0]);
				((eArc)this).EndPoint = new Pnt3D(Vertice[Vertice.Count - 1]);
				((eArc)this).MiddlePoint = new Pnt3D(MiddlePoint);
			}
			geoLength = Math.PI * 2.0 * ((eArc)this).Radius * (((eArc)this).EndAngle - ((eArc)this).StartAngle) / 360.0;
			geoAngleXY = 0.0;
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
		}
		if (GetType() == typeof(ePolyline))
		{
			geoLength = buStatics.Length3D(Vertice);
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
		}
		if (GetType() == typeof(ePolylineGroup))
		{
			List<List<Pnt3D>> TargetList = new List<List<Pnt3D>>();
			Pnt3D.Add(((ePolylineGroup)this).GroupVertices, ref TargetList);
			Pnt3D.Add(((ePolylineGroup)this).InternalVertices, ref TargetList);
			geoAngleXY = 0.0;
			buStatics.BoxSizeCalculate(TargetList, ref geoMinPoint, ref geoMaxPoint);
		}
		if (GetType() == typeof(eEllipse))
		{
			Vertice.Clear();
			int count2 = buStatics.EllipseVerticeCountByResolution(((eEllipse)this).MajorRadius, ((eEllipse)this).MinorRadius, buSystem.EntitiesResolution);
			buStatics.ArcEllipseToLineerByCount(((eEllipse)this).CenterPoint, ((eEllipse)this).MajorRadius, ((eEllipse)this).MinorRadius, 0.0, 360.0, ((eEllipse)this).Angle, count2, ((eEllipse)this).Plane, ref ((eEllipse)this).Vertice);
			geoLength = Math.Sqrt((((eEllipse)this).MajorRadius * ((eEllipse)this).MajorRadius + ((eEllipse)this).MinorRadius * ((eEllipse)this).MinorRadius) * 0.5) * Math.PI * 2.0;
			geoAngleXY = 0.0;
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
		}
		if (GetType() == typeof(eEllipseArc))
		{
			Vertice.Clear();
			int count3 = buStatics.ArcEllipseVerticeCountByResolution(((eEllipseArc)this).MajorRadius, ((eEllipseArc)this).MinorRadius, ((eEllipseArc)this).StartAngle, ((eEllipseArc)this).EndAngle, buSystem.EntitiesResolution);
			buStatics.ArcEllipseToLineerByCount(((eEllipseArc)this).CenterPoint, ((eEllipseArc)this).MajorRadius, ((eEllipseArc)this).MinorRadius, ((eEllipseArc)this).StartAngle, ((eEllipseArc)this).EndAngle, ((eEllipseArc)this).Angle, count3, ((eEllipseArc)this).Plane, ref ((eEllipseArc)this).Vertice);
			if (((eEllipseArc)this).Vertice.Count > 0)
			{
				((eEllipseArc)this).StartPoint = new Pnt3D(Vertice[0]);
				((eEllipseArc)this).EndPoint = new Pnt3D(Vertice[Vertice.Count - 1]);
			}
			geoLength = Math.Sqrt((((eEllipseArc)this).MajorRadius * ((eEllipseArc)this).MajorRadius + ((eEllipseArc)this).MinorRadius * ((eEllipseArc)this).MinorRadius) * 0.5) * Math.PI * 2.0 * (((eEllipseArc)this).EndAngle - ((eEllipseArc)this).StartAngle) / 360.0;
			geoAngleXY = 0.0;
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
		}
		if (GetType() == typeof(eBezeir))
		{
			Vertice.Clear();
			buStatics.CreatBezeirCurve(((eBezeir)this).ControlPoints, buSystem.EntitiesResolution.dt, ref Vertice);
			if (((eBezeir)this).Vertice.Count > 0)
			{
				((eBezeir)this).StartPoint = new Pnt3D(Vertice[0]);
				((eBezeir)this).EndPoint = new Pnt3D(Vertice[Vertice.Count - 1]);
			}
			geoLength = buStatics.Length3D(Vertice);
			geoAngleXY = 0.0;
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
		}
		if (GetType() == typeof(eBSpline))
		{
			double dt = buSystem.EntitiesResolution.dt;
			if (((eBSpline)this).dt > 0.0)
			{
				dt = ((eBSpline)this).dt;
			}
			Vertice.Clear();
			if (((eBSpline)this).BType == entityBSplineType.BSplineCubic)
			{
				buStatics.CreatBSplineCubicUniform(((eBSpline)this).ControlPoints, dt, bClosed, ref Vertice);
			}
			if (((eBSpline)this).BType == entityBSplineType.BSplineQuadratic)
			{
				buStatics.CreatBSplineQuadraticUniform(((eBSpline)this).ControlPoints, dt, bClosed, ref Vertice);
			}
			if (((eBSpline)this).BType == entityBSplineType.SplineCubic)
			{
				buStatics.CreatSplineCubicUniform(((eBSpline)this).ControlPoints, dt, ref Vertice);
			}
			if (((eBSpline)this).Vertice.Count > 0)
			{
				((eBSpline)this).StartPoint = new Pnt3D(Vertice[0]);
				((eBSpline)this).EndPoint = new Pnt3D(Vertice[Vertice.Count - 1]);
			}
			geoLength = buStatics.Length3D(Vertice);
			geoAngleXY = 0.0;
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
		}
		if (GetType() == typeof(ePicture))
		{
			Vertice.Clear();
			buStatics.RectangleCorner(((ePicture)this).StartPoint, ((ePicture)this).EndPoint, ((ePicture)this).Plane, ref Vertice);
			geoLength = buStatics.Length3D(Vertice);
			geoAngleXY = 0.0;
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
		}
		if (GetType() == typeof(eText))
		{
			Graphics graphics = Graphics.FromImage(new Bitmap(1000, 1000));
			Font font = new Font(((eText)this).TextFont.Name, (float)((eText)this).Height);
			SizeF sizeF = graphics.MeasureString(((eText)this).TextString, font, new PointF(0f, 0f), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
			Pnt3D pts = new Pnt3D(((eText)this).StartPoint);
			if (WorkPlane.isPlaneXY(((eText)this).Plane))
			{
				Pnt3D.Offset(ref pts, sizeF.Width, sizeF.Height, 0.0);
			}
			if (WorkPlane.isPlaneXZ(((eText)this).Plane))
			{
				Pnt3D.Offset(ref pts, sizeF.Width, 0.0, sizeF.Height);
			}
			if (WorkPlane.isPlaneYZ(((eText)this).Plane))
			{
				Pnt3D.Offset(ref pts, 0.0, sizeF.Width, sizeF.Height);
			}
			List<Pnt3D> Vertices = new List<Pnt3D>();
			buStatics.RectangleCorner(((eText)this).StartPoint, pts, ((eText)this).Plane, ref Vertices);
			Vertice.Clear();
			Pnt3D.Copy(Vertices, ref Vertice);
			geoLength = 0.0;
			geoAngleXY = 0.0;
		}
		if (GetType() == typeof(eCam))
		{
			geoLength = buStatics.Length3D(Vertice);
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
		}
		if (GetType() == typeof(eSolid3D))
		{
			Vertice.Clear();
			if (((eSolid3D)this).Triangles.Count > 0)
			{
				for (int i = 0; i <= ((eSolid3D)this).Triangles.Count - 1; i++)
				{
					Vertice.Add(new Pnt3D(((eSolid3D)this).Triangles[i].FirstPoint));
					Vertice.Add(new Pnt3D(((eSolid3D)this).Triangles[i].SecondPoint));
					Vertice.Add(new Pnt3D(((eSolid3D)this).Triangles[i].ThirdPoint));
				}
			}
			geoLength = 0.0;
			geoAngleXY = 0.0;
		}
		if (GetType() == typeof(eDimLineer))
		{
			Vertice.Clear();
			Vertice.Add(new Pnt3D(((eDimLineer)this).StartPoint));
			Vertice.Add(new Pnt3D(((eDimLineer)this).EndPoint));
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
			geoLength = buStatics.Length3D(Vertice);
			geoAngleXY = buStatics.PointAngle(((eDimLineer)this).EndPoint, ((eDimLineer)this).StartPoint);
		}
		if (GetType() == typeof(eDimRadial))
		{
			Vertice.Clear();
			Vertice.Add(new Pnt3D(((eDimRadial)this).StartPoint));
			Vertice.Add(new Pnt3D(((eDimRadial)this).EndPoint));
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
			geoLength = buStatics.Length3D(Vertice);
			geoAngleXY = buStatics.PointAngle(((eDimRadial)this).EndPoint, ((eDimRadial)this).StartPoint);
		}
		if (GetType() == typeof(eDimDiametric))
		{
			Vertice.Clear();
			Vertice.Add(new Pnt3D(((eDimDiametric)this).StartPoint));
			Vertice.Add(new Pnt3D(((eDimDiametric)this).EndPoint));
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
			geoLength = buStatics.Length3D(Vertice);
			geoAngleXY = buStatics.PointAngle(((eDimDiametric)this).EndPoint, ((eDimDiametric)this).StartPoint);
		}
		if (GetType() == typeof(eDimAngular))
		{
			Vertice.Clear();
			Vertice.Add(new Pnt3D(((eDimAngular)this).StartPoint));
			Vertice.Add(new Pnt3D(((eDimAngular)this).EndPoint));
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
			geoLength = buStatics.Length3D(Vertice);
			geoAngleXY = buStatics.PointAngle(((eDimAngular)this).EndPoint, ((eDimAngular)this).StartPoint);
		}
		if (GetType() == typeof(eSurface))
		{
			if (Triangles.Count > 0)
			{
				Vertice.Clear();
				if (((eSurface)this).Triangles.Count > 0)
				{
					for (int j = 0; j <= ((eSurface)this).Triangles.Count - 1; j++)
					{
						Vertice.Add(new Pnt3D(((eSurface)this).Triangles[j].FirstPoint));
						Vertice.Add(new Pnt3D(((eSurface)this).Triangles[j].SecondPoint));
						Vertice.Add(new Pnt3D(((eSurface)this).Triangles[j].ThirdPoint));
					}
				}
			}
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
			geoLength = 0.0;
		}
		if (GetType() == typeof(eMesh))
		{
			buStatics.BoxSizeCalculate(Vertice, ref geoMinPoint, ref geoMaxPoint);
			geoLength = 0.0;
		}
		if (!(GetType() == typeof(eSurfaceNull)))
		{
			return;
		}
		Vertice.Clear();
		if (((eSurfaceNull)this).Triangles.Count > 0)
		{
			for (int k = 0; k <= ((eSurfaceNull)this).Triangles.Count - 1; k++)
			{
				Vertice.Add(new Pnt3D(((eSurfaceNull)this).Triangles[k].FirstPoint));
				Vertice.Add(new Pnt3D(((eSurfaceNull)this).Triangles[k].SecondPoint));
				Vertice.Add(new Pnt3D(((eSurfaceNull)this).Triangles[k].ThirdPoint));
			}
		}
		geoLength = 0.0;
	}

	public string ToInfo(bool CamData)
	{
		try
		{
			string text = "Line";
			string text2 = "Arc";
			string text3 = "Circle";
			string text4 = "Point";
			string text5 = "Polyline";
			string text6 = "Ellipse";
			string text7 = "Ellipse Arc";
			string text8 = "Bezeir";
			string text9 = "BSpline";
			string text10 = "Plane";
			string text11 = "Count";
			string text12 = "Type";
			string text13 = "Length";
			string text14 = "Angle";
			string text15 = "Size";
			string text16 = "Start";
			string text17 = "End";
			string text18 = "Radius";
			string text19 = "Start Angle";
			string text20 = "End Angle";
			string text21 = "Major Radius";
			string text22 = "MinorRadius";
			string text23 = "Entitiy Sequence";
			string text24 = "Layer Sequence";
			string text25 = "Selected";
			string text26 = "Cam Selected";
			string text27 = "CamDirection";
			string text28 = "Tool";
			string text29 = "Surface";
			string text30 = "Mesh";
			string text31 = "Color";
			string text32 = "Thickness";
			string text33 = "Center";
			string text34 = "Image";
			string text35 = "Text";
			string text36 = "Height";
			string text37 = "Solid";
			string text38 = "Dim Linear";
			string text39 = "Dim Alinged";
			string text40 = "Dim Radius";
			string text41 = "Dim Diameter";
			string text42 = "Dim Oriented Hor";
			string text43 = "Dim Oriented Ver";
			string text44 = "Dim Angular";
			string text45 = "Diameter";
			string text46 = "Direction";
			if (AppLanguage.buClassStrings.Count > 44)
			{
				text4 = AppLanguage.buClassStrings[0];
				text = AppLanguage.buClassStrings[1];
				text2 = AppLanguage.buClassStrings[3];
				text3 = AppLanguage.buClassStrings[2];
				text6 = AppLanguage.buClassStrings[4];
				text7 = AppLanguage.buClassStrings[5];
				text8 = AppLanguage.buClassStrings[6];
				text9 = AppLanguage.buClassStrings[7];
				text5 = AppLanguage.buClassStrings[8];
				text16 = AppLanguage.buClassStrings[9];
				text17 = AppLanguage.buClassStrings[10];
				text13 = AppLanguage.buClassStrings[11];
				text14 = AppLanguage.buClassStrings[12];
				text15 = AppLanguage.buClassStrings[13];
				text23 = AppLanguage.buClassStrings[14];
				text24 = AppLanguage.buClassStrings[15];
				text18 = AppLanguage.buClassStrings[16];
				text19 = AppLanguage.buClassStrings[17];
				text20 = AppLanguage.buClassStrings[18];
				text21 = AppLanguage.buClassStrings[19];
				text22 = AppLanguage.buClassStrings[20];
				text11 = AppLanguage.buClassStrings[21];
				text12 = AppLanguage.buClassStrings[22];
				text10 = AppLanguage.buClassStrings[23];
				text25 = AppLanguage.buClassStrings[24];
				text26 = AppLanguage.buClassStrings[25];
				text27 = AppLanguage.buClassStrings[26];
				text28 = AppLanguage.buClassStrings[27];
				text31 = AppLanguage.buClassStrings[28];
				text32 = AppLanguage.buClassStrings[29];
				text33 = AppLanguage.buClassStrings[30];
				text34 = AppLanguage.buClassStrings[31];
				text35 = AppLanguage.buClassStrings[32];
				text36 = AppLanguage.buClassStrings[33];
				text29 = AppLanguage.buClassStrings[34];
				text37 = AppLanguage.buClassStrings[35];
				text38 = AppLanguage.buClassStrings[36];
				text39 = AppLanguage.buClassStrings[37];
				text40 = AppLanguage.buClassStrings[38];
				text41 = AppLanguage.buClassStrings[39];
				text43 = AppLanguage.buClassStrings[40];
				text42 = AppLanguage.buClassStrings[41];
				text44 = AppLanguage.buClassStrings[42];
				text45 = AppLanguage.buClassStrings[43];
				text46 = AppLanguage.buClassStrings[44];
			}
			string text47 = "";
			if (GetType() == typeof(ePoint))
			{
				text47 = text4 + Environment.NewLine;
				text47 = text47 + text16 + " (" + Vertice[0].X.ToString("f3") + " , " + Vertice[0].Y.ToString("f3") + " , " + Vertice[0].Z.ToString("f3") + ")" + Environment.NewLine;
			}
			if (GetType() == typeof(eLine))
			{
				text47 = text + Environment.NewLine;
				text47 = text47 + text16 + " (" + Vertice[0].X.ToString("f3") + " , " + Vertice[0].Y.ToString("f3") + " , " + Vertice[0].Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text17 + " (" + Vertice[Vertice.Count - 1].X.ToString("f3") + " , " + Vertice[Vertice.Count - 1].Y.ToString("f3") + " , " + Vertice[Vertice.Count - 1].Z.ToString("f3") + ")" + Environment.NewLine;
			}
			if (GetType() == typeof(eCircle))
			{
				eCircle eCircle2 = new eCircle((eCircle)this);
				text47 = text3 + Environment.NewLine;
				text47 = text47 + text33 + " (" + eCircle2.CenterPoint.X.ToString("f3") + " , " + eCircle2.CenterPoint.Y.ToString("f3") + " , " + eCircle2.CenterPoint.Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text18 + " = " + eCircle2.Radius.ToString("f3") + Environment.NewLine;
				text47 = text47 + text10 + " = " + eCircle2.Plane.ToString() + Environment.NewLine;
			}
			if (GetType() == typeof(eArc))
			{
				eArc eArc2 = new eArc((eArc)this);
				text47 = text2 + Environment.NewLine;
				text47 = text47 + text33 + " (" + eArc2.CenterPoint.X.ToString("f3") + " , " + eArc2.CenterPoint.Y.ToString("f3") + " , " + eArc2.CenterPoint.Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text18 + " = " + eArc2.Radius.ToString("f3") + Environment.NewLine;
				text47 = text47 + text19 + " = " + eArc2.StartAngle.ToString("f3") + Environment.NewLine;
				text47 = text47 + text20 + " = " + eArc2.EndAngle.ToString("f3") + Environment.NewLine;
				text47 = text47 + text10 + " = " + eArc2.Plane.ToString() + Environment.NewLine;
			}
			if (GetType() == typeof(eEllipse))
			{
				eEllipse eEllipse2 = new eEllipse((eEllipse)this);
				text47 = text6 + Environment.NewLine;
				text47 = text47 + text33 + " (" + eEllipse2.CenterPoint.X.ToString("f3") + " , " + eEllipse2.CenterPoint.Y.ToString("f3") + " , " + eEllipse2.CenterPoint.Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text21 + " = " + eEllipse2.MajorRadius.ToString("f3") + Environment.NewLine;
				text47 = text47 + text22 + " = " + eEllipse2.MinorRadius.ToString("f3") + Environment.NewLine;
				text47 = text47 + text14 + " = " + eEllipse2.Angle.ToString("f3") + Environment.NewLine;
				text47 = text47 + text10 + " = " + eEllipse2.Plane.ToString() + Environment.NewLine;
			}
			if (GetType() == typeof(eEllipseArc))
			{
				eEllipseArc eEllipseArc2 = new eEllipseArc((eEllipseArc)this);
				text47 = text6 + Environment.NewLine;
				text47 = text47 + text33 + " (" + eEllipseArc2.CenterPoint.X.ToString("f3") + " , " + eEllipseArc2.CenterPoint.Y.ToString("f3") + " , " + eEllipseArc2.CenterPoint.Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text21 + " = " + eEllipseArc2.MajorRadius.ToString("f3") + Environment.NewLine;
				text47 = text47 + text22 + " = " + eEllipseArc2.MinorRadius.ToString("f3") + Environment.NewLine;
				text47 = text47 + text19 + " = " + eEllipseArc2.StartAngle.ToString("f3") + Environment.NewLine;
				text47 = text47 + text20 + " = " + eEllipseArc2.EndAngle.ToString("f3") + Environment.NewLine;
				text47 = text47 + text14 + " = " + eEllipseArc2.Angle.ToString("f3") + Environment.NewLine;
				text47 = text47 + text10 + " = " + eEllipseArc2.Plane.ToString() + Environment.NewLine;
			}
			if (GetType() == typeof(ePolyline))
			{
				ePolyline ePolyline2 = new ePolyline((ePolyline)this);
				text47 = text5 + Environment.NewLine;
				text47 = text47 + text16 + " (" + Vertice[0].X.ToString("f3") + " , " + Vertice[0].Y.ToString("f3") + " , " + Vertice[0].Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text17 + " (" + Vertice[Vertice.Count - 1].X.ToString("f3") + " , " + Vertice[Vertice.Count - 1].Y.ToString("f3") + " , " + Vertice[Vertice.Count - 1].Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text11 + " = " + Vertice.Count + Environment.NewLine;
			}
			if (GetType() == typeof(eBezeir))
			{
				eBezeir eBezeir2 = new eBezeir((eBezeir)this);
				text47 = text8 + Environment.NewLine;
				text47 = text47 + text16 + " (" + Vertice[0].X.ToString("f3") + " , " + Vertice[0].Y.ToString("f3") + " , " + Vertice[0].Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text17 + " (" + Vertice[Vertice.Count - 1].X.ToString("f3") + " , " + Vertice[Vertice.Count - 1].Y.ToString("f3") + " , " + Vertice[Vertice.Count - 1].Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text11 + " = " + eBezeir2.ControlPoints.Count + Environment.NewLine;
			}
			if (GetType() == typeof(eBSpline))
			{
				eBSpline eBSpline2 = new eBSpline((eBSpline)this);
				text47 = text9 + Environment.NewLine;
				text47 = text47 + text16 + " (" + Vertice[0].X.ToString("f3") + " , " + Vertice[0].Y.ToString("f3") + " , " + Vertice[0].Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text17 + " (" + Vertice[Vertice.Count - 1].X.ToString("f3") + " , " + Vertice[Vertice.Count - 1].Y.ToString("f3") + " , " + Vertice[Vertice.Count - 1].Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text11 + " = " + eBSpline2.ControlPoints.Count + Environment.NewLine;
				text47 = text47 + text12 + " = " + eBSpline2.BType.ToString() + Environment.NewLine;
			}
			if (GetType() == typeof(ePicture))
			{
				ePicture ePicture2 = new ePicture((ePicture)this);
				text47 = text34 + Environment.NewLine;
				text47 = text47 + text16 + " (" + ePicture2.StartPoint.X.ToString("f3") + " , " + ePicture2.StartPoint.Y.ToString("f3") + " , " + ePicture2.StartPoint.Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text17 + " (" + ePicture2.EndPoint.X.ToString("f3") + " , " + ePicture2.EndPoint.Y.ToString("f3") + " , " + ePicture2.EndPoint.Z.ToString("f3") + ")" + Environment.NewLine;
			}
			if (GetType() == typeof(eText))
			{
				eText eText2 = new eText((eText)this);
				text47 = text4 + Environment.NewLine;
				text47 = text47 + text16 + " (" + Vertice[0].X.ToString("f3") + " , " + Vertice[0].Y.ToString("f3") + " , " + Vertice[0].Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text36 + " = " + eText2.Height + Environment.NewLine;
				text47 = text47 + text35 + " = " + eText2.TextString.ToString() + Environment.NewLine;
			}
			if (GetType() == typeof(eSurface))
			{
				eSurface eSurface2 = new eSurface((eSurface)this);
				text47 = text29 + " Triangle = " + eSurface2.SurfType.ToString() + Environment.NewLine;
			}
			if (GetType() == typeof(eMesh))
			{
				eMesh eMesh2 = new eMesh((eMesh)this);
				text47 = text30 + " " + eMesh2.TriIndex.Count + Environment.NewLine;
			}
			if (GetType() == typeof(eSolid3D))
			{
				text47 = text37 + Environment.NewLine;
			}
			if (GetType() == typeof(eDimLineer))
			{
				text47 = text38 + Environment.NewLine;
				text47 = text47 + text16 + " (" + Vertice[0].X.ToString("f3") + " , " + Vertice[0].Y.ToString("f3") + " , " + Vertice[0].Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text17 + " (" + Vertice[Vertice.Count - 1].X.ToString("f3") + " , " + Vertice[Vertice.Count - 1].Y.ToString("f3") + " , " + Vertice[Vertice.Count - 1].Z.ToString("f3") + ")" + Environment.NewLine;
			}
			if (GetType() == typeof(eDimRadial))
			{
				eDimRadial eDimRadial2 = new eDimRadial((eDimRadial)this);
				text47 = text38 + Environment.NewLine;
				text47 = text47 + text25 + " (" + Vertice[0].X.ToString("f3") + " , " + Vertice[0].Y.ToString("f3") + " , " + Vertice[0].Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text18 + " = " + eDimRadial2.Radius + Environment.NewLine;
			}
			if (GetType() == typeof(eDimDiametric))
			{
				eDimDiametric eDimDiametric2 = new eDimDiametric((eDimDiametric)this);
				text47 = text38 + Environment.NewLine;
				text47 = text47 + text25 + " (" + Vertice[0].X.ToString("f3") + " , " + Vertice[0].Y.ToString("f3") + " , " + Vertice[0].Z.ToString("f3") + ")" + Environment.NewLine;
				text47 = text47 + text39 + " = " + eDimDiametric2.Diameter + Environment.NewLine;
			}
			text47 = text47 + text13 + " = " + geoLength.ToString("f3") + Environment.NewLine;
			text47 = text47 + text15 + " (" + (geoMaxPoint.X - geoMinPoint.X).ToString("f3") + " , " + (geoMaxPoint.Y - geoMinPoint.Y).ToString("f3") + " , " + (geoMaxPoint.Z - geoMinPoint.Z).ToString("f3") + ")" + Environment.NewLine;
			text47 = text47 + text23 + " = " + EntityIndex.ToString("") + Environment.NewLine;
			text47 = text47 + text24 + " = " + LayerIndex.ToString("") + Environment.NewLine;
			text47 = text47 + text31 + " = " + buStatics.ColorToString(dispColor, ColorConvertType.Html) + "  -  " + text32 + " = " + dispThickness.ToString("f1") + Environment.NewLine;
			if (CamData)
			{
				text47 = text47 + text25 + " = " + bSelected + Environment.NewLine;
				text47 = text47 + text26 + " = " + bCamSelected + Environment.NewLine;
				text47 = text47 + text27 + " = " + camDirections.ToString() + Environment.NewLine;
				text47 = text47 + text28 + " = " + camToolNo + Environment.NewLine;
			}
			return text47;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return "";
		}
	}

	public void Copy(ref eEntities copiedEnt)
	{
		CopyEntity(this, ref copiedEnt);
	}

	public void Add(ref List<eEntities> listEnt)
	{
		AddEntity(this, ref listEnt);
	}

	public ArrayList ToDefAll(int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		buSerilization.ExceptionalVariables.Clear();
		buSerilization.ExceptionalVariables.Add("Shape");
		arrayList.Add(text + "<eEntities>");
		if (GetType() == typeof(ePoint))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(ePointGroup))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eLine))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eUpperLine))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eCircle))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eArc))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(ePolyline))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eCam))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(ePolylineGroup))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eEllipseArc))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eEllipse))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eBSpline))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eBezeir))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(ePicture))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eText))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eSolid3D))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eDimLineer))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eDimRadial))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eDimDiametric))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eDimAngular))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eSurface))
		{
			buSerilization.ExceptionalVariables.Add("Vertice");
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(eMesh))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		buSerilization.ExceptionalVariables.Clear();
		if (Shape != null)
		{
			arrayList.AddRange(Shape.ToDefAll(Space + 2).ToArray());
		}
		arrayList.Add(text + "</eEntities>");
		return arrayList;
	}

	public static eEntities Decode(List<string> AL, string Char, SerilizationMode Mode)
	{
		List<string> CalcList = new List<string>();
		List<string> list = new List<string>();
		eEntities eEntities2 = new eEntities();
		string text = "";
		buStatics.ListToSpecificList("<" + eEntities2.GetType().Name + Char + ">", "</" + eEntities2.GetType().Name + Char + ">", AL, ref CalcList);
		if (CalcList.Count > 0)
		{
			text = CalcList[0];
		}
		if ((text.Length == 0) & (AL.Count > 0))
		{
			text = AL[0];
		}
		if (text.Length > 0)
		{
			if (text.IndexOf("ePoint") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities3 = new eEntities();
					eEntities3 = ePoint.DecodePoint(CalcList);
					ShapeDataDecode(CalcList, ref eEntities3);
					CalcList.Clear();
					AL.Clear();
					return eEntities3;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities4 = new eEntities();
					eEntities4 = ePoint.DecodePoint(AL);
					ShapeDataDecode(AL, ref eEntities4);
					CalcList.Clear();
					AL.Clear();
					return eEntities4;
				}
			}
			if (text.IndexOf("ePointGroup") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities5 = new eEntities();
					eEntities5 = ePointGroup.DecodePoint(CalcList);
					ShapeDataDecode(CalcList, ref eEntities5);
					CalcList.Clear();
					AL.Clear();
					return eEntities5;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities6 = new eEntities();
					eEntities6 = ePointGroup.DecodePoint(AL);
					ShapeDataDecode(AL, ref eEntities6);
					CalcList.Clear();
					AL.Clear();
					return eEntities6;
				}
			}
			if (text.IndexOf("eLine") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities7 = new eEntities();
					eEntities7 = eLine.DecodeLine(CalcList);
					ShapeDataDecode(CalcList, ref eEntities7);
					CalcList.Clear();
					AL.Clear();
					return eEntities7;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities8 = new eEntities();
					eEntities8 = eLine.DecodeLine(AL);
					ShapeDataDecode(AL, ref eEntities8);
					CalcList.Clear();
					AL.Clear();
					return eEntities8;
				}
			}
			if (text.IndexOf("eUpperLine") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities9 = new eEntities();
					eEntities9 = eUpperLine.DecodeUpperLine(CalcList);
					ShapeDataDecode(CalcList, ref eEntities9);
					CalcList.Clear();
					AL.Clear();
					return eEntities9;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities10 = new eEntities();
					eEntities10 = eUpperLine.DecodeUpperLine(AL);
					ShapeDataDecode(AL, ref eEntities10);
					CalcList.Clear();
					AL.Clear();
					return eEntities10;
				}
			}
			if (text.IndexOf("eCircle") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities11 = new eEntities();
					eEntities11 = eCircle.DecodeCircle(CalcList);
					ShapeDataDecode(CalcList, ref eEntities11);
					CalcList.Clear();
					AL.Clear();
					return eEntities11;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities12 = new eEntities();
					eEntities12 = eCircle.DecodeCircle(AL);
					ShapeDataDecode(AL, ref eEntities12);
					CalcList.Clear();
					AL.Clear();
					return eEntities12;
				}
			}
			if (text.IndexOf("eArc") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities13 = new eEntities();
					eEntities13 = eArc.DecodeArc(CalcList);
					ShapeDataDecode(CalcList, ref eEntities13);
					CalcList.Clear();
					AL.Clear();
					return eEntities13;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities14 = new eEntities();
					eEntities14 = eArc.DecodeArc(AL);
					ShapeDataDecode(AL, ref eEntities14);
					CalcList.Clear();
					AL.Clear();
					return eEntities14;
				}
			}
			if (text.IndexOf("ePolyline") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities15 = new eEntities();
					eEntities15 = ePolyline.DecodePolyline(CalcList);
					ShapeDataDecode(CalcList, ref eEntities15);
					CalcList.Clear();
					AL.Clear();
					return eEntities15;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities16 = new eEntities();
					eEntities16 = ePolyline.DecodePolyline(AL);
					ShapeDataDecode(AL, ref eEntities16);
					CalcList.Clear();
					AL.Clear();
					return eEntities16;
				}
			}
			if (text.IndexOf("eCam") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities17 = new eEntities();
					eEntities17 = eCam.DecodePolyline(CalcList);
					ShapeDataDecode(CalcList, ref eEntities17);
					CalcList.Clear();
					AL.Clear();
					return eEntities17;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities18 = new eEntities();
					eEntities18 = eCam.DecodePolyline(AL);
					ShapeDataDecode(AL, ref eEntities18);
					CalcList.Clear();
					AL.Clear();
					return eEntities18;
				}
			}
			if (text.IndexOf("ePolylineGroup") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities19 = new eEntities();
					eEntities19 = ePolylineGroup.DecodePolyline(CalcList);
					ShapeDataDecode(CalcList, ref eEntities19);
					CalcList.Clear();
					AL.Clear();
					return eEntities19;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities20 = new eEntities();
					eEntities20 = ePolylineGroup.DecodePolyline(AL);
					ShapeDataDecode(AL, ref eEntities20);
					CalcList.Clear();
					AL.Clear();
					return eEntities20;
				}
			}
			if (text.IndexOf("eEllipse") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities21 = new eEntities();
					eEntities21 = eEllipse.DecodeEllipse(CalcList);
					ShapeDataDecode(CalcList, ref eEntities21);
					CalcList.Clear();
					AL.Clear();
					return eEntities21;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities22 = new eEntities();
					eEntities22 = eEllipse.DecodeEllipse(AL);
					ShapeDataDecode(AL, ref eEntities22);
					CalcList.Clear();
					AL.Clear();
					return eEntities22;
				}
			}
			if (text.IndexOf("eEllipseArc") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities23 = new eEntities();
					eEntities23 = eEllipseArc.DecodeEllipseArc(CalcList);
					ShapeDataDecode(CalcList, ref eEntities23);
					CalcList.Clear();
					AL.Clear();
					return eEntities23;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities24 = new eEntities();
					eEntities24 = eEllipseArc.DecodeEllipseArc(AL);
					ShapeDataDecode(AL, ref eEntities24);
					CalcList.Clear();
					AL.Clear();
					return eEntities24;
				}
			}
			if (text.IndexOf("eBezeir") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities25 = new eEntities();
					eEntities25 = eBezeir.DecodeBezeir(CalcList);
					ShapeDataDecode(CalcList, ref eEntities25);
					CalcList.Clear();
					AL.Clear();
					return eEntities25;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities26 = new eEntities();
					eEntities26 = eBezeir.DecodeBezeir(AL);
					ShapeDataDecode(AL, ref eEntities26);
					CalcList.Clear();
					AL.Clear();
					return eEntities26;
				}
			}
			if (text.IndexOf("eBSpline") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities27 = new eEntities();
					eEntities27 = eBSpline.DecodeBSpline(CalcList);
					ShapeDataDecode(CalcList, ref eEntities27);
					CalcList.Clear();
					AL.Clear();
					return eEntities27;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities28 = new eEntities();
					eEntities28 = eBSpline.DecodeBSpline(AL);
					ShapeDataDecode(AL, ref eEntities28);
					CalcList.Clear();
					AL.Clear();
					return eEntities28;
				}
			}
			if (text.IndexOf("ePicture") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities29 = new eEntities();
					eEntities29 = ePicture.DecodePicture(CalcList);
					ShapeDataDecode(CalcList, ref eEntities29);
					CalcList.Clear();
					AL.Clear();
					return eEntities29;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities30 = new eEntities();
					eEntities30 = ePicture.DecodePicture(AL);
					ShapeDataDecode(AL, ref eEntities30);
					CalcList.Clear();
					AL.Clear();
					return eEntities30;
				}
			}
			if (text.IndexOf("eText") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities31 = new eEntities();
					eEntities31 = eText.DecodeText(CalcList);
					ShapeDataDecode(CalcList, ref eEntities31);
					CalcList.Clear();
					AL.Clear();
					return eEntities31;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities32 = new eEntities();
					eEntities32 = eText.DecodeText(AL);
					ShapeDataDecode(AL, ref eEntities32);
					CalcList.Clear();
					AL.Clear();
					return eEntities32;
				}
			}
			if (text.IndexOf("eSolid") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities33 = new eEntities();
					eEntities33 = eSolid3D.DecodeSolid(CalcList);
					ShapeDataDecode(CalcList, ref eEntities33);
					CalcList.Clear();
					AL.Clear();
					return eEntities33;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities34 = new eEntities();
					eEntities34 = eSolid3D.DecodeSolid(AL);
					ShapeDataDecode(AL, ref eEntities34);
					CalcList.Clear();
					AL.Clear();
					return eEntities34;
				}
			}
			if (text.IndexOf("eDimLineer") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities35 = new eEntities();
					eEntities35 = eDimLineer.DecodeDimLinear(CalcList);
					ShapeDataDecode(CalcList, ref eEntities35);
					CalcList.Clear();
					AL.Clear();
					return eEntities35;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities36 = new eEntities();
					eEntities36 = eDimLineer.DecodeDimLinear(AL);
					ShapeDataDecode(AL, ref eEntities36);
					CalcList.Clear();
					AL.Clear();
					return eEntities36;
				}
			}
			if (text.IndexOf("eDimRadial") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities37 = new eEntities();
					eEntities37 = eDimRadial.DecodeDimRadial(CalcList);
					ShapeDataDecode(CalcList, ref eEntities37);
					CalcList.Clear();
					AL.Clear();
					return eEntities37;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities38 = new eEntities();
					eEntities38 = eDimRadial.DecodeDimRadial(AL);
					ShapeDataDecode(AL, ref eEntities38);
					CalcList.Clear();
					AL.Clear();
					return eEntities38;
				}
			}
			if (text.IndexOf("eDimDiametric") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities39 = new eEntities();
					eEntities39 = eDimDiametric.DecodeDimDiameter(CalcList);
					ShapeDataDecode(CalcList, ref eEntities39);
					CalcList.Clear();
					AL.Clear();
					return eEntities39;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities40 = new eEntities();
					eEntities40 = eDimDiametric.DecodeDimDiameter(AL);
					ShapeDataDecode(AL, ref eEntities40);
					CalcList.Clear();
					AL.Clear();
					return eEntities40;
				}
			}
			if (text.IndexOf("eDimAngular") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities41 = new eEntities();
					eEntities41 = eDimAngular.DecodeDimLinear(CalcList);
					ShapeDataDecode(CalcList, ref eEntities41);
					CalcList.Clear();
					AL.Clear();
					return eEntities41;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities42 = new eEntities();
					eEntities42 = eDimAngular.DecodeDimLinear(AL);
					ShapeDataDecode(AL, ref eEntities42);
					CalcList.Clear();
					AL.Clear();
					return eEntities42;
				}
			}
			if (text.IndexOf("eSurface") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities43 = new eEntities();
					eEntities43 = eSurface.DecodeSurface(CalcList);
					ShapeDataDecode(CalcList, ref eEntities43);
					return eEntities43;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities44 = new eEntities();
					eEntities44 = eSurface.DecodeSurface(AL);
					ShapeDataDecode(AL, ref eEntities44);
					return eEntities44;
				}
			}
			if (text.IndexOf("eMesh") >= 0)
			{
				if (CalcList.Count > 0)
				{
					eEntities eEntities45 = new eEntities();
					eEntities45 = eMesh.DecodeMesh(CalcList);
					ShapeDataDecode(CalcList, ref eEntities45);
					return eEntities45;
				}
				if (AL.Count > 0)
				{
					eEntities eEntities46 = new eEntities();
					eEntities46 = eMesh.DecodeMesh(AL);
					ShapeDataDecode(AL, ref eEntities46);
					return eEntities46;
				}
			}
		}
		return eEntities2;
	}

	public static void ShapeDataDecode(List<string> SL, ref eEntities Ent)
	{
		List<string> CalcList = new List<string>();
		buStatics.ListToSpecificList("<ShapeData>", "</ShapeData>", AddStartEndKey: false, SL, ref CalcList);
		if (CalcList.Count > 0)
		{
			Ent.Shape = ShapeData.Decode(CalcList, "", SerilizationMode.MultiLine);
		}
		else
		{
			Ent.Shape = null;
		}
	}
}
