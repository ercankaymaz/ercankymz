// Decompiled with JetBrains decompiler
// Type: buApplication3D.UserInterfaces.buUserSimSetVariables
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buApplication3D.UserInterfaces;

public class buUserSimSetVariables
{
  public static double SimLinearStep;
  public static double SimRotaryDegree;
  public static int GCodeLineOffset;
  public static bool CollisionControl;

  static buUserSimSetVariables()
  {
    buUserSimVariables.indexSim = -1;
    buUserSimVariables.SimMovePartIndex = new List<int>();
    buUserSimVariables.isMachineCreated = false;
    buUserSimVariables.pntMouseViewport = (Point3D) null;
  }
}
