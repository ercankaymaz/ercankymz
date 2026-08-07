// Decompiled with JetBrains decompiler
// Type: System.Buffers.ReadOnlySequenceDebugView`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Diagnostics;

#nullable disable
namespace System.Buffers;

internal sealed class ReadOnlySequenceDebugView<T>
{
  private readonly T[] _array;
  private readonly ReadOnlySequenceDebugView<T>.ReadOnlySequenceDebugViewSegments _segments;

  public ReadOnlySequenceDebugView(ReadOnlySequence<T> sequence)
  {
    this._array = sequence.ToArray<T>();
    int length = 0;
    foreach (ReadOnlyMemory<T> readOnlyMemory in sequence)
      ++length;
    ReadOnlyMemory<T>[] readOnlyMemoryArray = new ReadOnlyMemory<T>[length];
    int index = 0;
    foreach (ReadOnlyMemory<T> readOnlyMemory in sequence)
    {
      readOnlyMemoryArray[index] = readOnlyMemory;
      ++index;
    }
    this._segments = new ReadOnlySequenceDebugView<T>.ReadOnlySequenceDebugViewSegments()
    {
      Segments = readOnlyMemoryArray
    };
  }

  public ReadOnlySequenceDebugView<T>.ReadOnlySequenceDebugViewSegments BufferSegments
  {
    get => this._segments;
  }

  [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
  public T[] Items => this._array;

  [DebuggerDisplay("Count: {Segments.Length}", Name = "Segments")]
  public struct ReadOnlySequenceDebugViewSegments
  {
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public ReadOnlyMemory<T>[] Segments { get; set; }
  }
}
