// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.AsnWriter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Buffers;
using System.Buffers.Binary;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis.System.Formats.Asn13538873;
using System.Numerics;
using System.Runtime.CompilerServices.System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace System.Formats.Asn1;

[ComVisible(true)]
public sealed class AsnWriter
{
  private byte[] _buffer;
  private int _offset;
  private Stack<AsnWriter.StackFrame> _nestingStack;

  public AsnEncodingRules RuleSet { get; }

  public AsnWriter(AsnEncodingRules ruleSet)
  {
    this.RuleSet = ruleSet == AsnEncodingRules.BER || ruleSet == AsnEncodingRules.CER || ruleSet == AsnEncodingRules.DER ? ruleSet : throw new ArgumentOutOfRangeException(nameof (ruleSet));
  }

  public AsnWriter(AsnEncodingRules ruleSet, int initialCapacity)
    : this(ruleSet)
  {
    if (initialCapacity < 0)
      throw new ArgumentOutOfRangeException(nameof (initialCapacity), System.System.Formats.Asn13538873.SR.ArgumentOutOfRange_NeedNonNegNum);
    if (initialCapacity <= 0)
      return;
    this._buffer = new byte[initialCapacity];
  }

  public void Reset()
  {
    if (this._offset <= 0)
      return;
    Array.Clear((Array) this._buffer, 0, this._offset);
    this._offset = 0;
    this._nestingStack?.Clear();
  }

  public int GetEncodedLength()
  {
    Stack<AsnWriter.StackFrame> nestingStack = this._nestingStack;
    // ISSUE: explicit non-virtual call
    if ((nestingStack != null ? __nonvirtual (nestingStack.Count) : 0) != 0)
      throw new InvalidOperationException(System.System.Formats.Asn13538873.SR.AsnWriter_EncodeUnbalancedStack);
    return this._offset;
  }

  public bool TryEncode(Span<byte> destination, out int bytesWritten)
  {
    Stack<AsnWriter.StackFrame> nestingStack = this._nestingStack;
    // ISSUE: explicit non-virtual call
    if ((nestingStack != null ? __nonvirtual (nestingStack.Count) : 0) != 0)
      throw new InvalidOperationException(System.System.Formats.Asn13538873.SR.AsnWriter_EncodeUnbalancedStack);
    if (destination.Length < this._offset)
    {
      bytesWritten = 0;
      return false;
    }
    if (this._offset == 0)
    {
      bytesWritten = 0;
      return true;
    }
    bytesWritten = this._offset;
    this._buffer.AsSpan<byte>(0, this._offset).CopyTo(destination);
    return true;
  }

