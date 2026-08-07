// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.FlatViewSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class FlatViewSettings : buSerilization5
{
  public List<buEntity> Entities;
  public static byte f000657;
  public List<Point3D> Outter;
  public List<List<Point3D>> Inside;
  public static byte f00065A;
  public Point3D MinPoint;
  public Point3D MidPoint;

  public FlatViewSettings()
  {
    ((CreateModelProperties) this).normalPoint = new Pnt6D();
    ((CreateModelProperties) this).tangentPoint = new Pnt6D();
    ((CreateModelProperties) this).normalEntities = (Entity) null;
    ((CreateModelProperties) this).tangentEntities = (Entity) null;
    ((CreateModelProperties) this).LeadInEntities = (Entity) null;
    ((CreateModelProperties) this).LeadOutEntities = (Entity) null;
    ((CreateModelProperties) this).SafeInEntities = (Entity) null;
    ((CreateModelProperties) this).SafeOutEntities = (Entity) null;
    ((CreateModelProperties) this).NormalVector = new Vector3D();
    ((CreateModelProperties) this).TangentVector = new Vector3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public FlatViewSettings(MeshToSurfacePointsCalculations Data)
  {
    ((CreateModelProperties) this).normalPoint = new Pnt6D();
    ((CreateModelProperties) this).tangentPoint = new Pnt6D();
    ((CreateModelProperties) this).normalEntities = (Entity) null;
    ((CreateModelProperties) this).tangentEntities = (Entity) null;
    ((CreateModelProperties) this).LeadInEntities = (Entity) null;
    ((CreateModelProperties) this).LeadOutEntities = (Entity) null;
    ((CreateModelProperties) this).SafeInEntities = (Entity) null;
    ((CreateModelProperties) this).SafeOutEntities = (Entity) null;
    ((CreateModelProperties) this).NormalVector = new Vector3D();
    ((CreateModelProperties) this).TangentVector = new Vector3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) Data, ref CopiedClass);
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
    if (((CreateModelProperties) Data).normalEntities != null)
      ((CreateModelProperties) this).normalEntities = buVector5.CopyEntities(((CreateModelProperties) Data).normalEntities);
    if (((CreateModelProperties) Data).tangentEntities != null)
      ((CreateModelProperties) this).tangentEntities = buVector5.CopyEntities(((CreateModelProperties) Data).tangentEntities);
    ((CreateModelProperties) this).NormalVector = new Vector3D(((CreateModelProperties) Data).NormalVector.X, ((CreateModelProperties) Data).NormalVector.Y, ((CreateModelProperties) Data).NormalVector.Z);
    ((CreateModelProperties) this).TangentVector = new Vector3D(((CreateModelProperties) Data).TangentVector.X, ((CreateModelProperties) Data).TangentVector.Y, ((CreateModelProperties) Data).TangentVector.Z);
  }
}
