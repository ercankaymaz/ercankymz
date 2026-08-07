// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingSheetData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingSheetData : buSerilization5
{
  public double ClamperMillingFirstPositionOffset;
  public double ClamperNextDrillExtraMoveDistance;
  public double ClamperSingleLimit;
  public double ClamperSingleMustLimit;
  public double ClamperDualClamperMinLimit;
  public double ClamperNextLookOperationDistance;
  public double ClamperSmallMaterialCLampMinLengthPersc;
  public double ClamperMediumMaterialCLampMinLengthPersc;
  public double ClamperBigMaterialCLampMinLengthPersc;
  public double ClamperThickness;
  public double MaterialSmallLimit;
  public double MaterialMediumLimit;

  public buNestingSheetData(SewingMain data)
  {
    ((DrillCNCSettings) this).MainEntityList = new List<buEntity>();
    ((DrillCNCSettings) this).SimilationPoint = (SimulationTp) new camParameters5();
    ((DrillCNCSettings) this).isSorted = false;
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
    buRadialDim.Copy(((DrillCNCSettings) data).MainEntityList, ref ((DrillCNCSettings) this).MainEntityList);
    ((DrillCNCSettings) this).SimilationPoint = (SimulationTp) new camParameters5(((DrillCNCSettings) data).SimilationPoint);
  }

  public buNestingSheetData()
  {
    ((DrillCNCSettings) this).StitchLen = 0.0;
    ((DrillCNCSettings) this).isStitch = false;
    ((DrillCNCSettings) this).indexEntity = -1;
    ((DrillCNCSettings) this).indexVertex = -1;
    ((DrillCNCSettings) this).SortDir = entitySortDirection.Normal;
    ((DrillCNCSettings) this).DrawType = SewingDrawType.None;
    ((DrillCNCSettings) this).Punteriz = (SewingPunteriz) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingSheetData(
    int indexentity,
    int indexvertex,
    bool isstitch,
    double stitchlen,
    SewingDrawType drawType)
  {
    ((DrillCNCSettings) this).StitchLen = 0.0;
    ((DrillCNCSettings) this).isStitch = false;
    ((DrillCNCSettings) this).indexEntity = -1;
    ((DrillCNCSettings) this).indexVertex = -1;
    ((DrillCNCSettings) this).SortDir = entitySortDirection.Normal;
    ((DrillCNCSettings) this).DrawType = SewingDrawType.None;
    ((DrillCNCSettings) this).Punteriz = (SewingPunteriz) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((DrillCNCSettings) this).indexEntity = indexentity;
    ((DrillCNCSettings) this).indexVertex = indexvertex;
    ((DrillCNCSettings) this).isStitch = isstitch;
    ((DrillCNCSettings) this).StitchLen = stitchlen;
    ((DrillCNCSettings) this).DrawType = drawType;
  }

  public buNestingSheetData(SewingEntityCustomData data)
  {
    ((DrillCNCSettings) this).StitchLen = 0.0;
    ((DrillCNCSettings) this).isStitch = false;
    ((DrillCNCSettings) this).indexEntity = -1;
    ((DrillCNCSettings) this).indexVertex = -1;
    ((DrillCNCSettings) this).SortDir = entitySortDirection.Normal;
    ((DrillCNCSettings) this).DrawType = SewingDrawType.None;
    ((DrillCNCSettings) this).Punteriz = (SewingPunteriz) null;
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
    if (((DrillCNCSettings) data).Punteriz == null)
      return;
    ((DrillCNCSettings) this).Punteriz = (SewingPunteriz) new Line2D(((DrillCNCSettings) data).Punteriz);
  }
}
