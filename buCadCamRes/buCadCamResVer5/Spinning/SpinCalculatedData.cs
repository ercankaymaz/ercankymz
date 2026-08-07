// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Spinning.SpinCalculatedData
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buCadCamResVer5.Spinning;

public class SpinCalculatedData
{
  public List<Entity> CalculatedEntities = new List<Entity>();
  public Point3D StartPoint = new Point3D();
  public bool ReturnSameWay = false;
  public bool isFinished = false;
  public bool isMoveSafe = false;
  public double YOffset = 0.0;
}
