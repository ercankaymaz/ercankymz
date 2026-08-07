// Decompiled with JetBrains decompiler
// Type: buClass.CamPoint
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class CamPoint : buSerilization
{
  public ArrayList PreCodes = new ArrayList();
  public ArrayList AfterCodes = new ArrayList();
  public List<Pnt9DCam> Points = new List<Pnt9DCam>();
  public List<Pnt3D> PointsNoRTCP = new List<Pnt3D>();
  public Simulation SimilationPoint = new Simulation();
  public List<geoEntity> EntitiesMark = new List<geoEntity>();
  public List<geoEntity> EntitiesG1 = new List<geoEntity>();
  public List<geoEntity> EntitiesG0 = new List<geoEntity>();
  public List<geoEntity> EntitiesPlunge = new List<geoEntity>();
  public List<geoEntity> EntitiesLeave = new List<geoEntity>();
  public List<geoEntity> EntitiesOther = new List<geoEntity>();
  public List<geoEntity> EntitiesLeadIn = new List<geoEntity>();
  public List<geoEntity> EntitiesLeadOut = new List<geoEntity>();
  public List<int> EntityIndex = new List<int>();
  public List<DirectionArrow> DirectionArrows = new List<DirectionArrow>();
  public Pnt9D GCodeOffset = new Pnt9D();
  public int Type = 0;
  public int NumberOfPlungeMovement = 0;
  public int NumberOfLeaveMovement = 0;
  public double Feed = 100.0;
  public bool ForceWriteAllCoordinate = false;
  public bool IsRapid = false;
  public bool FastMoveByG1 = false;
  public string GoSafeAxis = "";
  public string Command = "";
  public int Mode = 0;

  public CamPoint()
  {
  }

  public CamPoint(CamPoint campoint)
  {
    this.Mode = campoint.Mode;
    this.Feed = campoint.Feed;
    this.Type = campoint.Type;
    this.IsRapid = campoint.IsRapid;
    this.ForceWriteAllCoordinate = campoint.ForceWriteAllCoordinate;
    this.Command = campoint.Command;
    this.GoSafeAxis = campoint.GoSafeAxis;
    this.FastMoveByG1 = campoint.FastMoveByG1;
    this.GCodeOffset = new Pnt9D(campoint.GCodeOffset);
    this.Points = new List<Pnt9DCam>();
    for (int index = 0; index <= campoint.Points.Count - 1; ++index)
      this.Points.Add(new Pnt9DCam(campoint.Points[index]));
    this.PointsNoRTCP = new List<Pnt3D>();
    for (int index = 0; index <= campoint.PointsNoRTCP.Count - 1; ++index)
      this.PointsNoRTCP.Add(new Pnt3D(campoint.PointsNoRTCP[index]));
    this.SimilationPoint = new Simulation(new Simulation(campoint.SimilationPoint));
    this.PreCodes = new ArrayList();
    for (int index = 0; index <= campoint.PreCodes.Count - 1; ++index)
      this.PreCodes.Add(campoint.PreCodes[index]);
    this.AfterCodes = new ArrayList();
    for (int index = 0; index <= campoint.AfterCodes.Count - 1; ++index)
      this.AfterCodes.Add(campoint.AfterCodes[index]);
    this.DirectionArrows = new List<DirectionArrow>();
    for (int index = 0; index <= campoint.DirectionArrows.Count - 1; ++index)
      this.DirectionArrows.Add(new DirectionArrow(campoint.DirectionArrows[index]));
    this.EntityIndex = new List<int>();
    for (int index = 0; index <= campoint.EntityIndex.Count - 1; ++index)
      this.EntityIndex.Add(campoint.EntityIndex[index]);
    this.EntitiesG1 = new List<geoEntity>();
    for (int index = 0; index <= campoint.EntitiesG1.Count - 1; ++index)
    {
      geoEntity CopiedTo = new geoEntity();
      geoEntity.Copy(campoint.EntitiesG1[index], ref CopiedTo);
      this.EntitiesG1.Add(CopiedTo);
    }
    this.EntitiesOther = new List<geoEntity>();
    for (int index = 0; index <= campoint.EntitiesOther.Count - 1; ++index)
    {
      geoEntity CopiedTo = new geoEntity();
      geoEntity.Copy(campoint.EntitiesOther[index], ref CopiedTo);
      this.EntitiesOther.Add(CopiedTo);
    }
    this.EntitiesMark = new List<geoEntity>();
    for (int index = 0; index <= campoint.EntitiesMark.Count - 1; ++index)
    {
      geoEntity CopiedTo = new geoEntity();
      geoEntity.Copy(campoint.EntitiesMark[index], ref CopiedTo);
      this.EntitiesMark.Add(CopiedTo);
    }
    this.EntitiesG0 = new List<geoEntity>();
    for (int index = 0; index <= campoint.EntitiesG0.Count - 1; ++index)
    {
      geoEntity CopiedTo = new geoEntity();
      geoEntity.Copy(campoint.EntitiesG0[index], ref CopiedTo);
      this.EntitiesG0.Add(CopiedTo);
    }
    this.EntitiesLeadIn = new List<geoEntity>();
    for (int index = 0; index <= campoint.EntitiesLeadIn.Count - 1; ++index)
    {
      geoEntity CopiedTo = new geoEntity();
      geoEntity.Copy(campoint.EntitiesLeadIn[index], ref CopiedTo);
      this.EntitiesLeadIn.Add(CopiedTo);
    }
    this.EntitiesLeadOut = new List<geoEntity>();
    for (int index = 0; index <= campoint.EntitiesLeadOut.Count - 1; ++index)
    {
      geoEntity CopiedTo = new geoEntity();
      geoEntity.Copy(campoint.EntitiesLeadOut[index], ref CopiedTo);
      this.EntitiesLeadOut.Add(CopiedTo);
    }
    this.EntitiesPlunge = new List<geoEntity>();
    for (int index = 0; index <= campoint.EntitiesPlunge.Count - 1; ++index)
    {
      geoEntity CopiedTo = new geoEntity();
      geoEntity.Copy(campoint.EntitiesPlunge[index], ref CopiedTo);
      this.EntitiesPlunge.Add(CopiedTo);
    }
    this.EntitiesLeave = new List<geoEntity>();
    for (int index = 0; index <= campoint.EntitiesLeave.Count - 1; ++index)
    {
      geoEntity CopiedTo = new geoEntity();
      geoEntity.Copy(campoint.EntitiesLeave[index], ref CopiedTo);
      this.EntitiesLeave.Add(CopiedTo);
    }
  }

  public override string ToString()
  {
    string str = "";
    if (this.Points.Count > 0)
    {
      str = $" - X: {this.Points[0].P9.X.ToString("f3")} , Y: {this.Points[0].P9.Y.ToString("f3")} , Z: {this.Points[0].P9.Z.ToString("f3")}";
      if (this.Points[0].P9.A != 0.0)
        str = $"{str} - A: {this.Points[0].P9.A.ToString("f3")}";
      if (this.Points[0].P9.B != 0.0)
        str = $"{str} - B: {this.Points[0].P9.B.ToString("f3")}";
      if (this.Points[0].P9.C != 0.0)
        str = $"{str} - C: {this.Points[0].P9.C.ToString("f3")}";
    }
    return $"Cnt: {this.Points.Count.ToString()} , Type: {this.Type.ToString()} , Feed: {this.Feed.ToString()}{str}";
  }
}
