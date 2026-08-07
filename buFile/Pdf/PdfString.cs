// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfString
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfString : PdfItem
{
  private readonly PdfStringFlags _flags;
  private string _value;
  private static readonly char[] Encode = new char[256 /*0x0100*/]
  {
    char.MinValue,
    '\u0001',
    '\u0002',
    '\u0003',
    '\u0004',
    '\u0005',
    '\u0006',
    '\a',
    '\b',
    '\t',
    '\n',
    '\v',
    '\f',
    '\r',
    '\u000E',
    '\u000F',
    '\u0010',
    '\u0011',
    '\u0012',
    '\u0013',
    '\u0014',
    '\u0015',
    '\u0016',
    '\u0017',
    '\u0018',
    '\u0019',
    '\u001A',
    '\u001B',
    '\u001C',
    '\u001D',
    '\u001E',
    '\u001F',
    ' ',
    '!',
    '"',
    '#',
    '$',
    '%',
    '&',
    '\'',
    '(',
    ')',
    '*',
    '+',
    ',',
    '-',
    '.',
    '/',
    '0',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    ':',
    ';',
    '<',
    '=',
    '>',
    '?',
    '@',
    'A',
    'B',
    'C',
    'D',
    'E',
    'F',
    'G',
    'H',
    'I',
    'J',
    'K',
    'L',
    'M',
    'N',
    'O',
    'P',
    'Q',
    'R',
    'S',
    'T',
    'U',
    'V',
    'W',
    'X',
    'Y',
    'Z',
    '[',
    '\\',
    ']',
    '^',
    '_',
    '`',
    'a',
    'b',
    'c',
    'd',
    'e',
    'f',
    'g',
    'h',
    'i',
    'j',
    'k',
    'l',
    'm',
    'n',
    'o',
    'p',
    'q',
    'r',
    's',
    't',
    'u',
    'v',
    'w',
    'x',
    'y',
    'z',
    '{',
    '|',
    '}',
    '~',
    '\u007F',
    '•',
    '†',
    '‡',
    '…',
    '—',
    '–',
    'ƒ',
    '⁄',
    '‹',
    '›',
    '−',
    '‰',
    '„',
    '“',
    '”',
    '‘',
    '’',
    '‚',
    '™',
    'ﬁ',
    'ﬂ',
    'Ł',
    'Œ',
    'Š',
    'Ÿ',
    'Ž',
    'ı',
    'ł',
    'œ',
    'š',
    'ž',
    '�',
    '€',
    '¡',
    '¢',
    '£',
    '¤',
    '¥',
    '¦',
    '§',
    '¨',
    '©',
    'ª',
    '«',
    '¬',
    '\u00AD',
    '®',
    '¯',
    '°',
    '±',
    '\u00B2',
    '\u00B3',
    '´',
    'µ',
    '¶',
    '·',
    '¸',
    '\u00B9',
    'º',
    '»',
    '\u00BC',
    '\u00BD',
    '\u00BE',
    '¿',
    'À',
    'Á',
    'Â',
    'Ã',
    'Ä',
    'Å',
    'Æ',
    'Ç',
    'È',
    'É',
    'Ê',
    'Ë',
    'Ì',
    'Í',
    'Î',
    'Ï',
    'Ð',
    'Ñ',
    'Ò',
    'Ó',
    'Ô',
    'Õ',
    'Ö',
    '×',
    'Ø',
    'Ù',
    'Ú',
    'Û',
    'Ü',
    'Ý',
    'Þ',
    'ß',
    'à',
    'á',
    'â',
    'ã',
    'ä',
    'å',
    'æ',
    'ç',
    'è',
    'é',
    'ê',
    'ë',
    'ì',
    'í',
    'î',
    'ï',
    'ð',
    'ñ',
    'ò',
    'ó',
    'ô',
    'õ',
    'ö',
    '÷',
    'ø',
    'ù',
    'ú',
    'û',
    'ü',
    'ý',
    'þ',
    'ÿ'
  };

  public PdfString()
  {
  }

  public PdfString(string value)
  {
    if (!PdfString.IsRawEncoding(value))
      this._flags = PdfStringFlags.Unicode;
    this._value = value;
  }

  public PdfString(string value, PdfStringEncoding encoding)
  {
    switch (encoding)
    {
      case PdfStringEncoding.RawEncoding:
        PdfString.CheckRawEncoding(value);
        goto case PdfStringEncoding.StandardEncoding;
      case PdfStringEncoding.StandardEncoding:
      case PdfStringEncoding.PDFDocEncoding:
      case PdfStringEncoding.MacRomanEncoding:
      case PdfStringEncoding.Unicode:
        this._value = value;
        this._flags = (PdfStringFlags) encoding;
        break;
      case PdfStringEncoding.WinAnsiEncoding:
        PdfString.CheckRawEncoding(value);
        goto case PdfStringEncoding.StandardEncoding;
      default:
        throw new ArgumentOutOfRangeException(nameof (encoding));
    }
  }

  internal PdfString(string value, PdfStringFlags flags)
  {
    this._value = value;
    this._flags = flags;
  }

  public int Length => this._value == null ? 0 : this._value.Length;

  public PdfStringEncoding Encoding
  {
    get => (PdfStringEncoding) (this._flags & PdfStringFlags.EncodingMask);
  }

  public bool HexLiteral => (this._flags & PdfStringFlags.HexLiteral) != 0;

  internal PdfStringFlags Flags => this._flags;

  public string Value => this._value ?? "";

  internal byte[] EncryptionValue
  {
    get => this._value == null ? new byte[0] : PdfEncoders.RawEncoding.GetBytes(this._value);
    set => this._value = PdfEncoders.RawEncoding.GetString(value, 0, value.Length);
  }

  public override string ToString()
  {
    PdfStringEncoding encoding = (PdfStringEncoding) (this._flags & PdfStringFlags.EncodingMask);
    return (this._flags & PdfStringFlags.HexLiteral) == PdfStringFlags.RawEncoding ? PdfEncoders.ToStringLiteral(this._value, encoding, (PdfStandardSecurityHandler) null) : PdfEncoders.ToHexStringLiteral(this._value, encoding, (PdfStandardSecurityHandler) null);
  }

  public string ToStringFromPdfDocEncoded()
  {
    int length = this._value.Length;
    char[] chArray = new char[length];
    for (int index1 = 0; index1 < length; ++index1)
    {
      char index2 = this._value[index1];
      chArray[index1] = index2 <= 'ÿ' ? PdfString.Encode[(int) index2] : throw new InvalidOperationException("DocEncoded string contains char greater 255.");
    }
    StringBuilder stringBuilder = new StringBuilder(length);
    for (int index = 0; index < length; ++index)
      stringBuilder.Append(chArray[index]);
    return stringBuilder.ToString();
  }

  private static void CheckRawEncoding(string s)
  {
    if (string.IsNullOrEmpty(s))
      return;
    int length = s.Length;
    for (int index = 0; index < length; ++index)
      Debug.Assert(s[index] < 'Ā', "RawString contains invalid character.");
  }

  private static bool IsRawEncoding(string s)
  {
    bool flag;
    if (string.IsNullOrEmpty(s))
    {
      flag = true;
    }
    else
    {
      int length = s.Length;
      for (int index = 0; index < length; ++index)
      {
        if (s[index] >= 'Ā')
        {
          flag = false;
          goto label_8;
        }
      }
      flag = true;
    }
label_8:
    return flag;
  }

  internal override void WriteObject(PdfWriter writer) => writer.Write(this);
}
