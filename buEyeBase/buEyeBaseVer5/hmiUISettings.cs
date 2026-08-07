// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.hmiUISettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class hmiUISettings : buSerilization5
{
  public static byte f000896;
  public static double Len;
  public static double Ang;
  public static double StartAng;
  public static double EndAng;
  public static double dX;
  public static double dY;
  public static double dZ;

  public hmiUISettings(CurveToSurfaceSettingsType data)
  {
    ((dynamicInfo) this).SurfaceOffset = 0.0;
    ((dynamicInfo) this).MinDistance = 0.0;
    ((dynamicInfo) this).MaxDistance = 0.0;
    ((HighLights) this).MaxZ = 0.0;
    ((HighLights) this).MinZ = 0.0;
    ((HighLights) this).InsideOffset = 0.0;
    ((WriteDxfDwgPropeties) this).OutsideOffset = 0.0;
    ((WriteDxfDwgPropeties) this).SilhouetteToPartEnd = false;
    ((WriteDxfDwgPropeties) this).isVertical = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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

  public override string ToString()
  {
    return "SurfaceOffset: " + ((dynamicInfo) this).SurfaceOffset.ToString();
  }

  public abstract void m000337();

  public hmiUISettings()
  {
    ((WriteDxfDwgPropeties) this).refPlane = (Plane) null;
    ((WriteDxfDwgPropeties) this).entityPlane = (Entity) null;
    ((WriteDxfDwgPropeties) this).entityXVector = (Entity) null;
    ((WriteDxfDwgPropeties) this).entityYVector = (Entity) null;
    ((WriteDxfDwgPropeties) this).entityZVector = (Entity) null;
    ((ColorType) this).entityBall = (Entity) null;
    ((ColorType) this).pntPlane = new Point3D();
    ((ColorDrawType) this).Explanation = "";
    ((ColorDrawType) this).Length = 0.0;
    ((ColorDrawType) this).Height = 0.0;
    ((GCodeConverter) this).Thickness = 1.0;
    ((GCodeConverter) this).Angle = 0.0;
    ((GCodeConverter) this).AngleOffset = 0.0;
    ((GCodeConverter) this).Index = -1;
    ((GCodeConverter) this).PlaneType = ProfilePlaneDef.Top0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public hmiUISettings(SelectedPlaneInfo data)
  {
    ((WriteDxfDwgPropeties) this).refPlane = (Plane) null;
    ((WriteDxfDwgPropeties) this).entityPlane = (Entity) null;
    ((WriteDxfDwgPropeties) this).entityXVector = (Entity) null;
    ((WriteDxfDwgPropeties) this).entityYVector = (Entity) null;
    ((WriteDxfDwgPropeties) this).entityZVector = (Entity) null;
    ((ColorType) this).entityBall = (Entity) null;
    ((ColorType) this).pntPlane = new Point3D();
    ((ColorDrawType) this).Explanation = "";
    ((ColorDrawType) this).Length = 0.0;
    ((ColorDrawType) this).Height = 0.0;
    ((GCodeConverter) this).Thickness = 1.0;
    ((GCodeConverter) this).Angle = 0.0;
    ((GCodeConverter) this).AngleOffset = 0.0;
    ((GCodeConverter) this).Index = -1;
    ((GCodeConverter) this).PlaneType = ProfilePlaneDef.Top0;
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
    if (((WriteDxfDwgPropeties) this).refPlane != (Plane) null)
      ((WriteDxfDwgPropeties) this).refPlane = (Plane) ((WriteDxfDwgPropeties) data).refPlane.Clone();
    if (((WriteDxfDwgPropeties) data).entityPlane != null)
      ((WriteDxfDwgPropeties) this).entityPlane = (Entity) ((WriteDxfDwgPropeties) data).entityPlane.Clone();
    if (((WriteDxfDwgPropeties) data).entityXVector != null)
      ((WriteDxfDwgPropeties) this).entityXVector = (Entity) ((WriteDxfDwgPropeties) data).entityXVector.Clone();
    if (((WriteDxfDwgPropeties) data).entityYVector != null)
      ((WriteDxfDwgPropeties) this).entityYVector = (Entity) ((WriteDxfDwgPropeties) data).entityYVector.Clone();
    if (((WriteDxfDwgPropeties) data).entityZVector != null)
      ((WriteDxfDwgPropeties) this).entityZVector = (Entity) ((WriteDxfDwgPropeties) data).entityZVector.Clone();
    if (((ColorType) data).entityBall == null)
      return;
    ((ColorType) this).entityBall = (Entity) ((ColorType) data).entityBall.Clone();
  }
}
