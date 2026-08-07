// Decompiled with JetBrains decompiler
// Type: buClass.camBase
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using buClass.Apps;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camBase : buSerilization
{
  public List<List<eEntities>> EntitiesList = new List<List<eEntities>>();
  public Pnt3D EntitiesPoint = new Pnt3D();
  public List<eEntities> Entities = new List<eEntities>();
  public List<List<eEntities>> CalculatedEntities = new List<List<eEntities>>();
  public List<eEntities> BaseEntities = new List<eEntities>();
  public List<eEntities> ItemEntities = new List<eEntities>();
  public List<List<Pnt6D>> CalculatedPnt6D = new List<List<Pnt6D>>();
  public List<Pnt9D> Points = new List<Pnt9D>();
  public List<List<Pnt3D>> SortedPoints = new List<List<Pnt3D>>();
  public List<CamPoint> CamPoints = new List<CamPoint>();
  public KinematicBase Kinematic = new KinematicBase();
  public ArrayList PreCodes = new ArrayList();
  public ArrayList AfterCodes = new ArrayList();
  public ArrayList CreatedGCodes = new ArrayList();
  public List<int> BaseEntitiesIndex = new List<int>();
  public ForceCamAxisStrings ForceAxisString = new ForceCamAxisStrings();
  public CamInfo Information = new CamInfo();
  public ToolBase Tool = new ToolBase();
  public WorkPlane Plane = new WorkPlane();
  public camParameters Parameter = new camParameters();
  public PostProcessor Post = new PostProcessor();
  public GrindingOperations GrindingParameter = new GrindingOperations();
  public object OperationData = new object();
  public object CamData = new object();
  public Vec3D MoveOffset = new Vec3D();
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D RefPoint = new Pnt3D();
  public ShapeData Shape = (ShapeData) null;
  public bool UseCreatedGCode = false;
  public bool UsedCamPost = false;
  public Color DrawColor = Color.Red;
  public int AxisCount = 3;
  public bool Enable = true;
  public int ZAxisIndex = 0;
  public int RegionIndex = 0;
  public double ZSafeDistance = 0.0;
  public int ModeIndex = 0;
  public int ModeSubIndex = 0;
  public string Station = "";
  public string Explanation = "";
  public string Name = "";
  public int LayerIndex = -1;
  public string LayerName = "";
  public string SceneName = "";
  public double OperationHeight = 0.0;
  public CamType CamType = CamType.None;
  public int CamOptions = 0;
  public int Index = 0;
  public int ImageIndex = 0;
  public int CadIndex = -1;
  public int CamID = 0;
  public int ParrentCamID = -1;
  public double TotalOperationTimeSec = 0.0;
  public double TotalOperationDistance = 0.0;
  public double TotalOperationG1Distance = 0.0;
  public double TotalOperationG0Distance = 0.0;
  public actionTypeBU Action = actionTypeBU.None;

  public camBase()
  {
  }

  public camBase(camBase data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    if (data.GrindingParameter != null)
      this.GrindingParameter = new GrindingOperations(data.GrindingParameter);
    if (data.Parameter != null)
      this.Parameter = new camParameters(data.Parameter);
    this.StartPoint = new Pnt3D(data.StartPoint);
    this.Kinematic = new KinematicBase(data.Kinematic);
    this.Tool = new ToolBase(data.Tool);
    if (data.Shape != null)
      this.Shape = new ShapeData(data.Shape);
    Pnt6D.Copy(data.CalculatedPnt6D, ref this.CalculatedPnt6D);
    if (this.OperationData != null)
      this.OperationData = buClone.DeepCopy<object>(data.OperationData);
    if (data.EntitiesList != null)
    {
      this.EntitiesList.Clear();
      this.EntitiesList = new List<List<eEntities>>();
      eEntities.CopyEntities(data.EntitiesList, ref this.EntitiesList);
    }
    this.BaseEntities.Clear();
    for (int index = 0; index <= data.BaseEntities.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(data.BaseEntities[index], ref copiedEnt);
      this.BaseEntities.Add(copiedEnt);
    }
    this.CalculatedEntities.Clear();
    eEntities.CopyEntities(data.CalculatedEntities, ref this.CalculatedEntities);
    this.Entities.Clear();
    for (int index = 0; index <= data.Entities.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(data.Entities[index], ref copiedEnt);
      this.Entities.Add(copiedEnt);
    }
    this.ItemEntities.Clear();
    for (int index = 0; index <= data.ItemEntities.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(data.ItemEntities[index], ref copiedEnt);
      this.ItemEntities.Add(copiedEnt);
    }
    this.Points.Clear();
    for (int index = 0; index <= data.Points.Count - 1; ++index)
      this.Points.Add(new Pnt9D(data.Points[index]));
    this.EntitiesPoint = new Pnt3D(data.EntitiesPoint);
    this.SortedPoints.Clear();
    for (int index = 0; index <= data.SortedPoints.Count - 1; ++index)
    {
      List<Pnt3D> CopiedPnt = new List<Pnt3D>();
      Pnt3D.Copy(data.SortedPoints[index], ref CopiedPnt);
      this.SortedPoints.Add(CopiedPnt);
    }
    this.CamPoints.Clear();
    for (int index = 0; index <= data.CamPoints.Count - 1; ++index)
      this.CamPoints.Add(new CamPoint(data.CamPoints[index]));
    this.AfterCodes.Clear();
    for (int index = 0; index <= data.AfterCodes.Count - 1; ++index)
      this.AfterCodes.Add(data.AfterCodes[index]);
    this.PreCodes.Clear();
    for (int index = 0; index <= data.PreCodes.Count - 1; ++index)
      this.PreCodes.Add(data.PreCodes[index]);
    this.CreatedGCodes.Clear();
    for (int index = 0; index <= data.CreatedGCodes.Count - 1; ++index)
      this.CreatedGCodes.Add(data.CreatedGCodes[index]);
    this.BaseEntitiesIndex.Clear();
    for (int index = 0; index <= data.BaseEntitiesIndex.Count - 1; ++index)
      this.BaseEntitiesIndex.Add(data.BaseEntitiesIndex[index]);
  }

  public static void CopyCam(camBase baseCam, ref camBase copiedCam)
  {
    copiedCam = new camBase(baseCam);
  }

  public static void CopyCam(List<camBase> RefCam, ref List<camBase> CopiedCam)
  {
    CopiedCam.Clear();
    CopiedCam = new List<camBase>();
    for (int index = 0; index <= RefCam.Count - 1; ++index)
    {
      camBase camBase = new camBase(RefCam[index]);
      CopiedCam.Add(camBase);
    }
  }

  public ArrayList ToDefAll(int Space)
  {
    string str = new string(' ', Space);
    ArrayList defAll = new ArrayList();
    buSerilization.ExceptionalVariables.Clear();
    buSerilization.ExceptionalVariables.Add("Shape");
    defAll.Add((object) (str + "<camBase>"));
    defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    defAll.Add((object) (str + "</camBase>"));
    return defAll;
  }

  public static eEntities Decode(List<string> AL, string Char, SerilizationMode Mode)
  {
    List<string> CalcList = new List<string>();
    List<string> stringList = new List<string>();
    eEntities eEntities = new eEntities();
    string str = "";
    buStatics.ListToSpecificList($"<{eEntities.GetType().Name}{Char}>", $"</{eEntities.GetType().Name}{Char}>", AL, ref CalcList);
    if (CalcList.Count > 0)
      str = CalcList[0];
    if (str.Length == 0 & AL.Count > 0)
      str = AL[0];
    if (str.Length <= 0)
      ;
    return eEntities;
  }
}
