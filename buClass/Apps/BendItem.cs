// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendItem : buSerilization
{
  public double ExtractXPosition = 0.0;
  public Pnt3D EntityPosition = new Pnt3D();
  public int Index;
  public int EntIndex;
  public double Offset;
  public double Angle;
  public double Radius;
  public bool Edge = false;
  public bool Enable = true;
  public bool IsArc = false;

  public BendItem()
  {
  }

  public BendItem(BendItem data)
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

  public override string ToString()
  {
    return $"X : {this.ExtractXPosition.ToString("f2")} - Angle :{this.Angle.ToString("f2")} , Edge: {this.Edge.ToString()} , IsArc: {this.IsArc.ToString()}";
  }
}
