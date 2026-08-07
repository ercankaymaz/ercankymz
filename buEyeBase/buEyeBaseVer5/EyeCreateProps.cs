// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.EyeCreateProps
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class EyeCreateProps
{
  public Vector3D vecNormal;
  public bool Enable;
  public bool isLast;
  public static byte f000633;
  public HitSurfacePointsGetType PointGetType;
  public double TangentAngleFromNormal;
  public double SurfaceNormalLength;
  public Pnt6D normalPoint;
  public Entity normalEntities;
  public Vector3D NormalVector;
  public Point3D pntBottomLeft;
  public Point3D pntBottomCenter;
  public Point3D pntBottomRight;
  public Point3D pntMiddleLeft;
  public Point3D pntMiddleCenter;
  public Point3D pntMiddleRight;
  public Point3D pntTopLeft;
  public Point3D pntTopCenter;
  public Point3D pntTopRight;
  public List<Point3D> MovePoints;

  public EyeCreateProps(PointWithIndex data)
  {
    ((AlingmentPoints3D) this).Pnt = new Point3D();
    ((AlingmentPoints3D) this).Index = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    ((AlingmentPoints3D) this).Pnt = F_NotchEdit.ToPoint3D(((AlingmentPoints3D) data).Pnt);
  }

  public override string ToString()
  {
    return $"Index: {((AlingmentPoints3D) this).Index.ToString()} - Pnt: {((AlingmentPoints3D) this).Pnt.ToString()}";
  }

  public abstract void m000285();
}
