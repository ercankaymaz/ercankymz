// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.IO.Lexer
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using PdfSharp.Pdf.Internal;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf.IO;

public class Lexer
{
  private readonly int _pdfLength;
  private int _idxChar;
  private char _currChar;
  private char _nextChar;
  private StringBuilder _token;
  private Symbol _symbol = Symbol.None;
  private readonly Stream _pdfSteam;

  public Lexer(Stream pdfInputStream)
  {
    this._pdfSteam = pdfInputStream;
    this._pdfLength = (int) this._pdfSteam.Length;
    this._idxChar = 0;
    this.Position = 0;
  }

  public int Position
  {
    get => this._idxChar;
    set
    {
      this._idxChar = value;
      this._pdfSteam.Position = (long) value;
      this._currChar = (char) this._pdfSteam.ReadByte();
      this._nextChar = (char) this._pdfSteam.ReadByte();
      this._token = new StringBuilder();
    }
  }

  public Symbol ScanNextToken()
  {
    char nonWhiteSpace;
    while (true)
    {
      this._token = new StringBuilder();
      nonWhiteSpace = this.MoveToNonWhiteSpace();
      switch (nonWhiteSpace)
      {
        case '%':
          int num = (int) this.ScanComment();
          continue;
        case '(':
          goto label_6;
        case '+':
        case '-':
          goto label_7;
        case '.':
          goto label_8;
        case '/':
          goto label_9;
        case '<':
          goto label_3;
        case '>':
          goto label_12;
        case '[':
          goto label_11;
        case ']':
          goto label_10;
        default:
          goto label_15;
      }
    }
label_3:
    Symbol symbol1;
    Symbol symbol2;
    if (this._nextChar == '<')
    {
      int num1 = (int) this.ScanNextChar(true);
      int num2 = (int) this.ScanNextChar(true);
      symbol1 = Symbol.BeginDictionary;
      this._symbol = Symbol.BeginDictionary;
      symbol2 = Symbol.BeginDictionary;
      goto label_22;
    }
    symbol2 = this._symbol = this.ScanHexadecimalString();
    goto label_22;
label_6:
    symbol2 = this._symbol = this.ScanLiteralString();
    goto label_22;
label_7:
    symbol2 = this._symbol = this.ScanNumber();
    goto label_22;
label_8:
    symbol2 = this._symbol = this.ScanNumber();
    goto label_22;
label_9:
    symbol2 = this._symbol = this.ScanName();
    goto label_22;
label_10:
    int num3 = (int) this.ScanNextChar(true);
    symbol1 = Symbol.EndArray;
    this._symbol = Symbol.EndArray;
    symbol2 = Symbol.EndArray;
    goto label_22;
label_11:
    int num4 = (int) this.ScanNextChar(true);
    symbol1 = Symbol.BeginArray;
    this._symbol = Symbol.BeginArray;
    symbol2 = Symbol.BeginArray;
    goto label_22;
label_12:
    if (this._nextChar == '>')
    {
      int num5 = (int) this.ScanNextChar(true);
      int num6 = (int) this.ScanNextChar(true);
      symbol1 = Symbol.EndDictionary;
      this._symbol = Symbol.EndDictionary;
      symbol2 = Symbol.EndDictionary;
      goto label_22;
    }
    ParserDiagnostics.HandleUnexpectedCharacter(this._nextChar);
label_15:
    if (char.IsDigit(nonWhiteSpace))
      symbol2 = !this.PeekReference() ? (this._symbol = this.ScanNumber()) : (this._symbol = this.ScanNumber());
    else if (char.IsLetter(nonWhiteSpace))
      symbol2 = this._symbol = this.ScanKeyword();
    else if (nonWhiteSpace == char.MaxValue)
    {
      symbol1 = Symbol.Eof;
      this._symbol = Symbol.Eof;
      symbol2 = Symbol.Eof;
    }
    else
    {
      ParserDiagnostics.HandleUnexpectedCharacter(nonWhiteSpace);
      symbol1 = Symbol.None;
      this._symbol = Symbol.None;
      symbol2 = Symbol.None;
    }
label_22:
    return symbol2;
  }

