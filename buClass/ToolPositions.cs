// Decompiled with JetBrains decompiler
// Type: buClass.ToolPositions
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolPositions : buSerilization
{
  public Pnt6D Position = new Pnt6D();
  public Pnt6D Offset = new Pnt6D();
  public double AngularPosition = 0.0;
  public ToolLocationType Location = ToolLocationType.None;

  public ToolPositions()
  {
  }

  public ToolPositions(ToolPositions data)
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

  public override string ToString() => "Pos: " + this.Position.ToString();
}
