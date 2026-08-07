// Decompiled with JetBrains decompiler
// Type: buClass.CoordinateCatch
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class CoordinateCatch : buSerilization
{
  public bool Found = false;
  public bool SnapFound = false;
  public bool OrthoFound = false;
  public bool OsnapFound = false;
  public bool TrackFound = false;
  public bool OverFound = false;
  public Pnt3D Point = new Pnt3D();
  public osnapType Type = osnapType.None;
  public osnapMethodType Method = osnapMethodType.None;
  public eEntities DrawEntity = new eEntities();
  public eEntities DrawEntity2 = new eEntities();
  public List<eEntities> HostEntities = new List<eEntities>();
  public int HostEntityIndex = -1;
  public double Width = 0.0;
  public double Height = 0.0;
  public double Depth = 0.0;
  public double Thickness = 2.0;
  public Color Color = Color.Lime;
  public List<Pnt3D> CatchBasePoints = new List<Pnt3D>();
  public Pnt3D EntityPoint = new Pnt3D();

  public CoordinateCatch()
  {
  }

  public CoordinateCatch(CoordinateCatch Catch)
  {
    this.HostEntityIndex = Catch.HostEntityIndex;
    this.Found = Catch.Found;
    this.Point = new Pnt3D(Catch.Point);
    this.Type = Catch.Type;
    this.Width = Catch.Width;
    this.Height = Catch.Height;
    this.Depth = Catch.Depth;
    this.Method = Catch.Method;
    this.Thickness = Catch.Thickness;
    this.Color = Catch.Color;
    eEntities copiedEnt1 = new eEntities();
    eEntities.CopyEntity(Catch.DrawEntity, ref copiedEnt1);
    this.DrawEntity = copiedEnt1;
    eEntities copiedEnt2 = new eEntities();
    eEntities.CopyEntity(Catch.DrawEntity2, ref copiedEnt2);
    this.DrawEntity2 = copiedEnt2;
    this.HostEntities = new List<eEntities>();
    eEntities.CopyEntities(Catch.HostEntities, ref this.HostEntities);
  }
}
