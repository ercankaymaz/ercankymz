// Decompiled with JetBrains decompiler
// Type: DevAge.Patterns.ActivityCanceledException
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Patterns;

[Serializable]
public class ActivityCanceledException : DevAgeApplicationException
{
  public ActivityCanceledException()
    : base("Activity canceled.")
  {
  }
}
