// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.AsnDecoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Buffers.Binary;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices.System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace System.Formats.Asn1;

[ComVisible(true)]
public static class AsnDecoder
{
  internal const int MaxCERSegmentSize = 1000;
  internal const int EndOfContentsEncodedLength = 2;

  public static bool TryReadEncodedValue(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out Asn1Tag tag,
    out int contentOffset,
    out int contentLength,
    out int bytesConsumed)
  {
    AsnDecoder.CheckEncodingRules(ruleSet);
    Asn1Tag tag1;
    int bytesConsumed1;
    int? length;
    int bytesRead;
    if (Asn1Tag.TryDecode(source, out tag1, out bytesConsumed1) && AsnDecoder.TryReadLength(source.Slice(bytesConsumed1), ruleSet, out length, out bytesRead))
    {
      int start = bytesConsumed1 + bytesRead;
      int actualLength;
      int bytesConsumed2;
      if (AsnDecoder.ValidateLength(source.Slice(start), ruleSet, tag1, length, out actualLength, out bytesConsumed2) == AsnDecoder.LengthValidity.Valid)
      {
        tag = tag1;
        contentOffset = start;
        contentLength = actualLength;
        bytesConsumed = start + bytesConsumed2;
        return true;
      }
    }
    tag = new Asn1Tag();
    ref int local1 = ref contentOffset;
    ref int local2 = ref contentLength;
    bytesConsumed = 0;
    local2 = 0;
    local1 = 0;
    return false;
  }

  public static Asn1Tag ReadEncodedValue(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int contentOffset,
    out int contentLength,
    out int bytesConsumed)
  {
    AsnDecoder.CheckEncodingRules(ruleSet);
    int bytesConsumed1;
    Asn1Tag localTag = Asn1Tag.Decode(source, out bytesConsumed1);
    int bytesConsumed2;
    int? encodedLength = AsnDecoder.ReadLength(source.Slice(bytesConsumed1), ruleSet, out bytesConsumed2);
    int start = bytesConsumed1 + bytesConsumed2;
    int actualLength;
    int bytesConsumed3;
    AsnDecoder.LengthValidity validity = AsnDecoder.ValidateLength(source.Slice(start), ruleSet, localTag, encodedLength, out actualLength, out bytesConsumed3);
    if (validity != AsnDecoder.LengthValidity.Valid)
      throw AsnDecoder.GetValidityException(validity);
    contentOffset = start;
    contentLength = actualLength;
    bytesConsumed = start + bytesConsumed3;
    return localTag;
  }

