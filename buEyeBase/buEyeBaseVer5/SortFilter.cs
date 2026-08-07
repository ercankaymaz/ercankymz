// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortFilter
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortFilter : buSerilization5
{
  public Color IntermediateColor;
  public Color TopColor;
  public bool ShowEdges;
  public Color EdgeColor;
  public float EdgeThickness;
  public silhouettesDrawingType SilhouettesDrawingMode;
  public float SilhouetteThickness;
  public edgeColorMethodType EdgeColorMethod;

  public override string ToString()
  {
    return $"X: {((ViewportSettings) this).refPoint.X.ToString("f3")} Y: {((ViewportSettings) this).refPoint.Y.ToString("f3")} Index: {((ViewportSettings) this).Index.ToString("")}";
  }

  public abstract void m00029F();
}