  public int Encode(Span<byte> destination)
  {
    int bytesWritten;
    if (!this.TryEncode(destination, out bytesWritten))
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_DestinationTooShort, nameof (destination));
    return bytesWritten;
  }

  [NullableContext(1)]
  public byte[] Encode()
  {
    Stack<AsnWriter.StackFrame> nestingStack = this._nestingStack;
    // ISSUE: explicit non-virtual call
    if ((nestingStack != null ? __nonvirtual (nestingStack.Count) : 0) != 0)
      throw new InvalidOperationException(System.System.Formats.Asn13538873.SR.AsnWriter_EncodeUnbalancedStack);
    return this._offset == 0 ? Array.Empty<byte>() : this._buffer.AsSpan<byte>(0, this._offset).ToArray();
  }

  private ReadOnlySpan<byte> EncodeAsSpan()
  {
    Stack<AsnWriter.StackFrame> nestingStack = this._nestingStack;
    // ISSUE: explicit non-virtual call
    if ((nestingStack != null ? __nonvirtual (nestingStack.Count) : 0) != 0)
      throw new InvalidOperationException(System.System.Formats.Asn13538873.SR.AsnWriter_EncodeUnbalancedStack);
    return this._offset == 0 ? ReadOnlySpan<byte>.Empty : new ReadOnlySpan<byte>(this._buffer, 0, this._offset);
  }

  public bool EncodedValueEquals(ReadOnlySpan<byte> other)
  {
    return this.EncodeAsSpan().SequenceEqual<byte>(other);
  }

  [NullableContext(1)]
  public bool EncodedValueEquals(AsnWriter other)
  {
    return other != null ? this.EncodeAsSpan().SequenceEqual<byte>(other.EncodeAsSpan()) : throw new ArgumentNullException(nameof (other));
  }

  private void EnsureWriteCapacity(int pendingCount)
  {
    if (pendingCount < 0)
      throw new OverflowException();
    if (this._buffer != null && this._buffer.Length - this._offset >= pendingCount)
      return;
    int num = checked (this._offset + pendingCount + 1023 /*0x03FF*/) / 1024 /*0x0400*/;
    byte[] buffer = this._buffer;
    Array.Resize<byte>(ref this._buffer, 1024 /*0x0400*/ * num);
    if (buffer == null)
      return;
    buffer.AsSpan<byte>(0, this._offset).Clear();
  }

  private void WriteTag(Asn1Tag tag)
  {
    int encodedSize = tag.CalculateEncodedSize();
    this.EnsureWriteCapacity(encodedSize);
    int bytesWritten;
    if (!tag.TryEncode(this._buffer.AsSpan<byte>(this._offset, encodedSize), out bytesWritten) || bytesWritten != encodedSize)
      throw new InvalidOperationException();
    this._offset += encodedSize;
  }

  private void WriteLength(int length)
  {
    if (length == -1)
    {
      this.EnsureWriteCapacity(1);
      this._buffer[this._offset] = (byte) 128 /*0x80*/;
      ++this._offset;
    }
    else if (length < 128 /*0x80*/)
    {
      this.EnsureWriteCapacity(1 + length);
      this._buffer[this._offset] = (byte) length;
      ++this._offset;
    }
    else
    {
      int subsequentByteCount = AsnWriter.GetEncodedLengthSubsequentByteCount(length);
      this.EnsureWriteCapacity(subsequentByteCount + 1 + length);
      this._buffer[this._offset] = (byte) (128 /*0x80*/ | subsequentByteCount);
      int index = this._offset + subsequentByteCount;
      int num = length;
      do
      {
        this._buffer[index] = (byte) num;
        num >>= 8;
        --index;
      }
      while (num > 0);
      this._offset += subsequentByteCount + 1;
    }
  }

  private static int GetEncodedLengthSubsequentByteCount(int length)
  {
    if (length < 0)
      throw new OverflowException();
    if (length <= (int) sbyte.MaxValue)
      return 0;
    if (length <= (int) byte.MaxValue)
      return 1;
    if (length <= (int) ushort.MaxValue)
      return 2;
    return length <= 16777215 /*0xFFFFFF*/ ? 3 : 4;
  }

  [NullableContext(1)]
  public void CopyTo(AsnWriter destination)
  {
    if (destination == null)
      throw new ArgumentNullException(nameof (destination));
    try
    {
      destination.WriteEncodedValue(this.EncodeAsSpan());
    }
    catch (ArgumentException ex)
    {
      throw new InvalidOperationException(new InvalidOperationException().Message, (Exception) ex);
    }
  }

  public void WriteEncodedValue(ReadOnlySpan<byte> value)
  {
    int bytesConsumed;
    if (!AsnDecoder.TryReadEncodedValue(value, this.RuleSet, out Asn1Tag _, out int _, out int _, out bytesConsumed) || bytesConsumed != value.Length)
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_WriteEncodedValue_OneValueAtATime, nameof (value));
    this.EnsureWriteCapacity(value.Length);
    value.CopyTo(this._buffer.AsSpan<byte>(this._offset));
    this._offset += value.Length;
  }

  private void WriteEndOfContents()
  {
    this.EnsureWriteCapacity(2);
    this._buffer[this._offset++] = (byte) 0;
    this._buffer[this._offset++] = (byte) 0;
  }

  private AsnWriter.Scope PushTag(Asn1Tag tag, UniversalTagNumber tagType)
  {
    if (this._nestingStack == null)
      this._nestingStack = new Stack<AsnWriter.StackFrame>();
    this.WriteTag(tag);
    this._nestingStack.Push(new AsnWriter.StackFrame(tag, this._offset, tagType));
    this.WriteLength(-1);
    return new AsnWriter.Scope(this);
  }

  private void PopTag(Asn1Tag tag, UniversalTagNumber tagType, bool sortContents = false)
  {
    (Asn1Tag tag1, int offset1, UniversalTagNumber itemType) = this._nestingStack != null && this._nestingStack.Count != 0 ? this._nestingStack.Peek() : throw new InvalidOperationException(System.System.Formats.Asn13538873.SR.AsnWriter_PopWrongTag);
    if (tag1 != tag || itemType != tagType)
      throw new InvalidOperationException(System.System.Formats.Asn13538873.SR.AsnWriter_PopWrongTag);
    this._nestingStack.Pop();
    if (sortContents)
      AsnWriter.SortContents(this._buffer, offset1 + 1, this._offset);
    if (this.RuleSet == AsnEncodingRules.CER && tagType != UniversalTagNumber.OctetString)
    {
      this.WriteEndOfContents();
    }
    else
    {
      int num1 = this._offset - 1 - offset1;
      int num2 = offset1 + 1;
      if (tagType == UniversalTagNumber.OctetString)
      {
        if (this.RuleSet == AsnEncodingRules.CER && num1 > 1000)
        {
          int result;
          int num3 = 4 * Math.DivRem(num1, 1000, out result) + 2 + AsnWriter.GetEncodedLengthSubsequentByteCount(result);
          this.EnsureWriteCapacity(num3 + 2);
          ReadOnlySpan<byte> readOnlySpan = (ReadOnlySpan<byte>) this._buffer.AsSpan<byte>(num2, num1);
          Span<byte> span = this._buffer.AsSpan<byte>(num2 + num3, num1);
          readOnlySpan.CopyTo(span);
          this._offset = offset1 - tag.CalculateEncodedSize();
          this.WriteConstructedCerOctetString(tag, (ReadOnlySpan<byte>) span);
          return;
        }
        int encodedSize = tag.CalculateEncodedSize();
        tag.AsPrimitive().Encode(this._buffer.AsSpan<byte>(offset1 - encodedSize, encodedSize));
      }
      int subsequentByteCount = AsnWriter.GetEncodedLengthSubsequentByteCount(num1);
      if (subsequentByteCount == 0)
      {
        this._buffer[offset1] = (byte) num1;
      }
      else
      {
        this.EnsureWriteCapacity(subsequentByteCount);
        Buffer.BlockCopy((Array) this._buffer, num2, (Array) this._buffer, num2 + subsequentByteCount, num1);
        int offset2 = this._offset;
        this._offset = offset1;
        this.WriteLength(num1);
        this._offset = offset2 + subsequentByteCount;
      }
    }
  }

  private static void SortContents(byte[] buffer, int start, int end)
  {
    int num1 = end - start;
    if (num1 == 0)
      return;
    AsnReader asnReader = new AsnReader(new ReadOnlyMemory<byte>(buffer, start, num1), AsnEncodingRules.BER);
    int num2 = start;
    ReadOnlyMemory<byte> readOnlyMemory1 = asnReader.ReadEncodedValue();
    if (!asnReader.HasData)
      return;
    List<(int, int)> valueTupleList = new List<(int, int)>();
    valueTupleList.Add((num2, readOnlyMemory1.Length));
    int num3 = num2 + readOnlyMemory1.Length;
    do
    {
      ReadOnlyMemory<byte> readOnlyMemory2 = asnReader.ReadEncodedValue();
      valueTupleList.Add((num3, readOnlyMemory2.Length));
      num3 += readOnlyMemory2.Length;
    }
    while (asnReader.HasData);
    AsnWriter.ArrayIndexSetOfValueComparer setOfValueComparer = new AsnWriter.ArrayIndexSetOfValueComparer(buffer);
    valueTupleList.Sort((IComparer<(int, int)>) setOfValueComparer);
    byte[] numArray = CryptoPool.Rent(num1);
    int dstOffset = 0;
    foreach ((int srcOffset, int count) in valueTupleList)
    {
      Buffer.BlockCopy((Array) buffer, srcOffset, (Array) numArray, dstOffset, count);
      dstOffset += count;
    }
    Buffer.BlockCopy((Array) numArray, 0, (Array) buffer, start, num1);
    CryptoPool.Return(numArray, num1);
  }

  private static void CheckUniversalTag(Asn1Tag? tag, UniversalTagNumber universalTagNumber)
  {
    if (!tag.HasValue)
      return;
    Asn1Tag asn1Tag = tag.Value;
    if (asn1Tag.TagClass == TagClass.Universal && (UniversalTagNumber) asn1Tag.TagValue != universalTagNumber)
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_UniversalValueIsFixed, nameof (tag));
  }

  public void WriteBitString(ReadOnlySpan<byte> value, int unusedBitCount = 0, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.BitString);
    this.WriteBitStringCore(tag ?? Asn1Tag.PrimitiveBitString, value, unusedBitCount);
  }

  private void WriteBitStringCore(Asn1Tag tag, ReadOnlySpan<byte> bitString, int unusedBitCount)
  {
    if (unusedBitCount < 0 || unusedBitCount > 7)
      throw new ArgumentOutOfRangeException(nameof (unusedBitCount), (object) unusedBitCount, System.System.Formats.Asn13538873.SR.Argument_UnusedBitCountRange);
    if (bitString.Length == 0 && unusedBitCount != 0)
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_UnusedBitCountMustBeZero, nameof (unusedBitCount));
    if (!AsnWriter.CheckValidLastByte(bitString.IsEmpty ? (byte) 0 : bitString[bitString.Length - 1], unusedBitCount))
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_UnusedBitWasSet, nameof (unusedBitCount));
    if (this.RuleSet == AsnEncodingRules.CER && bitString.Length >= 1000)
    {
      this.WriteConstructedCerBitString(tag, bitString, unusedBitCount);
    }
    else
    {
      this.WriteTag(tag.AsPrimitive());
      this.WriteLength(bitString.Length + 1);
      this._buffer[this._offset] = (byte) unusedBitCount;
      ++this._offset;
      bitString.CopyTo(this._buffer.AsSpan<byte>(this._offset));
      this._offset += bitString.Length;
    }
  }

  private static bool CheckValidLastByte(byte lastByte, int unusedBitCount)
  {
    int num = (1 << unusedBitCount) - 1;
    return ((int) lastByte & num) == 0;
  }

  private static int DetermineCerBitStringTotalLength(Asn1Tag tag, int contentLength)
  {
    int result;
    return Math.DivRem(contentLength, 999, out result) * 1004 + (result != 0 ? 3 + result + AsnWriter.GetEncodedLengthSubsequentByteCount(result) : 0) + 3 + tag.CalculateEncodedSize();
  }

  private void WriteConstructedCerBitString(
    Asn1Tag tag,
    ReadOnlySpan<byte> payload,
    int unusedBitCount)
  {
    this.EnsureWriteCapacity(AsnWriter.DetermineCerBitStringTotalLength(tag, payload.Length));
    this.WriteTag(tag.AsConstructed());
    this.WriteLength(-1);
    ReadOnlySpan<byte> readOnlySpan = payload;
    Asn1Tag primitiveBitString = Asn1Tag.PrimitiveBitString;
    while (readOnlySpan.Length > 999)
    {
      this.WriteTag(primitiveBitString);
      this.WriteLength(1000);
      this._buffer[this._offset] = (byte) 0;
      ++this._offset;
      Span<byte> destination = this._buffer.AsSpan<byte>(this._offset);
      readOnlySpan.Slice(0, 999).CopyTo(destination);
      readOnlySpan = readOnlySpan.Slice(999);
      this._offset += 999;
    }
    this.WriteTag(primitiveBitString);
    this.WriteLength(readOnlySpan.Length + 1);
    this._buffer[this._offset] = (byte) unusedBitCount;
    ++this._offset;
    Span<byte> destination1 = this._buffer.AsSpan<byte>(this._offset);
    readOnlySpan.CopyTo(destination1);
    this._offset += readOnlySpan.Length;
    this.WriteEndOfContents();
  }

  public void WriteBoolean(bool value, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.Boolean);
    this.WriteBooleanCore(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.Boolean, value);
  }

  private void WriteBooleanCore(Asn1Tag tag, bool value)
  {
    this.WriteTag(tag);
    this.WriteLength(1);
    this._buffer[this._offset] = value ? byte.MaxValue : (byte) 0;
    ++this._offset;
  }

  [NullableContext(1)]
  public void WriteEnumeratedValue(Enum value, Asn1Tag? tag = null)
  {
    if (value == null)
      throw new ArgumentNullException(nameof (value));
    this.WriteEnumeratedValue(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.Enumerated, value.GetType(), (object) value);
  }

  [NullableContext(1)]
  public void WriteEnumeratedValue<[Nullable(0)] TEnum>(TEnum value, Asn1Tag? tag = null) where TEnum : Enum
  {
    this.WriteEnumeratedValue(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.Enumerated, typeof (TEnum), (object) value);
  }

  private void WriteEnumeratedValue(Asn1Tag tag, Type tEnum, object value)
  {
    AsnWriter.CheckUniversalTag(new Asn1Tag?(tag), UniversalTagNumber.Enumerated);
    Type enumUnderlyingType = tEnum.GetEnumUnderlyingType();
    if (tEnum.IsDefined(typeof (FlagsAttribute), false))
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_EnumeratedValueRequiresNonFlagsEnum, nameof (tEnum));
    if (enumUnderlyingType == typeof (ulong))
    {
      ulong uint64 = Convert.ToUInt64(value);
      this.WriteNonNegativeIntegerCore(tag, uint64);
    }
    else
    {
      long int64 = Convert.ToInt64(value);
      this.WriteIntegerCore(tag, int64);
    }
  }

  public void WriteGeneralizedTime(DateTimeOffset value, bool omitFractionalSeconds = false, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.GeneralizedTime);
    this.WriteGeneralizedTimeCore(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.GeneralizedTime, value, omitFractionalSeconds);
  }

  private void WriteGeneralizedTimeCore(
    Asn1Tag tag,
    DateTimeOffset value,
    bool omitFractionalSeconds)
  {
    DateTimeOffset universalTime = value.ToUniversalTime();
    Span<byte> span1 = new Span<byte>();
    if (!omitFractionalSeconds)
    {
      long num = universalTime.Ticks % 10000000L;
      if (num != 0L)
      {
        Span<byte> destination = stackalloc byte[9];
        int bytesWritten;
        span1 = Utf8Formatter.TryFormat((Decimal) num / 10000000M, destination, out bytesWritten, new StandardFormat('G')) ? destination.Slice(1, bytesWritten - 1) : throw new InvalidOperationException();
      }
    }
    int length = 15 + span1.Length;
    this.WriteTag(tag);
    this.WriteLength(length);
    int year = universalTime.Year;
    int month = universalTime.Month;
    int day = universalTime.Day;
    int hour = universalTime.Hour;
    int minute = universalTime.Minute;
    int second = universalTime.Second;
    Span<byte> span2 = this._buffer.AsSpan<byte>(this._offset);
    StandardFormat format1 = new StandardFormat('D', (byte) 4);
    StandardFormat format2 = new StandardFormat('D', (byte) 2);
    int bytesWritten1;
    if (!Utf8Formatter.TryFormat(year, span2.Slice(0, 4), out bytesWritten1, format1) || !Utf8Formatter.TryFormat(month, span2.Slice(4, 2), out bytesWritten1, format2) || !Utf8Formatter.TryFormat(day, span2.Slice(6, 2), out bytesWritten1, format2) || !Utf8Formatter.TryFormat(hour, span2.Slice(8, 2), out bytesWritten1, format2) || !Utf8Formatter.TryFormat(minute, span2.Slice(10, 2), out bytesWritten1, format2) || !Utf8Formatter.TryFormat(second, span2.Slice(12, 2), out bytesWritten1, format2))
      throw new InvalidOperationException();
    this._offset += 14;
    span1.CopyTo(span2.Slice(14));
    this._offset += span1.Length;
    this._buffer[this._offset] = (byte) 90;
    ++this._offset;
  }

  public void WriteInteger(long value, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.Integer);
    this.WriteIntegerCore(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.Integer, value);
  }

  [CLSCompliant(false)]
  public void WriteInteger(ulong value, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.Integer);
    this.WriteNonNegativeIntegerCore(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.Integer, value);
  }

  public void WriteInteger(BigInteger value, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.Integer);
    this.WriteIntegerCore(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.Integer, value);
  }

  public void WriteInteger(ReadOnlySpan<byte> value, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.Integer);
    this.WriteIntegerCore(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.Integer, value);
  }

  public void WriteIntegerUnsigned(ReadOnlySpan<byte> value, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.Integer);
    this.WriteIntegerUnsignedCore(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.Integer, value);
  }

  private void WriteIntegerCore(Asn1Tag tag, long value)
  {
    if (value >= 0L)
    {
      this.WriteNonNegativeIntegerCore(tag, (ulong) value);
    }
    else
    {
      int length = value < (long) sbyte.MinValue ? (value < (long) short.MinValue ? (value < -8388608L ? (value < (long) int.MinValue ? (value < -549755813888L /*0xFFFFFF8000000000*/ ? (value < -140737488355328L /*0xFFFF800000000000*/ ? (value < -36028797018963968L /*0xFF80000000000000*/ ? 8 : 7) : 6) : 5) : 4) : 3) : 2) : 1;
      this.WriteTag(tag);
      this.WriteLength(length);
      long num = value;
      int index = this._offset + length - 1;
      do
      {
        this._buffer[index] = (byte) num;
        num >>= 8;
        --index;
      }
      while (index >= this._offset);
      this._offset += length;
    }
  }

  private void WriteNonNegativeIntegerCore(Asn1Tag tag, ulong value)
  {
    int length = value >= 128UL /*0x80*/ ? (value >= 32768UL /*0x8000*/ ? (value >= 8388608UL /*0x800000*/ ? (value >= 2147483648UL /*0x80000000*/ ? (value >= 549755813888UL /*0x8000000000*/ ? (value >= 140737488355328UL /*0x800000000000*/ ? (value >= 36028797018963968UL /*0x80000000000000*/ ? (value >= 9223372036854775808UL /*0x8000000000000000*/ ? 9 : 8) : 7) : 6) : 5) : 4) : 3) : 2) : 1;
    this.WriteTag(tag);
    this.WriteLength(length);
    ulong num = value;
    int index = this._offset + length - 1;
    do
    {
      this._buffer[index] = (byte) num;
      num >>= 8;
      --index;
    }
    while (index >= this._offset);
    this._offset += length;
  }

  private void WriteIntegerUnsignedCore(Asn1Tag tag, ReadOnlySpan<byte> value)
  {
    if (value.IsEmpty)
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_IntegerCannotBeEmpty, nameof (value));
    if (value.Length > 1 && value[0] == (byte) 0 && value[1] < (byte) 128 /*0x80*/)
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_IntegerRedundantByte, nameof (value));
    this.WriteTag(tag);
    if (value[0] >= (byte) 128 /*0x80*/)
    {
      this.WriteLength(checked (value.Length + 1));
      this._buffer[this._offset] = (byte) 0;
      ++this._offset;
    }
    else
      this.WriteLength(value.Length);
    value.CopyTo(this._buffer.AsSpan<byte>(this._offset));
    this._offset += value.Length;
  }

  private void WriteIntegerCore(Asn1Tag tag, ReadOnlySpan<byte> value)
  {
    if (value.IsEmpty)
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_IntegerCannotBeEmpty, nameof (value));
    ushort num;
    if (BinaryPrimitives.TryReadUInt16BigEndian(value, out num))
    {
      switch ((ushort) ((uint) num & 65408U))
      {
        case 0:
        case 65408:
          throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_IntegerRedundantByte, nameof (value));
      }
    }
    this.WriteTag(tag);
    this.WriteLength(value.Length);
    value.CopyTo(this._buffer.AsSpan<byte>(this._offset));
    this._offset += value.Length;
  }

  private void WriteIntegerCore(Asn1Tag tag, BigInteger value)
  {
    this.WriteTag(tag);
    byte[] byteArray = value.ToByteArray();
    Array.Reverse((Array) byteArray);
    this.WriteLength(byteArray.Length);
    Buffer.BlockCopy((Array) byteArray, 0, (Array) this._buffer, this._offset, byteArray.Length);
    this._offset += byteArray.Length;
  }

  [NullableContext(1)]
  public void WriteNamedBitList(Enum value, Asn1Tag? tag = null)
  {
    if (value == null)
      throw new ArgumentNullException(nameof (value));
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.BitString);
    this.WriteNamedBitList(tag, value.GetType(), value);
  }

  [NullableContext(1)]
  public void WriteNamedBitList<[Nullable(0)] TEnum>(TEnum value, Asn1Tag? tag = null) where TEnum : Enum
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.BitString);
    this.WriteNamedBitList(tag, typeof (TEnum), (Enum) value);
  }

  [NullableContext(1)]
  public void WriteNamedBitList(BitArray value, Asn1Tag? tag = null)
  {
    if (value == null)
      throw new ArgumentNullException(nameof (value));
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.BitString);
    this.WriteBitArray(value, tag);
  }

  private void WriteNamedBitList(Asn1Tag? tag, Type tEnum, Enum value)
  {
    Type enumUnderlyingType = tEnum.GetEnumUnderlyingType();
    if (!tEnum.IsDefined(typeof (FlagsAttribute), false))
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_NamedBitListRequiresFlagsEnum, nameof (tEnum));
    ulong integralValue = !(enumUnderlyingType == typeof (ulong)) ? (ulong) Convert.ToInt64((object) value) : Convert.ToUInt64((object) value);
    this.WriteNamedBitList(tag, integralValue);
  }

  private void WriteNamedBitList(Asn1Tag? tag, ulong integralValue)
  {
    Span<byte> span = stackalloc byte[8];
    span.Clear();
    int num1 = -1;
    int num2 = 0;
    while (integralValue != 0UL)
    {
      if (((long) integralValue & 1L) != 0L)
      {
        span[num2 / 8] |= (byte) (128 /*0x80*/ >> num2 % 8);
        num1 = num2;
      }
      integralValue >>= 1;
      ++num2;
    }
    if (num1 < 0)
    {
      this.WriteBitString(ReadOnlySpan<byte>.Empty, tag: tag);
    }
    else
    {
      int length = num1 / 8 + 1;
      int unusedBitCount = 7 - num1 % 8;
      this.WriteBitString((ReadOnlySpan<byte>) span.Slice(0, length), unusedBitCount, tag);
    }
  }

  private void WriteBitArray(BitArray value, Asn1Tag? tag)
  {
    if (value.Count == 0)
    {
      this.WriteBitString(ReadOnlySpan<byte>.Empty, tag: tag);
    }
    else
    {
      int num = checked (value.Count + 7) / 8;
      int unusedBitCount = num * 8 - value.Count;
      byte[] array = CryptoPool.Rent(num);
      value.CopyTo((Array) array, 0);
      Span<byte> span = array.AsSpan<byte>(0, num);
      AsnDecoder.ReverseBitsPerByte(span);
      this.WriteBitString((ReadOnlySpan<byte>) span, unusedBitCount, tag);
      CryptoPool.Return(array, num);
    }
  }

  public void WriteNull(Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.Null);
    this.WriteNullCore(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.Null);
  }

  private void WriteNullCore(Asn1Tag tag)
  {
    this.WriteTag(tag);
    this.WriteLength(0);
  }

  public AsnWriter.Scope PushOctetString(Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.OctetString);
    return this.PushTag(tag.HasValue ? tag.GetValueOrDefault().AsConstructed() : Asn1Tag.ConstructedOctetString, UniversalTagNumber.OctetString);
  }

  public void PopOctetString(Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.OctetString);
    this.PopTag(tag.HasValue ? tag.GetValueOrDefault().AsConstructed() : Asn1Tag.ConstructedOctetString, UniversalTagNumber.OctetString);
  }

  public void WriteOctetString(ReadOnlySpan<byte> value, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.OctetString);
    this.WriteOctetStringCore(tag ?? Asn1Tag.PrimitiveOctetString, value);
  }

  private void WriteOctetStringCore(Asn1Tag tag, ReadOnlySpan<byte> octetString)
  {
    if (this.RuleSet == AsnEncodingRules.CER && octetString.Length > 1000)
    {
      this.WriteConstructedCerOctetString(tag, octetString);
    }
    else
    {
      this.WriteTag(tag.AsPrimitive());
      this.WriteLength(octetString.Length);
      octetString.CopyTo(this._buffer.AsSpan<byte>(this._offset));
      this._offset += octetString.Length;
    }
  }

  private void WriteConstructedCerOctetString(Asn1Tag tag, ReadOnlySpan<byte> payload)
  {
    this.WriteTag(tag.AsConstructed());
    this.WriteLength(-1);
    int result;
    this.EnsureWriteCapacity(Math.DivRem(payload.Length, 1000, out result) * 1004 + (result != 0 ? 2 + result + AsnWriter.GetEncodedLengthSubsequentByteCount(result) : 0) + 2);
    ReadOnlySpan<byte> readOnlySpan = payload;
    Asn1Tag primitiveOctetString = Asn1Tag.PrimitiveOctetString;
    for (; readOnlySpan.Length > 1000; readOnlySpan = readOnlySpan.Slice(1000))
    {
      this.WriteTag(primitiveOctetString);
      this.WriteLength(1000);
      Span<byte> destination = this._buffer.AsSpan<byte>(this._offset);
      readOnlySpan.Slice(0, 1000).CopyTo(destination);
      this._offset += 1000;
    }
    this.WriteTag(primitiveOctetString);
    this.WriteLength(readOnlySpan.Length);
    Span<byte> destination1 = this._buffer.AsSpan<byte>(this._offset);
    readOnlySpan.CopyTo(destination1);
    this._offset += readOnlySpan.Length;
    this.WriteEndOfContents();
  }

  [NullableContext(1)]
  public void WriteObjectIdentifier(string oidValue, Asn1Tag? tag = null)
  {
    if (oidValue == null)
      throw new ArgumentNullException(nameof (oidValue));
    this.WriteObjectIdentifier(oidValue.AsSpan(), tag);
  }

  public void WriteObjectIdentifier(ReadOnlySpan<char> oidValue, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.ObjectIdentifier);
    this.WriteObjectIdentifierCore(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.ObjectIdentifier, oidValue);
  }

  private void WriteObjectIdentifierCore(Asn1Tag tag, ReadOnlySpan<char> oidValue)
  {
    if (oidValue.Length < 3)
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_InvalidOidValue, nameof (oidValue));
    byte[] numArray = oidValue[1] == '.' ? CryptoPool.Rent(oidValue.Length / 2) : throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_InvalidOidValue, nameof (oidValue));
    int num1 = 0;
    try
    {
      int num2;
      switch (oidValue[0])
      {
        case '0':
          num2 = 0;
          break;
        case '1':
          num2 = 1;
          break;
        case '2':
          num2 = 2;
          break;
        default:
          throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_InvalidOidValue, nameof (oidValue));
      }
      int num3 = num2;
      ReadOnlySpan<char> oidValue1 = oidValue.Slice(2);
      BigInteger subIdentifier1 = AsnWriter.ParseSubIdentifier(ref oidValue1) + (BigInteger) (40 * num3);
      int num4 = AsnWriter.EncodeSubIdentifier(numArray.AsSpan<byte>(num1), ref subIdentifier1);
      num1 += num4;
      while (!oidValue1.IsEmpty)
      {
        BigInteger subIdentifier2 = AsnWriter.ParseSubIdentifier(ref oidValue1);
        int num5 = AsnWriter.EncodeSubIdentifier(numArray.AsSpan<byte>(num1), ref subIdentifier2);
        num1 += num5;
      }
      this.WriteTag(tag);
      this.WriteLength(num1);
      Buffer.BlockCopy((Array) numArray, 0, (Array) this._buffer, this._offset, num1);
      this._offset += num1;
    }
    finally
    {
      CryptoPool.Return(numArray, num1);
    }
  }

  private static BigInteger ParseSubIdentifier(ref ReadOnlySpan<char> oidValue)
  {
    int num = oidValue.IndexOf<char>('.');
    switch (num)
    {
      case -1:
        num = oidValue.Length;
        break;
      case 0:
        throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_InvalidOidValue, nameof (oidValue));
      default:
        if (num != oidValue.Length - 1)
          break;
        goto case 0;
    }
    BigInteger subIdentifier = BigInteger.Zero;
    for (int index = 0; index < num; ++index)
    {
      if (index > 0 && subIdentifier == 0L)
        throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_InvalidOidValue, nameof (oidValue));
      subIdentifier = subIdentifier * (BigInteger) 10 + (BigInteger) AsnWriter.AtoI(oidValue[index]);
    }
    oidValue = oidValue.Slice(Math.Min(oidValue.Length, num + 1));
    return subIdentifier;
  }

  private static int AtoI(char c)
  {
    if (c < '0' || c > '9')
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_InvalidOidValue, "oidValue");
    return (int) c - 48 /*0x30*/;
  }

  private static int EncodeSubIdentifier(Span<byte> dest, ref BigInteger subIdentifier)
  {
    if (subIdentifier.IsZero)
    {
      dest[0] = (byte) 0;
      return 1;
    }
    BigInteger bigInteger = subIdentifier;
    int num1 = 0;
    do
    {
      byte num2 = (byte) (bigInteger & (BigInteger) (int) sbyte.MaxValue);
      if (subIdentifier != bigInteger)
        goto label_4;
label_3:
      bigInteger >>= 7;
      dest[num1] = num2;
      ++num1;
      continue;
label_4:
      num2 |= (byte) 128 /*0x80*/;
      goto label_3;
    }
    while (bigInteger != BigInteger.Zero);
    dest.Slice(0, num1).Reverse<byte>();
    return num1;
  }

  public AsnWriter.Scope PushSequence(Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.Sequence);
    return this.PushSequenceCore(tag.HasValue ? tag.GetValueOrDefault().AsConstructed() : Asn1Tag.Sequence);
  }

  public void PopSequence(Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.Sequence);
    this.PopSequenceCore(tag.HasValue ? tag.GetValueOrDefault().AsConstructed() : Asn1Tag.Sequence);
  }

  private AsnWriter.Scope PushSequenceCore(Asn1Tag tag)
  {
    return this.PushTag(tag, UniversalTagNumber.Sequence);
  }

  private void PopSequenceCore(Asn1Tag tag) => this.PopTag(tag, UniversalTagNumber.Sequence);

  public AsnWriter.Scope PushSetOf(Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.Set);
    return this.PushSetOfCore(tag.HasValue ? tag.GetValueOrDefault().AsConstructed() : Asn1Tag.SetOf);
  }

  public void PopSetOf(Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.Set);
    this.PopSetOfCore(tag.HasValue ? tag.GetValueOrDefault().AsConstructed() : Asn1Tag.SetOf);
  }

  private AsnWriter.Scope PushSetOfCore(Asn1Tag tag) => this.PushTag(tag, UniversalTagNumber.Set);

  private void PopSetOfCore(Asn1Tag tag)
  {
    bool sortContents = this.RuleSet == AsnEncodingRules.CER || this.RuleSet == AsnEncodingRules.DER;
    this.PopTag(tag, UniversalTagNumber.Set, sortContents);
  }

  [NullableContext(1)]
  public void WriteCharacterString(UniversalTagNumber encodingType, string value, Asn1Tag? tag = null)
  {
    if (value == null)
      throw new ArgumentNullException(nameof (value));
    this.WriteCharacterString(encodingType, value.AsSpan(), tag);
  }

  public void WriteCharacterString(
    UniversalTagNumber encodingType,
    ReadOnlySpan<char> str,
    Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, encodingType);
    Encoding encoding = AsnCharacterStringEncodings.GetEncoding(encodingType);
    this.WriteCharacterStringCore(tag ?? new Asn1Tag(encodingType), encoding, str);
  }

  private void WriteCharacterStringCore(Asn1Tag tag, Encoding encoding, ReadOnlySpan<char> str)
  {
    int byteCount = encoding.GetByteCount(str);
    if (this.RuleSet == AsnEncodingRules.CER && byteCount > 1000)
    {
      this.WriteConstructedCerCharacterString(tag, encoding, str, byteCount);
    }
    else
    {
      this.WriteTag(tag.AsPrimitive());
      this.WriteLength(byteCount);
      Span<byte> bytes = this._buffer.AsSpan<byte>(this._offset, byteCount);
      if (encoding.GetBytes(str, bytes) != byteCount)
        throw new InvalidOperationException();
      this._offset += byteCount;
    }
  }

  private void WriteConstructedCerCharacterString(
    Asn1Tag tag,
    Encoding encoding,
    ReadOnlySpan<char> str,
    int size)
  {
    byte[] numArray = CryptoPool.Rent(size);
    if (encoding.GetBytes(str, (Span<byte>) numArray) != size)
      throw new InvalidOperationException();
    this.WriteConstructedCerOctetString(tag, (ReadOnlySpan<byte>) numArray.AsSpan<byte>(0, size));
    CryptoPool.Return(numArray, size);
  }

  public void WriteUtcTime(DateTimeOffset value, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.UtcTime);
    this.WriteUtcTimeCore(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.UtcTime, value);
  }

  public void WriteUtcTime(DateTimeOffset value, int twoDigitYearMax, Asn1Tag? tag = null)
  {
    AsnWriter.CheckUniversalTag(tag, UniversalTagNumber.UtcTime);
    value = value.ToUniversalTime();
    if (value.Year > twoDigitYearMax || value.Year <= twoDigitYearMax - 100)
      throw new ArgumentOutOfRangeException(nameof (value));
    this.WriteUtcTimeCore(tag.HasValue ? tag.GetValueOrDefault().AsPrimitive() : Asn1Tag.UtcTime, value);
  }

  private void WriteUtcTimeCore(Asn1Tag tag, DateTimeOffset value)
  {
    this.WriteTag(tag);
    this.WriteLength(13);
    DateTimeOffset universalTime = value.ToUniversalTime();
    int year = universalTime.Year;
    int month = universalTime.Month;
    int day = universalTime.Day;
    int hour = universalTime.Hour;
    int minute = universalTime.Minute;
    int second = universalTime.Second;
    Span<byte> span = this._buffer.AsSpan<byte>(this._offset);
    StandardFormat format = new StandardFormat('D', (byte) 2);
    int bytesWritten;
    if (!Utf8Formatter.TryFormat(year % 100, span.Slice(0, 2), out bytesWritten, format) || !Utf8Formatter.TryFormat(month, span.Slice(2, 2), out bytesWritten, format) || !Utf8Formatter.TryFormat(day, span.Slice(4, 2), out bytesWritten, format) || !Utf8Formatter.TryFormat(hour, span.Slice(6, 2), out bytesWritten, format) || !Utf8Formatter.TryFormat(minute, span.Slice(8, 2), out bytesWritten, format) || !Utf8Formatter.TryFormat(second, span.Slice(10, 2), out bytesWritten, format))
      throw new InvalidOperationException();
    this._buffer[this._offset + 12] = (byte) 90;
    this._offset += 13;
  }

  private sealed class ArrayIndexSetOfValueComparer : IComparer<(int, int)>
  {
    private readonly byte[] _data;

    public ArrayIndexSetOfValueComparer(byte[] data) => this._data = data;

    public int Compare((int, int) x, (int, int) y)
    {
      (int start1, int length1) = x;
      (int start2, int length2) = y;
      int num = SetOfValueComparer.Instance.Compare(new ReadOnlyMemory<byte>(this._data, start1, length1), new ReadOnlyMemory<byte>(this._data, start2, length2));
      return num == 0 ? start1 - start2 : num;
    }
  }

  [IsReadOnly]
  private struct StackFrame : IEquatable<AsnWriter.StackFrame>
  {
    public Asn1Tag Tag { get; }

    public int Offset { get; }

    public UniversalTagNumber ItemType { get; }

    internal StackFrame(Asn1Tag tag, int offset, UniversalTagNumber itemType)
    {
      this.Tag = tag;
      this.Offset = offset;
      this.ItemType = itemType;
    }

    public void Deconstruct(out Asn1Tag tag, out int offset, out UniversalTagNumber itemType)
    {
      tag = this.Tag;
      offset = this.Offset;
      itemType = this.ItemType;
    }

    public bool Equals(AsnWriter.StackFrame other)
    {
      return this.Tag.Equals(other.Tag) && this.Offset == other.Offset && this.ItemType == other.ItemType;
    }

    public override bool Equals([NotNullWhen(true)] object obj)
    {
      return obj is AsnWriter.StackFrame other && this.Equals(other);
    }

    public override int GetHashCode() => (this.Tag, this.Offset, this.ItemType).GetHashCode();

    public static bool operator ==(AsnWriter.StackFrame left, AsnWriter.StackFrame right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(AsnWriter.StackFrame left, AsnWriter.StackFrame right)
    {
      return !left.Equals(right);
    }
  }

  [IsReadOnly]
  public struct Scope : IDisposable
  {
    private readonly AsnWriter _writer;
    private readonly AsnWriter.StackFrame _frame;
    private readonly int _depth;

    internal Scope(AsnWriter writer)
    {
      this._writer = writer;
      this._frame = this._writer._nestingStack.Peek();
      this._depth = this._writer._nestingStack.Count;
    }

    public void Dispose()
    {
      if (this._writer == null || this._writer._nestingStack.Count == 0)
        return;
      if (this._writer._nestingStack.Peek() == this._frame)
      {
        switch (this._frame.ItemType)
        {
          case UniversalTagNumber.OctetString:
            this._writer.PopOctetString(new Asn1Tag?(this._frame.Tag));
            break;
          case UniversalTagNumber.Sequence:
            this._writer.PopSequence(new Asn1Tag?(this._frame.Tag));
            break;
          case UniversalTagNumber.Set:
            this._writer.PopSetOf(new Asn1Tag?(this._frame.Tag));
            break;
          default:
            throw new InvalidOperationException();
        }
      }
      else if (this._writer._nestingStack.Count > this._depth && this._writer._nestingStack.Contains(this._frame))
        throw new InvalidOperationException(System.System.Formats.Asn13538873.SR.AsnWriter_PopWrongTag);
    }
  }
}
