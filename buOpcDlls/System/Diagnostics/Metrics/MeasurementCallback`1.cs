// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.MeasurementCallback`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Diagnostics.Metrics;

[ComVisible(true)]
public delegate void MeasurementCallback<T>(
  [Nullable(1)] Instrument instrument,
  T measurement,
  [Nullable(new byte[] {0, 0, 1, 2})] ReadOnlySpan<KeyValuePair<string, object>> tags,
  [Nullable(2)] object state)
  where T : struct;
