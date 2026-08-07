// Decompiled with JetBrains decompiler
// Type: SourceGrid.Extensions.PingGrids.ListPingSource`1
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid.Extensions.PingGrids;

public class ListPingSource<T> : List<T>, IPingData
{
  public bool AllowSort
  {
    get => true;
    set
    {
    }
  }

  public void ApplySort(string propertyName, bool ascending) => this.Sort();

  public object GetItemValue(int index, string propertyName) => throw new NotImplementedException();
}
