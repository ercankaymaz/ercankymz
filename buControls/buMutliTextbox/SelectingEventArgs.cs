// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.SelectingEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace buMutliTextbox;

public class SelectingEventArgs : EventArgs
{
  public AutocompleteItem Item { get; internal set; }

  public bool Cancel { get; set; }

  public int SelectedIndex { get; set; }

  public bool Handled { get; set; }
}
