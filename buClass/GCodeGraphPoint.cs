// Decompiled with JetBrains decompiler
// Type: buClass.GCodeGraphPoint
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class GCodeGraphPoint : buSerilization
{
  public Pnt9D Positions = new Pnt9D();
  public double Radius = 0.0;
  public IJK IJKValues = new IJK();
  public int CodeType = 0;

  public GCodeGraphPoint()
  {
  }

  public GCodeGraphPoint(GCodeGraphPoint data)
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
    this.IJKValues = new IJK(data.IJKValues);
  }

  public static GCodeGraphPoint Copy(GCodeGraphPoint P)
  {
    return new GCodeGraphPoint()
    {
      Positions = new Pnt9D(P.Positions),
      CodeType = P.CodeType,
      IJKValues = new IJK(P.IJKValues),
      Radius = P.Radius
    };
  }

  public static void Copy(List<GCodeGraphPoint> pts, ref List<GCodeGraphPoint> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new GCodeGraphPoint(GCodeGraphPoint.Copy(pts[index])));
  }

  public override string ToString()
  {
    return $"X{this.Positions.X.ToString("f3")} , Y{this.Positions.Y.ToString("f3")} , Z{this.Positions.Z.ToString("f3")} , Type{this.CodeType.ToString()} , R{this.Radius.ToString("f3")}";
  }
}
