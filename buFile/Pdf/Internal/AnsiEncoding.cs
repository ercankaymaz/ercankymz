// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Internal.AnsiEncoding
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Text;

#nullable disable
namespace PdfSharp.Pdf.Internal;

public sealed class AnsiEncoding : Encoding
{
  private static readonly char[] AnsiToUnicode = new char[256 /*0x0100*/]
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
    '€',
    '\u0081',
    '‚',
    'ƒ',
    '„',
    '…',
    '†',
    '‡',
    'ˆ',
    '‰',
    'Š',
    '‹',
    'Œ',
    '\u008D',
    'Ž',
    '\u008F',
    '\u0090',
    '‘',
    '’',
    '“',
    '”',
    '•',
    '–',
    '—',
    '˜',
    '™',
    'š',
    '›',
    'œ',
    '\u009D',
    'ž',
    'Ÿ',
    ' ',
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

  public override int GetByteCount(char[] chars, int index, int count) => count;

  public override int GetBytes(
    char[] chars,
    int charIndex,
    int charCount,
    byte[] bytes,
    int byteIndex)
  {
    int bytes1 = charCount;
    for (; charCount > 0; --charCount)
    {
      bytes[byteIndex] = (byte) AnsiEncoding.UnicodeToAnsi(chars[charIndex]);
      ++byteIndex;
      ++charIndex;
    }
    return bytes1;
  }

  public override int GetCharCount(byte[] bytes, int index, int count) => count;

  public override int GetChars(
    byte[] bytes,
    int byteIndex,
    int byteCount,
    char[] chars,
    int charIndex)
  {
    for (int index = byteCount; index > 0; --index)
    {
      chars[charIndex] = AnsiEncoding.AnsiToUnicode[(int) bytes[byteIndex]];
      ++byteIndex;
      ++charIndex;
    }
    return byteCount;
  }

  public override int GetMaxByteCount(int charCount) => charCount;

  public override int GetMaxCharCount(int byteCount) => byteCount;

  public static bool IsAnsi1252Char(char ch)
  {
    bool flag;
    if ((ch < '\u0080' ? 1 : (ch < ' ' ? 0 : (ch <= 'ÿ' ? 1 : 0))) != 0)
    {
      flag = true;
    }
    else
    {
      switch (ch)
      {
        case '\u0081':
        case '\u008D':
        case '\u008F':
        case '\u0090':
        case '\u009D':
        case 'Œ':
        case 'œ':
        case 'Š':
        case 'š':
        case 'Ÿ':
        case 'Ž':
        case 'ž':
        case 'ƒ':
        case 'ˆ':
        case '˜':
        case '–':
        case '—':
        case '‘':
        case '’':
        case '‚':
        case '“':
        case '”':
        case '„':
        case '†':
        case '‡':
        case '•':
        case '…':
        case '‰':
        case '‹':
        case '›':
        case '€':
        case '™':
          flag = true;
          break;
        default:
          flag = false;
          break;
      }
    }
    return flag;
  }

  public static char UnicodeToAnsi(char ch)
  {
    char ansi;
    if ((ch < '\u0080' ? 1 : (ch < ' ' ? 0 : (ch <= 'ÿ' ? 1 : 0))) != 0)
    {
      ansi = ch;
    }
    else
    {
      switch (ch)
      {
        case '\u0081':
          ansi = '\u0081';
          break;
        case '\u008D':
          ansi = '\u008D';
          break;
        case '\u008F':
          ansi = '\u008F';
          break;
        case '\u0090':
          ansi = '\u0090';
          break;
        case '\u009D':
          ansi = '\u009D';
          break;
        case 'Œ':
          ansi = '\u008C';
          break;
        case 'œ':
          ansi = '\u009C';
          break;
        case 'Š':
          ansi = '\u008A';
          break;
        case 'š':
          ansi = '\u009A';
          break;
        case 'Ÿ':
          ansi = '\u009F';
          break;
        case 'Ž':
          ansi = '\u008E';
          break;
        case 'ž':
          ansi = '\u009E';
          break;
        case 'ƒ':
          ansi = '\u0083';
          break;
        case 'ˆ':
          ansi = '\u0088';
          break;
        case '˜':
          ansi = '\u0098';
          break;
        case '–':
          ansi = '\u0096';
          break;
        case '—':
          ansi = '\u0097';
          break;
        case '‘':
          ansi = '\u0091';
          break;
        case '’':
          ansi = '\u0092';
          break;
        case '‚':
          ansi = '\u0082';
          break;
        case '“':
          ansi = '\u0093';
          break;
        case '”':
          ansi = '\u0094';
          break;
        case '„':
          ansi = '\u0084';
          break;
        case '†':
          ansi = '\u0086';
          break;
        case '‡':
          ansi = '\u0087';
          break;
        case '•':
          ansi = '\u0095';
          break;
        case '…':
          ansi = '\u0085';
          break;
        case '‰':
          ansi = '\u0089';
          break;
        case '‹':
          ansi = '\u008B';
          break;
        case '›':
          ansi = '\u009B';
          break;
        case '€':
          ansi = '\u0080';
          break;
        case '™':
          ansi = '\u0099';
          break;
        default:
          ansi = '¤';
          break;
      }
    }
    return ansi;
  }
}
