// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buListValueChangedEventArg
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using System.Collections.Generic;

#nullable disable
namespace buControls.Controls;

public class buListValueChangedEventArg
{
  public List<ValuesItem> Items = new List<ValuesItem>();
  public ValuesItem Value = new ValuesItem();
  public int IndexItem = -1;
  public string Command = "";

  public buListValueChangedEventArg()
  {
  }

  public buListValueChangedEventArg(
    List<ValuesItem> items,
    ValuesItem value,
    int indexItem,
    string command)
  {
    for (int index = 0; index <= items.Count - 1; ++index)
      this.Items.Add(items[index]);
    this.Value = new ValuesItem(value);
    this.IndexItem = indexItem;
    this.Command = command;
  }
}
