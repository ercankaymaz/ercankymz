// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.CounterTopCreateEventArg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class CounterTopCreateEventArg
{
  public double FinishCutForwardFeed;
  public double FinishCutBackwardFeed;
  public double FinishSafeDis;

  public abstract void m001FCC();

  public CounterTopCreateEventArg()
  {
    ((MarbleMachineSimultionSettings) this).ExtendPoint = new Point3D();
    ((MarbleMachineSimultionSettings) this).ExtendLength = 0.0;
    ((MarbleMachineSimultionSettings) this).CamID = -1;
    ((MarbleMachineSimultionSettings) this).indexCam = -1;
    ((MarbleMachineSimultionSettings) this).indexWire = -1;
    ((MarbleMachineSimultionSettings) this).indexWireSub = -1;
    ((MarbleMachineSimultionSettings) this).Direction = StartEndType.Start;
    ((MarbleMachineSimultionSettings) this).entityExtend = (buEntity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
