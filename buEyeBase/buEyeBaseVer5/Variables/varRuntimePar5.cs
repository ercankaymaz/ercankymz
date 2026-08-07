// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Variables.varRuntimePar5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Variables;

[Serializable]
public class varRuntimePar5 : buSerilization5
{
  public List<Color> \u0001;
  public double BridgeMinLimit;
  public double BridgeMaxLimit;
  public double MinEntityLength;
  private List<List<eEntities>> SubEntites;
  private List<List<eEntities>> SubBridges;
  private List<string> SubName;
  public List<Cf2FileProperties> FileDefinations;
  public List<LayerBase5> Layers;

  public HatchPatternKeyedCollection HatchPatternCopy(HatchPatternKeyedCollection baseItem)
  {
    HatchPatternKeyedCollection patternKeyedCollection = new HatchPatternKeyedCollection();
    patternKeyedCollection.Clear();
    for (int index1 = 0; index1 <= baseItem.Count - 1; ++index1)
    {
      bool flag = true;
      for (int index2 = 0; index2 <= patternKeyedCollection.Count - 1; ++index2)
      {
        if (baseItem[index1].Name == patternKeyedCollection[index2].Name)
          flag = false;
      }
      if (flag)
      {
        HatchPattern hatchPattern = (HatchPattern) baseItem[index1].Clone();
        patternKeyedCollection.Add(hatchPattern);
      }
    }
    return patternKeyedCollection;
  }

  public LayerKeyedCollection LayerCopy(LayerKeyedCollection baseItem, bool AddDefaultLayer = true)
  {
    LayerKeyedCollection layerKeyedCollection = new LayerKeyedCollection();
    layerKeyedCollection.Clear();
    for (int index1 = 0; index1 <= baseItem.Count - 1; ++index1)
    {
      bool flag = true;
      if (!AddDefaultLayer && baseItem[index1].Name.ToLower().Trim() == "default")
        flag = false;
      for (int index2 = 0; index2 <= layerKeyedCollection.Count - 1; ++index2)
      {
        if (baseItem[index1].Name == layerKeyedCollection[index2].Name)
          flag = false;
      }
      if (flag)
      {
        Layer layer = (Layer) baseItem[index1].Clone();
        layerKeyedCollection.Add(layer);
      }
    }
    return layerKeyedCollection;
  }
}
