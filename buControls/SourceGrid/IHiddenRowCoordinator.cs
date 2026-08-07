// Decompiled with JetBrains decompiler
// Type: SourceGrid.IHiddenRowCoordinator
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections.Generic;

#nullable disable
namespace SourceGrid;

public interface IHiddenRowCoordinator
{
  IEnumerable<int> LoopVisibleRows(int rowIndex, int numberOfRowsToProduce);

  int ConvertScrollbarValueToRowIndex(int scrollBarValue);

  int GetTotalHiddenRows();
}
