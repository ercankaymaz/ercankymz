// Decompiled with JetBrains decompiler
// Type: buClass.eCurveEntities
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;

#nullable disable
namespace buClass;

public class eCurveEntities : eEntities
{
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D EndPoint = new Pnt3D();
  public List<Pnt3D> ControlPoints = new List<Pnt3D>();

  public eCurveEntities()
  {
  }

  public eCurveEntities(eCurveEntities ent)
  {
    this.StartPoint = new Pnt3D(ent.StartPoint);
    this.EndPoint = new Pnt3D(ent.EndPoint);
    this.ControlPoints.Clear();
    Pnt3D.Copy(ent.ControlPoints, ref this.ControlPoints);
  }

  public static void CopyCurveBase(eEntities baseEnt, ref eEntities copiedEnt)
  {
    ((eCurveEntities) copiedEnt).StartPoint = new Pnt3D(((eCurveEntities) baseEnt).StartPoint);
    ((eCurveEntities) copiedEnt).EndPoint = new Pnt3D(((eCurveEntities) baseEnt).EndPoint);
    ((eCurveEntities) copiedEnt).ControlPoints.Clear();
    Pnt3D.Copy(((eCurveEntities) baseEnt).ControlPoints, ref ((eCurveEntities) copiedEnt).ControlPoints);
  }
}
