// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingNickTool
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendingNickTool : ToolBase
{
  public bool Pt1 = false;
  public bool Pt2 = false;
  public bool Pt3 = false;
  public bool Pt4 = false;
  public double Width = 4.5;

  public BendingNickTool()
  {
  }

  public BendingNickTool(BendingNickTool data)
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

  public override string ToString() => $"No:{this.Data.No.ToString()} ; {this.Data.Name}";
}