  private static ReadOnlySpan<byte> GetPrimitiveContentSpan(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Asn1Tag expectedTag,
    UniversalTagNumber tagNumber,
    out int bytesConsumed)
  {
    AsnDecoder.CheckEncodingRules(ruleSet);
    int bytesConsumed1;
    Asn1Tag tag = Asn1Tag.Decode(source, out bytesConsumed1);
    int bytesConsumed2;
    int? nullable = AsnDecoder.ReadLength(source.Slice(bytesConsumed1), ruleSet, out bytesConsumed2);
    int offset = bytesConsumed1 + bytesConsumed2;
    AsnDecoder.CheckExpectedTag(tag, expectedTag, tagNumber);
    if (tag.IsConstructed)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.Format(System.System.Formats.Asn13538873.SR.ContentException_PrimitiveEncodingRequired, (object) tagNumber));
    if (!nullable.HasValue)
      throw new AsnContentException();
    ReadOnlySpan<byte> primitiveContentSpan = AsnDecoder.Slice(source, offset, nullable.Value);
    bytesConsumed = offset + primitiveContentSpan.Length;
    return primitiveContentSpan;
  }

  private static bool TryReadLength(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int? length,
    out int bytesRead)
  {
    return AsnDecoder.DecodeLength(source, ruleSet, out length, out bytesRead) == AsnDecoder.LengthDecodeStatus.Success;
  }

  private static int? ReadLength(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed)
  {
    int? length;
    switch (AsnDecoder.DecodeLength(source, ruleSet, out length, out bytesConsumed))
    {
      case AsnDecoder.LengthDecodeStatus.DerIndefinite:
      case AsnDecoder.LengthDecodeStatus.LaxEncodingProhibited:
        throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_LengthRuleSetConstraint);
      case AsnDecoder.LengthDecodeStatus.LengthTooBig:
        throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_LengthTooBig);
      case AsnDecoder.LengthDecodeStatus.Success:
        return length;
      default:
        throw new AsnContentException();
    }
  }

  private static AsnDecoder.LengthDecodeStatus DecodeLength(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int? length,
    out int bytesRead)
  {
    length = new int?();
    bytesRead = 0;
    if (source.IsEmpty)
      return AsnDecoder.LengthDecodeStatus.NeedMoreData;
    byte num1 = source[bytesRead];
    ++bytesRead;
    if (num1 == (byte) 128 /*0x80*/)
    {
      if (ruleSet != AsnEncodingRules.DER)
        return AsnDecoder.LengthDecodeStatus.Success;
      bytesRead = 0;
      return AsnDecoder.LengthDecodeStatus.DerIndefinite;
    }
    if (num1 < (byte) 128 /*0x80*/)
    {
      length = new int?((int) num1);
      return AsnDecoder.LengthDecodeStatus.Success;
    }
    if (num1 == byte.MaxValue)
    {
      bytesRead = 0;
      return AsnDecoder.LengthDecodeStatus.ReservedValue;
    }
    byte num2 = (byte) ((uint) num1 & 4294967167U);
    if ((int) num2 + 1 > source.Length)
    {
      bytesRead = 0;
      return AsnDecoder.LengthDecodeStatus.NeedMoreData;
    }
    bool flag;
    if ((flag = ruleSet == AsnEncodingRules.DER || ruleSet == AsnEncodingRules.CER) && num2 > (byte) 4)
    {
      bytesRead = 0;
      return AsnDecoder.LengthDecodeStatus.LengthTooBig;
    }
    uint num3 = 0;
    for (int index = 0; index < (int) num2; ++index)
    {
      byte num4 = source[bytesRead];
      ++bytesRead;
      if (num3 == 0U)
      {
        if (!flag || num4 != (byte) 0)
        {
          if (!flag && num4 != (byte) 0 && (int) num2 - index > 4)
          {
            bytesRead = 0;
            return AsnDecoder.LengthDecodeStatus.LengthTooBig;
          }
        }
        else
        {
          bytesRead = 0;
          return AsnDecoder.LengthDecodeStatus.LaxEncodingProhibited;
        }
      }
      num3 = num3 << 8 | (uint) num4;
    }
    if (num3 > (uint) int.MaxValue)
    {
      bytesRead = 0;
      return AsnDecoder.LengthDecodeStatus.LengthTooBig;
    }
    if (flag && num3 < 128U /*0x80*/)
    {
      bytesRead = 0;
      return AsnDecoder.LengthDecodeStatus.LaxEncodingProhibited;
    }
    length = new int?((int) num3);
    return AsnDecoder.LengthDecodeStatus.Success;
  }

  private static Asn1Tag ReadTagAndLength(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int? contentsLength,
    out int bytesRead)
  {
    int bytesConsumed1;
    Asn1Tag asn1Tag = Asn1Tag.Decode(source, out bytesConsumed1);
    int bytesConsumed2;
    int? nullable = AsnDecoder.ReadLength(source.Slice(bytesConsumed1), ruleSet, out bytesConsumed2);
    int num = bytesConsumed1 + bytesConsumed2;
    if (asn1Tag.IsConstructed)
    {
      if (ruleSet == AsnEncodingRules.CER && nullable.HasValue)
        throw AsnDecoder.GetValidityException(AsnDecoder.LengthValidity.CerRequiresIndefinite);
    }
    else if (!nullable.HasValue)
      throw AsnDecoder.GetValidityException(AsnDecoder.LengthValidity.PrimitiveEncodingRequiresDefinite);
    bytesRead = num;
    contentsLength = nullable;
    return asn1Tag;
  }

  private static void ValidateEndOfContents(Asn1Tag tag, int? length, int headerLength)
  {
    if (!tag.IsConstructed)
    {
      int? nullable = length;
      if (nullable.GetValueOrDefault() == 0 & nullable.HasValue && headerLength == 2)
        return;
    }
    throw new AsnContentException();
  }

  private static AsnDecoder.LengthValidity ValidateLength(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Asn1Tag localTag,
    int? encodedLength,
    out int actualLength,
    out int bytesConsumed)
  {
    if (localTag.IsConstructed)
    {
      if (ruleSet == AsnEncodingRules.CER && encodedLength.HasValue)
      {
        ref int local = ref actualLength;
        bytesConsumed = 0;
        local = 0;
        return AsnDecoder.LengthValidity.CerRequiresIndefinite;
      }
    }
    else if (!encodedLength.HasValue)
    {
      ref int local = ref actualLength;
      bytesConsumed = 0;
      local = 0;
      return AsnDecoder.LengthValidity.PrimitiveEncodingRequiresDefinite;
    }
    if (encodedLength.HasValue)
    {
      int num = encodedLength.Value;
      if (num > source.Length)
      {
        ref int local = ref actualLength;
        bytesConsumed = 0;
        local = 0;
        return AsnDecoder.LengthValidity.LengthExceedsInput;
      }
      actualLength = num;
      bytesConsumed = num;
      return AsnDecoder.LengthValidity.Valid;
    }
    actualLength = AsnDecoder.SeekEndOfContents(source, ruleSet);
    bytesConsumed = actualLength + 2;
    return AsnDecoder.LengthValidity.Valid;
  }

  private static AsnContentException GetValidityException(AsnDecoder.LengthValidity validity)
  {
    switch (validity)
    {
      case AsnDecoder.LengthValidity.CerRequiresIndefinite:
        return new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_CerRequiresIndefiniteLength);
      case AsnDecoder.LengthValidity.LengthExceedsInput:
        return new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_LengthExceedsPayload);
      default:
        return new AsnContentException();
    }
  }

  private static int GetPrimitiveIntegerSize(Type primitiveType)
  {
    if (primitiveType == typeof (byte) || primitiveType == typeof (sbyte))
      return 1;
    if (primitiveType == typeof (short) || primitiveType == typeof (ushort))
      return 2;
    if (primitiveType == typeof (int) || primitiveType == typeof (uint))
      return 4;
    return !(primitiveType == typeof (long)) && !(primitiveType == typeof (ulong)) ? 0 : 8;
  }

  private static int SeekEndOfContents(ReadOnlySpan<byte> source, AsnEncodingRules ruleSet)
  {
    ReadOnlySpan<byte> source1 = source;
    int num1 = 0;
    int num2 = 1;
    while (!source1.IsEmpty)
    {
      int? contentsLength;
      int bytesRead;
      Asn1Tag tag = AsnDecoder.ReadTagAndLength(source1, ruleSet, out contentsLength, out bytesRead);
      if (tag == Asn1Tag.EndOfContents)
      {
        AsnDecoder.ValidateEndOfContents(tag, contentsLength, bytesRead);
        --num2;
        if (num2 == 0)
          return num1;
      }
      if (!contentsLength.HasValue)
      {
        ++num2;
        source1 = source1.Slice(bytesRead);
        num1 += bytesRead;
      }
      else
      {
        ReadOnlySpan<byte> readOnlySpan = AsnDecoder.Slice(source1, 0, bytesRead + contentsLength.Value);
        source1 = source1.Slice(readOnlySpan.Length);
        num1 += readOnlySpan.Length;
      }
    }
    throw new AsnContentException();
  }

  private static int ParseNonNegativeIntAndSlice(ref ReadOnlySpan<byte> data, int bytesToRead)
  {
    int nonNegativeInt = AsnDecoder.ParseNonNegativeInt(AsnDecoder.Slice(data, 0, bytesToRead));
    data = data.Slice(bytesToRead);
    return nonNegativeInt;
  }

  private static int ParseNonNegativeInt(ReadOnlySpan<byte> data)
  {
    uint nonNegativeInt;
    int bytesConsumed;
    if (!Utf8Parser.TryParse(data, out nonNegativeInt, out bytesConsumed) || nonNegativeInt > (uint) int.MaxValue || bytesConsumed != data.Length)
      throw new AsnContentException();
    return (int) nonNegativeInt;
  }

  private static ReadOnlySpan<byte> SliceAtMost(ReadOnlySpan<byte> source, int longestPermitted)
  {
    int length = Math.Min(longestPermitted, source.Length);
    return source.Slice(0, length);
  }

  private static ReadOnlySpan<byte> Slice(ReadOnlySpan<byte> source, int offset, int length)
  {
    if (length < 0 || source.Length - offset < length)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_LengthExceedsPayload);
    return source.Slice(offset, length);
  }

  private static ReadOnlySpan<byte> Slice(ReadOnlySpan<byte> source, int offset, int? length)
  {
    if (!length.HasValue)
      return source.Slice(offset);
    int length1 = length.Value;
    if (length1 < 0 || source.Length - offset < length1)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_LengthExceedsPayload);
    return source.Slice(offset, length1);
  }

  internal static ReadOnlyMemory<byte> Slice(
    ReadOnlyMemory<byte> bigger,
    ReadOnlySpan<byte> smaller)
  {
    if (smaller.IsEmpty)
      return new ReadOnlyMemory<byte>();
    int elementOffset;
    if (!bigger.Span.Overlaps<byte>(smaller, out elementOffset))
      throw new AsnContentException();
    return bigger.Slice(elementOffset, smaller.Length);
  }

  [Conditional("DEBUG")]
  private static void AssertEncodingRules(AsnEncodingRules ruleSet)
  {
  }

  internal static void CheckEncodingRules(AsnEncodingRules ruleSet)
  {
    if (ruleSet != AsnEncodingRules.BER && ruleSet != AsnEncodingRules.CER && ruleSet != AsnEncodingRules.DER)
      throw new ArgumentOutOfRangeException(nameof (ruleSet));
  }

  private static void CheckExpectedTag(
    Asn1Tag tag,
    Asn1Tag expectedTag,
    UniversalTagNumber tagNumber)
  {
    if (expectedTag.TagClass == TagClass.Universal && (UniversalTagNumber) expectedTag.TagValue != tagNumber)
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_UniversalValueIsFixed, nameof (expectedTag));
    if (expectedTag.TagClass != tag.TagClass || expectedTag.TagValue != tag.TagValue)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.Format(System.System.Formats.Asn13538873.SR.ContentException_WrongTag, (object) tag.TagClass, (object) tag.TagValue, (object) expectedTag.TagClass, (object) expectedTag.TagValue));
  }

  public static bool TryReadPrimitiveBitString(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int unusedBitCount,
    out ReadOnlySpan<byte> value,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    int unusedBitCount1;
    ReadOnlySpan<byte> readOnlySpan;
    int bytesConsumed1;
    byte normalizedLastByte;
    if (AsnDecoder.TryReadPrimitiveBitStringCore(source, ruleSet, expectedTag ?? Asn1Tag.PrimitiveBitString, out int? _, out int _, out unusedBitCount1, out readOnlySpan, out bytesConsumed1, out normalizedLastByte) && (readOnlySpan.Length == 0 || (int) normalizedLastByte == (int) readOnlySpan[readOnlySpan.Length - 1]))
    {
      unusedBitCount = unusedBitCount1;
      value = readOnlySpan;
      bytesConsumed = bytesConsumed1;
      return true;
    }
    unusedBitCount = 0;
    value = new ReadOnlySpan<byte>();
    bytesConsumed = 0;
    return false;
  }

  public static bool TryReadBitString(
    ReadOnlySpan<byte> source,
    Span<byte> destination,
    AsnEncodingRules ruleSet,
    out int unusedBitCount,
    out int bytesConsumed,
    out int bytesWritten,
    Asn1Tag? expectedTag = null)
  {
    if (source.Overlaps<byte>((ReadOnlySpan<byte>) destination))
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_SourceOverlapsDestination, nameof (destination));
    int? contentsLength;
    int headerLength;
    int unusedBitCount1;
    ReadOnlySpan<byte> readOnlySpan;
    int bytesConsumed1;
    byte normalizedLastByte;
    if (AsnDecoder.TryReadPrimitiveBitStringCore(source, ruleSet, expectedTag ?? Asn1Tag.PrimitiveBitString, out contentsLength, out headerLength, out unusedBitCount1, out readOnlySpan, out bytesConsumed1, out normalizedLastByte))
    {
      if (readOnlySpan.Length > destination.Length)
      {
        bytesConsumed = 0;
        bytesWritten = 0;
        unusedBitCount = 0;
        return false;
      }
      AsnDecoder.CopyBitStringValue(readOnlySpan, normalizedLastByte, destination);
      bytesWritten = readOnlySpan.Length;
      bytesConsumed = bytesConsumed1;
      unusedBitCount = unusedBitCount1;
      return true;
    }
    int bytesRead;
    int bytesWritten1;
    if (AsnDecoder.TryCopyConstructedBitStringValue(AsnDecoder.Slice(source, headerLength, contentsLength), ruleSet, destination, !contentsLength.HasValue, out unusedBitCount1, out bytesRead, out bytesWritten1))
    {
      unusedBitCount = unusedBitCount1;
      bytesConsumed = headerLength + bytesRead;
      bytesWritten = bytesWritten1;
      return true;
    }
    ref int local1 = ref bytesWritten;
    ref int local2 = ref bytesConsumed;
    unusedBitCount = 0;
    local2 = 0;
    local1 = 0;
    return false;
  }

  [return: Nullable(1)]
  public static byte[] ReadBitString(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int unusedBitCount,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    int? contentsLength;
    int headerLength;
    int unusedBitCount1;
    ReadOnlySpan<byte> readOnlySpan;
    int bytesConsumed1;
    byte normalizedLastByte;
    if (AsnDecoder.TryReadPrimitiveBitStringCore(source, ruleSet, expectedTag ?? Asn1Tag.PrimitiveBitString, out contentsLength, out headerLength, out unusedBitCount1, out readOnlySpan, out bytesConsumed1, out normalizedLastByte))
    {
      byte[] array = readOnlySpan.ToArray();
      if (readOnlySpan.Length > 0)
        array[array.Length - 1] = normalizedLastByte;
      unusedBitCount = unusedBitCount1;
      bytesConsumed = bytesConsumed1;
      return array;
    }
    byte[] numArray = CryptoPool.Rent(contentsLength ?? AsnDecoder.SeekEndOfContents(source.Slice(headerLength), ruleSet));
    int bytesRead;
    int bytesWritten;
    if (!AsnDecoder.TryCopyConstructedBitStringValue(AsnDecoder.Slice(source, headerLength, contentsLength), ruleSet, (Span<byte>) numArray, !contentsLength.HasValue, out unusedBitCount1, out bytesRead, out bytesWritten))
      throw new AsnContentException();
    byte[] array1 = numArray.AsSpan<byte>(0, bytesWritten).ToArray();
    CryptoPool.Return(numArray, bytesWritten);
    unusedBitCount = unusedBitCount1;
    bytesConsumed = headerLength + bytesRead;
    return array1;
  }

  private static void ParsePrimitiveBitStringContents(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int unusedBitCount,
    out ReadOnlySpan<byte> value,
    out byte normalizedLastByte)
  {
    if (ruleSet == AsnEncodingRules.CER && source.Length > 1000)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCer_TryBerOrDer);
    if (source.Length == 0)
      throw new AsnContentException();
    unusedBitCount = (int) source[0];
    if (unusedBitCount > 7)
      throw new AsnContentException();
    if (source.Length == 1)
    {
      if (unusedBitCount > 0)
        throw new AsnContentException();
      value = ReadOnlySpan<byte>.Empty;
      normalizedLastByte = (byte) 0;
    }
    else
    {
      int num1 = -1 << unusedBitCount;
      byte num2 = source[source.Length - 1];
      byte num3 = (byte) ((uint) num2 & (uint) num1);
      if ((int) num3 != (int) num2 && (ruleSet == AsnEncodingRules.DER || ruleSet == AsnEncodingRules.CER))
        throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
      normalizedLastByte = num3;
      value = source.Slice(1);
    }
  }

  private static void CopyBitStringValue(
    ReadOnlySpan<byte> value,
    byte normalizedLastByte,
    Span<byte> destination)
  {
    if (value.Length == 0)
      return;
    value.CopyTo(destination);
    destination[value.Length - 1] = normalizedLastByte;
  }

  private static int CountConstructedBitString(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    bool isIndefinite)
  {
    Span<byte> empty = Span<byte>.Empty;
    return AsnDecoder.ProcessConstructedBitString(source, ruleSet, empty, (AsnDecoder.BitStringCopyAction) null, isIndefinite, out int _, out int _);
  }

  private static void CopyConstructedBitString(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Span<byte> destination,
    bool isIndefinite,
    out int unusedBitCount,
    out int bytesRead,
    out int bytesWritten)
  {
    Span<byte> destination1 = destination;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    bytesWritten = AsnDecoder.ProcessConstructedBitString(source, ruleSet, destination1, AsnDecoder.\u003C\u003EO.\u003C0\u003E__CopyBitStringValue ?? (AsnDecoder.\u003C\u003EO.\u003C0\u003E__CopyBitStringValue = new AsnDecoder.BitStringCopyAction(AsnDecoder.CopyBitStringValue)), isIndefinite, out unusedBitCount, out bytesRead);
  }

  private static int ProcessConstructedBitString(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Span<byte> destination,
    AsnDecoder.BitStringCopyAction copyAction,
    bool isIndefinite,
    out int lastUnusedBitCount,
    out int bytesRead)
  {
    lastUnusedBitCount = 0;
    bytesRead = 0;
    int num1 = 1000;
    ReadOnlySpan<byte> readOnlySpan1 = source;
    Stack<(int, int, bool, int)> valueTupleStack = (Stack<(int, int, bool, int)>) null;
    int num2 = 0;
    Asn1Tag tag = Asn1Tag.ConstructedBitString;
    Span<byte> destination1 = destination;
    while (true)
    {
      while (!readOnlySpan1.IsEmpty)
      {
        int? contentsLength;
        int bytesRead1;
        tag = AsnDecoder.ReadTagAndLength(readOnlySpan1, ruleSet, out contentsLength, out bytesRead1);
        if (tag == Asn1Tag.PrimitiveBitString)
        {
          if (lastUnusedBitCount != 0)
            throw new AsnContentException();
          if (ruleSet == AsnEncodingRules.CER && num1 != 1000)
            throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCer_TryBerOrDer);
          ReadOnlySpan<byte> source1 = AsnDecoder.Slice(readOnlySpan1, bytesRead1, contentsLength.Value);
          ReadOnlySpan<byte> readOnlySpan2;
          byte normalizedLastByte;
          AsnDecoder.ParsePrimitiveBitStringContents(source1, ruleSet, out lastUnusedBitCount, out readOnlySpan2, out normalizedLastByte);
          int start = bytesRead1 + source1.Length;
          readOnlySpan1 = readOnlySpan1.Slice(start);
          bytesRead += start;
          num2 += readOnlySpan2.Length;
          num1 = source1.Length;
          if (copyAction != null)
          {
            copyAction(readOnlySpan2, normalizedLastByte, destination1);
            destination1 = destination1.Slice(readOnlySpan2.Length);
          }
        }
        else if (tag == Asn1Tag.EndOfContents & isIndefinite)
        {
          AsnDecoder.ValidateEndOfContents(tag, contentsLength, bytesRead1);
          bytesRead += bytesRead1;
          // ISSUE: explicit non-virtual call
          if (valueTupleStack != null && __nonvirtual (valueTupleStack.Count) > 0)
          {
            (int start, int length, bool flag, int num3) = valueTupleStack.Pop();
            readOnlySpan1 = source.Slice(start, length).Slice(bytesRead);
            bytesRead += num3;
            isIndefinite = flag;
          }
          else
            break;
        }
        else
        {
          if (!(tag == Asn1Tag.ConstructedBitString))
            throw new AsnContentException();
          if (ruleSet == AsnEncodingRules.CER)
            throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
          if (valueTupleStack == null)
            valueTupleStack = new Stack<(int, int, bool, int)>();
          int elementOffset;
          if (!source.Overlaps<byte>(readOnlySpan1, out elementOffset))
            throw new AsnContentException();
          valueTupleStack.Push((elementOffset, readOnlySpan1.Length, isIndefinite, bytesRead));
          readOnlySpan1 = AsnDecoder.Slice(readOnlySpan1, bytesRead1, contentsLength);
          bytesRead = bytesRead1;
          isIndefinite = !contentsLength.HasValue;
        }
      }
      if (!isIndefinite || !(tag != Asn1Tag.EndOfContents))
      {
        // ISSUE: explicit non-virtual call
        if (valueTupleStack != null && __nonvirtual (valueTupleStack.Count) > 0)
        {
          (int start, int length, bool flag, int num4) = valueTupleStack.Pop();
          readOnlySpan1 = source.Slice(start, length).Slice(bytesRead);
          isIndefinite = flag;
          bytesRead += num4;
        }
        else
          goto label_25;
      }
      else
        break;
    }
    throw new AsnContentException();