  public byte[] ReadStream(int length)
  {
    while (this._currChar == ' ')
    {
      int num1 = (int) this.ScanNextChar(true);
    }
    int num2 = this._currChar != '\r' ? this._idxChar + 1 : (this._nextChar != '\n' ? this._idxChar + 1 : this._idxChar + 2);
    this._pdfSteam.Position = (long) num2;
    byte[] array = new byte[length];
    int newSize = this._pdfSteam.Read(array, 0, length);
    Debug.Assert(newSize == length);
    if (array.Length != newSize)
      Array.Resize<byte>(ref array, newSize);
    this.Position = num2 + newSize;
    return array;
  }

  public string ReadRawString(int position, int length)
  {
    this._pdfSteam.Position = (long) position;
    byte[] numArray = new byte[length];
    this._pdfSteam.Read(numArray, 0, length);
    return PdfEncoders.RawEncoding.GetString(numArray, 0, numArray.Length);
  }

  public Symbol ScanComment()
  {
    Debug.Assert(this._currChar == '%');
    this._token = new StringBuilder();
    char ch;
    do
    {
      ch = this.AppendAndScanNextChar();
    }
    while ((ch == '\n' ? 1 : (ch == char.MaxValue ? 1 : 0)) == 0);
    Symbol symbol;
    if (this._token.ToString().StartsWith("%%EOF"))
    {
      symbol = Symbol.Eof;
    }
    else
    {
      this._symbol = Symbol.Comment;
      symbol = Symbol.Comment;
    }
    return symbol;
  }

  public Symbol ScanName()
  {
    Debug.Assert(this._currChar == '/');
    this._token = new StringBuilder();
    while (true)
    {
      char ch;
      do
      {
        ch = this.AppendAndScanNextChar();
        if ((Lexer.IsWhiteSpace(ch) || Lexer.IsDelimiter(ch) ? 1 : (ch == char.MaxValue ? 1 : 0)) != 0)
          goto label_4;
      }
      while (ch != '#');
      int num1 = (int) this.ScanNextChar(true);
      char[] chArray = new char[2]
      {
        this._currChar,
        this._nextChar
      };
      int num2 = (int) this.ScanNextChar(true);
      this._currChar = (char) int.Parse(new string(chArray), NumberStyles.AllowHexSpecifier);
    }
label_4:
    this._symbol = Symbol.Name;
    return Symbol.Name;
  }

  public Symbol ScanNumber()
  {
    bool flag = false;
    this._token = new StringBuilder();
    char c = this._currChar;
    if ((c == '+' ? 1 : (c == '-' ? 1 : 0)) != 0)
    {
      this._token.Append(c);
      c = this.ScanNextChar(true);
    }
    while (true)
    {
      if (!char.IsDigit(c))
      {
        if (c == '.')
        {
          if (flag)
            ParserDiagnostics.ThrowParserException("More than one period in number.");
          flag = true;
          this._token.Append(c);
        }
        else
          break;
      }
      else
        goto label_7;
label_6:
      c = this.ScanNextChar(true);
      continue;
label_7:
      this._token.Append(c);
      goto label_6;
    }
    Symbol symbol;
    if (flag)
    {
      symbol = Symbol.Real;
    }
    else
    {
      long num = long.Parse(this._token.ToString(), (IFormatProvider) CultureInfo.InvariantCulture);
      symbol = (num < (long) int.MinValue ? 0 : (num <= (long) int.MaxValue ? 1 : 0)) == 0 ? ((num <= 0L ? 0 : (num <= (long) uint.MaxValue ? 1 : 0)) == 0 ? Symbol.Real : Symbol.UInteger) : Symbol.Integer;
    }
    return symbol;
  }

