// Decompiled with JetBrains decompiler
// Type: System.SpanDebugView`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Diagnostics;

#nullable disable
namespace System;

internal sealed class SpanDebugView<T>
{
  private readonly T[] _array;

  public SpanDebugView(Span<T> span) => this._array = span.ToArray();

  public SpanDebugView(ReadOnlySpan<T> span) => this._array = span.ToArray();

  [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
  public T[] Items => this._array;
}