label_25:
    return num2;
  }

  private static bool TryCopyConstructedBitStringValue(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Span<byte> dest,
    bool isIndefinite,
    out int unusedBitCount,
    out int bytesRead,
    out int bytesWritten)
  {
    int num = AsnDecoder.CountConstructedBitString(source, ruleSet, isIndefinite);
    if (ruleSet == AsnEncodingRules.CER && num < 1000)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
    if (dest.Length < num)
    {
      unusedBitCount = 0;
      bytesRead = 0;
      bytesWritten = 0;
      return false;
    }
    AsnDecoder.CopyConstructedBitString(source, ruleSet, dest, isIndefinite, out unusedBitCount, out bytesRead, out bytesWritten);
    return true;
  }

  private static bool TryReadPrimitiveBitStringCore(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Asn1Tag expectedTag,
    out int? contentsLength,
    out int headerLength,
    out int unusedBitCount,
    out ReadOnlySpan<byte> value,
    out int bytesConsumed,
    out byte normalizedLastByte)
  {
    Asn1Tag tag = AsnDecoder.ReadTagAndLength(source, ruleSet, out contentsLength, out headerLength);
    AsnDecoder.CheckExpectedTag(tag, expectedTag, UniversalTagNumber.BitString);
    ReadOnlySpan<byte> source1 = AsnDecoder.Slice(source, headerLength, contentsLength);
    if (tag.IsConstructed)
    {
      if (ruleSet == AsnEncodingRules.DER)
        throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderDer_TryBerOrCer);
      unusedBitCount = 0;
      value = new ReadOnlySpan<byte>();
      normalizedLastByte = (byte) 0;
      bytesConsumed = 0;
      return false;
    }
    AsnDecoder.ParsePrimitiveBitStringContents(source1, ruleSet, out unusedBitCount, out value, out normalizedLastByte);
    bytesConsumed = headerLength + source1.Length;
    return true;
  }

  public static bool ReadBoolean(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    int bytesConsumed1;
    ReadOnlySpan<byte> primitiveContentSpan = AsnDecoder.GetPrimitiveContentSpan(source, ruleSet, expectedTag ?? Asn1Tag.Boolean, UniversalTagNumber.Boolean, out bytesConsumed1);
    if (primitiveContentSpan.Length != 1)
      throw new AsnContentException();
    switch (primitiveContentSpan[0])
    {
      case 0:
        bytesConsumed = bytesConsumed1;
        return false;
      case byte.MaxValue:
        bytesConsumed = bytesConsumed1;
        return true;
      default:
        if (ruleSet == AsnEncodingRules.DER || ruleSet == AsnEncodingRules.CER)
          throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
        goto case byte.MaxValue;
    }
  }

  public static ReadOnlySpan<byte> ReadEnumeratedBytes(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    return AsnDecoder.GetIntegerContents(source, ruleSet, expectedTag ?? Asn1Tag.Enumerated, UniversalTagNumber.Enumerated, out bytesConsumed);
  }

  [return: Nullable(1)]
  public static TEnum ReadEnumeratedValue<TEnum>(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
    where TEnum : Enum
  {
    Type enumType = typeof (TEnum);
    return (TEnum) Enum.ToObject(enumType, (object) AsnDecoder.ReadEnumeratedValue(source, ruleSet, enumType, out bytesConsumed, expectedTag));
  }

  [NullableContext(1)]
  public static Enum ReadEnumeratedValue(
    [Nullable(0)] ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Type enumType,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    if (enumType == (Type) null)
      throw new ArgumentNullException(nameof (enumType));
    Asn1Tag expectedTag1 = expectedTag ?? Asn1Tag.Enumerated;
    Type enumUnderlyingType = enumType.GetEnumUnderlyingType();
    if (enumType.IsDefined(typeof (FlagsAttribute), false))
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_EnumeratedValueRequiresNonFlagsEnum, nameof (enumType));
    int primitiveIntegerSize = AsnDecoder.GetPrimitiveIntegerSize(enumUnderlyingType);
    if (!(enumUnderlyingType == typeof (int)) && !(enumUnderlyingType == typeof (long)) && !(enumUnderlyingType == typeof (short)) && !(enumUnderlyingType == typeof (sbyte)))
    {
      if (!(enumUnderlyingType == typeof (uint)) && !(enumUnderlyingType == typeof (ulong)) && !(enumUnderlyingType == typeof (ushort)) && !(enumUnderlyingType == typeof (byte)))
        throw new AsnContentException(System.System.Formats.Asn13538873.SR.Format(System.System.Formats.Asn13538873.SR.Argument_EnumeratedValueBackingTypeNotSupported, (object) enumUnderlyingType.FullName));
      ulong num;
      int bytesConsumed1;
      if (!AsnDecoder.TryReadUnsignedInteger(source, ruleSet, primitiveIntegerSize, expectedTag1, UniversalTagNumber.Enumerated, out num, out bytesConsumed1))
        throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_EnumeratedValueTooBig);
      bytesConsumed = bytesConsumed1;
      return (Enum) Enum.ToObject(enumType, num);
    }
    long num1;
    int bytesConsumed2;
    if (!AsnDecoder.TryReadSignedInteger(source, ruleSet, primitiveIntegerSize, expectedTag1, UniversalTagNumber.Enumerated, out num1, out bytesConsumed2))
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_EnumeratedValueTooBig);
    bytesConsumed = bytesConsumed2;
    return (Enum) Enum.ToObject(enumType, num1);
  }

  public static DateTimeOffset ReadGeneralizedTime(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    byte[] rented = (byte[]) null;
    Span<byte> tmpSpace = stackalloc byte[64 /*0x40*/];
    int bytesConsumed1;
    ReadOnlySpan<byte> octetStringContents = AsnDecoder.GetOctetStringContents(source, ruleSet, expectedTag ?? Asn1Tag.GeneralizedTime, UniversalTagNumber.GeneralizedTime, out bytesConsumed1, ref rented, tmpSpace);
    DateTimeOffset generalizedTime = AsnDecoder.ParseGeneralizedTime(ruleSet, octetStringContents);
    if (rented != null)
      CryptoPool.Return(rented, octetStringContents.Length);
    bytesConsumed = bytesConsumed1;
    return generalizedTime;
  }

  private static DateTimeOffset ParseGeneralizedTime(
    AsnEncodingRules ruleSet,
    ReadOnlySpan<byte> contentOctets)
  {
    bool flag1;
    if ((flag1 = ruleSet == AsnEncodingRules.DER || ruleSet == AsnEncodingRules.CER) && contentOctets.Length < 15)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
    ReadOnlySpan<byte> data = contentOctets.Length >= 10 ? contentOctets : throw new AsnContentException();
    int negativeIntAndSlice1 = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 4);
    int negativeIntAndSlice2 = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
    int negativeIntAndSlice3 = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
    int negativeIntAndSlice4 = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
    int? nullable1 = new int?();
    int? nullable2 = new int?();
    ulong num1 = 0;
    ulong num2 = 1;
    byte num3 = byte.MaxValue;
    TimeSpan? nullable3 = new TimeSpan?();
    bool flag2 = false;
    byte num4 = 0;
    while (num4 == (byte) 0 && data.Length != 0)
    {
      byte? nextState = GetNextState(data[0]);
      if (!nextState.HasValue)
      {
        if (!nullable1.HasValue)
          nullable1 = new int?(AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2));
        else
          nullable2 = !nullable2.HasValue ? new int?(AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2)) : throw new AsnContentException();
      }
      else
        num4 = nextState.Value;
    }
    if (num4 == (byte) 1)
    {
      switch (data[0])
      {
        case 44:
          if (flag1)
            throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
          goto case 46;
        case 46:
          data = data.Slice(1);
          if (data.IsEmpty)
            throw new AsnContentException();
          int bytesConsumed;
          if (!Utf8Parser.TryParse(AsnDecoder.SliceAtMost(data, 12), out num1, out bytesConsumed) || bytesConsumed == 0)
            throw new AsnContentException();
          num3 = (byte) (num1 % 10UL);
          for (int index = 0; index < bytesConsumed; ++index)
            num2 *= 10UL;
          data = data.Slice(bytesConsumed);
          uint num5;
          while (Utf8Parser.TryParse(AsnDecoder.SliceAtMost(data, 9), out num5, out bytesConsumed))
          {
            data = data.Slice(bytesConsumed);
            num3 = (byte) (num5 % 10U);
          }
          if (data.Length != 0)
          {
            num4 = (GetNextState(data[0]) ?? throw new AsnContentException()).Value;
            break;
          }
          break;
        default:
          throw new AsnContentException();
      }
    }
    if (num4 == (byte) 2)
    {
      byte num6 = data[0];
      data = data.Slice(1);
      bool flag3;
      switch (num6)
      {
        case 43:
          flag3 = false;
          break;
        case 45:
          flag3 = true;
          break;
        case 90:
          nullable3 = new TimeSpan?(TimeSpan.Zero);
          flag2 = true;
          goto label_47;
        default:
          throw new AsnContentException();
      }
      int hours = !data.IsEmpty ? AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2) : throw new AsnContentException();
      int minutes = 0;
      if (data.Length != 0)
        minutes = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
      TimeSpan timeSpan = minutes <= 59 ? new TimeSpan(hours, minutes, 0) : throw new AsnContentException();
      if (flag3)
        timeSpan = -timeSpan;
      nullable3 = new TimeSpan?(timeSpan);
    }
