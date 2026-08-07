// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamWaveShapeArgs
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class FoamWaveShapeArgs : buSerilization5
{
  public double RotatePos;
  public double UpDistance;
  public PipeBendMoveCommand Command;
  public static byte f003C45;
  public string Name;
  public List<BendingLRAMaterialData> Orders;
  public static byte f003C48;
  public bool Enable;
  public double Length;
  public double Rotation;
  public double Angle;
  public double Radius;
  public static byte f003C4E;

  public static ArrayList ToDef(FoamBlock refItem, int Space) => new ArrayList();

  public override string ToString() => ((FoamPatternInfo) this).CamName.ToString();

  public abstract void m001AD2();
}
