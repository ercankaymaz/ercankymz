// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Internal.PdfEncoders
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Pdf.Security;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf.Internal;

internal static class PdfEncoders
{
  private static Encoding _rawEncoding;
  private static Encoding _rawUnicodeEncoding;
  private static Encoding _winAnsiEncoding;
  private static Encoding _docEncoding;
  private static Encoding _unicodeEncoding;
  private static byte[] docencode_______ = new byte[256 /*0x0100*/]
  {
    (byte) 0,
    (byte) 1,
    (byte) 2,
    (byte) 3,
    (byte) 4,
    (byte) 5,
    (byte) 6,
    (byte) 7,
    (byte) 8,
    (byte) 9,
    (byte) 10,
    (byte) 11,
    (byte) 12,
    (byte) 13,
    (byte) 14,
    (byte) 15,
    (byte) 16 /*0x10*/,
    (byte) 17,
    (byte) 18,
    (byte) 19,
    (byte) 20,
    (byte) 21,
    (byte) 22,
    (byte) 23,
    (byte) 24,
    (byte) 25,
    (byte) 26,
    (byte) 27,
    (byte) 28,
    (byte) 29,
    (byte) 30,
    (byte) 31 /*0x1F*/,
    (byte) 32 /*0x20*/,
    (byte) 33,
    (byte) 34,
    (byte) 35,
    (byte) 36,
    (byte) 37,
    (byte) 38,
    (byte) 39,
    (byte) 40,
    (byte) 41,
    (byte) 42,
    (byte) 43,
    (byte) 44,
    (byte) 45,
    (byte) 46,
    (byte) 47,
    (byte) 48 /*0x30*/,
    (byte) 49,
    (byte) 50,
    (byte) 51,
    (byte) 52,
    (byte) 53,
    (byte) 54,
    (byte) 55,
    (byte) 56,
    (byte) 57,
    (byte) 58,
    (byte) 59,
    (byte) 60,
    (byte) 61,
    (byte) 62,
    (byte) 63 /*0x3F*/,
    (byte) 64 /*0x40*/,
    (byte) 65,
    (byte) 66,
    (byte) 67,
    (byte) 68,
    (byte) 69,
    (byte) 70,
    (byte) 71,
    (byte) 72,
    (byte) 73,
    (byte) 74,
    (byte) 75,
    (byte) 76,
    (byte) 77,
    (byte) 78,
    (byte) 79,
    (byte) 80 /*0x50*/,
    (byte) 81,
    (byte) 82,
    (byte) 83,
    (byte) 84,
    (byte) 85,
    (byte) 86,
    (byte) 87,
    (byte) 88,
    (byte) 89,
    (byte) 90,
    (byte) 91,
    (byte) 92,
    (byte) 93,
    (byte) 94,
    (byte) 95,
    (byte) 96 /*0x60*/,
    (byte) 97,
    (byte) 98,
    (byte) 99,
    (byte) 100,
    (byte) 101,
    (byte) 102,
    (byte) 103,
    (byte) 104,
    (byte) 105,
    (byte) 106,
    (byte) 107,
    (byte) 108,
    (byte) 109,
    (byte) 110,
    (byte) 111,
    (byte) 112 /*0x70*/,
    (byte) 113,
    (byte) 114,
    (byte) 115,
    (byte) 116,
    (byte) 117,
    (byte) 118,
    (byte) 119,
    (byte) 120,
    (byte) 121,
    (byte) 122,
    (byte) 123,
    (byte) 124,
    (byte) 125,
    (byte) 126,
    (byte) 127 /*0x7F*/,
    (byte) 160 /*0xA0*/,
    (byte) 127 /*0x7F*/,
    (byte) 130,
    (byte) 131,
    (byte) 132,
    (byte) 133,
    (byte) 134,
    (byte) 135,
    (byte) 136,
    (byte) 137,
    (byte) 138,
    (byte) 139,
    (byte) 140,
    (byte) 141,
    (byte) 142,
    (byte) 143,
    (byte) 144 /*0x90*/,
    (byte) 145,
    (byte) 146,
    (byte) 147,
    (byte) 148,
    (byte) 149,
    (byte) 138,
    (byte) 140,
    (byte) 152,
    (byte) 153,
    (byte) 154,
    (byte) 155,
    (byte) 156,
    (byte) 157,
    (byte) 158,
    (byte) 159,
    (byte) 160 /*0xA0*/,
    (byte) 161,
    (byte) 162,
    (byte) 163,
    (byte) 164,
    (byte) 165,
    (byte) 166,
    (byte) 167,
    (byte) 168,
    (byte) 169,
    (byte) 170,
    (byte) 171,
    (byte) 172,
    (byte) 173,
    (byte) 174,
    (byte) 175,
    (byte) 176 /*0xB0*/,
    (byte) 177,
    (byte) 178,
    (byte) 179,
    (byte) 180,
    (byte) 181,
    (byte) 182,
    (byte) 183,
    (byte) 184,
    (byte) 185,
    (byte) 186,
    (byte) 187,
    (byte) 188,
    (byte) 189,
    (byte) 190,
    (byte) 191,
    (byte) 192 /*0xC0*/,
    (byte) 193,
    (byte) 194,
    (byte) 195,
    (byte) 196,
    (byte) 197,
    (byte) 198,
    (byte) 199,
    (byte) 200,
    (byte) 201,
    (byte) 202,
    (byte) 203,
    (byte) 204,
    (byte) 205,
    (byte) 206,
    (byte) 207,
    (byte) 208 /*0xD0*/,
    (byte) 209,
    (byte) 210,
    (byte) 211,
    (byte) 212,
    (byte) 213,
    (byte) 214,
    (byte) 215,
    (byte) 216,
    (byte) 217,
    (byte) 218,
    (byte) 219,
    (byte) 220,
    (byte) 221,
    (byte) 222,
    (byte) 223,
    (byte) 224 /*0xE0*/,
    (byte) 225,
    (byte) 226,
    (byte) 227,
    (byte) 228,
    (byte) 229,
    (byte) 230,
    (byte) 231,
    (byte) 232,
    (byte) 233,
    (byte) 234,
    (byte) 235,
    (byte) 236,
    (byte) 237,
    (byte) 238,
    (byte) 239,
    (byte) 240 /*0xF0*/,
    (byte) 241,
    (byte) 242,
    (byte) 243,
    (byte) 244,
    (byte) 245,
    (byte) 246,
    (byte) 247,
    (byte) 248,
    (byte) 249,
    (byte) 250,
    (byte) 251,
    (byte) 252,
    (byte) 253,
    (byte) 254,
    byte.MaxValue
  };

