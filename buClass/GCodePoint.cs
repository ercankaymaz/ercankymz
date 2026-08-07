// Decompiled with JetBrains decompiler
// Type: buClass.GCodePoint
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class GCodePoint : buSerilization
{
  public Pnt9D Offset = new Pnt9D();
  public Pnt9D Positions = new Pnt9D();
  public int CodeType = 0;
  public bool isMCode = false;
  public bool isGCode = false;
  public bool isTCode = false;
  public bool isG0Move = false;
  public ToolBase Tool = new ToolBase();
  public IJK IJKValue = new IJK();
  public double SpindleSpeed = 0.0;
  public double Feed = 0.0;
  public double R = 0.0;
  public double MValue = 0.0;
  public double GValue = 0.0;
  public double TValue = 0.0;
  public string CodeString = "";
  public string Aux = "";
  public geoEntity Entity = new geoEntity();

  public GCodePoint()
  {
  }

  public GCodePoint(GCodePoint data)
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
    this.Tool = new ToolBase(data.Tool);
    this.Entity = new geoEntity(data.Entity);
    this.IJKValue = new IJK(data.IJKValue);
  }

  public override string ToString()
  {
    if (this.isMCode)
      return $"M{this.CodeType.ToString()} X{this.Positions.X.ToString("f2")}";
    if (this.isTCode)
      return "T" + this.CodeType.ToString();
    if (!this.isGCode)
      return this.CodeString;
    return $"G{this.CodeType.ToString()} X{this.Positions.X.ToString("f2")} Y{this.Positions.Y.ToString("f2")} Z{this.Positions.Z.ToString("f2")} A{this.Positions.A.ToString("f2")} B{this.Positions.B.ToString("f2")} C{this.Positions.C.ToString("f2")}";
  }
}
