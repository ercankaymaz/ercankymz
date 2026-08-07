// Decompiled with JetBrains decompiler
// Type: buClass.AnalyseEntitiesOptions
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class AnalyseEntitiesOptions : buSerilization
{
  public Color FilterColor = Color.Transparent;
  public bool UseToolPurpose = false;
  public string AuxString = (string) null;
  public bool DontAddCamSelected = false;
  public List<int> DontAddEntityIndexList = new List<int>();
  public EntityDevideSettings Devide = new EntityDevideSettings();

  public AnalyseEntitiesOptions()
  {
  }

  public AnalyseEntitiesOptions(
    Color filterColor,
    EntityDevideSettings devide,
    bool dontAddCamSelected,
    List<int> dontAddEntityIndexList,
    string auxString,
    bool useToolPurpose)
  {
    this.AuxString = auxString;
    this.FilterColor = filterColor;
    this.Devide = new EntityDevideSettings(devide);
    this.DontAddCamSelected = dontAddCamSelected;
    this.UseToolPurpose = useToolPurpose;
    this.DontAddEntityIndexList.Clear();
    for (int index = 0; index <= dontAddEntityIndexList.Count - 1; ++index)
      this.DontAddEntityIndexList.Add(dontAddEntityIndexList[index]);
  }
}
