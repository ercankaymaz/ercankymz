// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.CLexer
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf.Content;

public class CLexer
{
  private static readonly double[] PowersOf10 = new double[11]
  {
    1.0,
    10.0,
    100.0,
    1000.0,
    10000.0,
    100000.0,
    1000000.0,
    10000000.0,
    100000000.0,
    1000000000.0,
    10000000000.0
  };
  private readonly byte[] _content;
  private int _charIndex;
  private char _currChar;
  private char _nextChar;
  private readonly StringBuilder _token = new StringBuilder();
  private long _tokenAsLong;
  private double _tokenAsReal;
  private CSymbol _symbol = CSymbol.None;

  public CLexer(byte[] content)
  {
    this._content = content;
    this._charIndex = 0;
  }

  public CLexer(MemoryStream content)
  {
    this._content = content.ToArray();
    this._charIndex = 0;
  }

  public CSymbol ScanNextToken()
  {
    char nonWhiteSpace;
    while (true)
    {
      this.ClearToken();
      nonWhiteSpace = this.MoveToNonWhiteSpace();
      switch (nonWhiteSpace)
      {
        case '"':
        case '\'':
          goto label_4;
        case '%':
          int num = (int) this.ScanComment();
          continue;
        case '(':
          goto label_5;
        case '+':
        case '-':
          goto label_6;
        case '.':
          goto label_7;
        case '/':
          goto label_8;
        case '<':
          goto label_3;
        case '[':
          goto label_17;
        case ']':
          goto label_16;
        default:
          goto label_9;
      }
    }
label_3:
    CSymbol csymbol1 = this._nextChar != '<' ? (this._symbol = this.ScanHexadecimalString()) : (this._symbol = this.ScanDictionary());
    goto label_18;
label_4:
    csymbol1 = this._symbol = this.ScanOperator();
    goto label_18;
label_5:
    csymbol1 = this._symbol = this.ScanLiteralString();
    goto label_18;
label_6:
    csymbol1 = this._symbol = this.ScanNumber();
    goto label_18;
label_7:
    csymbol1 = this._symbol = this.ScanNumber();
    goto label_18;
label_8:
    csymbol1 = this._symbol = this.ScanName();
    goto label_18;
label_9:
    if (char.IsDigit(nonWhiteSpace))
    {
      csymbol1 = this._symbol = this.ScanNumber();
      goto label_18;
    }
    if (char.IsLetter(nonWhiteSpace))
    {
      csymbol1 = this._symbol = this.ScanOperator();
      goto label_18;
    }
    CSymbol csymbol2;
    if (nonWhiteSpace == char.MaxValue)
    {
      csymbol2 = CSymbol.Eof;
      this._symbol = CSymbol.Eof;
      csymbol1 = CSymbol.Eof;
      goto label_18;
    }
    ContentReaderDiagnostics.HandleUnexpectedCharacter(nonWhiteSpace);
    csymbol2 = CSymbol.None;
    this._symbol = CSymbol.None;
    csymbol1 = CSymbol.None;
    goto label_18;
label_16:
    int num1 = (int) this.ScanNextChar();
    csymbol2 = CSymbol.EndArray;
    this._symbol = CSymbol.EndArray;
    csymbol1 = CSymbol.EndArray;
    goto label_18;
label_17:
    int num2 = (int) this.ScanNextChar();
    csymbol2 = CSymbol.BeginArray;
    this._symbol = CSymbol.BeginArray;
    csymbol1 = CSymbol.BeginArray;
label_18:
    return csymbol1;
  }

  public CSymbol ScanComment()
  {
    Debug.Assert(this._currChar == '%');
    this.ClearToken();
    char ch;
    do
      ;
    while (((ch = this.AppendAndScanNextChar()) == '\n' ? 0 : (ch != char.MaxValue ? 1 : 0)) != 0);
    this._symbol = CSymbol.Comment;
    return CSymbol.Comment;
  }

