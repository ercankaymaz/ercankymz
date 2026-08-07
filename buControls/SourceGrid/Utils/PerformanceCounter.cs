// Decompiled with JetBrains decompiler
// Type: SourceGrid.Utils.PerformanceCounter
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid.Utils;

public class PerformanceCounter : IDisposable, IPerformanceCounter
{
  private DateTime dateTime_0 = DateTime.MinValue;

  public PerformanceCounter() => this.dateTime_0 = DateTime.Now;

  public double GetSeconds() => (DateTime.Now - this.dateTime_0).TotalSeconds;

  public double GetMilisec() => (DateTime.Now - this.dateTime_0).TotalMilliseconds;

  public void Dispose()
  {
  }
}
