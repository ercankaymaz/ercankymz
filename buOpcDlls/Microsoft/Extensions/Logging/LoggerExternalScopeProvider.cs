// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.LoggerExternalScopeProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace Microsoft.Extensions.Logging;

[ComVisible(true)]
public class LoggerExternalScopeProvider : IExternalScopeProvider
{
  private readonly AsyncLocal<LoggerExternalScopeProvider.Scope> _currentScope = new AsyncLocal<LoggerExternalScopeProvider.Scope>();

  [NullableContext(1)]
  public void ForEachScope<[Nullable(2)] TState>([Nullable(new byte[] {1, 2, 1})] Action<object, TState> callback, TState state)
  {
    // ISSUE: variable of a compiler-generated type
    LoggerExternalScopeProvider.\u003C\u003Ec__DisplayClass2_0<TState> cDisplayClass20;
    // ISSUE: reference to a compiler-generated field
    cDisplayClass20.callback = callback;
    // ISSUE: reference to a compiler-generated field
    cDisplayClass20.state = state;
    Report(this._currentScope.Value, ref cDisplayClass20);

    static void Report(
      [Nullable(2)] LoggerExternalScopeProvider.Scope current,
      ref LoggerExternalScopeProvider.\u003C\u003Ec__DisplayClass2_0<TState> _param1)
    {
      if (current == null)
        return;
      Report(current.Parent, ref _param1);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      _param1.callback(current.State, _param1.state);
    }
  }

  [NullableContext(1)]
  public IDisposable Push([Nullable(2)] object state)
  {
    LoggerExternalScopeProvider.Scope parent = this._currentScope.Value;
    LoggerExternalScopeProvider.Scope scope = new LoggerExternalScopeProvider.Scope(this, state, parent);
    this._currentScope.Value = scope;
    return (IDisposable) scope;
  }

  private sealed class Scope : IDisposable
  {
    private readonly LoggerExternalScopeProvider _provider;
    private bool _isDisposed;

    internal Scope(
      LoggerExternalScopeProvider provider,
      object state,
      LoggerExternalScopeProvider.Scope parent)
    {
      this._provider = provider;
      this.State = state;
      this.Parent = parent;
    }

    public LoggerExternalScopeProvider.Scope Parent { get; }

    public object State { get; }

    public override string ToString() => this.State?.ToString();

    public void Dispose()
    {
      if (this._isDisposed)
        return;
      this._provider._currentScope.Value = this.Parent;
      this._isDisposed = true;
    }
  }
}
