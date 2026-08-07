// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortbuMostClosedResult
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortbuMostClosedResult : buSerilization5
{
  public bool UseStartEndPointCompositeCurve;
  public double Resolution;
  public double GapDistance;
  public double SortResolution;
  public double MinProfileFilterLength;
  public bool ConnectSmallGap;
  public SortingIntersectionRulesType IntersectionRules;
  public bool isPointOnEntity;
  public int SelectedIndex;

  public override string ToString()
  {
    string str1 = $"Width: {((ViewportDrawOptions) this).Width.ToString("f2")} , Height: {((ViewportDrawOptions) this).Height.ToString("f2")}";
    if (((ViewportDrawOptions) this).Depth != 0.0)
      str1 = $"{str1} , Depth: {((ViewportDrawOptions) this).Depth.ToString("f2")}";
    string str2 = $"{str1} | MinX: {((ViewportDrawOptions) this).MinPoint.X.ToString("f2")} , MinY: {((ViewportDrawOptions) this).MinPoint.Y.ToString("f2")}";
    if (((ViewportDrawOptions) this).MinPoint.Z != ((ViewportDrawOptions) this).MaxPoint.Z)
      str2 = $"{str2} , MinZ: {((ViewportDrawOptions) this).MinPoint.Z.ToString("f2")}";
    string str3 = $"{str2} | MaxX: {((ViewportDrawOptions) this).MaxPoint.X.ToString("f2")} , MaxY: {((ViewportDrawOptions) this).MaxPoint.Y.ToString("f2")}";
    if (((ViewportDrawOptions) this).MinPoint.Z != ((ViewportDrawOptions) this).MaxPoint.Z)
      str3 = $"{str3} , MaxZ: {((ViewportDrawOptions) this).MaxPoint.Z.ToString("f2")}";
    return str3;
  }
}
