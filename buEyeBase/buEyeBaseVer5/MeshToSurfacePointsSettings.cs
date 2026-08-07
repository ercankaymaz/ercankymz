// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MeshToSurfacePointsSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

public class MeshToSurfacePointsSettings : buSerilization5
{
  public double CDistanceAtC270;
  public KinemeticType Type;
  public string Name;
  public string FileName;
  public static List<string> Captions = new List<string>();
  public static byte f0005BC;
  public double XPosition;
  public double GeometrixMaxX;
  public double GeometrixMinX;
  public double XOffset;
  public double Width;
  public string Text;
  public double MaxPositionRange;
  public double MinPositionRange;
  public bool Used;
  public bool Enable;
  public static byte f0005C7;
  public double AngleXY;
  public double AngleXZ;
  public double AngleYZ;
  public static byte f0005CB;
  public double X;
  public double Y;
  public double Z;
  public double A;
  public double B;
  public double C;
  public double R;
  public double FeedRate;

  public MeshToSurfacePointsSettings() => ((pageInfo) this).\u002Ector();
}
