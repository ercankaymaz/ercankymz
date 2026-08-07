// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TuftingSelection
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class TuftingSelection : buSerilization
{
  public tuftingSelectionModeType Type = tuftingSelectionModeType.Auto;
  public tuftingManuelModeType ManuelMode = tuftingManuelModeType.ClickBlockPoints;
  public SortingNextGroupFindRulesType AutoNextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
  public SortingNextGroupFindRulesType ManuelNextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
  public tuftingManuelModeLayerType LayerMode = tuftingManuelModeLayerType.SelectedLayer;
  public bool OutlineFirst = true;
  public static List<string> Captions = new List<string>();

  public TuftingSelection()
  {
  }

  public TuftingSelection(TuftingSelection data)
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
}
