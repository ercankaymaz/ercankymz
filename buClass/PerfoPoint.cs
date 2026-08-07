// Decompiled with JetBrains decompiler
// Type: buClass.PerfoPoint
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class PerfoPoint : buSerilization
{
  public double X = 0.0;
  public double Width = 0.0;
  public double Height = 0.0;

  public PerfoPoint()
  {
  }

  public PerfoPoint(double x, double width, double height)
  {
    this.X = x;
    this.Width = width;
    this.Height = height;
  }

  public PerfoPoint(PerfoPoint lengths)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) lengths, ref CopiedClass);
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
    return $"X: {this.X.ToString()} - Width: {this.Width.ToString()} - Height: {this.Height.ToString()}";
  }
}
