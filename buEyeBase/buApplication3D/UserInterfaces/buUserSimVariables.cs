// Decompiled with JetBrains decompiler
// Type: buApplication3D.UserInterfaces.buUserSimVariables
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buApplication3D.UserInterfaces;

public class buUserSimVariables
{
  public static int indexSim;
  public static List<int> SimMovePartIndex;
  public static bool isMachineCreated;
  public static Point3D pntMouseViewport;

  public buUserSimVariables()
  {
  }

  public buUserSimVariables()
  {
  }

  public static void Init()
  {
    buUserSimVariables.SimMovePartIndex = new List<int>();
    buUserSimVariables.pntMouseViewport = new Point3D();
  }
}
