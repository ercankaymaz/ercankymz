// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buFoamCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buFoamCalc
{
  public CutterNotchType NotchType;
  public Point3D Position;
  public InOutType Direction;
  public double CurveAtPersentage;
  public double CurveAtLength;
  public double DirectionAngle;
  public bool InCurve;
  public string baseEntityName;
  public int baseEntityIndex;
  public static byte f003B36;
  [SpecialName]
  public int value__;
  public const CutterNotchType INotch = ; // Unable to render the field
  public const CutterNotchType VNotch = ; // Unable to render the field
  public static ToolGrindingRuntimeSettings varToolGrindingRuntime = (ToolGrindingRuntimeSettings) new buFoamCalc();
  public static ToolGrindingSettings varToolGrindingSetting = (ToolGrindingSettings) new buFoamCalc();

  public buFoamCalc()
  {
    ((Printer3DJob) this).MachineWidth = 3000.0;
    ((Printer3DJob) this).MachineHeight = 2000.0;
    ((Printer3DJob) this).RepeatCount = 1.0;
    ((Printer3DJob) this).ShowMachineSize = true;
    ((Printer3DJob) this).PastalWidth = 10000.0;
    ((Printer3DJob) this).DrillLayerName = "13";
    ((Printer3DJob) this).MirrorLayerName = "6";
    ((Printer3DJob) this).RopeDirectionLayerName = "7";
    ((Printer3DLayer) this).NotchInsideLayerName = "";
    ((Printer3DLayer) this).NotchOutsideLayerName = "";
    ((Printer3DLayer) this).ContourLayerName = "1";
    ((Printer3DLayer) this).ContourRuleScaleLayerName = "1";
    ((Printer3DSettings) this).NotchLayerName = "";
    ((Printer3DSettings) this).InfoLayerName = "";
    ((Printer3DSettings) this).PartInfoLayerName = "";
    ((Printer3DSettings) this).ContourRefLayerName = "";
    ((Printer3DSettings) this).InnerContourLayerName = "11";
    ((Printer3DSettings) this).InnerContourNoCutLayerName = "8";
    ((Printer3DSettings) this).InnerContourRefLayerName = "";
    ((Printer3DSettings) this).InnerContourPloter1LayerName = "14";
    ((Printer3DSettings) this).InnerContourPloter2LayerName = "87";
    ((Printer3DSettings) this).DrillMainDaimeterValue = 5.0;
    ((Printer3DSettings) this).DrillAuxDaimeterValue = 6.0;
    ((Printer3DSettings) this).NotchOnContour = true;
    ((Printer3DSettings) this).MirrorCenterPointCatchGapDistance = 5.0;
    ((Printer3DSettings) this).AddAttribute = false;
    ((Printer3DSettings) this).ExtendEntitiesFromRuleFile = true;
    ((Printer3DSettings) this).XScaleFactor = 0.254;
    ((Printer3DSettings) this).YScaleFactor = 0.254;
    ((Printer3DSettings) this).OffsetValue = 0.0;
    ((Printer3DSettings) this).DeleteOriginal = false;
    ((Printer3DRuntimeSettings) this).OffsetType = CamClosedContourType.Outter;
    ((Printer3DTempVars) this).LockLayers = false;
    ((Printer3DTempVars) this).ShowOperationInfo = true;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public buFoamCalc(CutterProgramSettings data)
  {
    ((Printer3DJob) this).MachineWidth = 3000.0;
    ((Printer3DJob) this).MachineHeight = 2000.0;
    ((Printer3DJob) this).RepeatCount = 1.0;
    ((Printer3DJob) this).ShowMachineSize = true;
    ((Printer3DJob) this).PastalWidth = 10000.0;
    ((Printer3DJob) this).DrillLayerName = "13";
    ((Printer3DJob) this).MirrorLayerName = "6";
    ((Printer3DJob) this).RopeDirectionLayerName = "7";
    ((Printer3DLayer) this).NotchInsideLayerName = "";
    ((Printer3DLayer) this).NotchOutsideLayerName = "";
    ((Printer3DLayer) this).ContourLayerName = "1";
    ((Printer3DLayer) this).ContourRuleScaleLayerName = "1";
    ((Printer3DSettings) this).NotchLayerName = "";
    ((Printer3DSettings) this).InfoLayerName = "";
    ((Printer3DSettings) this).PartInfoLayerName = "";
    ((Printer3DSettings) this).ContourRefLayerName = "";
    ((Printer3DSettings) this).InnerContourLayerName = "11";
    ((Printer3DSettings) this).InnerContourNoCutLayerName = "8";
    ((Printer3DSettings) this).InnerContourRefLayerName = "";
    ((Printer3DSettings) this).InnerContourPloter1LayerName = "14";
    ((Printer3DSettings) this).InnerContourPloter2LayerName = "87";
    ((Printer3DSettings) this).DrillMainDaimeterValue = 5.0;
    ((Printer3DSettings) this).DrillAuxDaimeterValue = 6.0;
    ((Printer3DSettings) this).NotchOnContour = true;
    ((Printer3DSettings) this).MirrorCenterPointCatchGapDistance = 5.0;
    ((Printer3DSettings) this).AddAttribute = false;
    ((Printer3DSettings) this).ExtendEntitiesFromRuleFile = true;
    ((Printer3DSettings) this).XScaleFactor = 0.254;
    ((Printer3DSettings) this).YScaleFactor = 0.254;
    ((Printer3DSettings) this).OffsetValue = 0.0;
    ((Printer3DSettings) this).DeleteOriginal = false;
    ((Printer3DRuntimeSettings) this).OffsetType = CamClosedContourType.Outter;
    ((Printer3DTempVars) this).LockLayers = false;
    ((Printer3DTempVars) this).ShowOperationInfo = true;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public static void Copy(CutterProgramSettings Source, ref CutterProgramSettings Target)
  {
    Target = (CutterProgramSettings) new buFoamCalc(Source);
  }

  public override string ToString() => "";

  static buFoamCalc() => Printer3DTempVars.Captions = new List<string>();

  public buFoamCalc()
  {
    // ISSUE: unable to decompile the method.
  }

  public buFoamCalc(CutterNotch data)
  {
    // ISSUE: unable to decompile the method.
  }

  public static void Copy(CutterNotch Source, ref CutterNotch Target)
  {
    Target = (CutterNotch) new buFoamCalc(Source);
  }

  public override string ToString()
  {
    // ISSUE: unable to decompile the method.
  }

  public abstract void m001A95();

  public buFoamCalc()
  {
  }

  static buFoamCalc()
  {
  }

  public buFoamCalc()
  {
    ((FoamItem) this).Name = "Job";
    ((FoamItem) this).refEntitiy = (buEntity) null;
    ((FoamItem) this).solidEntity = (Entity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buFoamCalc(ToolGrindingJob data)
  {
    ((FoamItem) this).Name = "Job";
    ((FoamItem) this).refEntitiy = (buEntity) null;
    ((FoamItem) this).solidEntity = (Entity) null;
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
    if (((FoamItem) data).refEntitiy != null)
      buDiametricDim.Copy(((FoamItem) data).refEntitiy, ref ((FoamItem) this).refEntitiy);
    if (((FoamItem) data).solidEntity == null)
      return;
    buRadialDim.Copy(((FoamItem) data).solidEntity, ref ((FoamItem) this).solidEntity);
  }

  public static ArrayList ToDef(List<ToolGrindingJob> Items, int Space)
  {
    string str = new string(' ', Space);
    return new ArrayList();
  }

  public static ArrayList ToDef(ToolGrindingJob Item, int Space)
  {
    string str = new string(' ', Space);
    return new ArrayList();
  }

  public static void Decode(List<string> AL, ref ProfileJob Job)
  {
    List<List<string>> stringListList = new List<List<string>>();
  }

  public override string ToString() => ((FoamItem) this).Name.ToString();

  public abstract void m001A9E();

  public buFoamCalc()
  {
    ((FoamItem) this).SimStep = 1;
    ((FoamItem) this).StepRun = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buFoamCalc(ToolGrindingRuntimeSettings data)
  {
    ((FoamItem) this).SimStep = 1;
    ((FoamItem) this).StepRun = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public buFoamCalc()
    : this()
  {
  }

  public buFoamCalc(ToolGrindingSettings data)
    : this()
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public buFoamCalc()
  {
  }
}
