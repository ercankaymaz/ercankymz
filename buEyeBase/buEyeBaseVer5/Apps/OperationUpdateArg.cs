// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.OperationUpdateArg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class OperationUpdateArg : buSerilization5
{
  public double RectangleHeight;
  public double RectangleRadius;
  public double RectangleChamfer;
  public double RectangleAngle;

  static OperationUpdateArg()
  {
    ProfileSettings.\u003C\u003E9 = (buProfileCalc.\u003C\u003Ec) new OperationUpdateArg();
  }

  internal int \u0001([In] MinMax obj0, [In] MinMax obj1) => obj0.Min.CompareTo(obj1.Min);
}
