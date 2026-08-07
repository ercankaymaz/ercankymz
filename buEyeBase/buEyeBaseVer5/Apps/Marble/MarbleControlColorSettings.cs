// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleControlColorSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleControlColorSettings : buSerilization5
{
  public static List<marbleCuttingItems> listVerticalItems;
  public static marbleCuttingItems[] cutItemsHor;
  public static marbleCuttingItems[] cutItemsVer;
  public static marbleCuttingItems[] cutItemsHorVerHor;
  public static marbleCuttingItems[] cutItemsHorVerVer;

  public override string ToString()
  {
    return $"Depth: {((MarbleRuntimeSettings) this).Depth.ToString()} - TopPosition: {((MarbleRuntimeSettings) this).TopPosition.ToString()} - BottomPosition: {((MarbleRuntimeSettings) this).BottomPosition.ToString()}";
  }

  public abstract void m001EB9();

  public MarbleControlColorSettings()
  {
    ((MarbleRuntimeSettings) this).MinThickness = 0.2;
    ((MarbleRuntimeSettings) this).MaxThickness = 10.0;
    ((MarbleRuntimeSettings) this).AreaCalculation = false;
    ((MarbleRuntimeSettings) this).AreaStep = 10;
    ((MarbleRuntimeSettings) this).ConnectGap = 0.5;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleControlColorSettings(
    double minThickness,
    double maxThickness,
    bool areacalc,
    int areastep,
    double connectGap)
  {
    ((MarbleRuntimeSettings) this).MinThickness = 0.2;
    ((MarbleRuntimeSettings) this).MaxThickness = 10.0;
    ((MarbleRuntimeSettings) this).AreaCalculation = false;
    ((MarbleRuntimeSettings) this).AreaStep = 10;
    ((MarbleRuntimeSettings) this).ConnectGap = 0.5;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((MarbleRuntimeSettings) this).MinThickness = minThickness;
    ((MarbleRuntimeSettings) this).MaxThickness = maxThickness;
    ((MarbleRuntimeSettings) this).AreaCalculation = areacalc;
    ((MarbleRuntimeSettings) this).AreaStep = areastep;
    ((MarbleRuntimeSettings) this).ConnectGap = connectGap;
  }

  public MarbleControlColorSettings(DepthPositionOptions data)
  {
    ((MarbleRuntimeSettings) this).MinThickness = 0.2;
    ((MarbleRuntimeSettings) this).MaxThickness = 10.0;
    ((MarbleRuntimeSettings) this).AreaCalculation = false;
    ((MarbleRuntimeSettings) this).AreaStep = 10;
    ((MarbleRuntimeSettings) this).ConnectGap = 0.5;
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
}
