// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SketchAnalyseSetData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SketchAnalyseSetData : buSerilization5
{
  public double CompositeCurveLength;

  public static void Copy(List<LayerBase5> Base, ref List<LayerBase5> Copied)
  {
    Copied.Clear();
    Copied = new List<LayerBase5>();
    for (int index = 0; index <= Base.Count - 1; ++index)
      Copied.Add((LayerBase5) new EditorCustomData(Base[index]));
  }

  public override string ToString()
  {
    return $"{((DevideEventFormVars) this).Name} , Enable = {((ScaleEventFormVars) this).Enable.ToString()} , Color : {((DevideEventFormVars) this).LayerColor.ToString()} , Thickness : {((DevideEventFormVars) this).LayerThickness.ToString()}";
  }

  static SketchAnalyseSetData() => DeleteTypeEventFormVars.Captions = new List<string>();

  public SketchAnalyseSetData()
  {
    ((DeleteTypeEventFormVars) this).LayerOriginalName = "";
    ((DeleteTypeEventFormVars) this).LayerNewName = "";
    ((DeleteTypeEventFormVars) this).LayerExtraName = "";
    ((DeleteTypeEventFormVars) this).LayerNewColor = Color.Blue;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
