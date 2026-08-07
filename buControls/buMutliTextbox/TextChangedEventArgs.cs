// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.TextChangedEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace buMutliTextbox;

public class TextChangedEventArgs : EventArgs
{
  public TextChangedEventArgs(Range changedRange) => this.ChangedRange = changedRange;

  public Range ChangedRange { get; set; }
}
