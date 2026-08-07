// Decompiled with JetBrains decompiler
// Type: System.MemoryDebugView`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Diagnostics;

#nullable disable
namespace System;

internal sealed class MemoryDebugView<T>
{
  private readonly ReadOnlyMemory<T> _memory;

  public MemoryDebugView(Memory<T> memory) => this._memory = (ReadOnlyMemory<T>) memory;

  public MemoryDebugView(ReadOnlyMemory<T> memory) => this._memory = memory;

  [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
  public T[] Items => this._memory.ToArray();
}
