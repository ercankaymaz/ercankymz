// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.hmiUIOptions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class hmiUIOptions : buSerilization5
{
  public bool SelectedOnly;
  public bool Convert2PointLinearPathToLine;
  public static byte f0008B6;
  public Color Color;
  public int Transperancy;
  public static byte f0008B9;

  public hmiUIOptions(SelectionAlingmentPoints data)
  {
    ((GCodePoint5) this).MovePoints = new List<Point3D>();
    ((GCodePoint5) this).TipPoints = new List<Point3D>();
    ((GCodePoint5) this).BoxSizePoints = new List<Point3D>();
    ((GCodePoint5) this).RotatePoints = new List<Point3D>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
    ((GCodePoint5) this).MovePoints.Clear();
    ((GCodePoint5) this).MovePoints = new List<Point3D>();
    buVector5.Copy(((GCodePoint5) data).MovePoints, ref ((GCodePoint5) this).MovePoints);
    ((GCodePoint5) this).TipPoints.Clear();
    ((GCodePoint5) this).TipPoints = new List<Point3D>();
    buVector5.Copy(((GCodePoint5) data).TipPoints, ref ((GCodePoint5) this).TipPoints);
    ((GCodePoint5) this).BoxSizePoints.Clear();
    ((GCodePoint5) this).BoxSizePoints = new List<Point3D>();
    buVector5.Copy(((GCodePoint5) data).BoxSizePoints, ref ((GCodePoint5) this).BoxSizePoints);
    ((GCodePoint5) this).RotatePoints.Clear();
    ((GCodePoint5) this).RotatePoints = new List<Point3D>();
    buVector5.Copy(((GCodePoint5) data).RotatePoints, ref ((GCodePoint5) this).RotatePoints);
  }

  public hmiUIOptions()
  {
    ((GCodePoint5) this).Object = (object) null;
    ((GCodePoint5) this).Explanation = "";
    ((GCodeChars5) this).Type = selectionFilterType.Face;
    ((GCodeChars5) this).PointOverEntity = new Point3D();
    ((GCodeChars5) this).BoxMin = new Point3D();
    ((GCodeChars5) this).BoxMax = new Point3D();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public hmiUIOptions(object obj, selectionFilterType type, Point3D pnt)
  {
    ((GCodePoint5) this).Object = (object) null;
    ((GCodePoint5) this).Explanation = "";
    ((GCodeChars5) this).Type = selectionFilterType.Face;
    ((GCodeChars5) this).PointOverEntity = new Point3D();
    ((GCodeChars5) this).BoxMin = new Point3D();
    ((GCodeChars5) this).BoxMax = new Point3D();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((GCodePoint5) this).Object = obj;
    ((GCodeChars5) this).Type = type;
    ((GCodeChars5) this).PointOverEntity = new Point3D(pnt.X, pnt.Y, pnt.Z);
  }

  public abstract void m000346();

  public hmiUIOptions()
  {
    ((GCodeChars5) this).Points = new List<Point3D>();
    ((GCodeChars5) this).Length = 0.0;
    ((GCodeChars5) this).Text = "";
    ((GCodeChars5) this).PntText = new Point3D();
    ((GCodeChars5) this).Color = Color.Red;
    ((GCodeChars5) this).Size = 2f;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public abstract void m000348();
}