  public CSymbol ScanInlineImage()
  {
    bool flag = false;
    do
    {
      int num = (int) this.ScanNextToken();
      if ((flag || this._symbol != CSymbol.Name ? 0 : (this.Token == "/ASCII85Decode" ? 1 : (this.Token == "/A85" ? 1 : 0))) != 0)
        flag = true;
    }
    while ((this._symbol != CSymbol.Operator ? 1 : (this.Token != "ID" ? 1 : 0)) != 0);
    if (flag)
    {
      while ((this._currChar == char.MaxValue ? 0 : (this._currChar != '~' ? 1 : (this._nextChar != '>' ? 1 : 0))) != 0)
      {
        int num = (int) this.ScanNextChar();
      }
      if (this._currChar == char.MaxValue)
        ContentReaderDiagnostics.HandleUnexpectedCharacter(this._currChar);
    }
    while (this._currChar != char.MaxValue)
    {
      if (CLexer.IsWhiteSpace(this._currChar))
      {
        if (this.ScanNextChar() == 'E' && this.ScanNextChar() == 'I' && CLexer.IsWhiteSpace(this.ScanNextChar()))
          break;
      }
      else
      {
        int num1 = (int) this.ScanNextChar();
      }
    }
    if (this._currChar == char.MaxValue)
      ContentReaderDiagnostics.HandleUnexpectedCharacter(this._currChar);
    return CSymbol.None;
  }

  public CSymbol ScanName()
  {
    Debug.Assert(this._currChar == '/');
    this.ClearToken();
    while (true)
    {
      char ch;
      do
      {
        ch = this.AppendAndScanNextChar();
        if ((CLexer.IsWhiteSpace(ch) ? 1 : (CLexer.IsDelimiter(ch) ? 1 : 0)) != 0)
          goto label_4;
      }
      while (ch != '#');
      int num1 = (int) this.ScanNextChar();
      char[] chArray = new char[2]
      {
        this._currChar,
        this._nextChar
      };
      int num2 = (int) this.ScanNextChar();
      this._currChar = (char) int.Parse(new string(chArray), NumberStyles.AllowHexSpecifier);
    }
label_4:
    this._symbol = CSymbol.Name;
    return CSymbol.Name;
  }

  protected CSymbol ScanDictionary()
  {
    this.ClearToken();
    this._token.Append(this._currChar);
    this._token.Append(this.ScanNextChar());
    bool flag1 = false;
    bool flag2 = false;
    int num1 = 0;
    int num2 = 0;
    while (true)
    {
      char ch;
      do
      {
        this._token.Append(ch = this.ScanNextChar());
        if (ch != '<')
        {
          if ((flag2 ? 0 : (ch == '(' ? 1 : 0)) == 0)
          {
            if ((!flag1 ? 0 : (ch == ')' ? 1 : 0)) == 0)
            {
              if ((!flag1 ? 0 : (ch == '\\' ? 1 : 0)) == 0)
              {
                switch (ch)
                {
                  case '>':
                    if (!flag2)
                      continue;
                    goto label_13;
                  case char.MaxValue:
                    goto label_17;
                  default:
                    continue;
                }
              }
              else
                goto label_10;
            }
            else
              goto label_6;
          }
          else
            goto label_2;
        }
        else
          goto label_18;
      }
      while (this._nextChar != '>');
      goto label_15;
label_2:
      if (flag1)
      {
        ++num2;
        continue;
      }
      flag1 = true;
      num2 = 0;
      continue;
label_6:
      if (num2 > 0)
      {
        --num2;
        continue;
      }
      flag1 = false;
      continue;
label_10:
      this._token.Append(this.ScanNextChar());
      continue;
label_13:
      flag2 = false;
      continue;
label_15:
      this._token.Append(this.ScanNextChar());
      if (num1 > 0)
      {
        --num1;
        continue;
      }
      break;
label_17:
      ContentReaderDiagnostics.HandleUnexpectedCharacter(ch);
      continue;
label_18:
      if (this._nextChar == '<')
      {
        this._token.Append(this.ScanNextChar());
        ++num1;
      }
      else
        flag2 = true;
    }
    int num3 = (int) this.ScanNextChar();
    return CSymbol.Dictionary;
  }

  public CSymbol ScanNumber()
  {
    long num = 0;
    int index = 0;
    bool flag1 = false;
    bool flag2 = false;
    this.ClearToken();
    char c = this._currChar;
    if ((c == '+' ? 1 : (c == '-' ? 1 : 0)) != 0)
    {
      if (c == '-')
        flag2 = true;
      this._token.Append(c);
      c = this.ScanNextChar();
    }
    while (true)
    {
      if (!char.IsDigit(c))
      {
        if (c == '.')
        {
          if (flag1)
            ContentReaderDiagnostics.ThrowContentReaderException("More than one period in number.");
          flag1 = true;
          this._token.Append(c);
        }
        else
          break;
      }
      else
        goto label_9;
label_8:
      c = this.ScanNextChar();
      continue;
label_9:
      this._token.Append(c);
      if (index < 10)
      {
        num = 10L * num + (long) c - 48L /*0x30*/;
        if (flag1)
        {
          ++index;
          goto label_8;
        }
        goto label_8;
      }
      goto label_8;
    }
    if (flag2)
      num = -num;
    CSymbol csymbol;
    if (flag1)
    {
      if (index > 0)
      {
        this._tokenAsReal = (double) num / CLexer.PowersOf10[index];
      }
      else
      {
        this._tokenAsReal = (double) num;
        this._tokenAsLong = num;
      }
      csymbol = CSymbol.Real;
    }
    else
    {
      this._tokenAsLong = num;
      this._tokenAsReal = Convert.ToDouble(num);
      Debug.Assert(long.Parse(this._token.ToString(), (IFormatProvider) CultureInfo.InvariantCulture) == num);
      if ((num < (long) int.MinValue ? 0 : (num < (long) int.MaxValue ? 1 : 0)) != 0)
      {
        csymbol = CSymbol.Integer;
      }
      else
      {
        ContentReaderDiagnostics.ThrowNumberOutOfIntegerRange(num);
        csymbol = CSymbol.Error;
      }
    }
    return csymbol;
  }

