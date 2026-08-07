// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.LineRemovedEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buMutliTextbox;

public class LineRemovedEventArgs : EventArgs
{
  public LineRemovedEventArgs(int index, int count, List<int> removedLineIds)
  {
    this.Index = index;
    this.Count = count;
    this.RemovedLineUniqueIds = removedLineIds;
  }

  public int Index { get; private set; }

  public int Count { get; private set; }

  public List<int> RemovedLineUniqueIds { get; private set; }
}
