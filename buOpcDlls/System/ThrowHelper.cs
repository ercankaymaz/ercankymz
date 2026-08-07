// Decompiled with JetBrains decompiler
// Type: System.ThrowHelper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Buffers;

#nullable disable
namespace System;

internal static class ThrowHelper
{
  internal static void ThrowArgumentNullException(ExceptionArgument argument)
  {
    throw ThrowHelper.CreateArgumentNullException(argument);
  }

  private static Exception CreateArgumentNullException(ExceptionArgument argument)
  {
    return (Exception) new ArgumentNullException(argument.ToString());
  }

  internal static void ThrowArrayTypeMismatchException()
  {
    throw ThrowHelper.CreateArrayTypeMismatchException();
  }

  private static Exception CreateArrayTypeMismatchException()
  {
    return (Exception) new ArrayTypeMismatchException();
  }

  internal static void ThrowArgumentException_InvalidTypeWithPointersNotSupported(Type type)
  {
    throw ThrowHelper.CreateArgumentException_InvalidTypeWithPointersNotSupported(type);
  }

  private static Exception CreateArgumentException_InvalidTypeWithPointersNotSupported(Type type)
  {
    return (Exception) new ArgumentException(System.System.Memory3568249.SR.Format(System.System.Memory3568249.SR.Argument_InvalidTypeWithPointersNotSupported, (object) type));
  }

  internal static void ThrowArgumentException_DestinationTooShort()
  {
    throw ThrowHelper.CreateArgumentException_DestinationTooShort();
  }

  private static Exception CreateArgumentException_DestinationTooShort()
  {
    return (Exception) new ArgumentException(System.System.Memory3568249.SR.Argument_DestinationTooShort);
  }

  internal static void ThrowIndexOutOfRangeException()
  {
    throw ThrowHelper.CreateIndexOutOfRangeException();
  }

  private static Exception CreateIndexOutOfRangeException()
  {
    return (Exception) new IndexOutOfRangeException();
  }

  internal static void ThrowArgumentOutOfRangeException()
  {
    throw ThrowHelper.CreateArgumentOutOfRangeException();
  }

  private static Exception CreateArgumentOutOfRangeException()
  {
    return (Exception) new ArgumentOutOfRangeException();
  }

  internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument)
  {
    throw ThrowHelper.CreateArgumentOutOfRangeException(argument);
  }

  private static Exception CreateArgumentOutOfRangeException(ExceptionArgument argument)
  {
    return (Exception) new ArgumentOutOfRangeException(argument.ToString());
  }

  internal static void ThrowArgumentOutOfRangeException_PrecisionTooLarge()
  {
    throw ThrowHelper.CreateArgumentOutOfRangeException_PrecisionTooLarge();
  }

  private static Exception CreateArgumentOutOfRangeException_PrecisionTooLarge()
  {
    return (Exception) new ArgumentOutOfRangeException("precision", System.System.Memory3568249.SR.Format(System.System.Memory3568249.SR.Argument_PrecisionTooLarge, (object) (byte) 99));
  }

  internal static void ThrowArgumentOutOfRangeException_SymbolDoesNotFit()
  {
    throw ThrowHelper.CreateArgumentOutOfRangeException_SymbolDoesNotFit();
  }

  private static Exception CreateArgumentOutOfRangeException_SymbolDoesNotFit()
  {
    return (Exception) new ArgumentOutOfRangeException("symbol", System.System.Memory3568249.SR.Argument_BadFormatSpecifier);
  }

  internal static void ThrowInvalidOperationException()
  {
    throw ThrowHelper.CreateInvalidOperationException();
  }

  private static Exception CreateInvalidOperationException()
  {
    return (Exception) new InvalidOperationException();
  }

  internal static void ThrowInvalidOperationException_OutstandingReferences()
  {
    throw ThrowHelper.CreateInvalidOperationException_OutstandingReferences();
  }

  private static Exception CreateInvalidOperationException_OutstandingReferences()
  {
    return (Exception) new InvalidOperationException(System.System.Memory3568249.SR.OutstandingReferences);
  }

  internal static void ThrowInvalidOperationException_UnexpectedSegmentType()
  {
    throw ThrowHelper.CreateInvalidOperationException_UnexpectedSegmentType();
  }

  private static Exception CreateInvalidOperationException_UnexpectedSegmentType()
  {
    return (Exception) new InvalidOperationException(System.System.Memory3568249.SR.UnexpectedSegmentType);
  }

  internal static void ThrowInvalidOperationException_EndPositionNotReached()
  {
    throw ThrowHelper.CreateInvalidOperationException_EndPositionNotReached();
  }

  private static Exception CreateInvalidOperationException_EndPositionNotReached()
  {
    return (Exception) new InvalidOperationException(System.System.Memory3568249.SR.EndPositionNotReached);
  }

  internal static void ThrowArgumentOutOfRangeException_PositionOutOfRange()
  {
    throw ThrowHelper.CreateArgumentOutOfRangeException_PositionOutOfRange();
  }

  private static Exception CreateArgumentOutOfRangeException_PositionOutOfRange()
  {
    return (Exception) new ArgumentOutOfRangeException("position");
  }

  internal static void ThrowArgumentOutOfRangeException_OffsetOutOfRange()
  {
    throw ThrowHelper.CreateArgumentOutOfRangeException_OffsetOutOfRange();
  }

  private static Exception CreateArgumentOutOfRangeException_OffsetOutOfRange()
  {
    return (Exception) new ArgumentOutOfRangeException("offset");
  }

  internal static void ThrowObjectDisposedException_ArrayMemoryPoolBuffer()
  {
    throw ThrowHelper.CreateObjectDisposedException_ArrayMemoryPoolBuffer();
  }

  private static Exception CreateObjectDisposedException_ArrayMemoryPoolBuffer()
  {
    return (Exception) new ObjectDisposedException("ArrayMemoryPoolBuffer");
  }

  internal static void ThrowFormatException_BadFormatSpecifier()
  {
    throw ThrowHelper.CreateFormatException_BadFormatSpecifier();
  }

  private static Exception CreateFormatException_BadFormatSpecifier()
  {
    return (Exception) new FormatException(System.System.Memory3568249.SR.Argument_BadFormatSpecifier);
  }

  internal static void ThrowArgumentException_OverlapAlignmentMismatch()
  {
    throw ThrowHelper.CreateArgumentException_OverlapAlignmentMismatch();
  }

  private static Exception CreateArgumentException_OverlapAlignmentMismatch()
  {
    return (Exception) new ArgumentException(System.System.Memory3568249.SR.Argument_OverlapAlignmentMismatch);
  }

  internal static void ThrowNotSupportedException()
  {
    throw ThrowHelper.CreateThrowNotSupportedException();
  }

  private static Exception CreateThrowNotSupportedException()
  {
    return (Exception) new NotSupportedException();
  }

  public static bool TryFormatThrowFormatException(out int bytesWritten)
  {
    bytesWritten = 0;
    ThrowHelper.ThrowFormatException_BadFormatSpecifier();
    return false;
  }

  public static bool TryParseThrowFormatException<T>(out T value, out int bytesConsumed)
  {
    value = default (T);
    bytesConsumed = 0;
    ThrowHelper.ThrowFormatException_BadFormatSpecifier();
    return false;
  }

  public static void ThrowArgumentValidationException<T>(
    ReadOnlySequenceSegment<T> startSegment,
    int startIndex,
    ReadOnlySequenceSegment<T> endSegment)
  {
    throw ThrowHelper.CreateArgumentValidationException<T>(startSegment, startIndex, endSegment);
  }

  private static Exception CreateArgumentValidationException<T>(
    ReadOnlySequenceSegment<T> startSegment,
    int startIndex,
    ReadOnlySequenceSegment<T> endSegment)
  {
    if (startSegment == null)
      return ThrowHelper.CreateArgumentNullException(ExceptionArgument.startSegment);
    if (endSegment == null)
      return ThrowHelper.CreateArgumentNullException(ExceptionArgument.endSegment);
    if (startSegment != endSegment && startSegment.RunningIndex > endSegment.RunningIndex)
      return ThrowHelper.CreateArgumentOutOfRangeException(ExceptionArgument.endSegment);
    return (uint) startSegment.Memory.Length < (uint) startIndex ? ThrowHelper.CreateArgumentOutOfRangeException(ExceptionArgument.startIndex) : ThrowHelper.CreateArgumentOutOfRangeException(ExceptionArgument.endIndex);
  }

  public static void ThrowArgumentValidationException(Array array, int start)
  {
    throw ThrowHelper.CreateArgumentValidationException(array, start);
  }

  private static Exception CreateArgumentValidationException(Array array, int start)
  {
    if (array == null)
      return ThrowHelper.CreateArgumentNullException(ExceptionArgument.array);
    return (uint) start > (uint) array.Length ? ThrowHelper.CreateArgumentOutOfRangeException(ExceptionArgument.start) : ThrowHelper.CreateArgumentOutOfRangeException(ExceptionArgument.length);
  }

  public static void ThrowStartOrEndArgumentValidationException(long start)
  {
    throw ThrowHelper.CreateStartOrEndArgumentValidationException(start);
  }

  private static Exception CreateStartOrEndArgumentValidationException(long start)
  {
    return start < 0L ? ThrowHelper.CreateArgumentOutOfRangeException(ExceptionArgument.start) : ThrowHelper.CreateArgumentOutOfRangeException(ExceptionArgument.length);
  }
}
