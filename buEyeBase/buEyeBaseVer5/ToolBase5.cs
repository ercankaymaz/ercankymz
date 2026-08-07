// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ToolBase5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ToolBase5 : buSerilization5
{
  public bool OtherEntitiesEnable;
  public bool AllAsSingle;
  public bool G1EntitiesFromOriginal;
  public buEntity RefEntity;
  public double PointTangentAngle;
  public static List<string> Captions;
  public double MinRadius;
  public double MaxRadius;
  public double Feed;
  public static byte f000397;
  public double MinLength;
  public double MaxLength;
  public double Feed;

  public abstract void m00016E();

  public ToolBase5()
  {
    ((ToolGeometry5) this).StockName = "Cam";
    ((ToolGeometry5) this).isError = false;
    ((ToolGeometry5) this).colorStock = (ColorType) new CircularSpeedReduction(Color.BurlyWood, 150);
    ((ToolGeometry5) this).MinPoint = new Point3D();
    ((ToolGeometry5) this).MaxPoint = new Point3D();
    ((ToolGeometry5) this).SizeStock = new SizeObject();
    ((ToolGeometry5) this).StockEntities = new List<buEntity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ToolBase5(CamStock data)
  {
    ((ToolGeometry5) this).StockName = "Cam";
    ((ToolGeometry5) this).isError = false;
    ((ToolGeometry5) this).colorStock = (ColorType) new CircularSpeedReduction(Color.BurlyWood, 150);
    ((ToolGeometry5) this).MinPoint = new Point3D();
    ((ToolGeometry5) this).MaxPoint = new Point3D();
    ((ToolGeometry5) this).SizeStock = new SizeObject();
    ((ToolGeometry5) this).StockEntities = new List<buEntity>();
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
    ((ToolGeometry5) this).colorStock = (ColorType) new CircularSpeedReduction(((ToolGeometry5) data).colorStock);
    buRadialDim.Copy(((ToolGeometry5) data).StockEntities, ref ((ToolGeometry5) this).StockEntities);
  }

  public static void Decode(List<string> AL, ref CamStock Item)
  {
  }

  public static ArrayList ToDef(CamStock refItem, int Space) => new ArrayList();

  public override string ToString() => "Size: " + ((ToolGeometry5) this).SizeStock.ToString();

  public abstract void m000174();

  public ToolBase5()
  {
    ((ToolGeometry5) this).Radius = 10.0;
    ((ToolGeometry5) this).RegenRatio = 0.01;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ToolBase5(RegenResolutionData data)
  {
    ((ToolGeometry5) this).Radius = 10.0;
    ((ToolGeometry5) this).RegenRatio = 0.01;
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
    return $"Radius: {((ToolGeometry5) this).Radius.ToString()} , RegenRatio: {((ToolGeometry5) this).RegenRatio.ToString()}";
  }

  public abstract void m000178();

  public ToolBase5()
  {
    ((ToolGeometry5) this).Points = new List<Point3D>();
    ((ToolGeometry5) this).Settings = (object) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public override string ToString()
  {
    string str = ((ToolGeometry5) this).Points.Count.ToString();
    if (((ToolGeometry5) this).Points.Count > 0)
      str = $"{str} - S: {((ToolGeometry5) this).Points[0].ToString()} - E: {((ToolGeometry5) this).Points[((ToolGeometry5) this).Points.Count - 1].ToString()}";
    return str;
  }

  public abstract void m00017B();

  public ToolBase5()
  {
    ((ToolGeometry5) this).Points = new List<Pnt6D>();
    ((ToolGeometry5) this).Settings = (object) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public override string ToString()
  {
    string str = ((ToolGeometry5) this).Points.Count.ToString();
    if (((ToolGeometry5) this).Points.Count > 0)
      str = $"{str} - S: {((ToolGeometry5) this).Points[0].ToString()} - E: {((ToolGeometry5) this).Points[((ToolGeometry5) this).Points.Count - 1].ToString()}";
    return str;
  }

  public abstract void m00017E();

  public ToolBase5()
  {
    ((ToolGeometry5) this).Tools = new List<ToolBase5>();
    ((ToolGeometry5) this).GroupName = "Tools";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ToolBase5(ToolGroup5 Data)
  {
    ((ToolGeometry5) this).Tools = new List<ToolBase5>();
    ((ToolGeometry5) this).GroupName = "Tools";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) Data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
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
    ((ToolGeometry5) this).Tools.Clear();
    for (int index = 0; index <= ((ToolGeometry5) Data).Tools.Count - 1; ++index)
      ((ToolGeometry5) this).Tools.Add((ToolBase5) new ToolGeometry5(((ToolGeometry5) Data).Tools[index]));
  }
}
