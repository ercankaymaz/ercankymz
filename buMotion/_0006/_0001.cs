// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buMotion;
using System;
using System.Drawing;

#nullable disable
namespace \u0006;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
internal sealed class \u0001 : Attribute
{
  static \u0001()
  {
    TechnicianType.clrWarning = Color.Gold;
    AlarmWarningActionType.clrAlarm = Color.Red;
    AlarmWarningActionType.clralarmSoft = Color.LightSalmon;
    AlarmWarningActionType.clrInfo = Color.Lavender;
    AlarmWarningActionType.clrMessage = Color.LightBlue;
  }
}
