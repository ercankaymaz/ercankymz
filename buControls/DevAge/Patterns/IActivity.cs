// Decompiled with JetBrains decompiler
// Type: DevAge.Patterns.IActivity
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Threading;

#nullable disable
namespace DevAge.Patterns;

public interface IActivity
{
  void Start(IActivityEvents events);

  void Cancel();

  ActivityCollection SubActivities { get; }

  ActivityStatus Status { get; }

  string Name { get; }

  WaitHandle WaitHandle { get; }

  Exception Exception { get; }

  IActivity Parent { get; set; }

  string FullName { get; }
}
