// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Printer3DSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class Printer3DSettings : buSerilization5
{
  public string NotchLayerName;
  public string InfoLayerName;
  public string PartInfoLayerName;
  public string ContourRefLayerName;
  public string InnerContourLayerName;
  public string InnerContourNoCutLayerName;
  public string InnerContourRefLayerName;
  public string InnerContourPloter1LayerName;
  public string InnerContourPloter2LayerName;
  public double DrillMainDaimeterValue;
  public double DrillAuxDaimeterValue;
  public bool NotchOnContour;
  public double MirrorCenterPointCatchGapDistance;
  public bool AddAttribute;
  public bool ExtendEntitiesFromRuleFile;
  public double XScaleFactor;
  public double YScaleFactor;
  public double OffsetValue;
  public bool DeleteOriginal;

  public Printer3DSettings(CutterIsoFileItems data)
  {
    ((buPrinter3D) this).Entities = new List<List<Entity>>();
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

  public Printer3DSettings()
  {
    ((buPrinter3D) this).SimStep = 1;
    ((Printer3DJob) this).ManuelSheetWidth = 1000.0;
    ((Printer3DJob) this).ManuelSheetHeight = 500.0;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }
}