  public Symbol ScanNumberOrReference()
  {
    Symbol symbol = this.ScanNumber();
    if (symbol == Symbol.Integer)
    {
      int position = this.Position;
      string token = this.Token;
    }
    return symbol;
  }

  public Symbol ScanKeyword()
  {
    this._token = new StringBuilder();
    for (char c = this._currChar; char.IsLetter(c); c = this.ScanNextChar(false))
      this._token.Append(c);
    Symbol symbol;
    switch (this._token.ToString())
    {
      case "R":
        this._symbol = Symbol.R;
        symbol = Symbol.R;
        break;
      case "endobj":
        this._symbol = Symbol.EndObj;
        symbol = Symbol.EndObj;
        break;
      case "endstream":
        this._symbol = Symbol.EndStream;
        symbol = Symbol.EndStream;
        break;
      case "false":
      case "true":
        this._symbol = Symbol.Boolean;
        symbol = Symbol.Boolean;
        break;
      case "null":
        this._symbol = Symbol.Null;
        symbol = Symbol.Null;
        break;
      case "obj":
        this._symbol = Symbol.Obj;
        symbol = Symbol.Obj;
        break;
      case "startxref":
        this._symbol = Symbol.StartXRef;
        symbol = Symbol.StartXRef;
        break;
      case "stream":
        this._symbol = Symbol.BeginStream;
        symbol = Symbol.BeginStream;
        break;
      case "trailer":
        this._symbol = Symbol.Trailer;
        symbol = Symbol.Trailer;
        break;
      case "xref":
        this._symbol = Symbol.XRef;
        symbol = Symbol.XRef;
        break;
      default:
        this._symbol = Symbol.Keyword;
        symbol = Symbol.Keyword;
        break;
    }
    return symbol;
  }

  public Symbol ScanLiteralString()
  {
    Debug.Assert(this._currChar == '(');
    this._token = new StringBuilder();
    int num1 = 0;
    char c = this.ScanNextChar(false);
    while (c != char.MaxValue)
    {
      switch (c)
      {
        case '(':
          ++num1;
          break;
        case ')':
          if (num1 != 0)
          {
            --num1;
            break;
          }
          int num2 = (int) this.ScanNextChar(false);
          goto label_24;
        case '\\':
          c = this.ScanNextChar(false);
          switch (c)
          {
            case '\n':
            case '\r':
              c = this.ScanNextChar(false);
              continue;
            case ' ':
              c = ' ';
              break;
            case '(':
              c = '(';
              break;
            case ')':
              c = ')';
              break;
            case '\\':
              c = '\\';
              break;
            case 'b':
              c = '\b';
              break;
            case 'f':
              c = '\f';
              break;
            case 'n':
              c = '\n';
              break;
            case 'r':
              c = '\r';
              break;
            case 't':
              c = '\t';
              break;
            default:
              if ((!char.IsDigit(c) || this._nextChar == '8' ? 0 : (this._nextChar != '9' ? 1 : 0)) != 0)
              {
                int num3 = (int) c - 48 /*0x30*/;
                if ((!char.IsDigit(this._nextChar) || this._nextChar == '8' ? 0 : (this._nextChar != '9' ? 1 : 0)) != 0)
                {
                  char ch1 = this.ScanNextChar(false);
                  num3 = num3 * 8 + (int) ch1 - 48 /*0x30*/;
                  if ((!char.IsDigit(this._nextChar) || this._nextChar == '8' ? 0 : (this._nextChar != '9' ? 1 : 0)) != 0)
                  {
                    char ch2 = this.ScanNextChar(false);
                    num3 = num3 * 8 + (int) ch2 - 48 /*0x30*/;
                  }
                }
                c = (char) num3;
                break;
              }
              break;
          }
          break;
      }
      this._token.Append(c);
      c = this.ScanNextChar(false);
    }
label_24:
    Symbol symbol;
    if ((this._token.Length < 2 || this._token[0] != 'þ' ? 0 : (this._token[1] == 'ÿ' ? 1 : 0)) != 0)
    {
      StringBuilder token = this._token;
      int length = token.Length;
      if ((length & 1) == 1)
      {
        token.Append(0);
        ++length;
        DebugBreak.Break();
      }
      this._token = new StringBuilder();
      for (int index = 2; index < length; index += 2)
        this._token.Append((char) (256U /*0x0100*/ * (uint) token[index] + (uint) token[index + 1]));
      this._symbol = Symbol.UnicodeString;
      symbol = Symbol.UnicodeString;
    }
    else if ((this._token.Length < 2 || this._token[0] != 'ÿ' ? 0 : (this._token[1] == 'þ' ? 1 : 0)) != 0)
    {
      StringBuilder token = this._token;
      int length = token.Length;
      if ((length & 1) == 1)
      {
        token.Append(0);
        ++length;
        DebugBreak.Break();
      }
      this._token = new StringBuilder();
      for (int index = 2; index < length; index += 2)
        this._token.Append((char) (256U /*0x0100*/ * (uint) token[index + 1] + (uint) token[index]));
      this._symbol = Symbol.UnicodeString;
      symbol = Symbol.UnicodeString;
    }
    else
    {
      this._symbol = Symbol.String;
      symbol = Symbol.String;
    }
    return symbol;
  }

