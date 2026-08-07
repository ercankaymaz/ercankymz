// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Rectangle2D
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class Rectangle2D : buSerilization5
{
  public string ReletedEntityName;
  public double Distance;
  public double Angle;

  public abstract void m0001E1();

  public Rectangle2D()
  {
    ((DimensionInfo) this).Codes = new List<SewingCode>();
    ((DimensionInfo) this).Point = new Point3D();
    ((DimensionInfo) this).DeltaX = 0.0;
    ((DimensionInfo) this).DeltaY = 0.0;
    ((DimensionInfo) this).FootHeight = 0.0;
    ((DimensionInfo) this).Speed = 0.0;
    ((DimensionInfo) this).Punterez = (SewingPunteriz) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public Rectangle2D(Point3D Pnt)
  {
    ((DimensionInfo) this).Codes = new List<SewingCode>();
    ((DimensionInfo) this).Point = new Point3D();
    ((DimensionInfo) this).DeltaX = 0.0;
    ((DimensionInfo) this).DeltaY = 0.0;
    ((DimensionInfo) this).FootHeight = 0.0;
    ((DimensionInfo) this).Speed = 0.0;
    ((DimensionInfo) this).Punterez = (SewingPunteriz) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((DimensionInfo) this).Point = new Point3D(Pnt.X, Pnt.Y, Pnt.Z);
  }

  public Rectangle2D(SewingVertex data)
  {
    ((DimensionInfo) this).Codes = new List<SewingCode>();
    ((DimensionInfo) this).Point = new Point3D();
    ((DimensionInfo) this).DeltaX = 0.0;
    ((DimensionInfo) this).DeltaY = 0.0;
    ((DimensionInfo) this).FootHeight = 0.0;
    ((DimensionInfo) this).Speed = 0.0;
    ((DimensionInfo) this).Punterez = (SewingPunteriz) null;
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
    if (((DimensionInfo) this).Punterez != null)
      ((DimensionInfo) this).Punterez = (SewingPunteriz) new Line2D(((DimensionInfo) data).Punterez);
    ((DimensionInfo) this).Codes.Clear();
    ((DimensionInfo) this).Codes = new List<SewingCode>();
    for (int index = 0; index <= ((DimensionInfo) data).Codes.Count - 1; ++index)
      ((DimensionInfo) this).Codes.Add((SewingCode) new Rectangle2D(((DimensionInfo) data).Codes[index]));
    ((DimensionInfo) this).Point = new Point3D(((DimensionInfo) data).Point.X, ((DimensionInfo) data).Point.Y, ((DimensionInfo) data).Point.Z);
  }

  public static void Copy(SewingVertex Data, ref SewingVertex Copied)
  {
    Copied = (SewingVertex) new Rectangle2D(Data);
  }

  public static void Copy(List<SewingVertex> Data, ref List<SewingVertex> Copied)
  {
    Copied.Clear();
    Copied = new List<SewingVertex>();
    for (int index = 0; index <= Data.Count - 1; ++index)
      Copied.Add((SewingVertex) new Rectangle2D(Data[index]));
  }

  public override string ToString()
  {
    return $"X: {((DimensionInfo) this).Point.X.ToString("f3")} , Y: {((DimensionInfo) this).Point.Y.ToString("f3")} - dX: {((DimensionInfo) this).DeltaX.ToString("f2")} - dY: {((DimensionInfo) this).DeltaY.ToString("f2")}- Code: {((DimensionInfo) this).Codes.Count.ToString()}";
  }

  public abstract void m0001E8();

  public Rectangle2D()
  {
    ((DimensionInfo) this).Explanation = "";
    ((DimensionInfo) this).Codes = SewingCodes.None;
    ((DimensionInfo) this).Data1 = 0.0;
    ((EntityInfo) this).Data2 = 0.0;
    ((EntityInfo) this).Data3 = 0.0;
    ((EntityInfo) this).Data4 = 0.0;
    ((EntityInfo) this).Data5 = 0.0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public Rectangle2D(SewingCodes codes, string explanation)
  {
    ((DimensionInfo) this).Explanation = "";
    ((DimensionInfo) this).Codes = SewingCodes.None;
    ((DimensionInfo) this).Data1 = 0.0;
    ((EntityInfo) this).Data2 = 0.0;
    ((EntityInfo) this).Data3 = 0.0;
    ((EntityInfo) this).Data4 = 0.0;
    ((EntityInfo) this).Data5 = 0.0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((DimensionInfo) this).Codes = codes;
    ((DimensionInfo) this).Explanation = explanation;
  }

  public Rectangle2D(SewingCode data)
  {
    ((DimensionInfo) this).Explanation = "";
    ((DimensionInfo) this).Codes = SewingCodes.None;
    ((DimensionInfo) this).Data1 = 0.0;
    ((EntityInfo) this).Data2 = 0.0;
    ((EntityInfo) this).Data3 = 0.0;
    ((EntityInfo) this).Data4 = 0.0;
    ((EntityInfo) this).Data5 = 0.0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
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
    return $"{((DimensionInfo) this).Codes.ToString()} ; Data1: {((DimensionInfo) this).Data1.ToString("f3")} ; Data2: {((EntityInfo) this).Data2.ToString("f3")} ; Data3: {((EntityInfo) this).Data3.ToString("f3")} ; Data4: {((EntityInfo) this).Data4.ToString("f3")} ; Data5: {((EntityInfo) this).Data5.ToString("f3")}";
  }
}