  public static Encoding RawEncoding
  {
    get => PdfEncoders._rawEncoding ?? (PdfEncoders._rawEncoding = (Encoding) new PdfSharp.Pdf.Internal.RawEncoding());
  }

  public static Encoding RawUnicodeEncoding
  {
    get
    {
      return PdfEncoders._rawUnicodeEncoding ?? (PdfEncoders._rawUnicodeEncoding = (Encoding) new PdfSharp.Pdf.Internal.RawUnicodeEncoding());
    }
  }

  public static Encoding WinAnsiEncoding
  {
    get
    {
      if (PdfEncoders._winAnsiEncoding == null)
        PdfEncoders._winAnsiEncoding = Encoding.GetEncoding(1252);
      return PdfEncoders._winAnsiEncoding;
    }
  }

  public static Encoding DocEncoding
  {
    get => PdfEncoders._docEncoding ?? (PdfEncoders._docEncoding = (Encoding) new PdfSharp.Pdf.Internal.DocEncoding());
  }

  public static Encoding UnicodeEncoding
  {
    get => PdfEncoders._unicodeEncoding ?? (PdfEncoders._unicodeEncoding = Encoding.Unicode);
  }

  public static string ToStringLiteral(
    string text,
    PdfStringEncoding encoding,
    PdfStandardSecurityHandler securityHandler)
  {
    string stringLiteral;
    if (string.IsNullOrEmpty(text))
    {
      stringLiteral = "()";
    }
    else
    {
      byte[] bytes1;
      switch (encoding)
      {
        case PdfStringEncoding.RawEncoding:
          bytes1 = PdfEncoders.RawEncoding.GetBytes(text);
          break;
        case PdfStringEncoding.PDFDocEncoding:
          bytes1 = PdfEncoders.DocEncoding.GetBytes(text);
          break;
        case PdfStringEncoding.WinAnsiEncoding:
          bytes1 = PdfEncoders.WinAnsiEncoding.GetBytes(text);
          break;
        case PdfStringEncoding.Unicode:
          bytes1 = PdfEncoders.RawUnicodeEncoding.GetBytes(text);
          break;
        default:
          throw new NotImplementedException(encoding.ToString());
      }
      byte[] bytes2 = PdfEncoders.FormatStringLiteral(bytes1, encoding == PdfStringEncoding.Unicode, true, false, securityHandler);
      stringLiteral = PdfEncoders.RawEncoding.GetString(bytes2, 0, bytes2.Length);
    }
    return stringLiteral;
  }