  public Symbol ScanHexadecimalString()
  {
    Debug.Assert(this._currChar == '<');
    this._token = new StringBuilder();
    char[] chArray = new char[2];
    int num1 = (int) this.ScanNextChar(true);
    while (true)
    {
      int nonWhiteSpace = (int) this.MoveToNonWhiteSpace();
      if (this._currChar != '>')
      {
        if (char.IsLetterOrDigit(this._currChar))
        {
          chArray[0] = char.ToUpper(this._currChar);
          if (char.IsLetterOrDigit(this._nextChar))
          {
            chArray[1] = char.ToUpper(this._nextChar);
            int num2 = (int) this.ScanNextChar(true);
          }
          else
            chArray[1] = '0';
          int num3 = (int) this.ScanNextChar(true);
          this._token.Append(Convert.ToChar(int.Parse(new string(chArray), NumberStyles.AllowHexSpecifier)));
        }
        else
          ParserDiagnostics.HandleUnexpectedCharacter(this._currChar);
      }
      else
        break;
    }
    int num4 = (int) this.ScanNextChar(true);
    string str = this._token.ToString();
    int length = str.Length;
    Symbol symbol;
    if ((length <= 2 || str[0] != 'þ' ? 0 : (str[1] == 'ÿ' ? 1 : 0)) != 0)
    {
      Debug.Assert(length % 2 == 0);
      this._token.Length = 0;
      for (int index = 2; index < length; index += 2)
        this._token.Append((char) ((uint) str[index] * 256U /*0x0100*/ + (uint) str[index + 1]));
      this._symbol = Symbol.UnicodeHexString;
      symbol = Symbol.UnicodeHexString;
    }
    else
    {
      this._symbol = Symbol.HexString;
      symbol = Symbol.HexString;
    }
    return symbol;
  }

  internal char ScanNextChar(bool handleCRLF)
  {
    if (this._pdfLength <= this._idxChar)
    {
      this._currChar = char.MaxValue;
      this._nextChar = char.MaxValue;
    }
    else
    {
      this._currChar = this._nextChar;
      this._nextChar = (char) this._pdfSteam.ReadByte();
      ++this._idxChar;
      if ((!handleCRLF ? 0 : (this._currChar == '\r' ? 1 : 0)) != 0)
      {
        if (this._nextChar == '\n')
        {
          this._currChar = this._nextChar;
          this._nextChar = (char) this._pdfSteam.ReadByte();
          ++this._idxChar;
        }
        else
          this._currChar = '\n';
      }
    }
    return this._currChar;
  }

