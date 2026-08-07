// Decompiled with JetBrains decompiler
// Type: buClass.DirectionArrow
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class DirectionArrow : buSerilization
{
  public bool Visible = true;
  public Color Color = Color.Gold;
  public double Thickness = 1.0;
  public double Angle = 0.0;
  public double PointAngle = 15.0;
  public double Length = 10.0;
  public bool Reverse = false;
  public Pnt3D Point = new Pnt3D();
  public Pnt3D PrePoint = new Pnt3D();
  public string BelongEntityName = "";
  public int BelongEntityIndex = -1;
  public static List<string> Captions = new List<string>();

  public DirectionArrow()
  {
  }

  public DirectionArrow(DirectionArrow arrow)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) arrow, ref CopiedClass);
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

  public override string ToString()
  {
    return $"{this.Visible.ToString()} , {this.Point.ToString()} , Ang : {this.Angle.ToString()} , Reverse: {this.Reverse.ToString()}";
  }
}
