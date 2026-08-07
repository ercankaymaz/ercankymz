// Decompiled with JetBrains decompiler
// Type: buClass.postRegionMode
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class postRegionMode : buSerilization
{
  public bool Enable = false;
  public string Code = "";
  public string Auxiliry1 = "";
  public string Auxiliry2 = "";
  public string Explanation = "";
  public ArrayList StartLines = new ArrayList();
  public ArrayList EndLines = new ArrayList();
  public ToolPost RegionToolDef = new ToolPost();
  public SpindlePost RegionSpindleDef = new SpindlePost(true, false, "M3", "M4", "M5");
  public CharDefinitions RegionTDef = new CharDefinitions("T", 0, 1.0, 0, 1);
  public CharDefinitions RegionSDef = new CharDefinitions("S", 0, 1.0, 0, 1);
  public CharDefinitions RegionXDef = new CharDefinitions("X", 3, 1.0, 0, 1);
  public CharDefinitions RegionYDef = new CharDefinitions("Y", 3, 1.0, 0, 1);
  public CharDefinitions RegionZDef = new CharDefinitions("Z", 3, 1.0, 0, 1);
  public CharDefinitions RegionADef = new CharDefinitions("A", 3, 1.0, 0, 1);
  public CharDefinitions RegionBDef = new CharDefinitions("B", 3, 1.0, 0, 1);
  public CharDefinitions RegionCDef = new CharDefinitions("C", 3, 1.0, 0, 1);

  public postRegionMode()
  {
  }

  public postRegionMode(postRegionMode data)
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
    this.RegionADef = new CharDefinitions(data.RegionADef);
    this.RegionBDef = new CharDefinitions(data.RegionBDef);
    this.RegionCDef = new CharDefinitions(data.RegionCDef);
    this.RegionSDef = new CharDefinitions(data.RegionSDef);
    this.RegionSpindleDef = new SpindlePost(data.RegionSpindleDef);
    this.RegionTDef = new CharDefinitions(data.RegionTDef);
    this.RegionToolDef = new ToolPost(data.RegionToolDef);
    this.RegionXDef = new CharDefinitions(data.RegionXDef);
    this.RegionYDef = new CharDefinitions(data.RegionYDef);
    this.RegionZDef = new CharDefinitions(data.RegionZDef);
    this.StartLines = new ArrayList();
    for (int index = 0; index <= data.StartLines.Count - 1; ++index)
      this.StartLines.Add(data.StartLines[index]);
    this.EndLines = new ArrayList();
    for (int index = 0; index <= data.EndLines.Count - 1; ++index)
      this.EndLines.Add(data.EndLines[index]);
  }
}
