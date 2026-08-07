// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buMotion;
using System;

#nullable disable
namespace \u0002;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
internal class \u0001 : Attribute
{
  public override string ToString()
  {
    return $"{((TechnicianType) this).Time.ToShortTimeString()} - BaseClass: {((TechnicianLoginInfo) this).BaseClass} - Method: {((TechnicianLoginInfo) this).Method} - Cmd: {((TechnicianLoginInfo) this).Command} - Msg: {((TechnicianLoginInfo) this).Message}";
  }
}
