// Decompiled with JetBrains decompiler
// Type: System.Buffers.BuffersExtensions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Buffers;

[ComVisible(true)]
public static class BuffersExtensions
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static SequencePosition? PositionOf<T>([System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref this ReadOnlySequence<T> source, T value) where T : object, IEquatable<T>
  {
    if (!source.IsSingleSegment)
      return BuffersExtensions.PositionOfMultiSegment<T>(ref source, value);
    int offset = source.First.Span.IndexOf<T>(value);
    return offset != -1 ? new SequencePosition?(source.GetPosition((long) offset)) : new SequencePosition?();
  }

  private static SequencePosition? PositionOfMultiSegment<T>(
    [System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref ReadOnlySequence<T> source,
    T value)
    where T : object, IEquatable<T>
  {
    SequencePosition start = source.Start;
    SequencePosition origin = start;
    ReadOnlyMemory<T> memory;
    while (source.TryGet(ref start, out memory))
    {
      int offset = memory.Span.IndexOf<T>(value);
      if (offset != -1)
        return new SequencePosition?(source.GetPosition((long) offset, origin));
      if (start.GetObject() != null)
        origin = start;
      else
        break;
    }
    return new SequencePosition?();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void CopyTo<T>([System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref this ReadOnlySequence<T> source, Span<T> destination)
  {
    if (source.Length > (long) destination.Length)
      ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.destination);
    if (source.IsSingleSegment)
      source.First.Span.CopyTo(destination);
    else
      BuffersExtensions.CopyToMultiSegment<T>(ref source, destination);
  }

  private static void CopyToMultiSegment<T>([System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref ReadOnlySequence<T> sequence, Span<T> destination)
  {
    SequencePosition start = sequence.Start;
    ReadOnlyMemory<T> memory;
    while (sequence.TryGet(ref start, out memory))
    {
      ReadOnlySpan<T> span = memory.Span;
      span.CopyTo(destination);
      if (start.GetObject() == null)
        break;
      destination = destination.Slice(span.Length);
    }
  }

  public static T[] ToArray<T>([System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref this ReadOnlySequence<T> sequence)
  {
    T[] destination = new T[sequence.Length];
    sequence.CopyTo<T>((Span<T>) destination);
    return destination;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void Write<T>(this IBufferWriter<T> writer, ReadOnlySpan<T> value)
  {
    Span<T> span = writer.GetSpan();
    if (value.Length <= span.Length)
    {
      value.CopyTo(span);
      writer.Advance(value.Length);
    }
    else
      BuffersExtensions.WriteMultiSegment<T>(writer, ref value, span);
  }

  private static void WriteMultiSegment<T>(
    IBufferWriter<T> writer,
    [System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref ReadOnlySpan<T> source,
    Span<T> destination)
  {
    ReadOnlySpan<T> readOnlySpan = source;
    while (true)
    {
      int num = Math.Min(destination.Length, readOnlySpan.Length);
      readOnlySpan.Slice(0, num).CopyTo(destination);
      writer.Advance(num);
      readOnlySpan = readOnlySpan.Slice(num);
      if (readOnlySpan.Length > 0)
        destination = writer.GetSpan(readOnlySpan.Length);
      else
        break;
    }
  }
}
