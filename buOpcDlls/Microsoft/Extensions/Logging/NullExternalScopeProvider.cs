// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.NullExternalScopeProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;

#nullable disable
namespace Microsoft.Extensions.Logging;

internal sealed class NullExternalScopeProvider : IExternalScopeProvider
{
  private NullExternalScopeProvider()
  {
  }

  [Nullable(1)]
  public static IExternalScopeProvider Instance { [NullableContext(1)] get; } = (IExternalScopeProvider) new NullExternalScopeProvider();

  void IExternalScopeProvider.ForEachScope<TState>(Action<object, TState> callback, TState state)
  {
  }

  IDisposable IExternalScopeProvider.Push(object state) => (IDisposable) NullScope.Instance;
}
