// Decompiled with JetBrains decompiler
// Type: buClass.GetChainEntitiesSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class GetChainEntitiesSettings : buSerilization
{
  public bool AddToSelection = false;
  public int StartEntityIndex = -1;
  public bool UseOnlyFirstSelectedEntitiyLayer = false;
  public bool UseMinDistance = false;
  public double MinDistance = 5.0;
  public static List<string> Captions = new List<string>();

  public GetChainEntitiesSettings()
  {
  }

  public GetChainEntitiesSettings(
    bool addToselection,
    int startEntityIndex,
    bool useOnlyFirstSelectedEntitiyLayer)
  {
    this.AddToSelection = addToselection;
    this.StartEntityIndex = startEntityIndex;
    this.UseOnlyFirstSelectedEntitiyLayer = useOnlyFirstSelectedEntitiyLayer;
  }

  public GetChainEntitiesSettings(GetChainEntitiesSettings data)
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

  public override string ToString() => "AddToSelection: " + this.AddToSelection.ToString();
}
