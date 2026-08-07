// Decompiled with JetBrains decompiler
// Type: buClass.CodeRepetition
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodeRepetition : buSerilization
{
  public bool Coordinate;
  public bool Feed;
  public bool Tool;
  public bool Command;
  public AxesEnableWithUVW AxesRepetation = new AxesEnableWithUVW();

  public CodeRepetition()
  {
  }

  public CodeRepetition(CodeRepetition data)
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
    this.AxesRepetation = new AxesEnableWithUVW(data.AxesRepetation);
  }

  public CodeRepetition(bool coordinate, bool feed, bool tool, bool command)
  {
    this.Coordinate = coordinate;
    this.Feed = feed;
    this.Tool = tool;
    this.Command = command;
  }

  public override string ToString()
  {
    return $"Tool: {this.Tool.ToString()} , Feed: {this.Feed.ToString()} , Coordinate: {this.Coordinate.ToString()}";
  }
}
