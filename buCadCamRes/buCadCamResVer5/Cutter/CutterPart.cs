// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Cutter.CutterPart
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buCadCamResVer5.Cutter;

public class CutterPart
{
  public Entity Cut = (Entity) null;
  public List<Entity> Drill = new List<Entity>();
  public List<Entity> RopeDirection = new List<Entity>();
  public List<Entity> InnerCut = new List<Entity>();
  public List<Entity> InnerNoCut = new List<Entity>();
  public List<Entity> Plotter1 = new List<Entity>();
  public List<Entity> Plotter2 = new List<Entity>();
  public List<Entity> textInfoEntities = new List<Entity>();
  public List<Entity> textPartInfoEntities = new List<Entity>();
  public List<Entity> NotchEntities = new List<Entity>();
  public Point3D pntMin = new Point3D();
  public Point3D pntMax = new Point3D();
  public List<CutterNotch> Notch = new List<CutterNotch>();
  public List<RulStrectPoints> StrectPntCut = new List<RulStrectPoints>();
  public List<RulStrectPoints> StrectPntInnerCut = new List<RulStrectPoints>();
  public List<RulStrectPoints> StrectPntDrillCut = new List<RulStrectPoints>();
  public List<RulStrectPoints> StrectPntRopeDirCut = new List<RulStrectPoints>();
  public List<RulStrectPoints> StrectPntInnerNoCut = new List<RulStrectPoints>();
  public List<RulStrectPoints> StrectPntPloter1Cut = new List<RulStrectPoints>();
  public List<RulStrectPoints> StrectPntPloter2Cut = new List<RulStrectPoints>();
  public List<RulStrectPoints> StrectPntNotch = new List<RulStrectPoints>();
}
