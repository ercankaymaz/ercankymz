// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ToolGeometry5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ToolGeometry5 : buSerilization5
{
  public static byte f00039B;
  public string StockName;
  public bool isError;
  public ColorType colorStock;
  public Point3D MinPoint;
  public Point3D MaxPoint;
  public SizeObject SizeStock;
  public List<buEntity> StockEntities;
  public static byte f0003A3;
  public double Radius;
  public double RegenRatio;
  public static byte f0003A6;
  public List<Point3D> Points;
  public object Settings;
  public static byte f0003A9;
  public List<Pnt6D> Points;
  public object Settings;
  public static byte f0003AC;
  public List<ToolBase5> Tools;
  public string GroupName;
  public static byte f0003AF;
  public ToolData5 Data;
  public ToolGeometry5 Geometry;
  public ToolCamData5 CamData;
  public ToolDisplay5 Display;
  public ToolPositions5 Positions;
  public ToolLimits5 Limits;
  public ToolPurpose Purpose;
  public ArrayList Aux;
  public ArrayList ToolPre;
  public ArrayList ToolNext;
  public ArrayList SpindlePre;
  public ArrayList SpindleNext;
  public static List<string> Captions;
  public static byte f0003BD;
  public double Diameter;
  public double SocketThickness;
  public double DiameterLeft;
  public double DiameterRight;
  public double DiameterBody;
  public double ShoulderThickness;
  public double ShoulderDiameter;
  public double ShoulderLength;
  public double BottomDiameter;
  public double TopDiameter;
  public double RoundRadius;
  public double Length;
  public double TotalLength;
  public double LengthLeft;
  public double LengthRigth;
  public double LengthDiameter;
  public double CutLength;
  public double CutLengthLeft;
  public double CutLengthRight;
  public double ArborLength;
  public double ArborTopDiameter;
  public double ArborBottomDiameter;
  public double HolderLength;
  public double HolderDiameter;
  public double HolderInDiameter;
  public double TaperAngle;
  public double LowerRadius;

  public abstract void m000181();

  public ToolGeometry5() => ((pageInfo) this).\u002Ector();

  public ToolGeometry5(ToolBase5 tool)
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    if (tool == null)
      return;
    this.Data = (ToolData5) new LayerBase5(((ToolGeometry5) tool).Data);
    this.Geometry = (ToolGeometry5) new ToolPositions5(((ToolGeometry5) tool).Geometry);
    this.CamData = (ToolCamData5) new CopyEventFormVars(((ToolGeometry5) tool).CamData);
    this.Positions = (ToolPositions5) new MirrorEventFormVars(((ToolGeometry5) tool).Positions);
    this.Display = (ToolDisplay5) new LayerBase5(((ToolGeometry5) tool).Display);
    this.Limits = (ToolLimits5) new ScaleEventFormVars(((ToolGeometry5) tool).Limits);
    this.Purpose = ((ToolGeometry5) tool).Purpose;
    this.Aux = new ArrayList();
    for (int index = 0; index <= ((ToolGeometry5) tool).Aux.Count - 1; ++index)
      this.Aux.Add(((ToolGeometry5) tool).Aux[index]);
    this.ToolPre = new ArrayList();
    for (int index = 0; index <= ((ToolGeometry5) tool).ToolPre.Count - 1; ++index)
      this.ToolPre.Add(((ToolGeometry5) tool).ToolPre[index]);
    this.ToolNext = new ArrayList();
    for (int index = 0; index <= ((ToolGeometry5) tool).ToolNext.Count - 1; ++index)
      this.ToolNext.Add(((ToolGeometry5) tool).ToolNext[index]);
    this.SpindlePre = new ArrayList();
    for (int index = 0; index <= ((ToolGeometry5) tool).SpindlePre.Count - 1; ++index)
      this.SpindlePre.Add(((ToolGeometry5) tool).SpindlePre[index]);
    this.SpindleNext = new ArrayList();
    for (int index = 0; index <= ((ToolGeometry5) tool).SpindleNext.Count - 1; ++index)
      this.SpindleNext.Add(((ToolGeometry5) tool).SpindleNext[index]);
  }

  public ToolGeometry5(ToolBase tool)
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    this.Data = (ToolData5) new LayerBase5(tool.Data);
    this.Geometry = (ToolGeometry5) new ToolPositions5(tool.Geometry);
    this.CamData = (ToolCamData5) new CopyEventFormVars(tool.CamData);
    this.Positions = (ToolPositions5) new MirrorEventFormVars(tool.Positions);
    this.Display = (ToolDisplay5) new LayerBase5(tool.Display);
    this.Limits = (ToolLimits5) new DevideEventFormVars(tool.Limits);
    this.Purpose = tool.Purpose;
    this.Aux = new ArrayList();
    for (int index = 0; index <= tool.Aux.Count - 1; ++index)
      this.Aux.Add(tool.Aux[index]);
  }
}