  public CSymbol ScanOperator()
  {
    this.ClearToken();
    char ch = this._currChar;
    while (CLexer.IsOperatorChar(ch))
      ch = this.AppendAndScanNextChar();
    this._symbol = CSymbol.Operator;
    return CSymbol.Operator;
  }

  public CSymbol ScanLiteralString()
  {
    Debug.Assert(this._currChar == '(');
    this.ClearToken();
    int num1 = 0;
    char c1 = this.ScanNextChar();
    CSymbol csymbol;
    if ((c1 != 'þ' ? 0 : (this._nextChar == 'ÿ' ? 1 : 0)) != 0)
    {
      int num2 = (int) this.ScanNextChar();
      char ch1 = this.ScanNextChar();
      if (ch1 == ')')
      {
        int num3 = (int) this.ScanNextChar();
        this._symbol = CSymbol.String;
        csymbol = CSymbol.String;
      }
      else
      {
        char ch2 = this.ScanNextChar();
        char c2 = (char) ((uint) ch1 * 256U /*0x0100*/ + (uint) ch2);
        while (true)
        {
          switch (c2)
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
              goto label_25;
            case '\\':
              c2 = this.ScanNextChar();
              switch (c2)
              {
                case '\n':
                  c2 = this.ScanNextChar();
                  continue;
                case '(':
                  c2 = '(';
                  break;
                case ')':
                  c2 = ')';
                  break;
                case '\\':
                  c2 = '\\';
                  break;
                case 'b':
                  c2 = '\b';
                  break;
                case 'f':
                  c2 = '\f';
                  break;
                case 'n':
                  c2 = '\n';
                  break;
                case 'r':
                  c2 = '\r';
                  break;
                case 't':
                  c2 = '\t';
                  break;
                default:
                  if (char.IsDigit(c2))
                  {
                    int num4 = (int) c2 - 48 /*0x30*/;
                    if (char.IsDigit(this._nextChar))
                    {
                      num4 = num4 * 8 + (int) this.ScanNextChar() - 48 /*0x30*/;
                      if (char.IsDigit(this._nextChar))
                        num4 = num4 * 8 + (int) this.ScanNextChar() - 48 /*0x30*/;
                    }
                    c2 = (char) num4;
                    break;
                  }
                  break;
              }
              break;
          }
          this._token.Append(c2);
          char ch3 = this.ScanNextChar();
          if (ch3 != ')')
          {
            char ch4 = this.ScanNextChar();
            c2 = (char) ((uint) ch3 * 256U /*0x0100*/ + (uint) ch4);
          }
          else
            goto label_26;
        }
label_25:
        int num5 = (int) this.ScanNextChar();
        this._symbol = CSymbol.String;
        csymbol = CSymbol.String;
        goto label_48;
label_26:
        int num6 = (int) this.ScanNextChar();
        this._symbol = CSymbol.String;
        csymbol = CSymbol.String;
      }
    }
    else
    {
      while (true)
      {
        switch (c1)
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
            goto label_47;
          case '\\':
            c1 = this.ScanNextChar();
            switch (c1)
            {
              case '\n':
                c1 = this.ScanNextChar();
                continue;
              case '(':
                c1 = '(';
                break;
              case ')':
                c1 = ')';
                break;
              case '\\':
                c1 = '\\';
                break;
              case 'b':
                c1 = '\b';
                break;
              case 'f':
                c1 = '\f';
                break;
              case 'n':
                c1 = '\n';
                break;
              case 'r':
                c1 = '\r';
                break;
              case 't':
                c1 = '\t';
                break;
              default:
                if (char.IsDigit(c1))
                {
                  int num7 = (int) c1 - 48 /*0x30*/;
                  if (char.IsDigit(this._nextChar))
                  {
                    num7 = num7 * 8 + (int) this.ScanNextChar() - 48 /*0x30*/;
                    if (char.IsDigit(this._nextChar))
                      num7 = num7 * 8 + (int) this.ScanNextChar() - 48 /*0x30*/;
                  }
                  c1 = (char) num7;
                  break;
                }
                break;
            }
            break;
        }
        this._token.Append(c1);
        c1 = this.ScanNextChar();
      }
label_47:
      int num8 = (int) this.ScanNextChar();
      this._symbol = CSymbol.String;
      csymbol = CSymbol.String;
    }
