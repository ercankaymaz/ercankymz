// Decompiled with JetBrains decompiler
// Type: buClass.ToolDiemaker
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolDiemaker : buSerilization
{
  public double Width = 2.0;
  public double NickDiameter = 0.0;
  public double ID = 0.0;
  public double PositionOffset = 0.0;
  public double BridgeHeight = 0.0;
  public bool Pt1 = false;
  public bool Pt2 = true;
  public bool Pt3 = false;
  public bool Pt4 = false;
  public bool Pt6 = false;
  public bool Cutting = false;
  public bool Creasing = false;
  public bool Perfo = false;
  public bool CutCrease = false;
  public DiemakerToolModeType Mode = DiemakerToolModeType.StraightCut;

  public ToolDiemaker()
  {
  }

  public ToolDiemaker(ToolDiemaker geo)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) geo, ref CopiedClass);
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
    return $"Pt2: {this.Pt2.ToString()} - Pt3: {this.Pt3.ToString()} - Cutting: {this.Cutting.ToString()} - Creasing: {this.Creasing.ToString()} - Perfo: {this.Perfo.ToString()} - Cut Crease: {this.CutCrease.ToString()} - Mode: {this.Mode.ToString()} - Width: {this.Width.ToString("f2")}";
  }
}
