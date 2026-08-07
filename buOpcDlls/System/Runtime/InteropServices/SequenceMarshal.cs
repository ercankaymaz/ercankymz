// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.SequenceMarshal
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Buffers;

#nullable disable
namespace System.Runtime.InteropServices;

[ComVisible(true)]
public static class SequenceMarshal
{
  public static bool TryGetReadOnlySequenceSegment<T>(
    ReadOnlySequence<T> sequence,
    out ReadOnlySequenceSegment<T> startSegment,
    out int startIndex,
    out ReadOnlySequenceSegment<T> endSegment,
    out int endIndex)
  {
    return sequence.TryGetReadOnlySequenceSegment(out startSegment, out startIndex, out endSegment, out endIndex);
  }

  public static bool TryGetArray<T>(ReadOnlySequence<T> sequence, out ArraySegment<T> segment)
  {
    return sequence.TryGetArray(out segment);
  }

  public static bool TryGetReadOnlyMemory<T>(
    ReadOnlySequence<T> sequence,
    out ReadOnlyMemory<T> memory)
  {
    if (!sequence.IsSingleSegment)
    {
      memory = new ReadOnlyMemory<T>();
      return false;
    }
    memory = sequence.First;
    return true;
  }

  internal static bool TryGetString(
    ReadOnlySequence<char> sequence,
    out string text,
    out int start,
    out int length)
  {
    return sequence.TryGetString(out text, out start, out length);
  }
}
