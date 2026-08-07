// Decompiled with JetBrains decompiler
// Type: buClass.Apps.JewelCalculation
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class JewelCalculation : buSerilization
{
  public bool Enable = true;
  public double DepthOverride = 0.0;
  public JewelVar JewelPar = new JewelVar();
  public List<eEntities> CadEntities = new List<eEntities>();
  public List<eEntities> ScreenEntities = new List<eEntities>();
  public camBase CamCalculation = new camBase();
  public ToolBase Tool = new ToolBase();
  public int TotalLineCount = 1;
  public string GCodes = "";

  public JewelCalculation()
  {
  }

  public JewelCalculation(JewelCalculation data)
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
    this.GCodes = data.GCodes;
    this.CadEntities.Clear();
    this.ScreenEntities.Clear();
    eEntities.CopyEntities(data.CadEntities, ref this.CadEntities);
    eEntities.CopyEntities(data.ScreenEntities, ref this.ScreenEntities);
    this.CamCalculation = new camBase(data.CamCalculation);
    this.JewelPar = new JewelVar(data.JewelPar);
  }
}
