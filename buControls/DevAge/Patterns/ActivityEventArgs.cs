// Decompiled with JetBrains decompiler
// Type: DevAge.Patterns.ActivityEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Patterns;

public class ActivityEventArgs : EventArgs
{
  private IActivity activity;

  public ActivityEventArgs(IActivity activity) => this.activity = activity;

  public IActivity Activity
  {
    get => this.activity;
    set => this.activity = value;
  }
}
