// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.ITraceWriter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
public interface ITraceWriter
{
  TraceLevel LevelFilter { get; }

  void Trace(TraceLevel level, string message, [Nullable(2)] Exception ex);
}