  private bool PeekReference()
  {
    int position = this.Position;
    while (char.IsDigit(this._currChar))
    {
      int num1 = (int) this.ScanNextChar(true);
    }
    bool flag;
    if (this._currChar == ' ')
    {
      while (this._currChar == ' ')
      {
        int num2 = (int) this.ScanNextChar(true);
      }
      if (char.IsDigit(this._currChar))
      {
        while (char.IsDigit(this._currChar))
        {
          int num3 = (int) this.ScanNextChar(true);
        }
        if (this._currChar == ' ')
        {
          while (this._currChar == ' ')
          {
            int num4 = (int) this.ScanNextChar(true);
          }
          if (this._currChar == 'R')
          {
            this.Position = position;
            flag = true;
            goto label_15;
          }
        }
      }
    }
    this.Position = position;
    flag = false;
label_15:
    return flag;
  }

  internal char AppendAndScanNextChar()
  {
    if (this._currChar == char.MaxValue)
      ParserDiagnostics.ThrowParserException("Undetected EOF reached.");
    this._token.Append(this._currChar);
    return this.ScanNextChar(true);
  }

  public char MoveToNonWhiteSpace()
  {
    char currChar;
    while (this._currChar != char.MaxValue)
    {
      switch (this._currChar)
      {
        case char.MinValue:
        case '\t':
        case '\n':
        case '\f':
        case '\r':
        case ' ':
          int num1 = (int) this.ScanNextChar(true);
          continue;
        case '\v':
        case '\u00AD':
          int num2 = (int) this.ScanNextChar(true);
          continue;
        default:
          currChar = this._currChar;
          goto label_7;
      }
    }
    currChar = this._currChar;
label_7:
    return currChar;
  }

  public string SurroundingsOfCurrentPosition(bool hex)
  {
    int num = Math.Max(this.Position - 20, 0);
    int count = Math.Min(40, this.PdfLength - num);
    long position = this._pdfSteam.Position;
    this._pdfSteam.Position = (long) num;
    byte[] buffer = new byte[count];
    this._pdfSteam.Read(buffer, 0, count);
    this._pdfSteam.Position = position;
    string str = "";
    if (hex)
    {
      for (int index = 0; index < count; ++index)
        str += ((int) buffer[index]).ToString("x2");
    }
    else
    {
      for (int index = 0; index < count; ++index)
        str += ((char) buffer[index]).ToString();
    }
    return str;
  }

  public Symbol Symbol
  {
    get => this._symbol;
    set => this._symbol = value;
  }

  public string Token => this._token.ToString();

  public bool TokenToBoolean
  {
    get
    {
      Debug.Assert(this._token.ToString() == "true" || this._token.ToString() == "false");
      return this._token.ToString()[0] == 't';
    }
  }

  public int TokenToInteger
  {
    get => int.Parse(this._token.ToString(), (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public uint TokenToUInteger
  {
    get => uint.Parse(this._token.ToString(), (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public double TokenToReal
  {
    get => double.Parse(this._token.ToString(), (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public PdfObjectID TokenToObjectID
  {
    get
    {
      string[] strArray = this.Token.Split('|');
      return new PdfObjectID(int.Parse(strArray[0]), int.Parse(strArray[1]));
    }
  }

  internal static bool IsWhiteSpace(char ch)
  {
    bool flag;
    switch (ch)
    {
      case char.MinValue:
      case '\t':
      case '\n':
      case '\f':
      case '\r':
      case ' ':
        flag = true;
        break;
      default:
        flag = false;
        break;
    }
    return flag;
  }

  internal static bool IsDelimiter(char ch)
  {
    bool flag;
    switch (ch)
    {
      case '%':
      case '(':
      case ')':
      case '/':
      case '<':
      case '>':
      case '[':
      case ']':
      case '{':
      case '}':
        flag = true;
        break;
      default:
        flag = false;
        break;
    }
    return flag;
  }

  public int PdfLength => this._pdfLength;
}
