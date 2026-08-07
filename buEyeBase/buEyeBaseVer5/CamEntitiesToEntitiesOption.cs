// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CamEntitiesToEntitiesOption
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class CamEntitiesToEntitiesOption : buSerilization5
{
  public List<Entity> G0Entities;
  public List<Entity> G1Entities;
  public List<Entity> LeaveEntities;
  public List<Entity> PlungeEntities;
  public List<Entity> LeadInEntities;
  public List<Entity> LeadOutEntities;
  public List<Entity> MarkEntities;
  public List<Entity> OtherEntities;
  public List<Entity> AllEntities;
  public List<Entity> G0Entities;

  public CamEntitiesToEntitiesOption(LeadOut5 data)
  {
    ((MWCalculationOptions) this).Enable = false;
    ((MWCalculationOptions) this).TangentAngle = 90.0;
    ((MWCalculationOptions) this).LeadType = LeadInOutType.Arc;
    ((MWCalculationOptions) this).ArcRadius = 10.0;
    ((MWCalculationOptions) this).ArcSweepAngle = 90.0;
    ((MWCalculationOptions) this).Length = 10.0;
    ((MWCalculationOptions) this).ExtendLength = 0.0;
    ((MWCalculationOptions) this).ClockDir = ClockDirectionType.CW;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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

  static CamEntitiesToEntitiesOption() => MWCalculationOptions.Captions = new List<string>();

  public CamEntitiesToEntitiesOption()
  {
    ((MWCalculationOptions) this).Errors = new List<CalculationError>();
    ((MWCalculationOptions) this).UsedEntities = new List<Entity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public CamEntitiesToEntitiesOption(camResult data)
  {
    ((MWCalculationOptions) this).Errors = new List<CalculationError>();
    ((MWCalculationOptions) this).UsedEntities = new List<Entity>();
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
    ((MWCalculationOptions) this).Errors.Clear();
    for (int index = 0; index <= ((MWCalculationOptions) data).Errors.Count - 1; ++index)
      ((MWCalculationOptions) this).Errors.Add(new CalculationError(((MWCalculationOptions) data).Errors[index]));
  }

  public CamEntitiesToEntitiesOption()
  {
    ((MWCalculationOptions) this).AddToCamListInMWCalculation = false;
    ((MWCalculationOptions) this).AddToCamListInLocalCalculation = false;
    ((MWCalculationOptions) this).DontApplyReset = false;
    ((MWCalculationOptions) this).UseStartPoint = false;
    ((MWCalculationOptions) this).HeightFromEntities = true;
    ((MWCalculationOptions) this).UseConstantStartPoint = false;
    ((MWCalculationOptions) this).UseEachCurveStartPoint = false;
    ((MWCalculationOptions) this).Editing = false;
    ((MWCalculationOptions) this).is5AxisWireframe = false;
    ((MWCalculationOptions) this).isAllG1 = false;
    ((MWCalculationOptions) this).StartPointX = 0.0;
    ((MWCalculationOptions) this).StartPointY = 0.0;
    ((MWCalculationOptions) this).StartZ = 0.0;
    ((MWCalculationOptions) this).Height = 0.0;
    ((MWCalculationOptions) this).Depth = 0.0;
    ((MWCalculationOptions) this).WireframeRoughtStepOverParaelelOverride = 0.0;
    ((MWCalculationOptions) this).CurveEntityRegenDeviation = 0.01;
    ((MWCalculationOptions) this).SolidEntityRegenDeviation = 0.01;
    ((MWCalculationOptions) this).RapidDistance = 0.0;
    ((MWCalculationOptions) this).SafeDistance = 0.0;
    ((MWCalculationOptions) this).isPointDistrubition = false;
    ((MWCalculationOptions) this).isClosed = false;
    ((MWCalculationOptions) this).isRough = false;
    ((MWCalculationOptions) this).isBuWireframeCalculation = false;
    ((MWCalculationOptions) this).isTriangularMeshAdvanced = false;
    ((MWCalculationOptions) this).isSpinCalculation = false;
    ((MWCalculationOptions) this).isSpinConstantCalculation = false;
    ((MWCalculationOptions) this).isBuSort = true;
    ((MWCalculationOptions) this).Reverse = false;
    ((MWCalculationOptions) this).DontShowDialogBox = false;
    ((MWCalculationOptions) this).DontShowbuDialogBox = false;
    ((MWCalculationOptions) this).UseSortedAndSplitedEntities = false;
    ((MWCalculationOptions) this).CheckBoxBounding = false;
    ((CamEntitiesToEntities) this).ShowLeadInOutPage = true;
    ((CamEntitiesToEntities) this).ShowOptionPage = true;
    ((CamEntitiesToEntities) this).ShowProgressForm = true;
    ((CamEntitiesToEntities) this).ToolDataToCamData = false;
    ((CamEntitiesToEntities) this).CheckIsCLosedEntities = true;
    ((CamEntitiesToEntities) this).AllowIntercetionCurve = false;
    ((CamEntitiesToEntities) this).SaveDefaultMWParameter = true;
    ((CamEntitiesToEntities) this).BoxBoundingMin = new Pnt3D();
    ((CamEntitiesToEntities) this).BoxBoundingMax = new Pnt3D();
    ((CamEntitiesToGEntities) this).NumberofAxis = 3;
    ((CamEntitiesToGEntities) this).CamID = -1;
    ((CamEntitiesToGEntities) this).FourthAxis = "C";
    ((CamEntitiesToGEntities) this).Mode = CamMode.WireFrame;
    ((CamEntitiesToGEntities) this).Direction = ClockDirectionType.CW;
    ((CamEntitiesToGEntities) this).CamWireframeType = CamWireFrameType.Contour;
    ((CamEntitiesToGEntities) this).CamTriMeshType = CamTriangularMeshType.Rough;
    ((CamEntitiesToGEntities) this).CamTriMesh5AXType = CamTriangularMesh5AxType.ParallelCuts;
    ((CamEntitiesToGEntities) this).CamSurfType = CamSurfaceType.SurfaceParalel;
    ((CamEntitiesTobuEntities) this).CamDrillType = CamDrillType.Line;
    ((CamEntitiesTobuEntities) this).CamDrillMode = CamDrillMode.Point;
    ((CamEntitiesTobuEntities) this).Action = actionTypeBU.None;
    ((CamEntitiesTobuEntities) this).CamMode = CamMode.WireFrame;
    ((CamEntitiesTobuEntities) this).CamRotateType = CamRotationType.Flat;
    ((CamEntitiesTobuEntities) this).DevideData = new EntityDevideData();
    ((CamEntitiesTobuEntities) this).SortingSettings = (SortSettings) new ShapeRuntimeData();
    ((CamEntitiesTobuEntities) this).ClickList = new List<Point3D>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
