// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.GCodeGraphPoint5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class GCodeGraphPoint5 : buSerilization5
{
  public double Length;
  public double Angle;
  public int Side;
  public Pnt3D Point;

  public GCodeGraphPoint5(ShapeSizeInfo data)
  {
    ((ShapeRuntimeData) this).MinBox = new Point3D();
    ((ShapeRuntimeData) this).MaxBox = new Point3D();
    ((ShapeRuntimeData) this).CenterPoint = new Point3D();
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
    ((ShapeRuntimeData) this).MaxBox = new Point3D(((ShapeRuntimeData) data).MaxBox.X, ((ShapeRuntimeData) data).MaxBox.Y, ((ShapeRuntimeData) data).MaxBox.Z);
    ((ShapeRuntimeData) this).MinBox = new Point3D(((ShapeRuntimeData) data).MinBox.X, ((ShapeRuntimeData) data).MinBox.Y, ((ShapeRuntimeData) data).MinBox.Z);
    ((ShapeRuntimeData) this).CenterPoint = new Point3D(((ShapeRuntimeData) data).CenterPoint.X, ((ShapeRuntimeData) data).CenterPoint.Y, ((ShapeRuntimeData) data).CenterPoint.Z);
  }

  public override string ToString()
  {
    return $"Min: {((ShapeRuntimeData) this).MinBox.ToString()} , MAx: {((ShapeRuntimeData) this).MaxBox.ToString()}";
  }

  public abstract void m000312();

  public GCodeGraphPoint5()
  {
    ((ShapeRuntimeData) this).LeadInLength = 10.0;
    ((ShapeRuntimeData) this).LeadOutLength = 10.0;
    ((ShapeRuntimeData) this).LeadInType = LeadInOutType.Line;
    ((ShapeRuntimeData) this).LeadOuType = LeadInOutType.Line;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public GCodeGraphPoint5(ShapeLeadInOut data)
  {
    ((ShapeRuntimeData) this).LeadInLength = 10.0;
    ((ShapeRuntimeData) this).LeadOutLength = 10.0;
    ((ShapeRuntimeData) this).LeadInType = LeadInOutType.Line;
    ((ShapeRuntimeData) this).LeadOuType = LeadInOutType.Line;
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
}
