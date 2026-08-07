// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SewingInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SewingInfo : buSerilization5
{
  public double CurveLength;
  public bool ConvertAllToPolyline;
  public bool PointDelete;
  public bool PolylinDelete;
  public bool LineDelete;
  public bool CircleDelete;
  public bool ArcDelete;
  public bool EllipseDelete;
  public bool EllipseArcDelete;
  public bool CompositeCurveDelete;

  public SewingInfo(LayerOverride data)
  {
    ((DeleteTypeEventFormVars) this).LayerOriginalName = "";
    ((DeleteTypeEventFormVars) this).LayerNewName = "";
    ((DeleteTypeEventFormVars) this).LayerExtraName = "";
    ((DeleteTypeEventFormVars) this).LayerNewColor = Color.Blue;
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

  public abstract void m0001BF();

  public SewingInfo()
  {
    ((DeleteTypeEventFormVars) this).Alignment = ContentAlignment.BottomLeft;
    ((DeleteTypeEventFormVars) this).CatchPoint = new Point3D();
    ((DeleteTypeEventFormVars) this).ShowZ = true;
    ((DeleteTypeEventFormVars) this).ShowAligment = true;
    ((DeleteTypeEventFormVars) this).isCoordinateMode = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public SewingInfo(CopyEventFormVars data)
  {
    ((DeleteTypeEventFormVars) this).Alignment = ContentAlignment.BottomLeft;
    ((DeleteTypeEventFormVars) this).CatchPoint = new Point3D();
    ((DeleteTypeEventFormVars) this).ShowZ = true;
    ((DeleteTypeEventFormVars) this).ShowAligment = true;
    ((DeleteTypeEventFormVars) this).isCoordinateMode = true;
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

  public SewingInfo()
  {
    ((MirrorEventFormVars) this).Alignment = ContentAlignment.BottomLeft;
    ((MirrorEventFormVars) this).CatchPoint = new Point3D();
    ((MirrorEventFormVars) this).ShowZ = true;
    ((MirrorEventFormVars) this).ShowAligment = true;
    ((EntityShapeInfo) this).isCoordinateMode = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
