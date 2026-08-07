// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SelectionOperation
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

#nullable disable
namespace buEyeBaseVer5;

public class SelectionOperation
{
  public double KeyHoleDepth;
  public double KeyHoleAngle;
  public double FreeDrawWidth;
  public double FreeDrawHeight;
  public double FreeDrawDepth;

  public SelectionOperation()
  {
    ((SortbuMostClosedResult) this).UseStartEndPointCompositeCurve = true;
    ((SortbuMostClosedResult) this).Resolution = 0.01;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