  public static string ToStringLiteral(
    byte[] bytes,
    bool unicode,
    PdfStandardSecurityHandler securityHandler)
  {
    string stringLiteral;
    if ((bytes == null ? 1 : (bytes.Length == 0 ? 1 : 0)) != 0)
    {
      stringLiteral = "()";
    }
    else
    {
      byte[] bytes1 = PdfEncoders.FormatStringLiteral(bytes, unicode, true, false, securityHandler);
      stringLiteral = PdfEncoders.RawEncoding.GetString(bytes1, 0, bytes1.Length);
    }
    return stringLiteral;
  }

  public static string ToHexStringLiteral(
    string text,
    PdfStringEncoding encoding,
    PdfStandardSecurityHandler securityHandler)
  {
    string hexStringLiteral;
    if (string.IsNullOrEmpty(text))
    {
      hexStringLiteral = "<>";
    }
    else
    {
      byte[] bytes1;
      switch (encoding)
      {
        case PdfStringEncoding.RawEncoding:
          bytes1 = PdfEncoders.RawEncoding.GetBytes(text);
          break;
        case PdfStringEncoding.PDFDocEncoding:
          bytes1 = PdfEncoders.DocEncoding.GetBytes(text);
          break;
        case PdfStringEncoding.WinAnsiEncoding:
          bytes1 = PdfEncoders.WinAnsiEncoding.GetBytes(text);
          break;
        case PdfStringEncoding.Unicode:
          bytes1 = PdfEncoders.RawUnicodeEncoding.GetBytes(text);
          break;
        default:
          throw new NotImplementedException(encoding.ToString());
      }
      byte[] bytes2 = PdfEncoders.FormatStringLiteral(bytes1, encoding == PdfStringEncoding.Unicode, true, true, securityHandler);
      hexStringLiteral = PdfEncoders.RawEncoding.GetString(bytes2, 0, bytes2.Length);
    }
    return hexStringLiteral;
  }

  public static string ToHexStringLiteral(
    byte[] bytes,
    bool unicode,
    PdfStandardSecurityHandler securityHandler)
  {
    string hexStringLiteral;
    if ((bytes == null ? 1 : (bytes.Length == 0 ? 1 : 0)) != 0)
    {
      hexStringLiteral = "<>";
    }
    else
    {
      byte[] bytes1 = PdfEncoders.FormatStringLiteral(bytes, unicode, true, true, securityHandler);
      hexStringLiteral = PdfEncoders.RawEncoding.GetString(bytes1, 0, bytes1.Length);
    }
    return hexStringLiteral;
  }