label_47:
    if (!data.IsEmpty)
      throw new AsnContentException();
    if (flag1)
    {
      if (!flag2 || !nullable2.HasValue)
        throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
      if (num3 == (byte) 0)
        throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
    }
    double num7 = (double) num1 / (double) num2;
    TimeSpan timeSpan1 = TimeSpan.Zero;
    if (!nullable1.HasValue)
    {
      nullable1 = new int?(0);
      nullable2 = new int?(0);
      if (num1 != 0UL)
        timeSpan1 = new TimeSpan((long) (num7 * 36000000000.0));
    }
    else if (!nullable2.HasValue)
    {
      nullable2 = new int?(0);
      if (num1 != 0UL)
        timeSpan1 = new TimeSpan((long) (num7 * 600000000.0));
    }
    else if (num1 != 0UL)
      timeSpan1 = new TimeSpan((long) (num7 * 10000000.0));
    try
    {
      return (nullable3.HasValue ? new DateTimeOffset(negativeIntAndSlice1, negativeIntAndSlice2, negativeIntAndSlice3, negativeIntAndSlice4, nullable1.Value, nullable2.Value, nullable3.Value) : new DateTimeOffset(new DateTime(negativeIntAndSlice1, negativeIntAndSlice2, negativeIntAndSlice3, negativeIntAndSlice4, nullable1.Value, nullable2.Value))) + timeSpan1;
    }
    catch (Exception ex)
    {
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_DefaultMessage, ex);
    }

    static byte? GetNextState(byte octet)
    {
      switch (octet)
      {
        case 43:
        case 45:
        case 90:
          return new byte?((byte) 2);
        case 44:
        case 46:
          return new byte?((byte) 1);
        default:
          return new byte?();
      }
    }
  }

  public static ReadOnlySpan<byte> ReadIntegerBytes(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    return AsnDecoder.GetIntegerContents(source, ruleSet, expectedTag ?? Asn1Tag.Integer, UniversalTagNumber.Integer, out bytesConsumed);
  }

  public static BigInteger ReadInteger(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    int bytesConsumed1;
    ReadOnlySpan<byte> readOnlySpan = AsnDecoder.ReadIntegerBytes(source, ruleSet, out bytesConsumed1, expectedTag);
    byte[] numArray = CryptoPool.Rent(readOnlySpan.Length);
    BigInteger bigInteger;
    try
    {
      byte maxValue = ((int) readOnlySpan[0] & 128 /*0x80*/) == 0 ? (byte) 0 : byte.MaxValue;
      numArray.AsSpan<byte>(readOnlySpan.Length, numArray.Length - readOnlySpan.Length).Fill(maxValue);
      readOnlySpan.CopyTo((Span<byte>) numArray);
      numArray.AsSpan<byte>(0, readOnlySpan.Length).Reverse<byte>();
      bigInteger = new BigInteger(numArray);
    }
    finally
    {
      CryptoPool.Return(numArray);
    }
    bytesConsumed = bytesConsumed1;
    return bigInteger;
  }

  public static bool TryReadInt32(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int value,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    long num;
    if (AsnDecoder.TryReadSignedInteger(source, ruleSet, 4, expectedTag ?? Asn1Tag.Integer, UniversalTagNumber.Integer, out num, out bytesConsumed))
    {
      value = (int) num;
      return true;
    }
    value = 0;
    return false;
  }

  [CLSCompliant(false)]
  public static bool TryReadUInt32(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out uint value,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    ulong num;
    if (AsnDecoder.TryReadUnsignedInteger(source, ruleSet, 4, expectedTag ?? Asn1Tag.Integer, UniversalTagNumber.Integer, out num, out bytesConsumed))
    {
      value = (uint) num;
      return true;
    }
    value = 0U;
    return false;
  }

  public static bool TryReadInt64(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out long value,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    return AsnDecoder.TryReadSignedInteger(source, ruleSet, 8, expectedTag ?? Asn1Tag.Integer, UniversalTagNumber.Integer, out value, out bytesConsumed);
  }

  [CLSCompliant(false)]
  public static bool TryReadUInt64(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out ulong value,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    return AsnDecoder.TryReadUnsignedInteger(source, ruleSet, 8, expectedTag ?? Asn1Tag.Integer, UniversalTagNumber.Integer, out value, out bytesConsumed);
  }

  private static ReadOnlySpan<byte> GetIntegerContents(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Asn1Tag expectedTag,
    UniversalTagNumber tagNumber,
    out int bytesConsumed)
  {
    int bytesConsumed1;
    ReadOnlySpan<byte> primitiveContentSpan = AsnDecoder.GetPrimitiveContentSpan(source, ruleSet, expectedTag, tagNumber, out bytesConsumed1);
    if (primitiveContentSpan.IsEmpty)
      throw new AsnContentException();
    ushort num;
    if (BinaryPrimitives.TryReadUInt16BigEndian(primitiveContentSpan, out num))
    {
      switch ((ushort) ((uint) num & 65408U))
      {
        case 0:
        case 65408:
          throw new AsnContentException();
      }
    }
    bytesConsumed = bytesConsumed1;
    return primitiveContentSpan;
  }

  private static bool TryReadSignedInteger(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    int sizeLimit,
    Asn1Tag expectedTag,
    UniversalTagNumber tagNumber,
    out long value,
    out int bytesConsumed)
  {
    int bytesConsumed1;
    ReadOnlySpan<byte> integerContents = AsnDecoder.GetIntegerContents(source, ruleSet, expectedTag, tagNumber, out bytesConsumed1);
    if (integerContents.Length > sizeLimit)
    {
      value = 0L;
      bytesConsumed = 0;
      return false;
    }
    long num = ((uint) integerContents[0] & 128U /*0x80*/) > 0U ? -1L : 0L;
    for (int index = 0; index < integerContents.Length; ++index)
      num = num << 8 | (long) integerContents[index];
    bytesConsumed = bytesConsumed1;
    value = num;
    return true;
  }

  private static bool TryReadUnsignedInteger(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    int sizeLimit,
    Asn1Tag expectedTag,
    UniversalTagNumber tagNumber,
    out ulong value,
    out int bytesConsumed)
  {
    int bytesConsumed1;
    ReadOnlySpan<byte> readOnlySpan = AsnDecoder.GetIntegerContents(source, ruleSet, expectedTag, tagNumber, out bytesConsumed1);
    if (((uint) readOnlySpan[0] & 128U /*0x80*/) > 0U)
    {
      bytesConsumed = 0;
      value = 0UL;
      return false;
    }
    if (readOnlySpan.Length > 1 && readOnlySpan[0] == (byte) 0)
      readOnlySpan = readOnlySpan.Slice(1);
    if (readOnlySpan.Length > sizeLimit)
    {
      bytesConsumed = 0;
      value = 0UL;
      return false;
    }
    ulong num = 0;
    for (int index = 0; index < readOnlySpan.Length; ++index)
      num = num << 8 | (ulong) readOnlySpan[index];
    bytesConsumed = bytesConsumed1;
    value = num;
    return true;
  }

  [return: Nullable(1)]
  public static TFlagsEnum ReadNamedBitListValue<TFlagsEnum>(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
    where TFlagsEnum : Enum
  {
    Type type = typeof (TFlagsEnum);
    int bytesConsumed1;
    TFlagsEnum flagsEnum = (TFlagsEnum) Enum.ToObject(type, (object) AsnDecoder.ReadNamedBitListValue(source, ruleSet, type, out bytesConsumed1, expectedTag));
    bytesConsumed = bytesConsumed1;
    return flagsEnum;
  }

  [NullableContext(1)]
  public static Enum ReadNamedBitListValue(
    [Nullable(0)] ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Type flagsEnumType,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    Type primitiveType = !(flagsEnumType == (Type) null) ? flagsEnumType.GetEnumUnderlyingType() : throw new ArgumentNullException(nameof (flagsEnumType));
    if (!flagsEnumType.IsDefined(typeof (FlagsAttribute), false))
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_NamedBitListRequiresFlagsEnum, nameof (flagsEnumType));
    Span<byte> destination = stackalloc byte[8].Slice(0, AsnDecoder.GetPrimitiveIntegerSize(primitiveType));
    int unusedBitCount;
    int bytesConsumed1;
    int bytesWritten;
    if (!AsnDecoder.TryReadBitString(source, destination, ruleSet, out unusedBitCount, out bytesConsumed1, out bytesWritten, expectedTag))
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.Format(System.System.Formats.Asn13538873.SR.ContentException_NamedBitListValueTooBig, (object) flagsEnumType.Name));
    if (bytesWritten == 0)
    {
      Enum @enum = (Enum) Enum.ToObject(flagsEnumType, 0);
      bytesConsumed = bytesConsumed1;
      return @enum;
    }
    ReadOnlySpan<byte> valueSpan = (ReadOnlySpan<byte>) destination.Slice(0, bytesWritten);
    if ((ruleSet == AsnEncodingRules.DER || ruleSet == AsnEncodingRules.CER) && ((int) valueSpan[bytesWritten - 1] & (int) (byte) (1 << unusedBitCount)) == 0)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
    Enum enum1 = (Enum) Enum.ToObject(flagsEnumType, AsnDecoder.InterpretNamedBitListReversed(valueSpan));
    bytesConsumed = bytesConsumed1;
    return enum1;
  }

  [return: Nullable(1)]
  public static BitArray ReadNamedBitList(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    int contentLength;
    Asn1Tag tag = AsnDecoder.ReadEncodedValue(source, ruleSet, out int _, out contentLength, out int _);
    if (expectedTag.HasValue)
      AsnDecoder.CheckExpectedTag(tag, expectedTag.Value, UniversalTagNumber.BitString);
    byte[] numArray = CryptoPool.Rent(contentLength);
    int unusedBitCount;
    int bytesConsumed1;
    int bytesWritten;
    if (!AsnDecoder.TryReadBitString(source, (Span<byte>) numArray, ruleSet, out unusedBitCount, out bytesConsumed1, out bytesWritten, expectedTag))
      throw new InvalidOperationException();
    int num = checked (bytesWritten * 8 - unusedBitCount);
    AsnDecoder.ReverseBitsPerByte(numArray.AsSpan<byte>(0, bytesWritten));
    BitArray bitArray = new BitArray(numArray);
    CryptoPool.Return(numArray, bytesWritten);
    bitArray.Length = num;
    bytesConsumed = bytesConsumed1;
    return bitArray;
  }

  private static long InterpretNamedBitListReversed(ReadOnlySpan<byte> valueSpan)
  {
    long num1 = 0;
    long num2 = 1;
    for (int index1 = 0; index1 < valueSpan.Length; ++index1)
    {
      byte num3 = valueSpan[index1];
      for (int index2 = 7; index2 >= 0; --index2)
      {
        int num4 = 1 << index2;
        if (((int) num3 & num4) != 0)
          num1 |= num2;
        num2 <<= 1;
      }
    }
    return num1;
  }

  internal static void ReverseBitsPerByte(Span<byte> value)
  {
    for (int index = 0; index < value.Length; ++index)
      value[index] = (byte) ((ulong) ((long) value[index] * 8623620610L & 1136090292240L) % 1023UL /*0x03FF*/);
  }

  public static void ReadNull(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    int bytesConsumed1;
    if (AsnDecoder.GetPrimitiveContentSpan(source, ruleSet, expectedTag ?? Asn1Tag.Null, UniversalTagNumber.Null, out bytesConsumed1).Length != 0)
      throw new AsnContentException();
    bytesConsumed = bytesConsumed1;
  }

  public static bool TryReadOctetString(
    ReadOnlySpan<byte> source,
    Span<byte> destination,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    out int bytesWritten,
    Asn1Tag? expectedTag = null)
  {
    if (source.Overlaps<byte>((ReadOnlySpan<byte>) destination))
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_SourceOverlapsDestination, nameof (destination));
    int? contentLength;
    int headerLength;
    ReadOnlySpan<byte> contents;
    int bytesConsumed1;
    if (AsnDecoder.TryReadPrimitiveOctetStringCore(source, ruleSet, expectedTag ?? Asn1Tag.PrimitiveOctetString, UniversalTagNumber.OctetString, out contentLength, out headerLength, out contents, out bytesConsumed1))
    {
      if (contents.Length > destination.Length)
      {
        bytesWritten = 0;
        bytesConsumed = 0;
        return false;
      }
      contents.CopyTo(destination);
      bytesWritten = contents.Length;
      bytesConsumed = bytesConsumed1;
      return true;
    }
    int bytesRead;
    bool flag;
    bytesConsumed = !(flag = AsnDecoder.TryCopyConstructedOctetStringContents(AsnDecoder.Slice(source, headerLength, contentLength), ruleSet, destination, !contentLength.HasValue, out bytesRead, out bytesWritten)) ? 0 : headerLength + bytesRead;
    return flag;
  }

  [return: Nullable(1)]
  public static byte[] ReadOctetString(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    byte[] rented = (byte[]) null;
    int bytesConsumed1;
    ReadOnlySpan<byte> octetStringContents = AsnDecoder.GetOctetStringContents(source, ruleSet, expectedTag ?? Asn1Tag.PrimitiveOctetString, UniversalTagNumber.OctetString, out bytesConsumed1, ref rented);
    byte[] array = octetStringContents.ToArray();
    if (rented != null)
      CryptoPool.Return(rented, octetStringContents.Length);
    bytesConsumed = bytesConsumed1;
    return array;
  }

  private static bool TryReadPrimitiveOctetStringCore(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Asn1Tag expectedTag,
    UniversalTagNumber universalTagNumber,
    out int? contentLength,
    out int headerLength,
    out ReadOnlySpan<byte> contents,
    out int bytesConsumed)
  {
    Asn1Tag tag = AsnDecoder.ReadTagAndLength(source, ruleSet, out contentLength, out headerLength);
    AsnDecoder.CheckExpectedTag(tag, expectedTag, universalTagNumber);
    ReadOnlySpan<byte> readOnlySpan = AsnDecoder.Slice(source, headerLength, contentLength);
    if (tag.IsConstructed)
    {
      if (ruleSet == AsnEncodingRules.DER)
        throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderDer_TryBerOrCer);
      contents = new ReadOnlySpan<byte>();
      bytesConsumed = 0;
      return false;
    }
    if (ruleSet == AsnEncodingRules.CER && readOnlySpan.Length > 1000)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCer_TryBerOrDer);
    contents = readOnlySpan;
    bytesConsumed = headerLength + readOnlySpan.Length;
    return true;
  }

  public static bool TryReadPrimitiveOctetString(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out ReadOnlySpan<byte> value,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    return AsnDecoder.TryReadPrimitiveOctetStringCore(source, ruleSet, expectedTag ?? Asn1Tag.PrimitiveOctetString, UniversalTagNumber.OctetString, out int? _, out int _, out value, out bytesConsumed);
  }

  private static int CountConstructedOctetString(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    bool isIndefinite)
  {
    int num = AsnDecoder.CopyConstructedOctetString(source, ruleSet, Span<byte>.Empty, false, isIndefinite, out int _);
    return ruleSet != AsnEncodingRules.CER || num > 1000 ? num : throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
  }

  private static void CopyConstructedOctetString(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Span<byte> destination,
    bool isIndefinite,
    out int bytesRead,
    out int bytesWritten)
  {
    bytesWritten = AsnDecoder.CopyConstructedOctetString(source, ruleSet, destination, true, isIndefinite, out bytesRead);
  }

  private static int CopyConstructedOctetString(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Span<byte> destination,
    bool write,
    bool isIndefinite,
    out int bytesRead)
  {
    bytesRead = 0;
    int num1 = 1000;
    ReadOnlySpan<byte> readOnlySpan1 = source;
    Stack<(int, int, bool, int)> valueTupleStack = (Stack<(int, int, bool, int)>) null;
    int num2 = 0;
    Asn1Tag tag = Asn1Tag.ConstructedBitString;
    Span<byte> destination1 = destination;
    while (true)
    {
      while (!readOnlySpan1.IsEmpty)
      {
        int? contentsLength;
        int bytesRead1;
        tag = AsnDecoder.ReadTagAndLength(readOnlySpan1, ruleSet, out contentsLength, out bytesRead1);
        if (tag == Asn1Tag.PrimitiveOctetString)
        {
          if (ruleSet == AsnEncodingRules.CER && num1 != 1000)
            throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
          ReadOnlySpan<byte> readOnlySpan2 = AsnDecoder.Slice(readOnlySpan1, bytesRead1, contentsLength.Value);
          int start = bytesRead1 + readOnlySpan2.Length;
          readOnlySpan1 = readOnlySpan1.Slice(start);
          bytesRead += start;
          num2 += readOnlySpan2.Length;
          num1 = readOnlySpan2.Length;
          if (ruleSet == AsnEncodingRules.CER && num1 > 1000)
            throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
          if (write)
          {
            readOnlySpan2.CopyTo(destination1);
            destination1 = destination1.Slice(readOnlySpan2.Length);
          }
        }
        else if (tag == Asn1Tag.EndOfContents & isIndefinite)
        {
          AsnDecoder.ValidateEndOfContents(tag, contentsLength, bytesRead1);
          bytesRead += bytesRead1;
          // ISSUE: explicit non-virtual call
          if (valueTupleStack != null && __nonvirtual (valueTupleStack.Count) > 0)
          {
            (int start, int length, bool flag, int num3) = valueTupleStack.Pop();
            readOnlySpan1 = source.Slice(start, length).Slice(bytesRead);
            bytesRead += num3;
            isIndefinite = flag;
          }
          else
            break;
        }
        else
        {
          if (!(tag == Asn1Tag.ConstructedOctetString))
            throw new AsnContentException();
          if (ruleSet == AsnEncodingRules.CER)
            throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
          if (valueTupleStack == null)
            valueTupleStack = new Stack<(int, int, bool, int)>();
          int elementOffset;
          if (!source.Overlaps<byte>(readOnlySpan1, out elementOffset))
            throw new AsnContentException();
          valueTupleStack.Push((elementOffset, readOnlySpan1.Length, isIndefinite, bytesRead));
          readOnlySpan1 = AsnDecoder.Slice(readOnlySpan1, bytesRead1, contentsLength);
          bytesRead = bytesRead1;
          isIndefinite = !contentsLength.HasValue;
        }
      }
      if (!isIndefinite || !(tag != Asn1Tag.EndOfContents))
      {
        // ISSUE: explicit non-virtual call
        if (valueTupleStack != null && __nonvirtual (valueTupleStack.Count) > 0)
        {
          (int start, int length, bool flag, int num4) = valueTupleStack.Pop();
          readOnlySpan1 = source.Slice(start, length).Slice(bytesRead);
          isIndefinite = flag;
          bytesRead += num4;
        }
        else
          goto label_25;
      }
      else
        break;
    }
    throw new AsnContentException();
label_25:
    return num2;
  }

  private static bool TryCopyConstructedOctetStringContents(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Span<byte> dest,
    bool isIndefinite,
    out int bytesRead,
    out int bytesWritten)
  {
    bytesRead = 0;
    int num = AsnDecoder.CountConstructedOctetString(source, ruleSet, isIndefinite);
    if (dest.Length < num)
    {
      bytesWritten = 0;
      return false;
    }
    AsnDecoder.CopyConstructedOctetString(source, ruleSet, dest, isIndefinite, out bytesRead, out bytesWritten);
    return true;
  }

  private static ReadOnlySpan<byte> GetOctetStringContents(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Asn1Tag expectedTag,
    UniversalTagNumber universalTagNumber,
    out int bytesConsumed,
    ref byte[] rented,
    Span<byte> tmpSpace = default (Span<byte>))
  {
    int? contentLength;
    int headerLength;
    ReadOnlySpan<byte> contents;
    if (AsnDecoder.TryReadPrimitiveOctetStringCore(source, ruleSet, expectedTag, universalTagNumber, out contentLength, out headerLength, out contents, out bytesConsumed))
      return contents;
    ReadOnlySpan<byte> source1 = source.Slice(headerLength);
    int minimumLength = contentLength ?? AsnDecoder.SeekEndOfContents(source1, ruleSet);
    if (tmpSpace.Length > 0 && minimumLength > tmpSpace.Length)
    {
      bool isIndefinite = !contentLength.HasValue;
      minimumLength = AsnDecoder.CountConstructedOctetString(source1, ruleSet, isIndefinite);
    }
    if (minimumLength > tmpSpace.Length)
    {
      rented = CryptoPool.Rent(minimumLength);
      tmpSpace = (Span<byte>) rented;
    }
    int bytesRead;
    int bytesWritten;
    if (!AsnDecoder.TryCopyConstructedOctetStringContents(AsnDecoder.Slice(source, headerLength, contentLength), ruleSet, tmpSpace, !contentLength.HasValue, out bytesRead, out bytesWritten))
      throw new AsnContentException();
    bytesConsumed = headerLength + bytesRead;
    return (ReadOnlySpan<byte>) tmpSpace.Slice(0, bytesWritten);
  }

  [return: Nullable(1)]
  public static string ReadObjectIdentifier(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    int bytesConsumed1;
    string str = AsnDecoder.ReadObjectIdentifier(AsnDecoder.GetPrimitiveContentSpan(source, ruleSet, expectedTag ?? Asn1Tag.ObjectIdentifier, UniversalTagNumber.ObjectIdentifier, out bytesConsumed1));
    bytesConsumed = bytesConsumed1;
    return str;
  }

  private static void ReadSubIdentifier(
    ReadOnlySpan<byte> source,
    out int bytesRead,
    out long? smallValue,
    out BigInteger? largeValue)
  {
    if (source[0] == (byte) 128 /*0x80*/)
      throw new AsnContentException();
    int num1 = -1;
    for (int index = 0; index < source.Length; ++index)
    {
      if (((int) source[index] & 128 /*0x80*/) == 0)
      {
        num1 = index;
        break;
      }
    }
    if (num1 < 0)
      throw new AsnContentException();
    bytesRead = num1 + 1;
    long num2 = 0;
    if (bytesRead <= 9)
    {
      for (int index = 0; index < bytesRead; ++index)
      {
        byte num3 = source[index];
        num2 = num2 << 7 | (long) (byte) ((uint) num3 & (uint) sbyte.MaxValue);
      }
      largeValue = new BigInteger?();
      smallValue = new long?(num2);
    }
    else
    {
      byte[] array = CryptoPool.Rent((bytesRead / 8 + 1) * 7);
      Array.Clear((Array) array, 0, array.Length);
      Span<byte> destination1 = (Span<byte>) array;
      Span<byte> destination2 = stackalloc byte[8];
      int num4 = bytesRead;
      int index = bytesRead - 8;
      while (num4 > 0)
      {
        byte num5 = source[index];
        num2 = num2 << 7 | (long) (byte) ((uint) num5 & (uint) sbyte.MaxValue);
        ++index;
        if (index >= num4)
        {
          BinaryPrimitives.WriteInt64LittleEndian(destination2, num2);
          destination2.Slice(0, 7).CopyTo(destination1);
          destination1 = destination1.Slice(7);
          num2 = 0L;
          num4 -= 8;
          index = Math.Max(0, num4 - 8);
        }
      }
      int clearSize = array.Length - destination1.Length;
      largeValue = new BigInteger?(new BigInteger(array));
      smallValue = new long?();
      CryptoPool.Return(array, clearSize);
    }
  }

  private static string ReadObjectIdentifier(ReadOnlySpan<byte> contents)
  {
    StringBuilder stringBuilder = contents.Length >= 1 ? new StringBuilder((int) (byte) contents.Length * 4) : throw new AsnContentException();
    int bytesRead;
    long? smallValue;
    BigInteger? largeValue;
    AsnDecoder.ReadSubIdentifier(contents, out bytesRead, out smallValue, out largeValue);
    if (smallValue.HasValue)
    {
      long num1 = smallValue.Value;
      byte num2;
      if (num1 < 40L)
        num2 = (byte) 0;
      else if (num1 < 80L /*0x50*/)
      {
        num2 = (byte) 1;
        num1 -= 40L;
      }
      else
      {
        num2 = (byte) 2;
        num1 -= 80L /*0x50*/;
      }
      stringBuilder.Append(num2);
      stringBuilder.Append('.');
      stringBuilder.Append(num1);
    }
    else
    {
      BigInteger bigInteger = largeValue.Value - (BigInteger) 80 /*0x50*/;
      stringBuilder.Append((byte) 2);
      stringBuilder.Append('.');
      stringBuilder.Append(bigInteger.ToString());
    }
    for (contents = contents.Slice(bytesRead); !contents.IsEmpty; contents = contents.Slice(bytesRead))
    {
      AsnDecoder.ReadSubIdentifier(contents, out bytesRead, out smallValue, out largeValue);
      stringBuilder.Append('.');
      if (smallValue.HasValue)
        stringBuilder.Append(smallValue.Value);
      else
        stringBuilder.Append(largeValue.Value.ToString());
    }
    return stringBuilder.ToString();
  }

  public static void ReadSequence(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int contentOffset,
    out int contentLength,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    int? contentsLength;
    int bytesRead;
    Asn1Tag tag = AsnDecoder.ReadTagAndLength(source, ruleSet, out contentsLength, out bytesRead);
    AsnDecoder.CheckExpectedTag(tag, expectedTag ?? Asn1Tag.Sequence, UniversalTagNumber.Sequence);
    if (!tag.IsConstructed)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.Format(System.System.Formats.Asn13538873.SR.ContentException_ConstructedEncodingRequired, (object) UniversalTagNumber.Sequence));
    if (contentsLength.HasValue)
    {
      if (contentsLength.Value + bytesRead > source.Length)
        throw AsnDecoder.GetValidityException(AsnDecoder.LengthValidity.LengthExceedsInput);
      contentLength = contentsLength.Value;
      contentOffset = bytesRead;
      bytesConsumed = contentLength + bytesRead;
    }
    else
    {
      int num = AsnDecoder.SeekEndOfContents(source.Slice(bytesRead), ruleSet);
      contentLength = num;
      contentOffset = bytesRead;
      bytesConsumed = num + bytesRead + 2;
    }
  }

  public static void ReadSetOf(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int contentOffset,
    out int contentLength,
    out int bytesConsumed,
    bool skipSortOrderValidation = false,
    Asn1Tag? expectedTag = null)
  {
    int? contentsLength;
    int bytesRead;
    Asn1Tag tag = AsnDecoder.ReadTagAndLength(source, ruleSet, out contentsLength, out bytesRead);
    AsnDecoder.CheckExpectedTag(tag, expectedTag ?? Asn1Tag.SetOf, UniversalTagNumber.Set);
    if (!tag.IsConstructed)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.Format(System.System.Formats.Asn13538873.SR.ContentException_ConstructedEncodingRequired, (object) UniversalTagNumber.Set));
    int num;
    ReadOnlySpan<byte> readOnlySpan;
    if (contentsLength.HasValue)
    {
      num = 0;
      readOnlySpan = AsnDecoder.Slice(source, bytesRead, contentsLength.Value);
    }
    else
    {
      int length = AsnDecoder.SeekEndOfContents(source.Slice(bytesRead), ruleSet);
      readOnlySpan = AsnDecoder.Slice(source, bytesRead, length);
      num = 2;
    }
    if (!skipSortOrderValidation && (ruleSet == AsnEncodingRules.DER || ruleSet == AsnEncodingRules.CER))
    {
      ReadOnlySpan<byte> source1 = readOnlySpan;
      ReadOnlySpan<byte> y = new ReadOnlySpan<byte>();
      while (!source1.IsEmpty)
      {
        int bytesConsumed1;
        AsnDecoder.ReadEncodedValue(source1, ruleSet, out int _, out int _, out bytesConsumed1);
        ReadOnlySpan<byte> x = source1.Slice(0, bytesConsumed1);
        source1 = source1.Slice(bytesConsumed1);
        y = SetOfValueComparer.Compare(x, y) >= 0 ? x : throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_SetOfNotSorted);
      }
    }
    contentOffset = bytesRead;
    contentLength = readOnlySpan.Length;
    bytesConsumed = bytesRead + readOnlySpan.Length + num;
  }

  public static bool TryReadPrimitiveCharacterStringBytes(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Asn1Tag expectedTag,
    out ReadOnlySpan<byte> value,
    out int bytesConsumed)
  {
    UniversalTagNumber universalTagNumber = UniversalTagNumber.IA5String;
    if (expectedTag.TagClass == TagClass.Universal)
    {
      universalTagNumber = (UniversalTagNumber) expectedTag.TagValue;
      if (!AsnDecoder.IsCharacterStringEncodingType(universalTagNumber))
        throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_Tag_NotCharacterString, nameof (expectedTag));
    }
    return AsnDecoder.TryReadPrimitiveOctetStringCore(source, ruleSet, expectedTag, universalTagNumber, out int? _, out int _, out value, out bytesConsumed);
  }

  public static bool TryReadCharacterStringBytes(
    ReadOnlySpan<byte> source,
    Span<byte> destination,
    AsnEncodingRules ruleSet,
    Asn1Tag expectedTag,
    out int bytesConsumed,
    out int bytesWritten)
  {
    if (source.Overlaps<byte>((ReadOnlySpan<byte>) destination))
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_SourceOverlapsDestination, nameof (destination));
    UniversalTagNumber universalTagNumber = UniversalTagNumber.IA5String;
    if (expectedTag.TagClass == TagClass.Universal)
    {
      universalTagNumber = (UniversalTagNumber) expectedTag.TagValue;
      if (!AsnDecoder.IsCharacterStringEncodingType(universalTagNumber))
        throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_Tag_NotCharacterString, nameof (expectedTag));
    }
    return AsnDecoder.TryReadCharacterStringBytesCore(source, ruleSet, expectedTag, universalTagNumber, destination, out bytesConsumed, out bytesWritten);
  }

  public static bool TryReadCharacterString(
    ReadOnlySpan<byte> source,
    Span<char> destination,
    AsnEncodingRules ruleSet,
    UniversalTagNumber encodingType,
    out int bytesConsumed,
    out int charsWritten,
    Asn1Tag? expectedTag = null)
  {
    Encoding encoding = AsnCharacterStringEncodings.GetEncoding(encodingType);
    return AsnDecoder.TryReadCharacterStringCore(source, ruleSet, expectedTag ?? new Asn1Tag(encodingType), encodingType, encoding, destination, out bytesConsumed, out charsWritten);
  }

  [return: Nullable(1)]
  public static string ReadCharacterString(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    UniversalTagNumber encodingType,
    out int bytesConsumed,
    Asn1Tag? expectedTag = null)
  {
    Encoding encoding = AsnCharacterStringEncodings.GetEncoding(encodingType);
    return AsnDecoder.ReadCharacterStringCore(source, ruleSet, expectedTag ?? new Asn1Tag(encodingType), encodingType, encoding, out bytesConsumed);
  }

  private static bool TryReadCharacterStringBytesCore(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Asn1Tag expectedTag,
    UniversalTagNumber universalTagNumber,
    Span<byte> destination,
    out int bytesConsumed,
    out int bytesWritten)
  {
    int? contentLength;
    int headerLength;
    ReadOnlySpan<byte> contents;
    int bytesConsumed1;
    if (AsnDecoder.TryReadPrimitiveOctetStringCore(source, ruleSet, expectedTag, universalTagNumber, out contentLength, out headerLength, out contents, out bytesConsumed1))
    {
      if (contents.Length > destination.Length)
      {
        bytesWritten = 0;
        bytesConsumed = 0;
        return false;
      }
      contents.CopyTo(destination);
      bytesWritten = contents.Length;
      bytesConsumed = bytesConsumed1;
      return true;
    }
    int bytesRead;
    bool flag;
    bytesConsumed = !(flag = AsnDecoder.TryCopyConstructedOctetStringContents(AsnDecoder.Slice(source, headerLength, contentLength), ruleSet, destination, !contentLength.HasValue, out bytesRead, out bytesWritten)) ? 0 : headerLength + bytesRead;
    return flag;
  }

  private static unsafe bool TryReadCharacterStringCore(
    ReadOnlySpan<byte> source,
    Span<char> destination,
    Encoding encoding,
    out int charsWritten)
  {
    try
    {
      if (source.Length != 0)
      {
        fixed (byte* bytes = &MemoryMarshal.GetReference<byte>(source))
          fixed (char* chars = &MemoryMarshal.GetReference<char>(destination))
          {
            if (encoding.GetCharCount(bytes, source.Length) > destination.Length)
            {
              charsWritten = 0;
              return false;
            }
            charsWritten = encoding.GetChars(bytes, source.Length, chars, destination.Length);
            return true;
          }
      }
      charsWritten = 0;
      return true;
    }
    catch (DecoderFallbackException ex)
    {
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_DefaultMessage, (Exception) ex);
    }
  }

  private static unsafe string ReadCharacterStringCore(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Asn1Tag expectedTag,
    UniversalTagNumber universalTagNumber,
    Encoding encoding,
    out int bytesConsumed)
  {
    byte[] rented = (byte[]) null;
    int bytesConsumed1;
    ReadOnlySpan<byte> octetStringContents = AsnDecoder.GetOctetStringContents(source, ruleSet, expectedTag, universalTagNumber, out bytesConsumed1, ref rented);
    string empty;
    if (octetStringContents.Length == 0)
    {
      empty = string.Empty;
    }
    else
    {
      fixed (byte* bytes = &MemoryMarshal.GetReference<byte>(octetStringContents))
      {
        try
        {
          empty = encoding.GetString(bytes, octetStringContents.Length);
        }
        catch (DecoderFallbackException ex)
        {
          throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_DefaultMessage, (Exception) ex);
        }
      }
    }
    if (rented != null)
      CryptoPool.Return(rented, octetStringContents.Length);
    bytesConsumed = bytesConsumed1;
    return empty;
  }

  private static bool TryReadCharacterStringCore(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    Asn1Tag expectedTag,
    UniversalTagNumber universalTagNumber,
    Encoding encoding,
    Span<char> destination,
    out int bytesConsumed,
    out int charsWritten)
  {
    byte[] rented = (byte[]) null;
    int bytesConsumed1;
    ReadOnlySpan<byte> octetStringContents = AsnDecoder.GetOctetStringContents(source, ruleSet, expectedTag, universalTagNumber, out bytesConsumed1, ref rented);
    bool flag = AsnDecoder.TryReadCharacterStringCore(octetStringContents, destination, encoding, out charsWritten);
    if (rented != null)
      CryptoPool.Return(rented, octetStringContents.Length);
    bytesConsumed = !flag ? 0 : bytesConsumed1;
    return flag;
  }

  private static bool IsCharacterStringEncodingType(UniversalTagNumber encodingType)
  {
    switch (encodingType)
    {
      case UniversalTagNumber.UTF8String:
      case UniversalTagNumber.NumericString:
      case UniversalTagNumber.PrintableString:
      case UniversalTagNumber.TeletexString:
      case UniversalTagNumber.VideotexString:
      case UniversalTagNumber.IA5String:
      case UniversalTagNumber.GraphicString:
      case UniversalTagNumber.VisibleString:
      case UniversalTagNumber.GeneralString:
      case UniversalTagNumber.UniversalString:
      case UniversalTagNumber.BMPString:
        return true;
      default:
        return false;
    }
  }

  public static DateTimeOffset ReadUtcTime(
    ReadOnlySpan<byte> source,
    AsnEncodingRules ruleSet,
    out int bytesConsumed,
    int twoDigitYearMax = 2049,
    Asn1Tag? expectedTag = null)
  {
    if (twoDigitYearMax < 1 || twoDigitYearMax > 9999)
      throw new ArgumentOutOfRangeException(nameof (twoDigitYearMax));
    Span<byte> tmpSpace = stackalloc byte[17];
    byte[] rented = (byte[]) null;
    int bytesConsumed1;
    ReadOnlySpan<byte> octetStringContents = AsnDecoder.GetOctetStringContents(source, ruleSet, expectedTag ?? Asn1Tag.UtcTime, UniversalTagNumber.UtcTime, out bytesConsumed1, ref rented, tmpSpace);
    DateTimeOffset utcTime = AsnDecoder.ParseUtcTime(octetStringContents, ruleSet, twoDigitYearMax);
    if (rented != null)
      CryptoPool.Return(rented, octetStringContents.Length);
    bytesConsumed = bytesConsumed1;
    return utcTime;
  }

  private static DateTimeOffset ParseUtcTime(
    ReadOnlySpan<byte> contentOctets,
    AsnEncodingRules ruleSet,
    int twoDigitYearMax)
  {
    if ((ruleSet == AsnEncodingRules.DER || ruleSet == AsnEncodingRules.CER) && contentOctets.Length != 13)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidUnderCerOrDer_TryBer);
    ReadOnlySpan<byte> data = contentOctets.Length >= 11 && contentOctets.Length <= 17 && (contentOctets.Length & 1) == 1 ? contentOctets : throw new AsnContentException();
    int negativeIntAndSlice1 = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
    int negativeIntAndSlice2 = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
    int negativeIntAndSlice3 = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
    int negativeIntAndSlice4 = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
    int negativeIntAndSlice5 = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
    int second = 0;
    int hours = 0;
    int minutes = 0;
    bool flag = false;
    if (contentOctets.Length == 17 || contentOctets.Length == 13)
      second = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
    if (contentOctets.Length != 11 && contentOctets.Length != 13)
    {
      if (data[0] == (byte) 45)
        flag = true;
      else if (data[0] != (byte) 43)
        throw new AsnContentException();
      data = data.Slice(1);
      hours = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
      minutes = AsnDecoder.ParseNonNegativeIntAndSlice(ref data, 2);
    }
    else if (data[0] != (byte) 90)
      throw new AsnContentException();
    TimeSpan offset = minutes <= 59 ? new TimeSpan(hours, minutes, 0) : throw new AsnContentException();
    if (flag)
      offset = -offset;
    int num = twoDigitYearMax / 100;
    if (negativeIntAndSlice1 > twoDigitYearMax % 100)
      --num;
    int year = num * 100 + negativeIntAndSlice1;
    try
    {
      return new DateTimeOffset(year, negativeIntAndSlice2, negativeIntAndSlice3, negativeIntAndSlice4, negativeIntAndSlice5, second, offset);
    }
    catch (Exception ex)
    {
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_DefaultMessage, ex);
    }
  }

  private enum LengthDecodeStatus
  {
    NeedMoreData,
    DerIndefinite,
    ReservedValue,
    LengthTooBig,
    LaxEncodingProhibited,
    Success,
  }

  private enum LengthValidity
  {
    CerRequiresIndefinite,
    PrimitiveEncodingRequiresDefinite,
    LengthExceedsInput,
    Valid,
  }

  private delegate void BitStringCopyAction(
    ReadOnlySpan<byte> value,
    byte normalizedLastByte,
    Span<byte> destination);
}
