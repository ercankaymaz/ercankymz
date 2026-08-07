// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileCalculatedJob
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Control;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileCalculatedJob : buSerilization5
{
  public const DrillItemType SlotByMilling = ; // Unable to render the field
  public const DrillItemType Profiling = ; // Unable to render the field

  public new void Dispose()
  {
    buCall.\u0001 = (buVector5) null;
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected new virtual void Dispose(bool disposing)
  {
    if (((ProfileItem) this).\u0001)
      return;
    if (disposing)
      buCall.\u0001 = (buVector5) null;
    ((ProfileItem) this).\u0001 = true;
  }

  public void SetLayerIndexFromLayerName(ref List<buEntity> refEntities, Design Viewport)
  {
    for (int index1 = 0; index1 <= refEntities.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= Viewport.Layers.Count - 1; ++index2)
      {
        if (((CustomDataSurrogate) refEntities[index1]).LayerName == Viewport.Layers[index2].Name)
          ;
      }
    }
  }

  public void SetLayerIndexFromLayerName(ref List<List<buEntity>> refEntities, Design Viewport)
  {
    for (int index1 = 0; index1 <= refEntities.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= refEntities[index1].Count - 1; ++index2)
      {
        for (int index3 = 0; index3 <= Viewport.Layers.Count - 1; ++index3)
        {
          if (((CustomDataSurrogate) refEntities[index1][index2]).LayerName == Viewport.Layers[index3].Name)
            ;
        }
      }
    }
  }

  public void GetAvailableNestingPartID(List<buNestingPart> Parts, ref int PartID)
  {
    try
    {
      int num = int.MinValue;
      if (Parts.Count == 0)
      {
        PartID = 0;
      }
      else
      {
        for (int index = 0; index <= Parts.Count - 1; ++index)
        {
          if (((ProfileOperation) Parts[index]).ID > num)
            num = ((ProfileOperation) Parts[index]).ID;
        }
        PartID = num + 1;
      }
    }
    catch (Exception ex)
    {
      string str = "ID:00400001";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void GetAvailableNestingSheetID(List<buNestingSheet> Sheets, ref int SheetID)
  {
    try
    {
      int num = int.MinValue;
      for (int index = 0; index <= Sheets.Count - 1; ++index)
      {
        if (((ProfileItemCalc) Sheets[index]).ID > num)
          num = ((ProfileItemCalc) Sheets[index]).ID;
      }
      SheetID = num + 1;
    }
    catch (Exception ex)
    {
      string str = "ID:00400002";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }
}
