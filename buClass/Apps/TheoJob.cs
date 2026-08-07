// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TheoJob
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class TheoJob : buSerilization
{
  public double Length = 100.0;
  public double OffsetedLength = 100.0;
  public double Width = 23.8;
  public double Pt = 2.0;
  public int Count = 0;
  public int Index = 0;
  public bool BendMark = false;
  public bool Done = false;
  public double StartOffset = 0.0;
  public double EndOffset = 0.0;
  public bool Mirrored = false;
  public double ToolWidth = 0.0;
  public List<Pnt3D> AllPoints = new List<Pnt3D>();
  public ArrayList Codes = new ArrayList();
  public ArrayList FullCodes = new ArrayList();
  public List<eEntities> Entities = new List<eEntities>();
  public List<TheoItem> Items = new List<TheoItem>();
  public static List<string> Captions = new List<string>();

  public TheoJob()
  {
  }

  public TheoJob(TheoJob data)
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
    this.Codes = new ArrayList();
    this.Entities.Clear();
    this.Items.Clear();
    this.AllPoints.Clear();
    int num = 0;
    while (num <= data.AllPoints.Count - 1)
      ++num;
    for (int index = 0; index <= data.Items.Count - 1; ++index)
    {
      if (data.Items[index].GetType() == typeof (TheoBridgeItem))
        this.Items.Add((TheoItem) new TheoBridgeItem((TheoBridgeItem) data.Items[index]));
      if (data.Items[index].GetType() == typeof (TheoBendItem))
        this.Items.Add((TheoItem) new TheoBendItem((TheoBendItem) data.Items[index]));
      if (data.Items[index].GetType() == typeof (TheoBroachItem))
        this.Items.Add((TheoItem) new TheoBroachItem((TheoBroachItem) data.Items[index]));
      if (data.Items[index].GetType() == typeof (TheoNickItem))
        this.Items.Add((TheoItem) new TheoNickItem((TheoNickItem) data.Items[index]));
    }
    for (int index = 0; index <= data.Codes.Count - 1; ++index)
      this.Codes.Add(data.Codes[index]);
    for (int index = 0; index <= data.FullCodes.Count - 1; ++index)
      this.FullCodes.Add(data.FullCodes[index]);
    for (int index = 0; index <= data.Entities.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(data.Entities[index], ref copiedEnt);
      this.Entities.Add(copiedEnt);
    }
  }

  public override string ToString()
  {
    return $"Len: {this.Length.ToString()} , Width: {this.Width.ToString()} , Pt: {this.Pt.ToString()} Cnt: {this.Count.ToString()}";
  }
}
