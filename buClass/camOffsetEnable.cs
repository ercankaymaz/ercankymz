// Decompiled with JetBrains decompiler
// Type: buClass.camOffsetEnable
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camOffsetEnable : buSerilization
{
  public bool Offset = true;
  public bool AdditionalOffset = false;
  public bool OffsetCount = false;
  public bool OverlapDistance = true;
  public bool Flow = true;
  public bool Corner = true;
  public bool OpenContour = true;
  public static List<string> Captions = new List<string>();

  public camOffsetEnable()
  {
  }

  public camOffsetEnable(
    bool offset,
    bool addtionaloffset,
    bool overlap,
    bool offsetcount,
    bool flow,
    bool corner,
    bool opentype)
  {
    this.Offset = offset;
    this.AdditionalOffset = addtionaloffset;
    this.OffsetCount = offsetcount;
    this.OverlapDistance = overlap;
    this.Flow = flow;
    this.Corner = corner;
    this.OpenContour = opentype;
  }

  public camOffsetEnable(camOffsetEnable Data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) Data, ref CopiedClass);
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
    return $"Offset: {this.Offset.ToString()} , Flow: {this.Flow.ToString()} , OpenContour: {this.OpenContour.ToString()} , OverlapDistance: {this.OverlapDistance.ToString()} , OffsetCount: {this.OffsetCount.ToString()}";
  }
}
