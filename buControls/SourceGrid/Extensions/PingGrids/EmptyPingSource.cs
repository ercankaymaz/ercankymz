// Decompiled with JetBrains decompiler
// Type: SourceGrid.Extensions.PingGrids.EmptyPingSource
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid.Extensions.PingGrids;

public class EmptyPingSource : IPingData
{
  public object GetItemValue(int index, string propertyName) => throw new NotImplementedException();

  public int Count
  {
    get => 0;
    set
    {
    }
  }

  public bool AllowSort
  {
    get => false;
    set
    {
    }
  }

  public void ApplySort(string propertyName, bool ascending) => throw new NotImplementedException();
}