  public static byte[] FormatStringLiteral(
    byte[] bytes,
    bool unicode,
    bool prefix,
    bool hex,
    PdfStandardSecurityHandler securityHandler)
  {
    byte[] numArray1;
    if ((bytes == null ? 1 : (bytes.Length == 0 ? 1 : 0)) != 0)
    {
      byte[] numArray2;
      if (!hex)
        numArray2 = new byte[2]{ (byte) 40, (byte) 41 };
      else
        numArray2 = new byte[2]{ (byte) 60, (byte) 62 };
      numArray1 = numArray2;
    }
    else
    {
      Debug.Assert(!unicode || bytes.Length % 2 == 0, "Odd number of bytes in Unicode string.");
      byte[] bytes1 = (byte[]) null;
      bool flag1 = false;
      if ((securityHandler == null ? 0 : (!hex ? 1 : 0)) != 0)
      {
        bytes1 = bytes;
        bytes = (byte[]) bytes.Clone();
        bytes = securityHandler.EncryptBytes(bytes);
        flag1 = true;
      }
      int length1 = bytes.Length;
      StringBuilder stringBuilder = new StringBuilder();
      bool flag2;
      if (!unicode)
      {
        if (!hex)
        {
          stringBuilder.Append("(");
          for (int index = 0; index < length1; ++index)
          {
            char ch = (char) bytes[index];
            if (ch < ' ')
            {
              switch (ch)
              {
                case '\b':
                  stringBuilder.Append("\\b");
                  continue;
                case '\t':
                  stringBuilder.Append("\\t");
                  continue;
                case '\n':
                  stringBuilder.Append("\\n");
                  continue;
                case '\r':
                  stringBuilder.Append("\\r");
                  continue;
                default:
                  flag2 = true;
                  stringBuilder.Append(ch);
                  continue;
              }
            }
            else
            {
              switch (ch)
              {
                case '(':
                  stringBuilder.Append("\\(");
                  continue;
                case ')':
                  stringBuilder.Append("\\)");
                  continue;
                case '\\':
                  stringBuilder.Append("\\\\");
                  continue;
                default:
                  stringBuilder.Append(ch);
                  continue;
              }
            }
          }
          stringBuilder.Append(')');
        }
        else
        {
          stringBuilder.Append('<');
          for (int index = 0; index < length1; ++index)
            stringBuilder.AppendFormat("{0:X2}", (object) bytes[index]);
          stringBuilder.Append('>');
        }
      }
      else if (hex)
      {
        if (securityHandler != null & prefix)
        {
          byte[] numArray3 = new byte[bytes.Length + 2];
          numArray3[0] = (byte) 254;
          numArray3[1] = byte.MaxValue;
          Array.Copy((Array) bytes, 0, (Array) numArray3, 2, bytes.Length);
          byte[] numArray4 = securityHandler.EncryptBytes(numArray3);
          flag2 = true;
          stringBuilder.Append("<");
          int length2 = numArray4.Length;
          for (int index = 0; index < length2; index += 2)
          {
            stringBuilder.AppendFormat("{0:X2}{1:X2}", (object) numArray4[index], (object) numArray4[index + 1]);
            if ((index == 0 ? 0 : (index % 48 /*0x30*/ == 0 ? 1 : 0)) != 0)
              stringBuilder.Append("\n");
          }
          stringBuilder.Append(">");
        }
        else
        {
          stringBuilder.Append(prefix ? "<FEFF" : "<");
          for (int index = 0; index < length1; index += 2)
          {
            stringBuilder.AppendFormat("{0:X2}{1:X2}", (object) bytes[index], (object) bytes[index + 1]);
            if ((index == 0 ? 0 : (index % 48 /*0x30*/ == 0 ? 1 : 0)) != 0)
              stringBuilder.Append("\n");
          }
          stringBuilder.Append(">");
        }
      }
      else
      {
        numArray1 = !flag1 ? PdfEncoders.FormatStringLiteral(bytes, true, prefix, true, (PdfStandardSecurityHandler) null) : PdfEncoders.FormatStringLiteral(bytes1, unicode, prefix, true, securityHandler);
        goto label_45;
      }
      numArray1 = PdfEncoders.RawEncoding.GetBytes(stringBuilder.ToString());
    }
label_45:
    return numArray1;
  }

  public static string Format(string format, params object[] args)
  {
    return string.Format((IFormatProvider) CultureInfo.InvariantCulture, format, args);
  }

  public static string ToString(double val)
  {
    return val.ToString("0.###", (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static string ToString(XColor color, PdfColorMode colorMode)
  {
    if (colorMode == PdfColorMode.Undefined)
      colorMode = color.ColorSpace == XColorSpace.Cmyk ? PdfColorMode.Cmyk : PdfColorMode.Rgb;
    string str;
    if (colorMode != PdfColorMode.Cmyk)
      str = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0:0.###} {1:0.###} {2:0.###}", (object) ((double) color.R / (double) byte.MaxValue), (object) ((double) color.G / (double) byte.MaxValue), (object) ((double) color.B / (double) byte.MaxValue));
    else
      str = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0:0.###} {1:0.###} {2:0.###} {3:0.###}", (object) color.C, (object) color.M, (object) color.Y, (object) color.K);
    return str;
  }

  public static string ToString(XMatrix matrix)
  {
    return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####}", (object) matrix.M11, (object) matrix.M12, (object) matrix.M21, (object) matrix.M22, (object) matrix.OffsetX, (object) matrix.OffsetY);
  }
}
