// Decompiled with JetBrains decompiler
// Type: System.Buffers.ReadOnlySequence`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Buffers;

[System.Runtime.CompilerServices.System.Memory.IsReadOnly]
[DebuggerTypeProxy(typeof (ReadOnlySequenceDebugView<>))]
[DebuggerDisplay("{ToString(),raw}")]
[ComVisible(true)]
public struct ReadOnlySequence<T>
{
  private readonly SequencePosition _sequenceStart;
  private readonly SequencePosition _sequenceEnd;
  public static readonly ReadOnlySequence<T> Empty = new ReadOnlySequence<T>(SpanHelpers.PerTypeValues<T>.EmptyArray);

  public long Length => this.GetLength();

  public bool IsEmpty => this.Length == 0L;

  public bool IsSingleSegment
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)] get
    {
      return this._sequenceStart.GetObject() == this._sequenceEnd.GetObject();
    }
  }

  public ReadOnlyMemory<T> First => this.GetFirstBuffer();

  public SequencePosition Start => this._sequenceStart;

  public SequencePosition End => this._sequenceEnd;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private ReadOnlySequence(
    object startSegment,
    int startIndexAndFlags,
    object endSegment,
    int endIndexAndFlags)
  {
    this._sequenceStart = new SequencePosition(startSegment, startIndexAndFlags);
    this._sequenceEnd = new SequencePosition(endSegment, endIndexAndFlags);
  }

  public ReadOnlySequence(
    ReadOnlySequenceSegment<T> startSegment,
    int startIndex,
    ReadOnlySequenceSegment<T> endSegment,
    int endIndex)
  {
    if (startSegment != null && endSegment != null && (startSegment == endSegment || startSegment.RunningIndex <= endSegment.RunningIndex))
    {
      ReadOnlyMemory<T> memory = startSegment.Memory;
      if ((uint) memory.Length >= (uint) startIndex)
      {
        memory = endSegment.Memory;
        if ((uint) memory.Length >= (uint) endIndex && (startSegment != endSegment || endIndex >= startIndex))
          goto label_4;
      }
    }
    ThrowHelper.ThrowArgumentValidationException<T>(startSegment, startIndex, endSegment);
label_4:
    this._sequenceStart = new SequencePosition((object) startSegment, ReadOnlySequence.SegmentToSequenceStart(startIndex));
    this._sequenceEnd = new SequencePosition((object) endSegment, ReadOnlySequence.SegmentToSequenceEnd(endIndex));
  }

  public ReadOnlySequence(T[] array)
  {
    if (array == null)
      ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
    this._sequenceStart = new SequencePosition((object) array, ReadOnlySequence.ArrayToSequenceStart(0));
    this._sequenceEnd = new SequencePosition((object) array, ReadOnlySequence.ArrayToSequenceEnd(array.Length));
  }

  public ReadOnlySequence(T[] array, int start, int length)
  {
    if (array == null || (uint) start > (uint) array.Length || (uint) length > (uint) (array.Length - start))
      ThrowHelper.ThrowArgumentValidationException((Array) array, start);
    this._sequenceStart = new SequencePosition((object) array, ReadOnlySequence.ArrayToSequenceStart(start));
    this._sequenceEnd = new SequencePosition((object) array, ReadOnlySequence.ArrayToSequenceEnd(start + length));
  }

  public ReadOnlySequence(ReadOnlyMemory<T> memory)
  {
    MemoryManager<T> manager;
    int start1;
    int length;
    if (MemoryMarshal.TryGetMemoryManager<T, MemoryManager<T>>(memory, out manager, out start1, out length))
    {
      this._sequenceStart = new SequencePosition((object) manager, ReadOnlySequence.MemoryManagerToSequenceStart(start1));
      this._sequenceEnd = new SequencePosition((object) manager, ReadOnlySequence.MemoryManagerToSequenceEnd(start1 + length));
    }
    else
    {
      ArraySegment<T> segment;
      if (MemoryMarshal.TryGetArray<T>(memory, out segment))
      {
        T[] array = segment.Array;
        int offset = segment.Offset;
        this._sequenceStart = new SequencePosition((object) array, ReadOnlySequence.ArrayToSequenceStart(offset));
        this._sequenceEnd = new SequencePosition((object) array, ReadOnlySequence.ArrayToSequenceEnd(offset + segment.Count));
      }
      else if (typeof (T) == typeof (char))
      {
        string text;
        int start2;
        if (!MemoryMarshal.TryGetString((ReadOnlyMemory<char>) (ValueType) memory, out text, out start2, out length))
          ThrowHelper.ThrowInvalidOperationException();
        this._sequenceStart = new SequencePosition((object) text, ReadOnlySequence.StringToSequenceStart(start2));
        this._sequenceEnd = new SequencePosition((object) text, ReadOnlySequence.StringToSequenceEnd(start2 + length));
      }
      else
      {
        ThrowHelper.ThrowInvalidOperationException();
        this._sequenceStart = new SequencePosition();
        this._sequenceEnd = new SequencePosition();
      }
    }
  }

  public ReadOnlySequence<T> Slice(long start, long length)
  {
    if (start < 0L || length < 0L)
      ThrowHelper.ThrowStartOrEndArgumentValidationException(start);
    int index1 = ReadOnlySequence<T>.GetIndex(ref this._sequenceStart);
    int index2 = ReadOnlySequence<T>.GetIndex(ref this._sequenceEnd);
    object obj1 = this._sequenceStart.GetObject();
    object endObject = this._sequenceEnd.GetObject();
    SequencePosition sequencePosition;
    SequencePosition end;
    if (obj1 != endObject)
    {
      ReadOnlySequenceSegment<T> startSegment = (ReadOnlySequenceSegment<T>) obj1;
      int num1 = startSegment.Memory.Length - index1;
      if ((long) num1 > start)
      {
        int num2 = index1 + (int) start;
        sequencePosition = new SequencePosition(obj1, num2);
        end = ReadOnlySequence<T>.GetEndPosition(startSegment, obj1, num2, endObject, index2, length);
      }
      else
      {
        if (num1 < 0)
          ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
        sequencePosition = ReadOnlySequence<T>.SeekMultiSegment(startSegment.Next, endObject, index2, start - (long) num1, ExceptionArgument.start);
        int index3 = ReadOnlySequence<T>.GetIndex(ref sequencePosition);
        object obj2 = sequencePosition.GetObject();
        if (obj2 != endObject)
        {
          end = ReadOnlySequence<T>.GetEndPosition((ReadOnlySequenceSegment<T>) obj2, obj2, index3, endObject, index2, length);
        }
        else
        {
          if ((long) (index2 - index3) < length)
            ThrowHelper.ThrowStartOrEndArgumentValidationException(0L);
          end = new SequencePosition(obj2, index3 + (int) length);
        }
      }
    }
    else
    {
      if ((long) (index2 - index1) < start)
        ThrowHelper.ThrowStartOrEndArgumentValidationException(-1L);
      int integer = index1 + (int) start;
      sequencePosition = new SequencePosition(obj1, integer);
      if ((long) (index2 - integer) < length)
        ThrowHelper.ThrowStartOrEndArgumentValidationException(0L);
      end = new SequencePosition(obj1, integer + (int) length);
    }
    return this.SliceImpl(ref sequencePosition, ref end);
  }

  public ReadOnlySequence<T> Slice(long start, SequencePosition end)
  {
    if (start < 0L)
      ThrowHelper.ThrowStartOrEndArgumentValidationException(start);
    uint index1 = (uint) ReadOnlySequence<T>.GetIndex(ref end);
    object endObject = end.GetObject();
    uint index2 = (uint) ReadOnlySequence<T>.GetIndex(ref this._sequenceStart);
    object @object = this._sequenceStart.GetObject();
    uint index3 = (uint) ReadOnlySequence<T>.GetIndex(ref this._sequenceEnd);
    object obj = this._sequenceEnd.GetObject();
    if (@object == obj)
    {
      if (!ReadOnlySequence<T>.InRange(index1, index2, index3))
        ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
      if ((long) (index1 - index2) < start)
        ThrowHelper.ThrowStartOrEndArgumentValidationException(-1L);
    }
    else
    {
      ReadOnlySequenceSegment<T> onlySequenceSegment = (ReadOnlySequenceSegment<T>) @object;
      ulong start1 = (ulong) onlySequenceSegment.RunningIndex + (ulong) index2;
      ulong num1 = (ulong) ((ReadOnlySequenceSegment<T>) endObject).RunningIndex + (ulong) index1;
      if (!ReadOnlySequence<T>.InRange(num1, start1, (ulong) ((ReadOnlySequenceSegment<T>) obj).RunningIndex + (ulong) index3))
        ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
      if (start1 + (ulong) start > num1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);
      int num2 = onlySequenceSegment.Memory.Length - (int) index2;
      if ((long) num2 <= start)
      {
        if (num2 < 0)
          ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
        SequencePosition start2 = ReadOnlySequence<T>.SeekMultiSegment(onlySequenceSegment.Next, endObject, (int) index1, start - (long) num2, ExceptionArgument.start);
        return this.SliceImpl(ref start2, ref end);
      }
    }
    SequencePosition start3 = new SequencePosition(@object, (int) index2 + (int) start);
    return this.SliceImpl(ref start3, ref end);
  }

  public ReadOnlySequence<T> Slice(SequencePosition start, long length)
  {
    uint index1 = (uint) ReadOnlySequence<T>.GetIndex(ref start);
    object @object = start.GetObject();
    uint index2 = (uint) ReadOnlySequence<T>.GetIndex(ref this._sequenceStart);
    object obj = this._sequenceStart.GetObject();
    uint index3 = (uint) ReadOnlySequence<T>.GetIndex(ref this._sequenceEnd);
    object endObject = this._sequenceEnd.GetObject();
    if (obj == endObject)
    {
      if (!ReadOnlySequence<T>.InRange(index1, index2, index3))
        ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
      if (length < 0L)
        ThrowHelper.ThrowStartOrEndArgumentValidationException(0L);
      if ((long) (index3 - index1) < length)
        ThrowHelper.ThrowStartOrEndArgumentValidationException(0L);
    }
    else
    {
      ReadOnlySequenceSegment<T> onlySequenceSegment = (ReadOnlySequenceSegment<T>) @object;
      ulong num1 = (ulong) onlySequenceSegment.RunningIndex + (ulong) index1;
      ulong start1 = (ulong) ((ReadOnlySequenceSegment<T>) obj).RunningIndex + (ulong) index2;
      ulong end1 = (ulong) ((ReadOnlySequenceSegment<T>) endObject).RunningIndex + (ulong) index3;
      if (!ReadOnlySequence<T>.InRange(num1, start1, end1))
        ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
      if (length < 0L)
        ThrowHelper.ThrowStartOrEndArgumentValidationException(0L);
      if (num1 + (ulong) length > end1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length);
      int num2 = onlySequenceSegment.Memory.Length - (int) index1;
      if ((long) num2 < length)
      {
        if (num2 < 0)
          ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
        SequencePosition end2 = ReadOnlySequence<T>.SeekMultiSegment(onlySequenceSegment.Next, endObject, (int) index3, length - (long) num2, ExceptionArgument.length);
        return this.SliceImpl(ref start, ref end2);
      }
    }
    ref SequencePosition local1 = ref start;
    SequencePosition sequencePosition = new SequencePosition(@object, (int) index1 + (int) length);
    ref SequencePosition local2 = ref sequencePosition;
    return this.SliceImpl(ref local1, ref local2);
  }

  public ReadOnlySequence<T> Slice(int start, int length)
  {
    return this.Slice((long) start, (long) length);
  }

  public ReadOnlySequence<T> Slice(int start, SequencePosition end)
  {
    return this.Slice((long) start, end);
  }

  public ReadOnlySequence<T> Slice(SequencePosition start, int length)
  {
    return this.Slice(start, (long) length);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ReadOnlySequence<T> Slice(SequencePosition start, SequencePosition end)
  {
    this.BoundsCheck((uint) ReadOnlySequence<T>.GetIndex(ref start), start.GetObject(), (uint) ReadOnlySequence<T>.GetIndex(ref end), end.GetObject());
    return this.SliceImpl(ref start, ref end);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ReadOnlySequence<T> Slice(SequencePosition start)
  {
    this.BoundsCheck(ref start);
    return this.SliceImpl(ref start, ref this._sequenceEnd);
  }

  public ReadOnlySequence<T> Slice(long start)
  {
    if (start < 0L)
      ThrowHelper.ThrowStartOrEndArgumentValidationException(start);
    if (start == 0L)
      return this;
    SequencePosition start1 = this.Seek(ref this._sequenceStart, ref this._sequenceEnd, start, ExceptionArgument.start);
    return this.SliceImpl(ref start1, ref this._sequenceEnd);
  }

  public override string ToString()
  {
    if (typeof (T) == typeof (char))
    {
      ReadOnlySequence<T> source = this;
      ReadOnlySequence<char> sequence = Unsafe.As<ReadOnlySequence<T>, ReadOnlySequence<char>>(ref source);
      string text;
      int start;
      int length;
      if (SequenceMarshal.TryGetString(sequence, out text, out start, out length))
        return text.Substring(start, length);
      if (this.Length < (long) int.MaxValue)
        return new string(sequence.ToArray<char>());
    }
    return $"System.Buffers.ReadOnlySequence<{typeof (T).Name}>[{this.Length}]";
  }

  public ReadOnlySequence<T>.Enumerator GetEnumerator()
  {
    return new ReadOnlySequence<T>.Enumerator(ref this);
  }

  public SequencePosition GetPosition(long offset) => this.GetPosition(offset, this._sequenceStart);

  public SequencePosition GetPosition(long offset, SequencePosition origin)
  {
    if (offset < 0L)
      ThrowHelper.ThrowArgumentOutOfRangeException_OffsetOutOfRange();
    return this.Seek(ref origin, ref this._sequenceEnd, offset, ExceptionArgument.offset);
  }

  public bool TryGet(ref SequencePosition position, out ReadOnlyMemory<T> memory, bool advance = true)
  {
    SequencePosition next;
    bool buffer = this.TryGetBuffer(ref position, out memory, out next);
    if (advance)
      position = next;
    return buffer;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal bool TryGetBuffer(
    [System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref SequencePosition position,
    out ReadOnlyMemory<T> memory,
    out SequencePosition next)
  {
    object obj1 = position.GetObject();
    next = new SequencePosition();
    if (obj1 == null)
    {
      memory = new ReadOnlyMemory<T>();
      return false;
    }
    ReadOnlySequence<T>.SequenceType sequenceType = this.GetSequenceType();
    object obj2 = this._sequenceEnd.GetObject();
    int index1 = ReadOnlySequence<T>.GetIndex(ref position);
    int index2 = ReadOnlySequence<T>.GetIndex(ref this._sequenceEnd);
    if (sequenceType == ReadOnlySequence<T>.SequenceType.MultiSegment)
    {
      ReadOnlySequenceSegment<T> onlySequenceSegment = (ReadOnlySequenceSegment<T>) obj1;
      if (onlySequenceSegment != obj2)
      {
        ReadOnlySequenceSegment<T> next1 = onlySequenceSegment.Next;
        if (next1 == null)
          ThrowHelper.ThrowInvalidOperationException_EndPositionNotReached();
        next = new SequencePosition((object) next1, 0);
        memory = onlySequenceSegment.Memory.Slice(index1);
      }
      else
        memory = onlySequenceSegment.Memory.Slice(index1, index2 - index1);
    }
    else
    {
      if (obj1 != obj2)
        ThrowHelper.ThrowInvalidOperationException_EndPositionNotReached();
      memory = sequenceType != ReadOnlySequence<T>.SequenceType.Array ? (!(typeof (T) == typeof (char)) || sequenceType != ReadOnlySequence<T>.SequenceType.String ? (ReadOnlyMemory<T>) ((MemoryManager<T>) obj1).Memory.Slice(index1, index2 - index1) : (ReadOnlyMemory<T>) (ValueType) ((string) obj1).AsMemory(index1, index2 - index1)) : new ReadOnlyMemory<T>((T[]) obj1, index1, index2 - index1);
    }
    return true;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private ReadOnlyMemory<T> GetFirstBuffer()
  {
    object obj = this._sequenceStart.GetObject();
    if (obj == null)
      return new ReadOnlyMemory<T>();
    int integer1 = this._sequenceStart.GetInteger();
    int integer2 = this._sequenceEnd.GetInteger();
    bool flag = obj != this._sequenceEnd.GetObject();
    if (integer1 >= 0)
    {
      if (integer2 >= 0)
      {
        ReadOnlyMemory<T> memory = ((ReadOnlySequenceSegment<T>) obj).Memory;
        return flag ? memory.Slice(integer1) : memory.Slice(integer1, integer2 - integer1);
      }
      if (flag)
        ThrowHelper.ThrowInvalidOperationException_EndPositionNotReached();
      return new ReadOnlyMemory<T>((T[]) obj, integer1, (integer2 & int.MaxValue) - integer1);
    }
    if (flag)
      ThrowHelper.ThrowInvalidOperationException_EndPositionNotReached();
    if (typeof (T) == typeof (char) && integer2 < 0)
      return (ReadOnlyMemory<T>) (ValueType) ((string) obj).AsMemory(integer1 & int.MaxValue, integer2 - integer1);
    int start = integer1 & int.MaxValue;
    return (ReadOnlyMemory<T>) ((MemoryManager<T>) obj).Memory.Slice(start, integer2 - start);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private SequencePosition Seek(
    [System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref SequencePosition start,
    [System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref SequencePosition end,
    long offset,
    ExceptionArgument argument)
  {
    int index1 = ReadOnlySequence<T>.GetIndex(ref start);
    int index2 = ReadOnlySequence<T>.GetIndex(ref end);
    object @object = start.GetObject();
    object endObject = end.GetObject();
    if (@object != endObject)
    {
      ReadOnlySequenceSegment<T> onlySequenceSegment = (ReadOnlySequenceSegment<T>) @object;
      int num = onlySequenceSegment.Memory.Length - index1;
      if ((long) num <= offset)
      {
        if (num < 0)
          ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
        return ReadOnlySequence<T>.SeekMultiSegment(onlySequenceSegment.Next, endObject, index2, offset - (long) num, argument);
      }
    }
    else if ((long) (index2 - index1) < offset)
      ThrowHelper.ThrowArgumentOutOfRangeException(argument);
    return new SequencePosition(@object, index1 + (int) offset);
  }

  private static SequencePosition SeekMultiSegment(
    ReadOnlySequenceSegment<T> currentSegment,
    object endObject,
    int endIndex,
    long offset,
    ExceptionArgument argument)
  {
    for (; currentSegment != null && currentSegment != endObject; currentSegment = currentSegment.Next)
    {
      int length = currentSegment.Memory.Length;
      if ((long) length <= offset)
        offset -= (long) length;
      else
        goto label_6;
    }
    if (currentSegment == null || (long) endIndex < offset)
      ThrowHelper.ThrowArgumentOutOfRangeException(argument);
label_6:
    return new SequencePosition((object) currentSegment, (int) offset);
  }

  private void BoundsCheck([System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref SequencePosition position)
  {
    uint index1 = (uint) ReadOnlySequence<T>.GetIndex(ref position);
    uint index2 = (uint) ReadOnlySequence<T>.GetIndex(ref this._sequenceStart);
    uint index3 = (uint) ReadOnlySequence<T>.GetIndex(ref this._sequenceEnd);
    object obj1 = this._sequenceStart.GetObject();
    object obj2 = this._sequenceEnd.GetObject();
    if (obj1 == obj2)
    {
      if (ReadOnlySequence<T>.InRange(index1, index2, index3))
        return;
      ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
    }
    else
    {
      ulong start = (ulong) ((ReadOnlySequenceSegment<T>) obj1).RunningIndex + (ulong) index2;
      if (ReadOnlySequence<T>.InRange((ulong) ((ReadOnlySequenceSegment<T>) position.GetObject()).RunningIndex + (ulong) index1, start, (ulong) ((ReadOnlySequenceSegment<T>) obj2).RunningIndex + (ulong) index3))
        return;
      ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
    }
  }

  private void BoundsCheck(
    uint sliceStartIndex,
    object sliceStartObject,
    uint sliceEndIndex,
    object sliceEndObject)
  {
    uint index1 = (uint) ReadOnlySequence<T>.GetIndex(ref this._sequenceStart);
    uint index2 = (uint) ReadOnlySequence<T>.GetIndex(ref this._sequenceEnd);
    object obj1 = this._sequenceStart.GetObject();
    object obj2 = this._sequenceEnd.GetObject();
    if (obj1 == obj2)
    {
      if (sliceStartObject == sliceEndObject && sliceStartObject == obj1 && sliceStartIndex <= sliceEndIndex && sliceStartIndex >= index1 && sliceEndIndex <= index2)
        return;
      ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
    }
    else
    {
      ulong num1 = (ulong) ((ReadOnlySequenceSegment<T>) sliceStartObject).RunningIndex + (ulong) sliceStartIndex;
      ulong num2 = (ulong) ((ReadOnlySequenceSegment<T>) sliceEndObject).RunningIndex + (ulong) sliceEndIndex;
      if (num1 > num2)
        ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
      if (num1 >= (ulong) ((ReadOnlySequenceSegment<T>) obj1).RunningIndex + (ulong) index1 && num2 <= (ulong) ((ReadOnlySequenceSegment<T>) obj2).RunningIndex + (ulong) index2)
        return;
      ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
    }
  }

  private static SequencePosition GetEndPosition(
    ReadOnlySequenceSegment<T> startSegment,
    object startObject,
    int startIndex,
    object endObject,
    int endIndex,
    long length)
  {
    int num = startSegment.Memory.Length - startIndex;
    if ((long) num > length)
      return new SequencePosition(startObject, startIndex + (int) length);
    if (num < 0)
      ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
    return ReadOnlySequence<T>.SeekMultiSegment(startSegment.Next, endObject, endIndex, length - (long) num, ExceptionArgument.length);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private ReadOnlySequence<T>.SequenceType GetSequenceType()
  {
    return (ReadOnlySequence<T>.SequenceType) -(2 * (this._sequenceStart.GetInteger() >> 31 /*0x1F*/) + (this._sequenceEnd.GetInteger() >> 31 /*0x1F*/));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static int GetIndex([System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref SequencePosition position)
  {
    return position.GetInteger() & int.MaxValue;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private ReadOnlySequence<T> SliceImpl([System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref SequencePosition start, [System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref SequencePosition end)
  {
    return new ReadOnlySequence<T>(start.GetObject(), ReadOnlySequence<T>.GetIndex(ref start) | this._sequenceStart.GetInteger() & int.MinValue, end.GetObject(), ReadOnlySequence<T>.GetIndex(ref end) | this._sequenceEnd.GetInteger() & int.MinValue);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private long GetLength()
  {
    int index1 = ReadOnlySequence<T>.GetIndex(ref this._sequenceStart);
    int index2 = ReadOnlySequence<T>.GetIndex(ref this._sequenceEnd);
    object obj1 = this._sequenceStart.GetObject();
    object obj2 = this._sequenceEnd.GetObject();
    if (obj1 == obj2)
      return (long) (index2 - index1);
    ReadOnlySequenceSegment<T> onlySequenceSegment = (ReadOnlySequenceSegment<T>) obj1;
    return ((ReadOnlySequenceSegment<T>) obj2).RunningIndex + (long) index2 - (onlySequenceSegment.RunningIndex + (long) index1);
  }

  internal bool TryGetReadOnlySequenceSegment(
    out ReadOnlySequenceSegment<T> startSegment,
    out int startIndex,
    out ReadOnlySequenceSegment<T> endSegment,
    out int endIndex)
  {
    object obj = this._sequenceStart.GetObject();
    if (obj != null && this.GetSequenceType() == ReadOnlySequence<T>.SequenceType.MultiSegment)
    {
      startSegment = (ReadOnlySequenceSegment<T>) obj;
      startIndex = ReadOnlySequence<T>.GetIndex(ref this._sequenceStart);
      endSegment = (ReadOnlySequenceSegment<T>) this._sequenceEnd.GetObject();
      endIndex = ReadOnlySequence<T>.GetIndex(ref this._sequenceEnd);
      return true;
    }
    startSegment = (ReadOnlySequenceSegment<T>) null;
    startIndex = 0;
    endSegment = (ReadOnlySequenceSegment<T>) null;
    endIndex = 0;
    return false;
  }

  internal bool TryGetArray(out ArraySegment<T> segment)
  {
    if (this.GetSequenceType() != ReadOnlySequence<T>.SequenceType.Array)
    {
      segment = new ArraySegment<T>();
      return false;
    }
    int index = ReadOnlySequence<T>.GetIndex(ref this._sequenceStart);
    segment = new ArraySegment<T>((T[]) this._sequenceStart.GetObject(), index, ReadOnlySequence<T>.GetIndex(ref this._sequenceEnd) - index);
    return true;
  }

  internal bool TryGetString(out string text, out int start, out int length)
  {
    if (!(typeof (T) != typeof (char)) && this.GetSequenceType() == ReadOnlySequence<T>.SequenceType.String)
    {
      start = ReadOnlySequence<T>.GetIndex(ref this._sequenceStart);
      length = ReadOnlySequence<T>.GetIndex(ref this._sequenceEnd) - start;
      text = (string) this._sequenceStart.GetObject();
      return true;
    }
    start = 0;
    length = 0;
    text = (string) null;
    return false;
  }

  private static bool InRange(uint value, uint start, uint end) => value - start <= end - start;

  private static bool InRange(ulong value, ulong start, ulong end) => value - start <= end - start;

  public struct Enumerator
  {
    private readonly ReadOnlySequence<T> _sequence;
    private SequencePosition _next;
    private ReadOnlyMemory<T> _currentMemory;

    public Enumerator([System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref ReadOnlySequence<T> sequence)
    {
      this._currentMemory = new ReadOnlyMemory<T>();
      this._next = sequence.Start;
      this._sequence = sequence;
    }

    public ReadOnlyMemory<T> Current => this._currentMemory;

    public bool MoveNext()
    {
      return this._next.GetObject() != null && this._sequence.TryGet(ref this._next, out this._currentMemory);
    }
  }

  private enum SequenceType
  {
    MultiSegment,
    Array,
    MemoryManager,
    String,
    Empty,
  }
}
