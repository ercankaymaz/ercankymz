// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.Asn1Tag
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Diagnostics.CodeAnalysis.System.Formats.Asn13538873;
using System.Runtime.CompilerServices.System.Formats.Asn1;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Formats.Asn1;

[IsReadOnly]
[ComVisible(true)]
public struct Asn1Tag : IEquatable<Asn1Tag>
{
  private const byte ClassMask = 192 /*0xC0*/;
  private const byte ConstructedMask = 32 /*0x20*/;
  private const byte ControlMask = 224 /*0xE0*/;
  private const byte TagNumberMask = 31 /*0x1F*/;
  private readonly byte _controlFlags;
  internal static readonly Asn1Tag EndOfContents = new Asn1Tag((byte) 0, 0);
  public static readonly Asn1Tag Boolean = new Asn1Tag((byte) 0, 1);
  public static readonly Asn1Tag Integer = new Asn1Tag((byte) 0, 2);
  public static readonly Asn1Tag PrimitiveBitString = new Asn1Tag((byte) 0, 3);
  public static readonly Asn1Tag ConstructedBitString = new Asn1Tag((byte) 32 /*0x20*/, 3);
  public static readonly Asn1Tag PrimitiveOctetString = new Asn1Tag((byte) 0, 4);
  public static readonly Asn1Tag ConstructedOctetString = new Asn1Tag((byte) 32 /*0x20*/, 4);
  public static readonly Asn1Tag Null = new Asn1Tag((byte) 0, 5);
  public static readonly Asn1Tag ObjectIdentifier = new Asn1Tag((byte) 0, 6);
  public static readonly Asn1Tag Enumerated = new Asn1Tag((byte) 0, 10);
  public static readonly Asn1Tag Sequence = new Asn1Tag((byte) 32 /*0x20*/, 16 /*0x10*/);
  public static readonly Asn1Tag SetOf = new Asn1Tag((byte) 32 /*0x20*/, 17);
  public static readonly Asn1Tag UtcTime = new Asn1Tag((byte) 0, 23);
  public static readonly Asn1Tag GeneralizedTime = new Asn1Tag((byte) 0, 24);

  public TagClass TagClass => (TagClass) ((int) this._controlFlags & 192 /*0xC0*/);

  public bool IsConstructed => ((uint) this._controlFlags & 32U /*0x20*/) > 0U;

  public int TagValue { get; }

  private Asn1Tag(byte controlFlags, int tagValue)
  {
    this._controlFlags = (byte) ((uint) controlFlags & 224U /*0xE0*/);
    this.TagValue = tagValue;
  }

  public Asn1Tag(UniversalTagNumber universalTagNumber, bool isConstructed = false)
    : this(isConstructed ? (byte) 32 /*0x20*/ : (byte) 0, (int) universalTagNumber)
  {
    if (universalTagNumber < UniversalTagNumber.EndOfContents || universalTagNumber > UniversalTagNumber.RelativeObjectIdentifierIRI || universalTagNumber == (UniversalTagNumber.ObjectDescriptor | UniversalTagNumber.External))
      throw new ArgumentOutOfRangeException(nameof (universalTagNumber));
  }

  public Asn1Tag(TagClass tagClass, int tagValue, bool isConstructed = false)
    : this((byte) ((int) (byte) tagClass | (isConstructed ? 32 /*0x20*/ : 0)), tagValue)
  {
    if (tagClass <= TagClass.Application)
    {
      if (tagClass == TagClass.Universal || tagClass == TagClass.Application)
        goto label_5;
    }
    else if (tagClass == TagClass.ContextSpecific || tagClass == TagClass.Private)
      goto label_5;
    throw new ArgumentOutOfRangeException(nameof (tagClass));
label_5:
    if (tagValue < 0)
      throw new ArgumentOutOfRangeException(nameof (tagValue));
  }

  public Asn1Tag AsConstructed()
  {
    return new Asn1Tag((byte) ((uint) this._controlFlags | 32U /*0x20*/), this.TagValue);
  }

  public Asn1Tag AsPrimitive()
  {
    return new Asn1Tag((byte) ((uint) this._controlFlags & 4294967263U), this.TagValue);
  }

