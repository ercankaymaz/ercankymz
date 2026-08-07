// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.AsnReader
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices.System.Formats.Asn1;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Formats.Asn1;

[ComVisible(true)]
public class AsnReader
{
  internal const int MaxCERSegmentSize = 1000;
  private ReadOnlyMemory<byte> _data;
  private readonly AsnReaderOptions _options;

  public AsnEncodingRules RuleSet { get; }

  public bool HasData => !this._data.IsEmpty;

  public AsnReader(ReadOnlyMemory<byte> data, AsnEncodingRules ruleSet, AsnReaderOptions options = default (AsnReaderOptions))
  {
    AsnDecoder.CheckEncodingRules(ruleSet);
    this._data = data;
    this.RuleSet = ruleSet;
    this._options = options;
  }

  public void ThrowIfNotEmpty()
  {
    if (this.HasData)
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_TooMuchData);
  }

  public Asn1Tag PeekTag() => Asn1Tag.Decode(this._data.Span, out int _);

  public ReadOnlyMemory<byte> PeekEncodedValue()
  {
    int bytesConsumed;
    AsnDecoder.ReadEncodedValue(this._data.Span, this.RuleSet, out int _, out int _, out bytesConsumed);
    return this._data.Slice(0, bytesConsumed);
  }

  public ReadOnlyMemory<byte> PeekContentBytes()
  {
    int contentOffset;
    int contentLength;
    AsnDecoder.ReadEncodedValue(this._data.Span, this.RuleSet, out contentOffset, out contentLength, out int _);
    return this._data.Slice(contentOffset, contentLength);
  }

  public ReadOnlyMemory<byte> ReadEncodedValue()
  {
    ReadOnlyMemory<byte> readOnlyMemory = this.PeekEncodedValue();
    this._data = this._data.Slice(readOnlyMemory.Length);
    return readOnlyMemory;
  }

  [NullableContext(1)]
  public AsnReader Clone() => new AsnReader(this._data, this.RuleSet, this._options);

  private AsnReader CloneAtSlice(int start, int length)
  {
    return new AsnReader(this._data.Slice(start, length), this.RuleSet, this._options);
  }

  public bool TryReadPrimitiveBitString(
    out int unusedBitCount,
    out ReadOnlyMemory<byte> value,
    Asn1Tag? expectedTag = null)
  {
    ReadOnlySpan<byte> smaller;
    int bytesConsumed;
    bool flag;
    if (flag = AsnDecoder.TryReadPrimitiveBitString(this._data.Span, this.RuleSet, out unusedBitCount, out smaller, out bytesConsumed, expectedTag))
    {
      value = AsnDecoder.Slice(this._data, smaller);
      this._data = this._data.Slice(bytesConsumed);
    }
    else
      value = new ReadOnlyMemory<byte>();
    return flag;
  }

  public bool TryReadBitString(
    Span<byte> destination,
    out int unusedBitCount,
    out int bytesWritten,
    Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    bool flag;
    if (flag = AsnDecoder.TryReadBitString(this._data.Span, destination, this.RuleSet, out unusedBitCount, out bytesConsumed, out bytesWritten, expectedTag))
      this._data = this._data.Slice(bytesConsumed);
    return flag;
  }

  [NullableContext(1)]
  public byte[] ReadBitString(out int unusedBitCount, Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    byte[] numArray = AsnDecoder.ReadBitString(this._data.Span, this.RuleSet, out unusedBitCount, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return numArray;
  }

  public bool ReadBoolean(Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    bool flag = AsnDecoder.ReadBoolean(this._data.Span, this.RuleSet, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return flag;
  }

  public ReadOnlyMemory<byte> ReadEnumeratedBytes(Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    ReadOnlyMemory<byte> readOnlyMemory = AsnDecoder.Slice(this._data, AsnDecoder.ReadEnumeratedBytes(this._data.Span, this.RuleSet, out bytesConsumed, expectedTag));
    this._data = this._data.Slice(bytesConsumed);
    return readOnlyMemory;
  }

  [NullableContext(1)]
  public TEnum ReadEnumeratedValue<[Nullable(0)] TEnum>(Asn1Tag? expectedTag = null) where TEnum : Enum
  {
    int bytesConsumed;
    TEnum @enum = AsnDecoder.ReadEnumeratedValue<TEnum>(this._data.Span, this.RuleSet, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return @enum;
  }

  [NullableContext(1)]
  public Enum ReadEnumeratedValue(Type enumType, Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    Enum @enum = AsnDecoder.ReadEnumeratedValue(this._data.Span, this.RuleSet, enumType, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return @enum;
  }

  public DateTimeOffset ReadGeneralizedTime(Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    DateTimeOffset dateTimeOffset = AsnDecoder.ReadGeneralizedTime(this._data.Span, this.RuleSet, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return dateTimeOffset;
  }

  public ReadOnlyMemory<byte> ReadIntegerBytes(Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    ReadOnlyMemory<byte> readOnlyMemory = AsnDecoder.Slice(this._data, AsnDecoder.ReadIntegerBytes(this._data.Span, this.RuleSet, out bytesConsumed, expectedTag));
    this._data = this._data.Slice(bytesConsumed);
    return readOnlyMemory;
  }

  public BigInteger ReadInteger(Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    BigInteger bigInteger = AsnDecoder.ReadInteger(this._data.Span, this.RuleSet, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return bigInteger;
  }

  public bool TryReadInt32(out int value, Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    bool flag = AsnDecoder.TryReadInt32(this._data.Span, this.RuleSet, out value, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return flag;
  }

  [CLSCompliant(false)]
  public bool TryReadUInt32(out uint value, Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    bool flag = AsnDecoder.TryReadUInt32(this._data.Span, this.RuleSet, out value, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return flag;
  }

  public bool TryReadInt64(out long value, Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    bool flag = AsnDecoder.TryReadInt64(this._data.Span, this.RuleSet, out value, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return flag;
  }

  [CLSCompliant(false)]
  public bool TryReadUInt64(out ulong value, Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    bool flag = AsnDecoder.TryReadUInt64(this._data.Span, this.RuleSet, out value, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return flag;
  }

  [NullableContext(1)]
  public TFlagsEnum ReadNamedBitListValue<[Nullable(0)] TFlagsEnum>(Asn1Tag? expectedTag = null) where TFlagsEnum : Enum
  {
    int bytesConsumed;
    TFlagsEnum flagsEnum = AsnDecoder.ReadNamedBitListValue<TFlagsEnum>(this._data.Span, this.RuleSet, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return flagsEnum;
  }

  [NullableContext(1)]
  public Enum ReadNamedBitListValue(Type flagsEnumType, Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    Enum @enum = AsnDecoder.ReadNamedBitListValue(this._data.Span, this.RuleSet, flagsEnumType, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return @enum;
  }

  [NullableContext(1)]
  public BitArray ReadNamedBitList(Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    BitArray bitArray = AsnDecoder.ReadNamedBitList(this._data.Span, this.RuleSet, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return bitArray;
  }

  public void ReadNull(Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    AsnDecoder.ReadNull(this._data.Span, this.RuleSet, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
  }

  public bool TryReadOctetString(
    Span<byte> destination,
    out int bytesWritten,
    Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    bool flag;
    if (flag = AsnDecoder.TryReadOctetString(this._data.Span, destination, this.RuleSet, out bytesConsumed, out bytesWritten, expectedTag))
      this._data = this._data.Slice(bytesConsumed);
    return flag;
  }

  [NullableContext(1)]
  public byte[] ReadOctetString(Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    byte[] numArray = AsnDecoder.ReadOctetString(this._data.Span, this.RuleSet, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return numArray;
  }

  public bool TryReadPrimitiveOctetString(out ReadOnlyMemory<byte> contents, Asn1Tag? expectedTag = null)
  {
    ReadOnlySpan<byte> smaller;
    int bytesConsumed;
    bool flag;
    if (flag = AsnDecoder.TryReadPrimitiveOctetString(this._data.Span, this.RuleSet, out smaller, out bytesConsumed, expectedTag))
    {
      contents = AsnDecoder.Slice(this._data, smaller);
      this._data = this._data.Slice(bytesConsumed);
    }
    else
      contents = new ReadOnlyMemory<byte>();
    return flag;
  }

  [NullableContext(1)]
  public string ReadObjectIdentifier(Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    string str = AsnDecoder.ReadObjectIdentifier(this._data.Span, this.RuleSet, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return str;
  }

  [NullableContext(1)]
  public AsnReader ReadSequence(Asn1Tag? expectedTag = null)
  {
    int contentOffset;
    int contentLength;
    int bytesConsumed;
    AsnDecoder.ReadSequence(this._data.Span, this.RuleSet, out contentOffset, out contentLength, out bytesConsumed, expectedTag);
    AsnReader asnReader = this.CloneAtSlice(contentOffset, contentLength);
    this._data = this._data.Slice(bytesConsumed);
    return asnReader;
  }

  [NullableContext(1)]
  public AsnReader ReadSetOf(Asn1Tag? expectedTag = null)
  {
    return this.ReadSetOf(this._options.SkipSetSortOrderVerification, expectedTag);
  }

  [NullableContext(1)]
  public AsnReader ReadSetOf(bool skipSortOrderValidation, Asn1Tag? expectedTag = null)
  {
    int contentOffset;
    int contentLength;
    int bytesConsumed;
    AsnDecoder.ReadSetOf(this._data.Span, this.RuleSet, out contentOffset, out contentLength, out bytesConsumed, skipSortOrderValidation, expectedTag);
    AsnReader asnReader = this.CloneAtSlice(contentOffset, contentLength);
    this._data = this._data.Slice(bytesConsumed);
    return asnReader;
  }

  public bool TryReadPrimitiveCharacterStringBytes(
    Asn1Tag expectedTag,
    out ReadOnlyMemory<byte> contents)
  {
    ReadOnlySpan<byte> smaller;
    int bytesConsumed;
    bool flag;
    if (flag = AsnDecoder.TryReadPrimitiveCharacterStringBytes(this._data.Span, this.RuleSet, expectedTag, out smaller, out bytesConsumed))
    {
      contents = AsnDecoder.Slice(this._data, smaller);
      this._data = this._data.Slice(bytesConsumed);
    }
    else
      contents = new ReadOnlyMemory<byte>();
    return flag;
  }

  public bool TryReadCharacterStringBytes(
    Span<byte> destination,
    Asn1Tag expectedTag,
    out int bytesWritten)
  {
    int bytesConsumed;
    bool flag;
    if (flag = AsnDecoder.TryReadCharacterStringBytes(this._data.Span, destination, this.RuleSet, expectedTag, out bytesConsumed, out bytesWritten))
      this._data = this._data.Slice(bytesConsumed);
    return flag;
  }

  public bool TryReadCharacterString(
    Span<char> destination,
    UniversalTagNumber encodingType,
    out int charsWritten,
    Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    bool flag = AsnDecoder.TryReadCharacterString(this._data.Span, destination, this.RuleSet, encodingType, out bytesConsumed, out charsWritten, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return flag;
  }

  [NullableContext(1)]
  public string ReadCharacterString(UniversalTagNumber encodingType, Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    string str = AsnDecoder.ReadCharacterString(this._data.Span, this.RuleSet, encodingType, out bytesConsumed, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return str;
  }

  public DateTimeOffset ReadUtcTime(Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    DateTimeOffset dateTimeOffset = AsnDecoder.ReadUtcTime(this._data.Span, this.RuleSet, out bytesConsumed, this._options.UtcTimeTwoDigitYearMax, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return dateTimeOffset;
  }

  public DateTimeOffset ReadUtcTime(int twoDigitYearMax, Asn1Tag? expectedTag = null)
  {
    int bytesConsumed;
    DateTimeOffset dateTimeOffset = AsnDecoder.ReadUtcTime(this._data.Span, this.RuleSet, out bytesConsumed, twoDigitYearMax, expectedTag);
    this._data = this._data.Slice(bytesConsumed);
    return dateTimeOffset;
  }
}
