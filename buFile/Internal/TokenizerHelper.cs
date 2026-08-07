// Decompiled with JetBrains decompiler
// Type: PdfSharp.Internal.TokenizerHelper
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Globalization;

#nullable disable
namespace PdfSharp.Internal;

internal class TokenizerHelper
{
  private bool _foundSeparator;
  private char _argSeparator;
  private int _charIndex;
  private int _currentTokenIndex;
  private int _currentTokenLength;
  private char _quoteChar;
  private string _str;
  private int _strLen;

  public TokenizerHelper(string str, IFormatProvider formatProvider)
  {
    char numericListSeparator = TokenizerHelper.GetNumericListSeparator(formatProvider);
    this.Initialize(str, '\'', numericListSeparator);
  }

  public TokenizerHelper(string str, char quoteChar, char separator)
  {
    this.Initialize(str, quoteChar, separator);
  }

  private void Initialize(string str, char quoteChar, char separator)
  {
    this._str = str;
    this._strLen = str == null ? 0 : str.Length;
    this._currentTokenIndex = -1;
    this._quoteChar = quoteChar;
    this._argSeparator = separator;
    while (this._charIndex < this._strLen && char.IsWhiteSpace(this._str, this._charIndex))
      ++this._charIndex;
  }

  public string NextTokenRequired()
  {
    if (!this.NextToken(false))
      throw new InvalidOperationException("PrematureStringTermination");
    return this.GetCurrentToken();
  }

  public string NextTokenRequired(bool allowQuotedToken)
  {
    if (!this.NextToken(allowQuotedToken))
      throw new InvalidOperationException("PrematureStringTermination");
    return this.GetCurrentToken();
  }

  public string GetCurrentToken()
  {
    return this._currentTokenIndex >= 0 ? this._str.Substring(this._currentTokenIndex, this._currentTokenLength) : (string) null;
  }

  public void LastTokenRequired()
  {
    if (this._charIndex != this._strLen)
      throw new InvalidOperationException("Extra data encountered");
  }

  public bool NextToken() => this.NextToken(false);

  public bool NextToken(bool allowQuotedToken)
  {
    return this.NextToken(allowQuotedToken, this._argSeparator);
  }

  public bool NextToken(bool allowQuotedToken, char separator)
  {
    this._currentTokenIndex = -1;
    this._foundSeparator = false;
    bool flag;
    if (this._charIndex >= this._strLen)
    {
      flag = false;
    }
    else
    {
      char ch = this._str[this._charIndex];
      int num1 = 0;
      if ((!allowQuotedToken ? 0 : ((int) ch == (int) this._quoteChar ? 1 : 0)) != 0)
      {
        ++num1;
        ++this._charIndex;
      }
      int charIndex = this._charIndex;
      int num2 = 0;
      while (this._charIndex < this._strLen)
      {
        char c = this._str[this._charIndex];
        if (num1 > 0)
        {
          if ((int) c == (int) this._quoteChar)
          {
            --num1;
            if (num1 == 0)
            {
              ++this._charIndex;
              break;
            }
          }
        }
        else if ((char.IsWhiteSpace(c) ? 1 : ((int) c == (int) separator ? 1 : 0)) != 0)
        {
          if ((int) c == (int) separator)
          {
            this._foundSeparator = true;
            break;
          }
          break;
        }
        ++this._charIndex;
        ++num2;
      }
      if (num1 > 0)
        throw new InvalidOperationException("Missing end quote");
      this.ScanToNextToken(separator);
      this._currentTokenIndex = charIndex;
      this._currentTokenLength = num2;
      if (this._currentTokenLength < 1)
        throw new InvalidOperationException("Empty token");
      flag = true;
    }
    return flag;
  }

  private void ScanToNextToken(char separator)
  {
    if (this._charIndex >= this._strLen)
      return;
    char c1 = this._str[this._charIndex];
    if (((int) c1 == (int) separator ? 0 : (!char.IsWhiteSpace(c1) ? 1 : 0)) != 0)
      throw new InvalidOperationException("ExtraDataEncountered");
    int num = 0;
    while (this._charIndex < this._strLen)
    {
      char c2 = this._str[this._charIndex];
      if ((int) c2 == (int) separator)
      {
        this._foundSeparator = true;
        ++num;
        ++this._charIndex;
        if (num > 1)
          throw new InvalidOperationException("EmptyToken");
      }
      else if (char.IsWhiteSpace(c2))
        ++this._charIndex;
      else
        break;
    }
    if ((num <= 0 ? 0 : (this._charIndex >= this._strLen ? 1 : 0)) != 0)
      throw new InvalidOperationException("EmptyToken");
  }

  public static char GetNumericListSeparator(IFormatProvider provider)
  {
    char numericListSeparator = ',';
    NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
    if ((instance.NumberDecimalSeparator.Length <= 0 ? 0 : ((int) numericListSeparator == (int) instance.NumberDecimalSeparator[0] ? 1 : 0)) != 0)
      numericListSeparator = ';';
    return numericListSeparator;
  }

  public bool FoundSeparator => this._foundSeparator;
}
