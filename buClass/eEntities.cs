// Decompiled with JetBrains decompiler
// Type: buClass.eEntities
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
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
  public string auxText = (string) null;
  public DrawSource EntityData = (DrawSource) null;
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
  public object Object = (object) null;
  public TuftData Tuft = (TuftData) null;
  public ShapeData Shape = (ShapeData) null;
  public DiemakerData Diemaker = (DiemakerData) null;
  public AdditionalData Additional = (AdditionalData) null;
  public List<Pnt3D> Vertice = new List<Pnt3D>();
  public List<Triangle3D> Triangles = (List<Triangle3D>) null;
  public List<Pnt3D> Normals = (List<Pnt3D>) null;

  public static void CopyBase(eEntities baseEnt, eEntities copiedEnt)
  {
    baseEnt.GetType().BaseType.ToString();
    if (baseEnt.GetType().BaseType != (Type) null && baseEnt.GetType().BaseType == typeof (ePlaneEntities))
    {
      ePlaneEntities ePlaneEntities = new ePlaneEntities();
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
      copiedEnt.Tuft = new TuftData(baseEnt.Tuft);
    if (baseEnt.Diemaker != null)
      copiedEnt.Diemaker = new DiemakerData(baseEnt.Diemaker);
    if (baseEnt.Additional != null)
      copiedEnt.Additional = new AdditionalData(baseEnt.Additional);
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
    for (int index = 0; index <= baseEnt.Vertice.Count - 1; ++index)
      copiedEnt.Vertice.Add(new Pnt3D(baseEnt.Vertice[index]));
    if (baseEnt.Triangles != null)
    {
      copiedEnt.Triangles = new List<Triangle3D>();
      for (int index = 0; index <= baseEnt.Triangles.Count - 1; ++index)
        copiedEnt.Triangles.Add(new Triangle3D(baseEnt.Triangles[index]));
    }
    if (baseEnt.Normals == null)
      return;
    copiedEnt.Normals = new List<Pnt3D>();
    for (int index = 0; index <= baseEnt.Normals.Count - 1; ++index)
      copiedEnt.Normals.Add(new Pnt3D(baseEnt.Normals[index]));
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
      copiedEnt.Tuft = new TuftData(baseEnt.Tuft);
    if (baseEnt.Diemaker != null)
      copiedEnt.Diemaker = new DiemakerData(baseEnt.Diemaker);
    if (baseEnt.Additional != null)
      copiedEnt.Additional = new AdditionalData(baseEnt.Additional);
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
      copiedEnt.Tuft = new TuftData(baseEnt.Tuft);
    if (baseEnt.Diemaker != null)
      copiedEnt.Diemaker = new DiemakerData(baseEnt.Diemaker);
    if (baseEnt.Additional != null)
      copiedEnt.Additional = new AdditionalData(baseEnt.Additional);
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

  public static void CopyCommonPorperties(
    eEntities baseEnt,
    bool GeometryThings,
    bool DisplayThings,
    bool CamThings,
    ref eEntities copiedEnt)
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
      copiedEnt.Tuft = new TuftData(baseEnt.Tuft);
    if (baseEnt.Diemaker != null)
      copiedEnt.Diemaker = new DiemakerData(baseEnt.Diemaker);
    if (baseEnt.Additional != null)
      copiedEnt.Additional = new AdditionalData(baseEnt.Additional);
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
      copiedEnt = (eEntities) null;
    }
    else
    {
      if (baseEnt.GetType() == typeof (ePoint))
        copiedEnt = (eEntities) new ePoint(baseEnt);
      if (baseEnt.GetType() == typeof (ePointGroup))
        copiedEnt = (eEntities) new ePointGroup(baseEnt);
      if (baseEnt.GetType() == typeof (eLine))
        copiedEnt = (eEntities) new eLine(baseEnt);
      if (baseEnt.GetType() == typeof (eCircle))
        copiedEnt = (eEntities) new eCircle(baseEnt);
      if (baseEnt.GetType() == typeof (eArc))
        copiedEnt = (eEntities) new eArc(baseEnt);
      if (baseEnt.GetType() == typeof (ePolyline))
        copiedEnt = (eEntities) new ePolyline(baseEnt);
      if (baseEnt.GetType() == typeof (ePolylineGroup))
        copiedEnt = (eEntities) new ePolylineGroup(baseEnt);
      if (baseEnt.GetType() == typeof (eEllipse))
        copiedEnt = (eEntities) new eEllipse(baseEnt);
      if (baseEnt.GetType() == typeof (eEllipseArc))
        copiedEnt = (eEntities) new eEllipseArc(baseEnt);
      if (baseEnt.GetType() == typeof (eBSpline))
        copiedEnt = (eEntities) new eBSpline(baseEnt);
      if (baseEnt.GetType() == typeof (eBezeir))
        copiedEnt = (eEntities) new eBezeir(baseEnt);
      if (baseEnt.GetType() == typeof (ePicture))
        copiedEnt = (eEntities) new ePicture(baseEnt);
      if (baseEnt.GetType() == typeof (eText))
        copiedEnt = (eEntities) new eText(baseEnt);
      if (baseEnt.GetType() == typeof (eCam))
        copiedEnt = (eEntities) new eCam(baseEnt);
      if (baseEnt.GetType() == typeof (eUpperLine))
        copiedEnt = (eEntities) new eUpperLine(baseEnt);
      if (baseEnt.GetType() == typeof (eSolid3D))
        copiedEnt = (eEntities) new eSolid3D(baseEnt);
      if (baseEnt.GetType() == typeof (eDimLineer))
        copiedEnt = (eEntities) new eDimLineer(baseEnt);
      if (baseEnt.GetType() == typeof (eDimRadial))
        copiedEnt = (eEntities) new eDimRadial(baseEnt);
      if (baseEnt.GetType() == typeof (eDimDiametric))
        copiedEnt = (eEntities) new eDimDiametric(baseEnt);
      if (baseEnt.GetType() == typeof (eDimAngular))
        copiedEnt = (eEntities) new eDimAngular(baseEnt);
      if (baseEnt.GetType() == typeof (eSurface))
        copiedEnt = (eEntities) new eSurface(baseEnt);
      if (baseEnt.GetType() == typeof (eMesh))
        copiedEnt = (eEntities) new eMesh(baseEnt);
      if (!(baseEnt.GetType() == typeof (eSurfaceNull)))
        return;
      copiedEnt = (eEntities) new eSurfaceNull(baseEnt);
    }
  }

  public static void CopyEntityKeepIDAndIndex(eEntities baseEnt, ref eEntities copiedEnt)
  {
    int entityId = copiedEnt.EntityID;
    int entityIndex = copiedEnt.EntityIndex;
    eEntities.CopyEntity(baseEnt, ref copiedEnt);
    copiedEnt.EntityID = entityId;
    copiedEnt.EntityIndex = entityIndex;
  }

  public static eEntities CopyEntityKeepIDAndIndex(eEntities baseEnt, eEntities copiedEnt)
  {
    int entityId = copiedEnt.EntityID;
    int entityIndex = copiedEnt.EntityIndex;
    eEntities.CopyEntity(baseEnt, ref copiedEnt);
    copiedEnt.EntityID = entityId;
    copiedEnt.EntityIndex = entityIndex;
    return copiedEnt;
  }

  public static eEntities CopyEntity(eEntities baseEnt)
  {
    eEntities copiedEnt = new eEntities();
    eEntities.CopyEntity(baseEnt, ref copiedEnt);
    return copiedEnt;
  }

  public static void CopyEntities(List<eEntities> baseEnt, ref List<eEntities> CopiedEnt)
  {
    if (CopiedEnt == null)
      CopiedEnt = new List<eEntities>();
    CopiedEnt.Clear();
    for (int index = 0; index <= baseEnt.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(baseEnt[index], ref copiedEnt);
      CopiedEnt.Add(copiedEnt);
    }
  }

  public static void CopyEntities(List<eEntities> baseEnt, List<eEntities> CopiedEnt)
  {
    if (CopiedEnt == null)
      CopiedEnt = new List<eEntities>();
    CopiedEnt.Clear();
    for (int index = 0; index <= baseEnt.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(baseEnt[index], ref copiedEnt);
      CopiedEnt.Add(copiedEnt);
    }
  }

  public static void CopyEntities(
    List<List<eEntities>> baseEnt,
    ref List<List<eEntities>> CopiedEnt)
  {
    if (CopiedEnt == null)
      CopiedEnt = new List<List<eEntities>>();
    CopiedEnt.Clear();
    for (int index = 0; index <= baseEnt.Count - 1; ++index)
    {
      List<eEntities> CopiedEnt1 = new List<eEntities>();
      eEntities.CopyEntities(baseEnt[index], ref CopiedEnt1);
      CopiedEnt.Add(CopiedEnt1);
    }
  }

  public static List<eEntities> CopyEntities(List<eEntities> baseEnt)
  {
    List<eEntities> CopiedEnt = new List<eEntities>();
    eEntities.CopyEntities(baseEnt, ref CopiedEnt);
    return CopiedEnt;
  }

  public static void AddEntity(eEntities baseEnt, ref List<eEntities> listEnt)
  {
    eEntities copiedEnt = new eEntities();
    eEntities.CopyEntity(baseEnt, ref copiedEnt);
    listEnt.Add(copiedEnt);
    copiedEnt.Vertice.Clear();
  }

  public static void AddEntities(List<eEntities> baseEnt, ref List<eEntities> CopiedEnt)
  {
    for (int index = 0; index <= baseEnt.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(baseEnt[index], ref copiedEnt);
      CopiedEnt.Add(copiedEnt);
    }
  }

  public static void AddEntities(List<List<eEntities>> baseEnt, ref List<List<eEntities>> CopiedEnt)
  {
    for (int index = 0; index <= baseEnt.Count - 1; ++index)
    {
      List<eEntities> CopiedEnt1 = new List<eEntities>();
      eEntities.CopyEntities(baseEnt[index], ref CopiedEnt1);
      CopiedEnt.Add(CopiedEnt1);
    }
  }

  public static void SetAuxText(string Text, ref eEntities Entity) => Entity.auxText = Text;

  public static void SetAuxValue(double Value, ref eEntities Entity) => Entity.auxValue = Value;

  public static void ResetCamSelected(ref eEntities Ent) => Ent.bCamSelected = false;

  public static void ResetCamSelected(ref List<eEntities> Ent)
  {
    for (int index = 0; index <= Ent.Count - 1; ++index)
      Ent[index].bCamSelected = false;
  }

  public void Update()
  {
    if (this.GetType() == typeof (ePoint))
    {
      this.Vertice.Clear();
      this.Vertice.Add(new Pnt3D(((ePoint) this).StartPoint));
      this.geoMinPoint = new Pnt3D(((ePoint) this).StartPoint);
      this.geoMaxPoint = new Pnt3D(((ePoint) this).StartPoint);
    }
    if (this.GetType() == typeof (ePointGroup))
    {
      this.geoLength = 0.0;
      this.geoAngleXY = 0.0;
    }
    if (this.GetType() == typeof (eLine))
    {
      this.Vertice.Clear();
      this.Vertice.Add(new Pnt3D(((eLine) this).StartPoint));
      this.Vertice.Add(new Pnt3D(((eLine) this).EndPoint));
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
      this.geoLength = buStatics.Length3D(this.Vertice);
      this.geoAngleXY = buStatics.PointAngle(((eLine) this).EndPoint, ((eLine) this).StartPoint);
    }
    if (this.GetType() == typeof (eUpperLine))
    {
      this.Vertice.Clear();
      this.Vertice.Add(new Pnt3D(((eLine) this).StartPoint));
      this.Vertice.Add(new Pnt3D(((eLine) this).EndPoint));
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
      this.geoLength = buStatics.Length3D(this.Vertice);
      this.geoAngleXY = buStatics.PointAngle(((eLine) this).EndPoint, ((eLine) this).StartPoint);
    }
    if (this.GetType() == typeof (eCircle))
    {
      this.Vertice.Clear();
      int Count = buStatics.ArcVerticeCountByResolution(((eCircle) this).Radius, 0.0, 360.0, buSystem.EntitiesResolution);
      if (Count < 50)
        Count = 50;
      buStatics.ArcToLineerByCount(((ePlaneEntities) this).CenterPoint, ((eCircle) this).Radius, 0.0, 360.0, Count, ((ePlaneEntities) this).Plane, ref this.Vertice);
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
      this.geoLength = 2.0 * Math.PI * ((eCircle) this).Radius;
      this.geoAngleXY = 0.0;
    }
    if (this.GetType() == typeof (eArc))
    {
      this.Vertice.Clear();
      int Count = buStatics.ArcVerticeCountByResolution(((eCircle) this).Radius, ((eArc) this).StartAngle, ((eArc) this).EndAngle, buSystem.EntitiesResolution);
      Pnt3D StartPoint = new Pnt3D();
      Pnt3D MiddlePoint = new Pnt3D();
      Pnt3D EndPoint = new Pnt3D();
      buStatics.ArcStartMiddleEndPoint(((ePlaneEntities) this).CenterPoint, ((eCircle) this).Radius, ((eArc) this).StartAngle, ((eArc) this).EndAngle, ((ePlaneEntities) this).Plane, ref StartPoint, ref MiddlePoint, ref EndPoint);
      buStatics.ArcToLineerByCount(((ePlaneEntities) this).CenterPoint, ((eCircle) this).Radius, ((eArc) this).StartAngle, ((eArc) this).EndAngle, Count, ((ePlaneEntities) this).Plane, ref this.Vertice);
      if (this.Vertice.Count > 0)
      {
        ((eArc) this).StartPoint = new Pnt3D(this.Vertice[0]);
        ((eArc) this).EndPoint = new Pnt3D(this.Vertice[this.Vertice.Count - 1]);
        ((eArc) this).MiddlePoint = new Pnt3D(MiddlePoint);
      }
      this.geoLength = 2.0 * Math.PI * ((eCircle) this).Radius * (((eArc) this).EndAngle - ((eArc) this).StartAngle) / 360.0;
      this.geoAngleXY = 0.0;
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
    }
    if (this.GetType() == typeof (ePolyline))
    {
      this.geoLength = buStatics.Length3D(this.Vertice);
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
    }
    if (this.GetType() == typeof (ePolylineGroup))
    {
      List<List<Pnt3D>> TargetList = new List<List<Pnt3D>>();
      Pnt3D.Add(((ePolylineGroup) this).GroupVertices, ref TargetList);
      Pnt3D.Add(((ePolylineGroup) this).InternalVertices, ref TargetList);
      this.geoAngleXY = 0.0;
      buStatics.BoxSizeCalculate(TargetList, ref this.geoMinPoint, ref this.geoMaxPoint);
    }
    if (this.GetType() == typeof (eEllipse))
    {
      this.Vertice.Clear();
      buStatics.ArcEllipseToLineerByCount(((ePlaneEntities) this).CenterPoint, ((eEllipse) this).MajorRadius, ((eEllipse) this).MinorRadius, 0.0, 360.0, ((eEllipse) this).Angle, buStatics.EllipseVerticeCountByResolution(((eEllipse) this).MajorRadius, ((eEllipse) this).MinorRadius, buSystem.EntitiesResolution), ((ePlaneEntities) this).Plane, ref this.Vertice);
      this.geoLength = Math.Sqrt((((eEllipse) this).MajorRadius * ((eEllipse) this).MajorRadius + ((eEllipse) this).MinorRadius * ((eEllipse) this).MinorRadius) * 0.5) * Math.PI * 2.0;
      this.geoAngleXY = 0.0;
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
    }
    if (this.GetType() == typeof (eEllipseArc))
    {
      this.Vertice.Clear();
      buStatics.ArcEllipseToLineerByCount(((ePlaneEntities) this).CenterPoint, ((eEllipse) this).MajorRadius, ((eEllipse) this).MinorRadius, ((eEllipseArc) this).StartAngle, ((eEllipseArc) this).EndAngle, ((eEllipse) this).Angle, buStatics.ArcEllipseVerticeCountByResolution(((eEllipse) this).MajorRadius, ((eEllipse) this).MinorRadius, ((eEllipseArc) this).StartAngle, ((eEllipseArc) this).EndAngle, buSystem.EntitiesResolution), ((ePlaneEntities) this).Plane, ref this.Vertice);
      if (this.Vertice.Count > 0)
      {
        ((eEllipseArc) this).StartPoint = new Pnt3D(this.Vertice[0]);
        ((eEllipseArc) this).EndPoint = new Pnt3D(this.Vertice[this.Vertice.Count - 1]);
      }
      this.geoLength = Math.Sqrt((((eEllipse) this).MajorRadius * ((eEllipse) this).MajorRadius + ((eEllipse) this).MinorRadius * ((eEllipse) this).MinorRadius) * 0.5) * Math.PI * 2.0 * (((eEllipseArc) this).EndAngle - ((eEllipseArc) this).StartAngle) / 360.0;
      this.geoAngleXY = 0.0;
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
    }
    if (this.GetType() == typeof (eBezeir))
    {
      this.Vertice.Clear();
      buStatics.CreatBezeirCurve(((eCurveEntities) this).ControlPoints, buSystem.EntitiesResolution.dt, ref this.Vertice);
      if (this.Vertice.Count > 0)
      {
        ((eCurveEntities) this).StartPoint = new Pnt3D(this.Vertice[0]);
        ((eCurveEntities) this).EndPoint = new Pnt3D(this.Vertice[this.Vertice.Count - 1]);
      }
      this.geoLength = buStatics.Length3D(this.Vertice);
      this.geoAngleXY = 0.0;
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
    }
    if (this.GetType() == typeof (eBSpline))
    {
      double dt = buSystem.EntitiesResolution.dt;
      if (((eBSpline) this).dt > 0.0)
        dt = ((eBSpline) this).dt;
      this.Vertice.Clear();
      if (((eBSpline) this).BType == entityBSplineType.BSplineCubic)
        buStatics.CreatBSplineCubicUniform(((eCurveEntities) this).ControlPoints, dt, this.bClosed, ref this.Vertice);
      if (((eBSpline) this).BType == entityBSplineType.BSplineQuadratic)
        buStatics.CreatBSplineQuadraticUniform(((eCurveEntities) this).ControlPoints, dt, this.bClosed, ref this.Vertice);
      if (((eBSpline) this).BType == entityBSplineType.SplineCubic)
        buStatics.CreatSplineCubicUniform(((eCurveEntities) this).ControlPoints, dt, ref this.Vertice);
      if (this.Vertice.Count > 0)
      {
        ((eCurveEntities) this).StartPoint = new Pnt3D(this.Vertice[0]);
        ((eCurveEntities) this).EndPoint = new Pnt3D(this.Vertice[this.Vertice.Count - 1]);
      }
      this.geoLength = buStatics.Length3D(this.Vertice);
      this.geoAngleXY = 0.0;
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
    }
    if (this.GetType() == typeof (ePicture))
    {
      this.Vertice.Clear();
      buStatics.RectangleCorner(((ePicture) this).StartPoint, ((ePicture) this).EndPoint, ((ePlaneEntities) this).Plane, ref this.Vertice);
      this.geoLength = buStatics.Length3D(this.Vertice);
      this.geoAngleXY = 0.0;
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
    }
    if (this.GetType() == typeof (eText))
    {
      SizeF sizeF = Graphics.FromImage((Image) new Bitmap(1000, 1000)).MeasureString(((eText) this).TextString, new Font(((eText) this).TextFont.Name, (float) ((eText) this).Height), new PointF(0.0f, 0.0f), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
      Pnt3D pts = new Pnt3D(((eText) this).StartPoint);
      if (WorkPlane.isPlaneXY(((ePlaneEntities) this).Plane))
        Pnt3D.Offset(ref pts, (double) sizeF.Width, (double) sizeF.Height, 0.0);
      if (WorkPlane.isPlaneXZ(((ePlaneEntities) this).Plane))
        Pnt3D.Offset(ref pts, (double) sizeF.Width, 0.0, (double) sizeF.Height);
      if (WorkPlane.isPlaneYZ(((ePlaneEntities) this).Plane))
        Pnt3D.Offset(ref pts, 0.0, (double) sizeF.Width, (double) sizeF.Height);
      List<Pnt3D> Vertices = new List<Pnt3D>();
      buStatics.RectangleCorner(((eText) this).StartPoint, pts, ((ePlaneEntities) this).Plane, ref Vertices);
      this.Vertice.Clear();
      Pnt3D.Copy(Vertices, ref this.Vertice);
      this.geoLength = 0.0;
      this.geoAngleXY = 0.0;
    }
    if (this.GetType() == typeof (eCam))
    {
      this.geoLength = buStatics.Length3D(this.Vertice);
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
    }
    if (this.GetType() == typeof (eSolid3D))
    {
      this.Vertice.Clear();
      if (this.Triangles.Count > 0)
      {
        for (int index = 0; index <= this.Triangles.Count - 1; ++index)
        {
          this.Vertice.Add(new Pnt3D(this.Triangles[index].FirstPoint));
          this.Vertice.Add(new Pnt3D(this.Triangles[index].SecondPoint));
          this.Vertice.Add(new Pnt3D(this.Triangles[index].ThirdPoint));
        }
      }
      this.geoLength = 0.0;
      this.geoAngleXY = 0.0;
    }
    if (this.GetType() == typeof (eDimLineer))
    {
      this.Vertice.Clear();
      this.Vertice.Add(new Pnt3D(((eDimLineer) this).StartPoint));
      this.Vertice.Add(new Pnt3D(((eDimLineer) this).EndPoint));
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
      this.geoLength = buStatics.Length3D(this.Vertice);
      this.geoAngleXY = buStatics.PointAngle(((eDimLineer) this).EndPoint, ((eDimLineer) this).StartPoint);
    }
    if (this.GetType() == typeof (eDimRadial))
    {
      this.Vertice.Clear();
      this.Vertice.Add(new Pnt3D(((eDimRadial) this).StartPoint));
      this.Vertice.Add(new Pnt3D(((eDimRadial) this).EndPoint));
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
      this.geoLength = buStatics.Length3D(this.Vertice);
      this.geoAngleXY = buStatics.PointAngle(((eDimRadial) this).EndPoint, ((eDimRadial) this).StartPoint);
    }
    if (this.GetType() == typeof (eDimDiametric))
    {
      this.Vertice.Clear();
      this.Vertice.Add(new Pnt3D(((eDimDiametric) this).StartPoint));
      this.Vertice.Add(new Pnt3D(((eDimDiametric) this).EndPoint));
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
      this.geoLength = buStatics.Length3D(this.Vertice);
      this.geoAngleXY = buStatics.PointAngle(((eDimDiametric) this).EndPoint, ((eDimDiametric) this).StartPoint);
    }
    if (this.GetType() == typeof (eDimAngular))
    {
      this.Vertice.Clear();
      this.Vertice.Add(new Pnt3D(((eDimAngular) this).StartPoint));
      this.Vertice.Add(new Pnt3D(((eDimAngular) this).EndPoint));
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
      this.geoLength = buStatics.Length3D(this.Vertice);
      this.geoAngleXY = buStatics.PointAngle(((eDimAngular) this).EndPoint, ((eDimAngular) this).StartPoint);
    }
    if (this.GetType() == typeof (eSurface))
    {
      if (this.Triangles.Count > 0)
      {
        this.Vertice.Clear();
        if (this.Triangles.Count > 0)
        {
          for (int index = 0; index <= this.Triangles.Count - 1; ++index)
          {
            this.Vertice.Add(new Pnt3D(this.Triangles[index].FirstPoint));
            this.Vertice.Add(new Pnt3D(this.Triangles[index].SecondPoint));
            this.Vertice.Add(new Pnt3D(this.Triangles[index].ThirdPoint));
          }
        }
      }
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
      this.geoLength = 0.0;
    }
    if (this.GetType() == typeof (eMesh))
    {
      buStatics.BoxSizeCalculate(this.Vertice, ref this.geoMinPoint, ref this.geoMaxPoint);
      this.geoLength = 0.0;
    }
    if (!(this.GetType() == typeof (eSurfaceNull)))
      return;
    this.Vertice.Clear();
    if (this.Triangles.Count > 0)
    {
      for (int index = 0; index <= this.Triangles.Count - 1; ++index)
      {
        this.Vertice.Add(new Pnt3D(this.Triangles[index].FirstPoint));
        this.Vertice.Add(new Pnt3D(this.Triangles[index].SecondPoint));
        this.Vertice.Add(new Pnt3D(this.Triangles[index].ThirdPoint));
      }
    }
    this.geoLength = 0.0;
  }

  public string ToInfo(bool CamData)
  {
    try
    {
      string str1 = "Line";
      string str2 = "Arc";
      string str3 = "Circle";
      string str4 = "Point";
      string str5 = "Polyline";
      string str6 = "Ellipse";
      string str7 = "Ellipse Arc";
      string str8 = "Bezeir";
      string str9 = "BSpline";
      string str10 = "Plane";
      string str11 = "Count";
      string str12 = "Type";
      string str13 = "Length";
      string str14 = "Angle";
      string str15 = "Size";
      string str16 = "Start";
      string str17 = "End";
      string str18 = "Radius";
      string str19 = "Start Angle";
      string str20 = "End Angle";
      string str21 = "Major Radius";
      string str22 = "MinorRadius";
      string str23 = "Entitiy Sequence";
      string str24 = "Layer Sequence";
      string str25 = "Selected";
      string str26 = "Cam Selected";
      string str27 = "CamDirection";
      string str28 = "Tool";
      string str29 = "Surface";
      string str30 = "Mesh";
      string str31 = "Color";
      string str32 = "Thickness";
      string str33 = "Center";
      string str34 = "Image";
      string str35 = "Text";
      string str36 = "Height";
      string str37 = "Solid";
      string str38 = "Dim Linear";
      string str39 = "Dim Alinged";
      string str40 = "Dim Radius";
      string str41 = "Dim Diameter";
      string str42 = "Dim Oriented Hor";
      string str43 = "Dim Oriented Ver";
      string str44 = "Dim Angular";
      string str45 = "Diameter";
      string str46 = "Direction";
      if (AppLanguage.buClassStrings.Count > 44)
      {
        str4 = AppLanguage.buClassStrings[0];
        str1 = AppLanguage.buClassStrings[1];
        str2 = AppLanguage.buClassStrings[3];
        str3 = AppLanguage.buClassStrings[2];
        str6 = AppLanguage.buClassStrings[4];
        str7 = AppLanguage.buClassStrings[5];
        str8 = AppLanguage.buClassStrings[6];
        str9 = AppLanguage.buClassStrings[7];
        str5 = AppLanguage.buClassStrings[8];
        str16 = AppLanguage.buClassStrings[9];
        str17 = AppLanguage.buClassStrings[10];
        str13 = AppLanguage.buClassStrings[11];
        str14 = AppLanguage.buClassStrings[12];
        str15 = AppLanguage.buClassStrings[13];
        str23 = AppLanguage.buClassStrings[14];
        str24 = AppLanguage.buClassStrings[15];
        str18 = AppLanguage.buClassStrings[16 /*0x10*/];
        str19 = AppLanguage.buClassStrings[17];
        str20 = AppLanguage.buClassStrings[18];
        str21 = AppLanguage.buClassStrings[19];
        str22 = AppLanguage.buClassStrings[20];
        str11 = AppLanguage.buClassStrings[21];
        str12 = AppLanguage.buClassStrings[22];
        str10 = AppLanguage.buClassStrings[23];
        str25 = AppLanguage.buClassStrings[24];
        str26 = AppLanguage.buClassStrings[25];
        str27 = AppLanguage.buClassStrings[26];
        str28 = AppLanguage.buClassStrings[27];
        str31 = AppLanguage.buClassStrings[28];
        str32 = AppLanguage.buClassStrings[29];
        str33 = AppLanguage.buClassStrings[30];
        str34 = AppLanguage.buClassStrings[31 /*0x1F*/];
        str35 = AppLanguage.buClassStrings[32 /*0x20*/];
        str36 = AppLanguage.buClassStrings[33];
        str29 = AppLanguage.buClassStrings[34];
        str37 = AppLanguage.buClassStrings[35];
        str38 = AppLanguage.buClassStrings[36];
        str39 = AppLanguage.buClassStrings[37];
        str40 = AppLanguage.buClassStrings[38];
        str41 = AppLanguage.buClassStrings[39];
        str43 = AppLanguage.buClassStrings[40];
        str42 = AppLanguage.buClassStrings[41];
        str44 = AppLanguage.buClassStrings[42];
        str45 = AppLanguage.buClassStrings[43];
        str46 = AppLanguage.buClassStrings[44];
      }
      string str47 = "";
      if (this.GetType() == typeof (ePoint))
        str47 = $"{str4 + Environment.NewLine}{str16} ({this.Vertice[0].X.ToString("f3")} , {this.Vertice[0].Y.ToString("f3")} , {this.Vertice[0].Z.ToString("f3")}){Environment.NewLine}";
      if (this.GetType() == typeof (eLine))
        str47 = $"{$"{str1 + Environment.NewLine}{str16} ({this.Vertice[0].X.ToString("f3")} , {this.Vertice[0].Y.ToString("f3")} , {this.Vertice[0].Z.ToString("f3")}){Environment.NewLine}"}{str17} ({this.Vertice[this.Vertice.Count - 1].X.ToString("f3")} , {this.Vertice[this.Vertice.Count - 1].Y.ToString("f3")} , {this.Vertice[this.Vertice.Count - 1].Z.ToString("f3")}){Environment.NewLine}";
      if (this.GetType() == typeof (eCircle))
      {
        eCircle eCircle = new eCircle(this);
        str47 = $"{$"{$"{str3 + Environment.NewLine}{str33} ({eCircle.CenterPoint.X.ToString("f3")} , {eCircle.CenterPoint.Y.ToString("f3")} , {eCircle.CenterPoint.Z.ToString("f3")}){Environment.NewLine}"}{str18} = {eCircle.Radius.ToString("f3")}{Environment.NewLine}"}{str10} = {eCircle.Plane.ToString()}{Environment.NewLine}";
      }
      if (this.GetType() == typeof (eArc))
      {
        eArc eArc = new eArc(this);
        str47 = $"{$"{$"{$"{$"{str2 + Environment.NewLine}{str33} ({eArc.CenterPoint.X.ToString("f3")} , {eArc.CenterPoint.Y.ToString("f3")} , {eArc.CenterPoint.Z.ToString("f3")}){Environment.NewLine}"}{str18} = {eArc.Radius.ToString("f3")}{Environment.NewLine}"}{str19} = {eArc.StartAngle.ToString("f3")}{Environment.NewLine}"}{str20} = {eArc.EndAngle.ToString("f3")}{Environment.NewLine}"}{str10} = {eArc.Plane.ToString()}{Environment.NewLine}";
      }
      if (this.GetType() == typeof (eEllipse))
      {
        eEllipse eEllipse = new eEllipse(this);
        str47 = $"{$"{$"{$"{$"{str6 + Environment.NewLine}{str33} ({eEllipse.CenterPoint.X.ToString("f3")} , {eEllipse.CenterPoint.Y.ToString("f3")} , {eEllipse.CenterPoint.Z.ToString("f3")}){Environment.NewLine}"}{str21} = {eEllipse.MajorRadius.ToString("f3")}{Environment.NewLine}"}{str22} = {eEllipse.MinorRadius.ToString("f3")}{Environment.NewLine}"}{str14} = {eEllipse.Angle.ToString("f3")}{Environment.NewLine}"}{str10} = {eEllipse.Plane.ToString()}{Environment.NewLine}";
      }
      if (this.GetType() == typeof (eEllipseArc))
      {
        eEllipseArc eEllipseArc = new eEllipseArc(this);
        str47 = $"{$"{$"{$"{$"{$"{$"{str6 + Environment.NewLine}{str33} ({eEllipseArc.CenterPoint.X.ToString("f3")} , {eEllipseArc.CenterPoint.Y.ToString("f3")} , {eEllipseArc.CenterPoint.Z.ToString("f3")}){Environment.NewLine}"}{str21} = {eEllipseArc.MajorRadius.ToString("f3")}{Environment.NewLine}"}{str22} = {eEllipseArc.MinorRadius.ToString("f3")}{Environment.NewLine}"}{str19} = {eEllipseArc.StartAngle.ToString("f3")}{Environment.NewLine}"}{str20} = {eEllipseArc.EndAngle.ToString("f3")}{Environment.NewLine}"}{str14} = {eEllipseArc.Angle.ToString("f3")}{Environment.NewLine}"}{str10} = {eEllipseArc.Plane.ToString()}{Environment.NewLine}";
      }
      int count;
      if (this.GetType() == typeof (ePolyline))
      {
        ePolyline ePolyline = new ePolyline(this);
        string[] strArray = new string[5]
        {
          $"{$"{str5 + Environment.NewLine}{str16} ({this.Vertice[0].X.ToString("f3")} , {this.Vertice[0].Y.ToString("f3")} , {this.Vertice[0].Z.ToString("f3")}){Environment.NewLine}"}{str17} ({this.Vertice[this.Vertice.Count - 1].X.ToString("f3")} , {this.Vertice[this.Vertice.Count - 1].Y.ToString("f3")} , {this.Vertice[this.Vertice.Count - 1].Z.ToString("f3")}){Environment.NewLine}",
          str11,
          " = ",
          null,
          null
        };
        count = this.Vertice.Count;
        strArray[3] = count.ToString();
        strArray[4] = Environment.NewLine;
        str47 = string.Concat(strArray);
      }
      if (this.GetType() == typeof (eBezeir))
      {
        eBezeir eBezeir = new eBezeir(this);
        string[] strArray = new string[5]
        {
          $"{$"{str8 + Environment.NewLine}{str16} ({this.Vertice[0].X.ToString("f3")} , {this.Vertice[0].Y.ToString("f3")} , {this.Vertice[0].Z.ToString("f3")}){Environment.NewLine}"}{str17} ({this.Vertice[this.Vertice.Count - 1].X.ToString("f3")} , {this.Vertice[this.Vertice.Count - 1].Y.ToString("f3")} , {this.Vertice[this.Vertice.Count - 1].Z.ToString("f3")}){Environment.NewLine}",
          str11,
          " = ",
          null,
          null
        };
        count = eBezeir.ControlPoints.Count;
        strArray[3] = count.ToString();
        strArray[4] = Environment.NewLine;
        str47 = string.Concat(strArray);
      }
      if (this.GetType() == typeof (eBSpline))
      {
        eBSpline eBspline = new eBSpline(this);
        string[] strArray = new string[5]
        {
          $"{$"{str9 + Environment.NewLine}{str16} ({this.Vertice[0].X.ToString("f3")} , {this.Vertice[0].Y.ToString("f3")} , {this.Vertice[0].Z.ToString("f3")}){Environment.NewLine}"}{str17} ({this.Vertice[this.Vertice.Count - 1].X.ToString("f3")} , {this.Vertice[this.Vertice.Count - 1].Y.ToString("f3")} , {this.Vertice[this.Vertice.Count - 1].Z.ToString("f3")}){Environment.NewLine}",
          str11,
          " = ",
          null,
          null
        };
        count = eBspline.ControlPoints.Count;
        strArray[3] = count.ToString();
        strArray[4] = Environment.NewLine;
        str47 = $"{string.Concat(strArray)}{str12} = {eBspline.BType.ToString()}{Environment.NewLine}";
      }
      if (this.GetType() == typeof (ePicture))
      {
        ePicture ePicture = new ePicture(this);
        str47 = $"{$"{str34 + Environment.NewLine}{str16} ({ePicture.StartPoint.X.ToString("f3")} , {ePicture.StartPoint.Y.ToString("f3")} , {ePicture.StartPoint.Z.ToString("f3")}){Environment.NewLine}"}{str17} ({ePicture.EndPoint.X.ToString("f3")} , {ePicture.EndPoint.Y.ToString("f3")} , {ePicture.EndPoint.Z.ToString("f3")}){Environment.NewLine}";
      }
      if (this.GetType() == typeof (eText))
      {
        eText eText = new eText(this);
        str47 = $"{$"{$"{str4 + Environment.NewLine}{str16} ({this.Vertice[0].X.ToString("f3")} , {this.Vertice[0].Y.ToString("f3")} , {this.Vertice[0].Z.ToString("f3")}){Environment.NewLine}"}{str36} = {eText.Height.ToString()}{Environment.NewLine}"}{str35} = {eText.TextString.ToString()}{Environment.NewLine}";
      }
      if (this.GetType() == typeof (eSurface))
      {
        eSurface eSurface = new eSurface(this);
        str47 = $"{str29} Triangle = {eSurface.SurfType.ToString()}{Environment.NewLine}";
      }
      if (this.GetType() == typeof (eMesh))
      {
        eMesh eMesh = new eMesh(this);
        string str48 = str30;
        count = eMesh.TriIndex.Count;
        string str49 = count.ToString();
        string newLine = Environment.NewLine;
        str47 = $"{str48} {str49}{newLine}";
      }
      if (this.GetType() == typeof (eSolid3D))
        str47 = str37 + Environment.NewLine;
      if (this.GetType() == typeof (eDimLineer))
        str47 = $"{$"{str38 + Environment.NewLine}{str16} ({this.Vertice[0].X.ToString("f3")} , {this.Vertice[0].Y.ToString("f3")} , {this.Vertice[0].Z.ToString("f3")}){Environment.NewLine}"}{str17} ({this.Vertice[this.Vertice.Count - 1].X.ToString("f3")} , {this.Vertice[this.Vertice.Count - 1].Y.ToString("f3")} , {this.Vertice[this.Vertice.Count - 1].Z.ToString("f3")}){Environment.NewLine}";
      if (this.GetType() == typeof (eDimRadial))
      {
        eDimRadial eDimRadial = new eDimRadial(this);
        str47 = $"{$"{str38 + Environment.NewLine}{str25} ({this.Vertice[0].X.ToString("f3")} , {this.Vertice[0].Y.ToString("f3")} , {this.Vertice[0].Z.ToString("f3")}){Environment.NewLine}"}{str18} = {eDimRadial.Radius.ToString()}{Environment.NewLine}";
      }
      if (this.GetType() == typeof (eDimDiametric))
      {
        eDimDiametric eDimDiametric = new eDimDiametric(this);
        str47 = $"{$"{str38 + Environment.NewLine}{str25} ({this.Vertice[0].X.ToString("f3")} , {this.Vertice[0].Y.ToString("f3")} , {this.Vertice[0].Z.ToString("f3")}){Environment.NewLine}"}{str39} = {eDimDiametric.Diameter.ToString()}{Environment.NewLine}";
      }
      string str50 = $"{str47}{str13} = {this.geoLength.ToString("f3")}{Environment.NewLine}";
      string[] strArray1 = new string[10];
      strArray1[0] = str50;
      strArray1[1] = str15;
      strArray1[2] = " (";
      double num = this.geoMaxPoint.X - this.geoMinPoint.X;
      strArray1[3] = num.ToString("f3");
      strArray1[4] = " , ";
      num = this.geoMaxPoint.Y - this.geoMinPoint.Y;
      strArray1[5] = num.ToString("f3");
      strArray1[6] = " , ";
      num = this.geoMaxPoint.Z - this.geoMinPoint.Z;
      strArray1[7] = num.ToString("f3");
      strArray1[8] = ")";
      strArray1[9] = Environment.NewLine;
      string info = $"{$"{$"{string.Concat(strArray1)}{str23} = {this.EntityIndex.ToString("")}{Environment.NewLine}"}{str24} = {this.LayerIndex.ToString("")}{Environment.NewLine}"}{str31} = {buStatics.ColorToString(this.dispColor, ColorConvertType.Html)}  -  {str32} = {this.dispThickness.ToString("f1")}{Environment.NewLine}";
      if (CamData)
        info = $"{$"{$"{$"{info}{str25} = {this.bSelected.ToString()}{Environment.NewLine}"}{str26} = {this.bCamSelected.ToString()}{Environment.NewLine}"}{str27} = {this.camDirections.ToString()}{Environment.NewLine}"}{str28} = {this.camToolNo.ToString()}{Environment.NewLine}";
      return info;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
      return "";
    }
  }

  public void Copy(ref eEntities copiedEnt) => eEntities.CopyEntity(this, ref copiedEnt);

  public void Add(ref List<eEntities> listEnt) => eEntities.AddEntity(this, ref listEnt);

  public ArrayList ToDefAll(int Space)
  {
    string str = new string(' ', Space);
    ArrayList defAll = new ArrayList();
    buSerilization.ExceptionalVariables.Clear();
    buSerilization.ExceptionalVariables.Add("Shape");
    defAll.Add((object) (str + "<eEntities>"));
    if (this.GetType() == typeof (ePoint))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (ePointGroup))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (eLine))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eUpperLine))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eCircle))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eArc))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (ePolyline))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (eCam))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (ePolylineGroup))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (eEllipseArc))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eEllipse))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eBSpline))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eBezeir))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (ePicture))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eText))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eSolid3D))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eDimLineer))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eDimRadial))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eDimDiametric))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eDimAngular))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eSurface))
    {
      buSerilization.ExceptionalVariables.Add("Vertice");
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    }
    if (this.GetType() == typeof (eMesh))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    buSerilization.ExceptionalVariables.Clear();
    if (this.Shape != null)
      defAll.AddRange((ICollection) this.Shape.ToDefAll(Space + 2).ToArray());
    defAll.Add((object) (str + "</eEntities>"));
    return defAll;
  }

  public static eEntities Decode(List<string> AL, string Char, SerilizationMode Mode)
  {
    List<string> CalcList = new List<string>();
    List<string> stringList = new List<string>();
    eEntities eEntities1 = new eEntities();
    string str = "";
    buStatics.ListToSpecificList($"<{eEntities1.GetType().Name}{Char}>", $"</{eEntities1.GetType().Name}{Char}>", AL, ref CalcList);
    if (CalcList.Count > 0)
      str = CalcList[0];
    if (str.Length == 0 & AL.Count > 0)
      str = AL[0];
    if (str.Length > 0)
    {
      if (str.IndexOf("ePoint") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities2 = new eEntities();
          eEntities Ent = ePoint.DecodePoint(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities3 = new eEntities();
          eEntities Ent = ePoint.DecodePoint(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("ePointGroup") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities4 = new eEntities();
          eEntities Ent = ePointGroup.DecodePoint(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities5 = new eEntities();
          eEntities Ent = ePointGroup.DecodePoint(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eLine") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities6 = new eEntities();
          eEntities Ent = eLine.DecodeLine(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities7 = new eEntities();
          eEntities Ent = eLine.DecodeLine(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eUpperLine") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities8 = new eEntities();
          eEntities Ent = eUpperLine.DecodeUpperLine(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities9 = new eEntities();
          eEntities Ent = eUpperLine.DecodeUpperLine(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eCircle") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities10 = new eEntities();
          eEntities Ent = eCircle.DecodeCircle(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities11 = new eEntities();
          eEntities Ent = eCircle.DecodeCircle(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eArc") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities12 = new eEntities();
          eEntities Ent = eArc.DecodeArc(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities13 = new eEntities();
          eEntities Ent = eArc.DecodeArc(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("ePolyline") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities14 = new eEntities();
          eEntities Ent = ePolyline.DecodePolyline(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities15 = new eEntities();
          eEntities Ent = ePolyline.DecodePolyline(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eCam") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities16 = new eEntities();
          eEntities Ent = eCam.DecodePolyline(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities17 = new eEntities();
          eEntities Ent = eCam.DecodePolyline(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("ePolylineGroup") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities18 = new eEntities();
          eEntities Ent = (eEntities) ePolylineGroup.DecodePolyline(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities19 = new eEntities();
          eEntities Ent = (eEntities) ePolylineGroup.DecodePolyline(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eEllipse") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities20 = new eEntities();
          eEntities Ent = eEllipse.DecodeEllipse(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities21 = new eEntities();
          eEntities Ent = eEllipse.DecodeEllipse(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eEllipseArc") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities22 = new eEntities();
          eEntities Ent = eEllipseArc.DecodeEllipseArc(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities23 = new eEntities();
          eEntities Ent = eEllipseArc.DecodeEllipseArc(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eBezeir") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities24 = new eEntities();
          eEntities Ent = eBezeir.DecodeBezeir(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities25 = new eEntities();
          eEntities Ent = eBezeir.DecodeBezeir(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eBSpline") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities26 = new eEntities();
          eEntities Ent = eBSpline.DecodeBSpline(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities27 = new eEntities();
          eEntities Ent = eBSpline.DecodeBSpline(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("ePicture") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities28 = new eEntities();
          eEntities Ent = ePicture.DecodePicture(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities29 = new eEntities();
          eEntities Ent = ePicture.DecodePicture(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eText") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities30 = new eEntities();
          eEntities Ent = eText.DecodeText(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities31 = new eEntities();
          eEntities Ent = eText.DecodeText(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eSolid") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities32 = new eEntities();
          eEntities Ent = (eEntities) eSolid3D.DecodeSolid(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities33 = new eEntities();
          eEntities Ent = (eEntities) eSolid3D.DecodeSolid(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eDimLineer") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities34 = new eEntities();
          eEntities Ent = eDimLineer.DecodeDimLinear(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities35 = new eEntities();
          eEntities Ent = eDimLineer.DecodeDimLinear(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eDimRadial") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities36 = new eEntities();
          eEntities Ent = eDimRadial.DecodeDimRadial(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities37 = new eEntities();
          eEntities Ent = eDimRadial.DecodeDimRadial(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eDimDiametric") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities38 = new eEntities();
          eEntities Ent = eDimDiametric.DecodeDimDiameter(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities39 = new eEntities();
          eEntities Ent = eDimDiametric.DecodeDimDiameter(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eDimAngular") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities40 = new eEntities();
          eEntities Ent = eDimAngular.DecodeDimLinear(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities41 = new eEntities();
          eEntities Ent = eDimAngular.DecodeDimLinear(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          CalcList.Clear();
          AL.Clear();
          return Ent;
        }
      }
      if (str.IndexOf("eSurface") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities42 = new eEntities();
          eEntities Ent = (eEntities) eSurface.DecodeSurface(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities43 = new eEntities();
          eEntities Ent = (eEntities) eSurface.DecodeSurface(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          return Ent;
        }
      }
      if (str.IndexOf("eMesh") >= 0)
      {
        if (CalcList.Count > 0)
        {
          eEntities eEntities44 = new eEntities();
          eEntities Ent = (eEntities) eMesh.DecodeMesh(CalcList);
          eEntities.ShapeDataDecode(CalcList, ref Ent);
          return Ent;
        }
        if (AL.Count > 0)
        {
          eEntities eEntities45 = new eEntities();
          eEntities Ent = (eEntities) eMesh.DecodeMesh(AL);
          eEntities.ShapeDataDecode(AL, ref Ent);
          return Ent;
        }
      }
    }
    return eEntities1;
  }

  public static void ShapeDataDecode(List<string> SL, ref eEntities Ent)
  {
    List<string> CalcList = new List<string>();
    buStatics.ListToSpecificList("<ShapeData>", "</ShapeData>", false, SL, ref CalcList);
    if (CalcList.Count > 0)
      Ent.Shape = ShapeData.Decode(CalcList, "", SerilizationMode.MultiLine);
    else
      Ent.Shape = (ShapeData) null;
  }
}
