// Decompiled with JetBrains decompiler
// Type: SourceGrid.Extensions.PingGrids.IPingData
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid.Extensions.PingGrids;

public interface IPingData
{
  int Count { get; }

  bool AllowSort { get; set; }

  void ApplySort(string propertyName, bool ascending);

  object GetItemValue(int index, string propertyName);
}
