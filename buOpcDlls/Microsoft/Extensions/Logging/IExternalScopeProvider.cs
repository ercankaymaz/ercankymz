// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.IExternalScopeProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Extensions.Logging;

[NullableContext(1)]
[ComVisible(true)]
public interface IExternalScopeProvider
{
  void ForEachScope<[Nullable(2)] TState>([Nullable(new byte[] {1, 2, 1})] Action<object, TState> callback, TState state);

  IDisposable Push([Nullable(2)] object state);
}
