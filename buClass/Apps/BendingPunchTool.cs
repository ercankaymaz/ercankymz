// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingPunchTool
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendingPunchTool : ToolBase
{
  public bool Pt1 = false;
  public bool Pt2 = false;
  public bool Pt3 = false;
  public bool Pt4 = false;
  public double Width = 0.0;
  public double Offset = 0.0;
  public bool Bridge12 = false;
  public bool Bridge15 = false;
  public bool Bridge18 = false;
  public int ToolNoOriginal = 0;
  public int Mode = 0;
  public double Pt = 0.0;
  public BendingToolType BendingToolType = BendingToolType.StraightCut;
  public bool Cutting = false;
  public bool Creasing = false;
  public bool Perfo = false;
  public bool Combi = false;

  public BendingPunchTool()
  {
  }

  public BendingPunchTool(BendingPunchTool data)
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
    return $"No:{this.Data.No.ToString()} ; Width:{this.Width.ToString()} ; Offset:{this.Offset.ToString()} ; {this.Data.Name}";
  }
}
