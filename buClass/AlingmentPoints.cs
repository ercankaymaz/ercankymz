// Decompiled with JetBrains decompiler
// Type: buClass.AlingmentPoints
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class AlingmentPoints : buSerilization
{
  public Pnt3D pntBottomLeft = new Pnt3D();
  public Pnt3D pntBottomCenter = new Pnt3D();
  public Pnt3D pntBottomRight = new Pnt3D();
  public Pnt3D pntMiddleLeft = new Pnt3D();
  public Pnt3D pntMiddleCenter = new Pnt3D();
  public Pnt3D pntMiddleRight = new Pnt3D();
  public Pnt3D pntTopLeft = new Pnt3D();
  public Pnt3D pntTopCenter = new Pnt3D();
  public Pnt3D pntTopRight = new Pnt3D();
  public List<Pnt3D> MovePoints = new List<Pnt3D>();
  public List<Pnt3D> TipPoints = new List<Pnt3D>();
  public List<Pnt3D> BoxSizePoints = new List<Pnt3D>();
  public List<Pnt3D> RotatePoints = new List<Pnt3D>();

  public AlingmentPoints()
  {
  }

  public AlingmentPoints(AlingmentPoints data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    this.MovePoints.Clear();
    this.MovePoints = new List<Pnt3D>();
    for (int index = 0; index <= data.MovePoints.Count - 1; ++index)
      this.MovePoints.Add(new Pnt3D(data.MovePoints[index]));
    this.TipPoints.Clear();
    this.TipPoints = new List<Pnt3D>();
    for (int index = 0; index <= data.TipPoints.Count - 1; ++index)
      this.TipPoints.Add(new Pnt3D(data.TipPoints[index]));
    this.BoxSizePoints.Clear();
    this.BoxSizePoints = new List<Pnt3D>();
    for (int index = 0; index <= data.BoxSizePoints.Count - 1; ++index)
      this.BoxSizePoints.Add(new Pnt3D(data.BoxSizePoints[index]));
    this.RotatePoints.Clear();
    this.RotatePoints = new List<Pnt3D>();
    for (int index = 0; index <= data.RotatePoints.Count - 1; ++index)
      this.RotatePoints.Add(new Pnt3D(data.RotatePoints[index]));
  }
}
