// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Editor.UClick
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using devDept.Eyeshot.Entities;
using devDept.Geometry;

#nullable disable
namespace buCadCamResVer5.Editor;

public class UClick
{
  public Point2D Position;
  public Point3D Pnt3D;
  public Entity Entity;
  public bool Snapped;

  public UClick(Point2D position, Entity entity = null, bool snapped = false)
  {
    this.Position = position;
    this.Entity = entity;
    this.Snapped = snapped;
  }

  public UClick(Point2D position, Point3D pnt, Entity entity = null, bool snapped = false)
  {
    this.Position = position;
    this.Pnt3D = pnt;
    this.Entity = entity;
    this.Snapped = snapped;
  }

  public UClick(double x, double y)
  {
    this.Position = new Point2D(x, y);
    this.Entity = (Entity) null;
    this.Snapped = false;
  }
}
