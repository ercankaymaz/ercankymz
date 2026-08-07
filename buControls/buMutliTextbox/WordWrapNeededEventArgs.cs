// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.WordWrapNeededEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buMutliTextbox;

public class WordWrapNeededEventArgs : EventArgs
{
  public List<int> CutOffPositions { get; private set; }

  public bool ImeAllowed { get; private set; }

  public Line Line { get; private set; }

  public WordWrapNeededEventArgs(List<int> cutOffPositions, bool imeAllowed, Line line)
  {
    this.CutOffPositions = cutOffPositions;
    this.ImeAllowed = imeAllowed;
    this.Line = line;
  }
}
