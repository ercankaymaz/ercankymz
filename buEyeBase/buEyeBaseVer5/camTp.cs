// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camTp
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camTp : buSerilization5
{
  public buEntity dimEntity;
  public ShapeDataValueType ShapeValueType;
  public planeNames PlaneType;
  public bool UsePlaneType;
  public ArrayList PreCodes;
  public ArrayList PreCodesWithoutNo;
  public ArrayList AfterCodes;
  public ArrayList AfterCodesWithoutNo;
  public List<TpPnt9D> PrePoints;
  public List<TpPnt9D> AfterPoints;
  public ArrayList ToolPreCodes;
  public ArrayList ToolAfterCodes;
  public ArrayList SpindlePreCodes;
  public ArrayList SpindleAfterCodes;
  public ArrayList CreatedGCodes;
  public List<Entity> RefEntities;
  public List<Entity> sortedEntities;
  public List<List<Entity>> splitedEntities;
  public SimulationTp SimilationPoint;
  public Pnt3D SimilationToolOffset;
  public List<Entity> EntitiesMark;
  public List<Entity> EntitiesG1;
  public List<Entity> EntitiesG1Orj;
  public List<Entity> EntitiesG0;
  public List<Entity> EntitiesPlunge;
  public List<Entity> EntitiesLeave;
  public List<Entity> EntitiesOther;
  public List<Entity> EntitiesLeadIn;
  public List<Entity> EntitiesLeadOut;
  public List<Entity> EntitiesConnection;
  public List<int> EntityIndex;
  public List<DirectionArrow> DirectionArrows;
  public List<camTpPoint> CamPoints;
  public KinematicBase5 Kinematic;
  public PostProcessor Post;
  public CamInfo Information;
  public ToolBase5 Tool;
  public WorkPlane Plane;
  public camParameters5 Parameter;
  public object mwParameter;
  public Vector3D OperationVector;
  public Pnt6D PositionOffset;
  public MWCalculationOptions MWCalcOptions;
  public object OperationData;
  public object CamData;
  public Pnt3D RefPoint;
  public Vec3D MoveOffset;
  public CamType TypeCam;
  public CamMode Mode;
  public CamWireFrameType CamWireframeType;
  public CamTriangularMeshType CamTriMeshType;
  public CamDrillType CamDrillType;
  public planeNames PlaneName;
  public CamSequence Sequnce;
  public string Station;
  public string Explanation;
  public string Name;
  public string SceneName;
  public double OperationHeight;
  public double ZSafeDistance;
  public double Aux1;
  public double Aux2;
  public bool Aux1First;
  public int AxisCount;
  public int MaterialIndex;
  public int RegionIndex;
  public int ZAxisIndex;
  public int CamOptions;
  public int Index;
  public int ImageIndex;
  public int CamID;
  public int NumberOfAxis;
  public bool UsedCamPost;
  public bool Enable;
  public new bool Visible;

  public camTp()
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    this.dimEntity = (buEntity) new buMultilineText();
  }

  public camTp(buEntity dimEnt, ShapeDataValueType ValueType)
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    buDiametricDim.Copy(dimEnt, ref this.dimEntity);
    this.ShapeValueType = ValueType;
  }

  public camTp(DimensionGroup data)
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    if (((camTp) data).dimEntity == null)
      return;
    buDiametricDim.Copy(((camTp) data).dimEntity, ref this.dimEntity);
  }

  public override string ToString() => this.ShapeValueType.ToString();

  public camTp()
  {
    ((camTpPoint) this).Used = false;
    ((camTpPoint) this).Action = actionTypeBU.None;
    ((camTpPoint) this).Obj1 = (object) null;
    ((camTpPoint) this).Obj2 = (object) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public camTp(camTp data)
  {
    ((camTpPoint) this).Used = false;
    ((camTpPoint) this).Action = actionTypeBU.None;
    ((camTpPoint) this).Obj1 = (object) null;
    ((camTpPoint) this).Obj2 = (object) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    if (data == null)
      return;
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    this.MoveOffset = new Vec3D(data.MoveOffset);
    if (data.Parameter != null)
      this.Parameter = (camParameters5) new camRuntime5(data.Parameter);
    if (data.Kinematic != null)
      this.Kinematic = (KinematicBase5) new OsnapPoint(data.Kinematic);
    if (data.Post != null)
      this.Post = new PostProcessor(data.Post);
    if (data.Information != null)
      this.Information = new CamInfo(data.Information);
    if (data.Plane != null)
      this.Plane = new WorkPlane(data.Plane);
    this.AfterPoints = new List<TpPnt9D>();
    this.PrePoints = new List<TpPnt9D>();
    for (int index = 0; index <= data.AfterPoints.Count - 1; ++index)
      this.AfterPoints.Add(new TpPnt9D(data.AfterPoints[index]));
    for (int index = 0; index <= data.PrePoints.Count - 1; ++index)
      this.PrePoints.Add(new TpPnt9D(data.PrePoints[index]));
    if (this.OperationData != null && this.OperationData.GetType() != typeof (object))
      this.OperationData = buClone.DeepCopy<object>(data.OperationData);
    if (data.SimilationPoint != null)
      this.SimilationPoint = (SimulationTp) new camParameters5(data.SimilationPoint);
    if (data.DirectionArrows != null)
    {
      this.DirectionArrows.Clear();
      for (int index = 0; index <= data.DirectionArrows.Count - 1; ++index)
        this.DirectionArrows.Add(new DirectionArrow(this.DirectionArrows[index]));
    }
    if (data.splitedEntities != null)
    {
      this.splitedEntities.Clear();
      this.splitedEntities = new List<List<Entity>>();
      buVector5.CopyEntities(data.splitedEntities, ref this.splitedEntities);
    }
    if (data.sortedEntities != null)
    {
      this.sortedEntities.Clear();
      this.sortedEntities = new List<Entity>();
      buVector5.CopyEntities(data.sortedEntities, ref this.sortedEntities);
    }
    if (data.RefEntities != null)
    {
      this.RefEntities.Clear();
      this.RefEntities = new List<Entity>();
      buVector5.CopyEntities(data.RefEntities, ref this.RefEntities);
    }
    if (data.EntitiesG0 != null)
    {
      this.EntitiesG0.Clear();
      buVector5.CopyEntities(data.EntitiesG0, ref this.EntitiesG0);
    }
    if (data.EntitiesG1 != null)
    {
      this.EntitiesG1.Clear();
      buVector5.CopyEntities(data.EntitiesG1, ref this.EntitiesG1);
    }
    if (data.EntitiesLeadIn != null)
    {
      this.EntitiesLeadIn.Clear();
      buVector5.CopyEntities(data.EntitiesLeadIn, ref this.EntitiesLeadIn);
    }
    if (data.EntitiesLeadOut != null)
    {
      this.EntitiesLeadOut.Clear();
      buVector5.CopyEntities(data.EntitiesLeadOut, ref this.EntitiesLeadOut);
    }
    if (data.EntitiesLeave != null)
    {
      this.EntitiesLeave.Clear();
      buVector5.CopyEntities(data.EntitiesLeave, ref this.EntitiesLeave);
    }
    if (data.EntitiesMark != null)
    {
      this.EntitiesMark.Clear();
      buVector5.CopyEntities(data.EntitiesMark, ref this.EntitiesMark);
    }
    if (data.EntitiesOther != null)
    {
      this.EntitiesOther.Clear();
      buVector5.CopyEntities(data.EntitiesOther, ref this.EntitiesOther);
    }
    if (data.EntitiesPlunge != null)
    {
      this.EntitiesPlunge.Clear();
      buVector5.CopyEntities(data.EntitiesPlunge, ref this.EntitiesPlunge);
    }
    if (data.EntitiesConnection != null)
    {
      this.EntitiesConnection.Clear();
      buVector5.CopyEntities(data.EntitiesConnection, ref this.EntitiesConnection);
    }
    this.EntityIndex.Clear();
    for (int index = 0; index <= data.EntityIndex.Count - 1; ++index)
      this.EntityIndex.Add(data.EntityIndex[index]);
    this.CamPoints.Clear();
    for (int index = 0; index <= data.CamPoints.Count - 1; ++index)
      this.CamPoints.Add((camTpPoint) new TpPnt9D(data.CamPoints[index]));
    this.AfterCodes.Clear();
    for (int index = 0; index <= data.AfterCodes.Count - 1; ++index)
      this.AfterCodes.Add(data.AfterCodes[index]);
    this.AfterCodesWithoutNo.Clear();
    for (int index = 0; index <= data.AfterCodesWithoutNo.Count - 1; ++index)
      this.AfterCodesWithoutNo.Add(data.AfterCodesWithoutNo[index]);
    this.PreCodes.Clear();
    for (int index = 0; index <= data.PreCodes.Count - 1; ++index)
      this.PreCodes.Add(data.PreCodes[index]);
    this.PreCodesWithoutNo.Clear();
    for (int index = 0; index <= data.PreCodesWithoutNo.Count - 1; ++index)
      this.PreCodesWithoutNo.Add(data.PreCodesWithoutNo[index]);
    this.ToolPreCodes.Clear();
    for (int index = 0; index <= data.ToolPreCodes.Count - 1; ++index)
      this.ToolPreCodes.Add(data.ToolPreCodes[index]);
    this.ToolAfterCodes.Clear();
    for (int index = 0; index <= data.ToolAfterCodes.Count - 1; ++index)
      this.ToolAfterCodes.Add(data.ToolAfterCodes[index]);
    this.SpindleAfterCodes.Clear();
    for (int index = 0; index <= data.SpindleAfterCodes.Count - 1; ++index)
      this.SpindleAfterCodes.Add(data.SpindleAfterCodes[index]);
    this.SpindlePreCodes.Clear();
    for (int index = 0; index <= data.SpindlePreCodes.Count - 1; ++index)
      this.SpindlePreCodes.Add(data.SpindlePreCodes[index]);
    this.CreatedGCodes.Clear();
    for (int index = 0; index <= data.CreatedGCodes.Count - 1; ++index)
      this.CreatedGCodes.Add(data.CreatedGCodes[index]);
  }

  public static void CopyCam(camTp baseCam, ref camTp copiedCam) => copiedCam = new camTp(baseCam);
}
