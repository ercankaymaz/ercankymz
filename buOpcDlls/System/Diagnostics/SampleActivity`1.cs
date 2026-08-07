// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.SampleActivity`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Diagnostics;

[ComVisible(true)]
public delegate ActivitySamplingResult SampleActivity<[Nullable(2)] T>(
  [Nullable(new byte[] {0, 1})] ref ActivityCreationOptions<T> options);
