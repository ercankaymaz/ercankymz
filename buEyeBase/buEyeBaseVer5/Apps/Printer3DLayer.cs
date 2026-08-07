// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Printer3DLayer
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
public class Printer3DLayer : buSerilization5
{
  public string NotchInsideLayerName;
  public string NotchOutsideLayerName;
  public string ContourLayerName;
  public string ContourRuleScaleLayerName;

  public Printer3DLayer()
  {
    ((buPrinter3D) this).XScaleFactor = 0.254;
    ((buPrinter3D) this).YScaleFactor = 0.254;
    ((buPrinter3D) this).NotchOnContour = false;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public Printer3DLayer(CutterIsoFileSettings data)
  {
    ((buPrinter3D) this).XScaleFactor = 0.254;
    ((buPrinter3D) this).YScaleFactor = 0.254;
    ((buPrinter3D) this).NotchOnContour = false;
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

  public Printer3DLayer()
  {
    ((buPrinter3D) this).Entities = new List<List<Entity>>();
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }
}
