// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TheoBendItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class TheoBendItem : TheoItem
{
  public double YPos = 0.0;
  public double ModeY1_ = 0.0;
  public double ModeY2_ = 0.0;
  public double Ratio = 0.0;
  public double Angle = 0.0;
  public double Radius = 0.0;
  public double BendAngle = 0.0;
  public double Tool = 0.0;
  public bool NoToolFound = false;
  public List<TheoBendOriginalPosition> OriginalFromCode = new List<TheoBendOriginalPosition>();
  public Pnt3D BendPosition = new Pnt3D();
  public Pnt3D GraphPosition = new Pnt3D();

  public TheoBendItem()
  {
  }

  public TheoBendItem(TheoBendItem data)
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
    this.OriginalFromCode.Clear();
    for (int index = 0; index <= data.OriginalFromCode.Count - 1; ++index)
      this.OriginalFromCode.Add(new TheoBendOriginalPosition(data.OriginalFromCode[index]));
  }

  public TheoBendItem(double angle, double radius, double bendangle)
  {
    this.Angle = angle;
    this.Radius = radius;
    this.BendAngle = bendangle;
  }

  public override string ToString()
  {
    return $"Bend - Angle: {this.BendAngle.ToString()} - X: {this.XPos.ToString()} - Rad: {this.Radius.ToString()} - No Tool: {this.NoToolFound.ToString()}";
  }
}
