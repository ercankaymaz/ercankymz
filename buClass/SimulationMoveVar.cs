// Decompiled with JetBrains decompiler
// Type: buClass.SimulationMoveVar
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class SimulationMoveVar : buSerilization
{
  public AxesEnable Axes = new AxesEnable();
  public Pnt3D RotationPoint = new Pnt3D();
  public static List<string> Captions = new List<string>();

  public SimulationMoveVar()
  {
  }

  public SimulationMoveVar(SimulationMoveVar data)
  {
    this.Axes = new AxesEnable(data.Axes);
    this.RotationPoint = new Pnt3D(data.RotationPoint);
  }
}