  public static bool TryDecode(ReadOnlySpan<byte> source, out Asn1Tag tag, out int bytesConsumed)
  {
    tag = new Asn1Tag();
    bytesConsumed = 0;
    if (source.IsEmpty)
      return false;
    byte controlFlags = source[bytesConsumed];
    ++bytesConsumed;
    uint tagValue = (uint) controlFlags & 31U /*0x1F*/;
    if (tagValue == 31U /*0x1F*/)
    {
      tagValue = 0U;
      while (source.Length > bytesConsumed)
      {
        byte num1 = source[bytesConsumed];
        byte num2 = (byte) ((uint) num1 & (uint) sbyte.MaxValue);
        ++bytesConsumed;
        if (tagValue < 33554432U /*0x02000000*/)
        {
          tagValue = tagValue << 7 | (uint) num2;
          if (tagValue != 0U)
          {
            if (((int) num1 & 128 /*0x80*/) != 128 /*0x80*/)
            {
              if (tagValue <= 30U)
              {
                bytesConsumed = 0;
                return false;
              }
              if (tagValue > (uint) int.MaxValue)
              {
                bytesConsumed = 0;
                return false;
              }
              goto label_15;
            }
          }
          else
          {
            bytesConsumed = 0;
            return false;
          }
        }
        else
        {
          bytesConsumed = 0;
          return false;
        }
      }
      bytesConsumed = 0;
      return false;
    }
label_15:
    tag = new Asn1Tag(controlFlags, (int) tagValue);
    return true;
  }

  public static Asn1Tag Decode(ReadOnlySpan<byte> source, out int bytesConsumed)
  {
    Asn1Tag tag;
    if (!Asn1Tag.TryDecode(source, out tag, out bytesConsumed))
      throw new AsnContentException(System.System.Formats.Asn13538873.SR.ContentException_InvalidTag);
    return tag;
  }

  public int CalculateEncodedSize()
  {
    if (this.TagValue < 31 /*0x1F*/)
      return 1;
    if (this.TagValue <= (int) sbyte.MaxValue)
      return 2;
    if (this.TagValue <= 16383 /*0x3FFF*/)
      return 3;
    if (this.TagValue <= 2097151 /*0x1FFFFF*/)
      return 4;
    return this.TagValue <= 268435455 /*0x0FFFFFFF*/ ? 5 : 6;
  }

  public bool TryEncode(Span<byte> destination, out int bytesWritten)
  {
    int encodedSize = this.CalculateEncodedSize();
    if (destination.Length < encodedSize)
    {
      bytesWritten = 0;
      return false;
    }
    if (encodedSize == 1)
    {
      byte num = (byte) ((uint) this._controlFlags | (uint) this.TagValue);
      destination[0] = num;
      bytesWritten = 1;
      return true;
    }
    byte num1 = (byte) ((uint) this._controlFlags | 31U /*0x1F*/);
    destination[0] = num1;
    int tagValue = this.TagValue;
    int index = encodedSize - 1;
    while (tagValue > 0)
    {
      int num2 = tagValue & (int) sbyte.MaxValue;
      if (tagValue != this.TagValue)
        num2 |= 128 /*0x80*/;
      destination[index] = (byte) num2;
      tagValue >>= 7;
      --index;
    }
    bytesWritten = encodedSize;
    return true;
  }

  public int Encode(Span<byte> destination)
  {
    int bytesWritten;
    if (!this.TryEncode(destination, out bytesWritten))
      throw new ArgumentException(System.System.Formats.Asn13538873.SR.Argument_DestinationTooShort, nameof (destination));
    return bytesWritten;
  }

  public bool Equals(Asn1Tag other)
  {
    return (int) this._controlFlags == (int) other._controlFlags && this.TagValue == other.TagValue;
  }

  [NullableContext(2)]
  public override bool Equals([NotNullWhen(true)] object obj)
  {
    return obj is Asn1Tag other && this.Equals(other);
  }

  public override int GetHashCode() => (int) this._controlFlags << 24 ^ this.TagValue;

  public static bool operator ==(Asn1Tag left, Asn1Tag right) => left.Equals(right);

  public static bool operator !=(Asn1Tag left, Asn1Tag right) => !left.Equals(right);

  public bool HasSameClassAndValue(Asn1Tag other)
  {
    return this.TagValue == other.TagValue && this.TagClass == other.TagClass;
  }

  [NullableContext(1)]
  public override string ToString()
  {
    string str = this.TagClass != TagClass.Universal ? $"{this.TagClass}-{this.TagValue}" : ((UniversalTagNumber) this.TagValue).ToString();
    return this.IsConstructed ? "Constructed " + str : str;
  }
}
