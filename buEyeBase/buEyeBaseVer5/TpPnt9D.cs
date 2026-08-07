// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.TpPnt9D
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class TpPnt9D
{
  public bool isAngleAvailable;
  public bool isSecondHead;
  public ToolBase5 ToolCam;
  public planeNames PlaneName;
  public CamSequence SubSequence;
  public static byte f000186;
  public ArrayList PreCodes;
  public ArrayList AfterCodes;
  public double Feed;
  public double Radius;
  public double ToolNo;
  public string ToolName;
  public string OverWriteString;
  public double SpindleSpeed;
  public double PlungeValue;
  public double SimDevideLen;
  public int Type;
  public int ArcType;
  public bool IsArc;
  public bool IsMark;
  public bool IsLimit;
  public bool IsSafePosition;
  public bool LeaveAxisMovement;
  public bool PlungeAxisMovement;
  public bool DontUseAdditionalCommand;
  public string PlungeAxis;
  public string LeaveAxis;
  public string GCodeExtraLine;
  public CamPlungeActionType PlungeAction;
  public CamMoveType MoveType;
  public AxesEnableWithUVW EnableAxes;
  public TpArcData ArcData;

  public override string ToString()
  {
    string str = ((camTp) this).TypeCam.ToString();
    if (((camTp) this).Tool != null)
      str = $"{str} - Tool Purpose: {((ToolGeometry5) ((camTp) this).Tool).Purpose.ToString()} - Type: {((ToolData5) ((ToolGeometry5) ((camTp) this).Tool).Geometry).GeometryType.ToString()}";
    if (((camTpPoint) this).Used)
      str += " - Used";
    if (((camTp) this).Sequnce != 0)
      str = $"{str} - Seq: {((camTp) this).Sequnce.ToString()}";
    return str;
  }

  public abstract void m0000CB();

  public TpPnt9D()
  {
    ((camTpPoint) this).PreCodes = new ArrayList();
    ((camTpPoint) this).AfterCodes = new ArrayList();
    ((camTpPoint) this).PrePoints = new List<TpPnt9D>();
    ((camTpPoint) this).AfterPoints = new List<TpPnt9D>();
    ((camTpPoint) this).Points = new List<TpPnt9D>();
    ((camTpPoint) this).GCodeOffset = new Pnt9D();
    ((camTpPoint) this).Command = "";
    ((camTpPoint) this).Type = 0;
    ((camTpPoint) this).Mode = 0;
    ((camTpPoint) this).NumberOfPlungeMovement = 0;
    ((camTpPoint) this).NumberOfLeaveMovement = 0;
    ((camTpPoint) this).Feed = 0.0;
    ((camTpPoint) this).ForceWriteAllCoordinate = false;
    ((camTpPoint) this).isInside = false;
    ((camTpPoint) this).Used = false;
    this.isAngleAvailable = false;
    this.isSecondHead = false;
    this.ToolCam = (ToolBase5) null;
    this.PlaneName = planeNames.Top;
    this.SubSequence = CamSequence.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public TpPnt9D(camTpPoint campoint, bool CopyClass = true)
  {
    ((camTpPoint) this).PreCodes = new ArrayList();
    ((camTpPoint) this).AfterCodes = new ArrayList();
    ((camTpPoint) this).PrePoints = new List<TpPnt9D>();
    ((camTpPoint) this).AfterPoints = new List<TpPnt9D>();
    ((camTpPoint) this).Points = new List<TpPnt9D>();
    ((camTpPoint) this).GCodeOffset = new Pnt9D();
    ((camTpPoint) this).Command = "";
    ((camTpPoint) this).Type = 0;
    ((camTpPoint) this).Mode = 0;
    ((camTpPoint) this).NumberOfPlungeMovement = 0;
    ((camTpPoint) this).NumberOfLeaveMovement = 0;
    ((camTpPoint) this).Feed = 0.0;
    ((camTpPoint) this).ForceWriteAllCoordinate = false;
    ((camTpPoint) this).isInside = false;
    ((camTpPoint) this).Used = false;
    this.isAngleAvailable = false;
    this.isSecondHead = false;
    this.ToolCam = (ToolBase5) null;
    this.PlaneName = planeNames.Top;
    this.SubSequence = CamSequence.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    if (CopyClass)
    {
      object CopiedClass = new object();
      buSerilization5.CopyClass((object) campoint, ref CopiedClass);
      if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
      {
        FieldInfo[] fields = this.GetType().GetFields();
        if (fields != null)
        {
          for (int index = 0; index <= fields.Length - 1; ++index)
          {
            string name = fields[index].Name;
            object obj = fields[index].GetValue(CopiedClass);
            fields[index].SetValue((object) this, obj);
          }
        }
      }
    }
    if (((TpPnt9D) campoint).ToolCam != null)
      this.ToolCam = (ToolBase5) new ToolGeometry5(((TpPnt9D) campoint).ToolCam);
    ((camTpPoint) this).Mode = campoint.Mode;
    ((camTpPoint) this).Type = campoint.Type;
    ((camTpPoint) this).Command = campoint.Command;
    ((camTpPoint) this).GCodeOffset = new Pnt9D(campoint.GCodeOffset);
    ((camTpPoint) this).AfterPoints = new List<TpPnt9D>();
    ((camTpPoint) this).PrePoints = new List<TpPnt9D>();
    ((camTpPoint) this).Points = new List<TpPnt9D>();
    for (int index = 0; index <= campoint.Points.Count - 1; ++index)
      ((camTpPoint) this).Points.Add(new TpPnt9D(campoint.Points[index]));
    for (int index = 0; index <= campoint.AfterPoints.Count - 1; ++index)
      ((camTpPoint) this).AfterPoints.Add(new TpPnt9D(campoint.AfterPoints[index]));
    for (int index = 0; index <= campoint.PrePoints.Count - 1; ++index)
      ((camTpPoint) this).PrePoints.Add(new TpPnt9D(campoint.PrePoints[index]));
    ((camTpPoint) this).PreCodes = new ArrayList();
    for (int index = 0; index <= campoint.PreCodes.Count - 1; ++index)
      ((camTpPoint) this).PreCodes.Add(campoint.PreCodes[index]);
    ((camTpPoint) this).AfterCodes = new ArrayList();
    for (int index = 0; index <= campoint.AfterCodes.Count - 1; ++index)
      ((camTpPoint) this).AfterCodes.Add(campoint.AfterCodes[index]);
  }

  public override string ToString()
  {
    string str = "";
    if (((camTpPoint) this).Points.Count > 0)
    {
      str = $" - X: {((TpArcData) ((camTpPoint) this).Points[0]).P9.X.ToString("f3")} , Y: {((TpArcData) ((camTpPoint) this).Points[0]).P9.Y.ToString("f3")} , Z: {((TpArcData) ((camTpPoint) this).Points[0]).P9.Z.ToString("f3")}";
      if (((TpArcData) ((camTpPoint) this).Points[0]).P9.A != 0.0)
        str = $"{str} - A: {((TpArcData) ((camTpPoint) this).Points[0]).P9.A.ToString("f3")}";
      if (((TpArcData) ((camTpPoint) this).Points[0]).P9.B != 0.0)
        str = $"{str} - B: {((TpArcData) ((camTpPoint) this).Points[0]).P9.B.ToString("f3")}";
      if (((TpArcData) ((camTpPoint) this).Points[0]).P9.C != 0.0)
        str = $"{str} - C: {((TpArcData) ((camTpPoint) this).Points[0]).P9.C.ToString("f3")}";
      if (((camTpPoint) this).PreCodes.Count > 0)
        str = $"{str} - Pre: {((camTpPoint) this).PreCodes[0].ToString()}";
      if (((camTpPoint) this).AfterCodes.Count > 0)
        str = $"{str} - After: {((camTpPoint) this).AfterCodes[0].ToString()}";
      if (this.SubSequence != 0)
        str = $"{str} - Seq: {this.SubSequence.ToString()}";
    }
    return $"Cnt: {((camTpPoint) this).Points.Count.ToString()} , Type: {((camTpPoint) this).Type.ToString()}{str}";
  }

  public abstract void m0000CF();

  public TpPnt9D()
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public TpPnt9D(double x, double y, double z)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(x, y, z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
  }

  public TpPnt9D(double x, double y, double z, double feed, int type)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(x, y, z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
  }

  public TpPnt9D(double x, double y, double z, double a, double feed, int type)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(x, y, z, a, 0.0, 0.0, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
  }

  public TpPnt9D(double x, double y, double z, double a, double b, double c)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(x, y, z, a, b, c, 0.0, 0.0, 0.0);
  }

  public TpPnt9D(
    double x,
    double y,
    double z,
    double a,
    double b,
    double c,
    double feed,
    int type)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(x, y, z, a, b, c, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
  }

  public TpPnt9D(
    double x,
    double y,
    double z,
    double a,
    double b,
    double c,
    double u,
    double v,
    double w)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(x, y, z, a, b, c, u, v, w);
  }

  public TpPnt9D(Pnt3D P, OrientationAngle Orientation, double feed, int type)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(P.X, P.Y, P.Z, Orientation.A, Orientation.B, Orientation.C, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
  }

  public TpPnt9D(Point3D P, double feed, int type)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(P.X, P.Y, P.Z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
  }

  public TpPnt9D(Pnt6D P)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
  }

  public TpPnt9D(Pnt6D P, double feed, int type)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
  }

  public TpPnt9D(Pnt6D P, double feed, int type, bool plungemove)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
    this.PlungeAxisMovement = plungemove;
  }

  public TpPnt9D(Pnt6D P, double feed, int type, bool plungemove, bool Leavemove)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
    this.PlungeAxisMovement = plungemove;
    this.LeaveAxisMovement = Leavemove;
  }

  public TpPnt9D(Pnt9D P)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
  }

  public TpPnt9D(Pnt9D P, double feed, int type)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
    this.Feed = feed;
    this.Type = type;
  }

  public TpPnt9D(Pnt9D P, double feed, int type, bool plungemove)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
    this.Feed = feed;
    this.Type = type;
    this.PlungeAxisMovement = plungemove;
  }

  public TpPnt9D(Pnt9D P, double feed, int type, bool plungemove, bool Leavemove)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
    this.Feed = feed;
    this.Type = type;
    this.PlungeAxisMovement = plungemove;
    this.LeaveAxisMovement = Leavemove;
  }

  public TpPnt9D(TpPnt9D Pnt, bool CopyClass = false)
  {
    ((TpArcData) this).P9 = new Pnt9D();
    ((TpArcData) this).Offsets = new Pnt9D();
    ((TpArcData) this).PostOffsets = new Pnt9D();
    ((TpArcData) this).XChar = (string) null;
    ((TpArcData) this).YChar = (string) null;
    ((TpArcData) this).ZChar = (string) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    if (CopyClass)
    {
      object CopiedClass = new object();
      buSerilization5.CopyClass((object) Pnt, ref CopiedClass);
      if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
        return;
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields == null)
        return;
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
    else
    {
      if (Pnt == null)
        return;
      this.ArcType = Pnt.ArcType;
      this.DontUseAdditionalCommand = Pnt.DontUseAdditionalCommand;
      this.Feed = Pnt.Feed;
      this.GCodeExtraLine = Pnt.GCodeExtraLine;
      this.IsArc = Pnt.IsArc;
      this.IsMark = Pnt.IsMark;
      this.IsLimit = Pnt.IsLimit;
      this.IsSafePosition = Pnt.IsSafePosition;
      this.LeaveAxis = Pnt.LeaveAxis;
      this.MoveType = Pnt.MoveType;
      ((TpArcData) this).Offsets = new Pnt9D(((TpArcData) Pnt).Offsets);
      this.PlungeAction = Pnt.PlungeAction;
      this.PlungeAxis = Pnt.PlungeAxis;
      this.PlungeAxisMovement = Pnt.PlungeAxisMovement;
      this.PlungeValue = Pnt.PlungeValue;
      this.LeaveAxisMovement = Pnt.LeaveAxisMovement;
      this.Radius = Pnt.Radius;
      this.SimDevideLen = Pnt.SimDevideLen;
      this.SpindleSpeed = Pnt.SpindleSpeed;
      this.Type = Pnt.Type;
      this.ToolName = Pnt.ToolName;
      this.ToolNo = Pnt.ToolNo;
      ((TpArcData) this).P9 = new Pnt9D(((TpArcData) Pnt).P9);
      this.ArcData = (TpArcData) new camParameters5(Pnt.ArcData);
      this.AfterCodes.Clear();
      this.PreCodes.Clear();
      for (int index = 0; index <= Pnt.AfterCodes.Count - 1; ++index)
        this.AfterCodes.Add(Pnt.AfterCodes[index]);
      for (int index = 0; index <= Pnt.PreCodes.Count - 1; ++index)
        this.PreCodes.Add(Pnt.PreCodes[index]);
      this.EnableAxes = new AxesEnableWithUVW(Pnt.EnableAxes);
    }
  }

  public static TpPnt9D Copy(TpPnt9D P) => new TpPnt9D(P);

  public static TpPnt9D[] Copy(TpPnt9D[] pts)
  {
    TpPnt9D[] tpPnt9DArray = new TpPnt9D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      tpPnt9DArray[index] = TpPnt9D.Copy(pts[index]);
    return tpPnt9DArray;
  }
}
