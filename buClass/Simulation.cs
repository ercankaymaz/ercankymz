// Decompiled with JetBrains decompiler
// Type: buClass.Simulation
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class Simulation : buSerilization
{
  public List<Pnt6DSim> SimDetailedPoints = new List<Pnt6DSim>();
  public List<Pnt6D> SimPoints = new List<Pnt6D>();

  public Simulation()
  {
  }

  public Simulation(Simulation sim)
  {
    this.SimDetailedPoints.Clear();
    this.SimPoints.Clear();
    for (int index = 0; index <= sim.SimDetailedPoints.Count - 1; ++index)
      this.SimDetailedPoints.Add(new Pnt6DSim(sim.SimDetailedPoints[index]));
    for (int index = 0; index <= sim.SimPoints.Count - 1; ++index)
      this.SimPoints.Add(new Pnt6D(sim.SimPoints[index]));
  }

  public override string ToString() => "Count: " + this.SimDetailedPoints.Count.ToString();
}
