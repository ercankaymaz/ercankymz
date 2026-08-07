// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCounterTopBase
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCounterTopBase : buSerilization5
{
  public bool Collapseas3DWihDifferentColor;
  public bool CollopseSharpCorner;
  public Color colorAngleSolid;
  public Color colorAnglePlane;
  public Color colorChamferTopPlane;
  public Color colorChamferBottomPlane;
  public Color colorChamferTopSolid;
  public Color colorChamferBottomSolid;

  public void CharSizeCalculateFromItemSize(
    double Width,
    double Height,
    double MinSize,
    double MaxSize,
    double Ratio,
    ref double calcHeight,
    ref double calcRatio)
  {
    double num = Width >= Height ? Height * Ratio : Width * Ratio;
    if (num < MinSize)
      num = MinSize;
    if (num > MaxSize)
      num = MaxSize;
    calcRatio = num / MinSize;
    calcHeight = Math.Round(num, 1);
  }
}
