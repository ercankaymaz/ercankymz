// Decompiled with JetBrains decompiler
// Type: DevAge.Patterns.ActivityExceptionEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Patterns;

public class ActivityExceptionEventArgs : ActivityEventArgs
{
  private Exception exception;

  public ActivityExceptionEventArgs(IActivity activity, Exception exception)
    : base(activity)
  {
    this.exception = exception;
  }

  public Exception Exception
  {
    get => this.exception;
    set => this.exception = value;
  }
}