label_48:
    return csymbol;
  }

  public CSymbol ScanHexadecimalString()
  {
    Debug.Assert(this._currChar == '<');
    this.ClearToken();
    char[] chArray = new char[2];
    int num1 = (int) this.ScanNextChar();
    while (true)
    {
      do
      {
        int nonWhiteSpace = (int) this.MoveToNonWhiteSpace();
        if (this._currChar == '>')
          goto label_4;
      }
      while (!char.IsLetterOrDigit(this._currChar));
      chArray[0] = char.ToUpper(this._currChar);
      chArray[1] = char.ToUpper(this._nextChar);
      this._token.Append(Convert.ToChar(int.Parse(new string(chArray), NumberStyles.AllowHexSpecifier)));
      int num2 = (int) this.ScanNextChar();
      int num3 = (int) this.ScanNextChar();
    }
label_4:
    int num4 = (int) this.ScanNextChar();
    string str = this._token.ToString();
    int length = str.Length;
    if ((length <= 2 || str[0] != 'þ' ? 0 : (str[1] == 'ÿ' ? 1 : 0)) != 0)
    {
      Debug.Assert(length % 2 == 0);
      this._token.Length = 0;
      for (int index = 2; index < length; index += 2)
        this._token.Append((char) ((uint) str[index] * 256U /*0x0100*/ + (uint) str[index + 1]));
    }
    this._symbol = CSymbol.HexString;
    return CSymbol.HexString;
  }

  internal char ScanNextChar()
  {
    if (this.ContLength <= this._charIndex)
    {
      this._currChar = char.MaxValue;
      if (CLexer.IsOperatorChar(this._nextChar))
        this._token.Append(this._nextChar);
      this._nextChar = char.MaxValue;
    }
    else
    {
      this._currChar = this._nextChar;
      this._nextChar = (char) this._content[this._charIndex++];
      if (this._currChar == '\r')
      {
        if (this._nextChar == '\n')
        {
          this._currChar = this._nextChar;
          this._nextChar = this.ContLength > this._charIndex ? (char) this._content[this._charIndex++] : char.MaxValue;
        }
        else
          this._currChar = '\n';
      }
    }
    return this._currChar;
  }

  private void ClearToken()
  {
    this._token.Length = 0;
    this._tokenAsLong = 0L;
    this._tokenAsReal = 0.0;
  }

  internal char AppendAndScanNextChar()
  {
    this._token.Append(this._currChar);
    return this.ScanNextChar();
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
          int num = (int) this.ScanNextChar();
          continue;
        default:
          currChar = this._currChar;
          goto label_6;
      }
    }
    currChar = this._currChar;
label_6:
    return currChar;
  }

  public CSymbol Symbol
  {
    get => this._symbol;
    set => this._symbol = value;
  }

  public string Token => this._token.ToString();

  internal int TokenToInteger
  {
    get
    {
      Debug.Assert(this._tokenAsLong == (long) int.Parse(this._token.ToString(), (IFormatProvider) CultureInfo.InvariantCulture));
      return (int) this._tokenAsLong;
    }
  }

  internal double TokenToReal
  {
    get
    {
      Debug.Assert(this._tokenAsReal == double.Parse(this._token.ToString(), (IFormatProvider) CultureInfo.InvariantCulture));
      return this._tokenAsReal;
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

  internal static bool IsOperatorChar(char ch)
  {
    bool flag;
    if (char.IsLetter(ch))
    {
      flag = true;
    }
    else
    {
      switch (ch)
      {
        case '"':
        case '\'':
        case '*':
          flag = true;
          break;
        default:
          flag = false;
          break;
      }
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
        flag = true;
        break;
      default:
        flag = false;
        break;
    }
    return flag;
  }

  public int ContLength => this._content.Length;

  public int Position
  {
    get => this._charIndex;
    set
    {
      this._charIndex = value;
      this._currChar = (char) this._content[this._charIndex - 1];
      this._nextChar = (char) this._content[this._charIndex - 1];
    }
  }
}
