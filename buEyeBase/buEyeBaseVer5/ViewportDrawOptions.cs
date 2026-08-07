// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ViewportDrawOptions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class ViewportDrawOptions
{
  public Point3D MinPoint;
  public Point3D MidPoint;
  public Point3D MaxPoint;
  public double Width;
  public double Height;
  public double Depth;
  public static byte f000666;
  public Color BottomColor;
  public Color MiddleColor;
  public Color TopColor;
  public displayType DisplayType;

  public ViewportDrawOptions(RoboticSurfacePoint data)
  {
    ((CreateModelProperties) this).pntBase = new Point3D();
    ((CreateModelProperties) this).pntPre = new Point3D();
    ((CreateModelProperties) this).pntNext = new Point3D();
    ((CreateModelProperties) this).pntNormal = new Pnt6D();
    ((CreateModelProperties) this).pntTangent = new Pnt6D();
    ((CreateModelProperties) this).entNormal = (Entity) null;
    ((CreateModelProperties) this).entTangent = (Entity) null;
    ((CreateModelProperties) this).entContour = (Entity) null;
    ((CreateModelProperties) this).entLeadIn = (Entity) null;
    ((CreateModelProperties) this).entLeadOut = (Entity) null;
    ((CreateModelProperties) this).entSafeIn = (Entity) null;
    ((CreateModelProperties) this).entSafeOut = (Entity) null;
    ((EyeCreateProps) this).vecNormal = new Vector3D();
    ((EyeCreateProps) this).Enable = true;
    ((EyeCreateProps) this).isLast = false;
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
    if (((CreateModelProperties) data).pntBase != (Point3D) null)
      ((CreateModelProperties) this).pntBase = new Point3D(((CreateModelProperties) data).pntBase.X, ((CreateModelProperties) data).pntBase.Y, ((CreateModelProperties) data).pntBase.Z);
    if (((CreateModelProperties) data).pntNext != (Point3D) null)
      ((CreateModelProperties) this).pntNext = new Point3D(((CreateModelProperties) data).pntNext.X, ((CreateModelProperties) data).pntNext.Y, ((CreateModelProperties) data).pntNext.Z);
    if (((CreateModelProperties) data).pntPre != (Point3D) null)
      ((CreateModelProperties) this).pntPre = new Point3D(((CreateModelProperties) data).pntPre.X, ((CreateModelProperties) data).pntPre.Y, ((CreateModelProperties) data).pntPre.Z);
    ((EyeCreateProps) this).vecNormal = (Vector3D) ((EyeCreateProps) data).vecNormal.Clone();
    if (((CreateModelProperties) data).entContour != null)
    {
      ((CreateModelProperties) this).entContour = (Entity) ((CreateModelProperties) data).entContour.Clone();
      if (((CreateModelProperties) data).entContour.EntityData != null)
      {
        if (((CreateModelProperties) data).entContour.EntityData.GetType() == typeof (CustomData))
          ((CreateModelProperties) this).entContour.EntityData = (object) new ClipperOffset((CustomData) ((CreateModelProperties) data).entContour.EntityData);
        else
          ((CreateModelProperties) this).entContour.EntityData = (object) new ClipperOffset();
      }
      else
        ((CreateModelProperties) this).entContour.EntityData = (object) new ClipperOffset();
    }
    if (((CreateModelProperties) data).entNormal != null)
    {
      ((CreateModelProperties) this).entNormal = (Entity) ((CreateModelProperties) data).entNormal.Clone();
      if (((CreateModelProperties) data).entNormal.EntityData != null)
      {
        if (((CreateModelProperties) data).entNormal.EntityData.GetType() == typeof (CustomData))
          ((CreateModelProperties) this).entNormal.EntityData = (object) new ClipperOffset((CustomData) ((CreateModelProperties) data).entNormal.EntityData);
        else
          ((CreateModelProperties) this).entNormal.EntityData = (object) new ClipperOffset();
      }
      else
        ((CreateModelProperties) this).entNormal.EntityData = (object) new ClipperOffset();
    }
    if (((CreateModelProperties) data).entTangent != null)
    {
      ((CreateModelProperties) this).entTangent = (Entity) ((CreateModelProperties) data).entTangent.Clone();
      if (((CreateModelProperties) data).entTangent.EntityData != null)
      {
        if (((CreateModelProperties) data).entTangent.EntityData.GetType() == typeof (CustomData))
          ((CreateModelProperties) this).entTangent.EntityData = (object) new ClipperOffset((CustomData) ((CreateModelProperties) data).entTangent.EntityData);
        else
          ((CreateModelProperties) this).entTangent.EntityData = (object) new ClipperOffset();
      }
      else
        ((CreateModelProperties) this).entTangent.EntityData = (object) new ClipperOffset();
    }
    if (((CreateModelProperties) data).entLeadIn != null)
      ((CreateModelProperties) this).entLeadIn = buVector5.CopyEntities(((CreateModelProperties) data).entLeadIn);
    if (((CreateModelProperties) data).entLeadOut != null)
      ((CreateModelProperties) this).entLeadOut = buVector5.CopyEntities(((CreateModelProperties) data).entLeadOut);
    if (((CreateModelProperties) data).entSafeIn != null)
      ((CreateModelProperties) this).entSafeIn = buVector5.CopyEntities(((CreateModelProperties) data).entSafeIn);
    if (((CreateModelProperties) data).entSafeOut == null)
      return;
    ((CreateModelProperties) this).entSafeOut = buVector5.CopyEntities(((CreateModelProperties) data).entSafeOut);
  }

  public static void Copy(RoboticSurfacePoint Source, ref RoboticSurfacePoint Target)
  {
    Target = (RoboticSurfacePoint) new ViewportDrawOptions(Source);
  }

  public override string ToString()
  {
    return "Normal : " + ((CreateModelProperties) this).pntNormal.ToString();
  }
}
