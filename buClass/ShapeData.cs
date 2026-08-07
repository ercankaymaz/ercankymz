// Decompiled with JetBrains decompiler
// Type: buClass.ShapeData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ShapeData : buSerilization
{
  public ShapeData()
  {
  }

  public ShapeData(ShapeData data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
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

  public static void Copy(ShapeData Base, ref ShapeData Copied)
  {
    if (Base.GetType() == typeof (PointData))
      Copied = (ShapeData) new PointData((PointData) Base);
    if (Base.GetType() == typeof (LineData))
      Copied = (ShapeData) new LineData((LineData) Base);
    if (Base.GetType() == typeof (RectangleCenterData))
      Copied = (ShapeData) new RectangleCenterData((RectangleCenterData) Base);
    if (Base.GetType() == typeof (RectangleCornerData))
      Copied = (ShapeData) new RectangleCornerData((RectangleCornerData) Base);
    if (Base.GetType() == typeof (RectangleCornerChamferData))
      Copied = (ShapeData) new RectangleCornerChamferData((RectangleCornerChamferData) Base);
    if (Base.GetType() == typeof (RectangleCornerFilletData))
      Copied = (ShapeData) new RectangleCornerFilletData((RectangleCornerFilletData) Base);
    if (Base.GetType() == typeof (CircleCenterData))
      Copied = (ShapeData) new CircleCenterData((CircleCenterData) Base);
    if (Base.GetType() == typeof (SlotData))
      Copied = (ShapeData) new SlotData((SlotData) Base);
    if (Base.GetType() == typeof (EllipseCenterData))
      Copied = (ShapeData) new EllipseCenterData((EllipseCenterData) Base);
    if (Base.GetType() == typeof (PolygonCenterData))
      Copied = (ShapeData) new PolygonCenterData((PolygonCenterData) Base);
    if (Base.GetType() == typeof (BarrelData))
      Copied = (ShapeData) new BarrelData((BarrelData) Base);
    if (Base.GetType() == typeof (TextVectorData))
      Copied = (ShapeData) new TextVectorData((TextVectorData) Base);
    if (!(Base.GetType() == typeof (TriangleTwinData)))
      return;
    Copied = (ShapeData) new TriangleTwinData((TriangleTwinData) Base);
  }

  public static ShapeData Decode(List<string> AL, string Char, SerilizationMode Mode)
  {
    ShapeData shapeData = (ShapeData) null;
    if (AL.Count > 0)
    {
      string str = AL[0];
      if (str.Length > 0)
      {
        if (str.IndexOf("PointData") >= 0)
        {
          shapeData = (ShapeData) new PointData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("RectangleCornerData") >= 0)
        {
          shapeData = (ShapeData) new RectangleCornerData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("RectangleCenterData") >= 0)
        {
          shapeData = (ShapeData) new RectangleCenterData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("RectangleCornerChamferData") >= 0)
        {
          shapeData = (ShapeData) new RectangleCornerChamferData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("RectangleCornerFilletData") >= 0)
        {
          shapeData = (ShapeData) new RectangleCornerFilletData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("LineData") >= 0)
        {
          shapeData = (ShapeData) new LineData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("CircleCenterData") >= 0)
        {
          shapeData = (ShapeData) new CircleCenterData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("EllipseCenterData") >= 0)
        {
          shapeData = (ShapeData) new EllipseCenterData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("SlotData") >= 0)
        {
          shapeData = (ShapeData) new SlotData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("PolygonCenterData") >= 0)
        {
          shapeData = (ShapeData) new PolygonCenterData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("TriangleTwinData") >= 0)
        {
          shapeData = (ShapeData) new TriangleTwinData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("BarrelData") >= 0)
        {
          shapeData = (ShapeData) new BarrelData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
        if (str.IndexOf("TextVectorData") >= 0)
        {
          shapeData = (ShapeData) new TextVectorData();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) shapeData);
        }
      }
    }
    return shapeData;
  }

  public ArrayList ToDefAll(int Space)
  {
    string str = new string(' ', Space);
    ArrayList defAll = new ArrayList();
    buSerilization.ExceptionalVariables.Clear();
    defAll.Add((object) (str + "<ShapeData>"));
    if (this.GetType() == typeof (LineData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (RectangleCornerData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (RectangleCornerFilletData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (RectangleCornerChamferData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (CircleCenterData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (EllipseCenterData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (PointData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (RectangleCenterData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (SlotData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (PolygonCenterData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (BarrelData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (TriangleTwinData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (TextVectorData))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    defAll.Add((object) (str + "</ShapeData>"));
    return defAll;
  }
}
