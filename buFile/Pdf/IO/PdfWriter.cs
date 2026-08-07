// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.IO.PdfWriter
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf.IO;

internal class PdfWriter
{
  private PdfWriterLayout _layout;
  private PdfWriterOptions _options;
  private int _indent = 2;
  private int _writeIndent;
  private PdfWriter.CharCat _lastCat;
  private Stream _stream;
  private PdfStandardSecurityHandler _securityHandler;
  private readonly List<PdfWriter.StackItem> _stack = new List<PdfWriter.StackItem>();
  private int _commentPosition;

  public PdfWriter(Stream pdfStream, PdfStandardSecurityHandler securityHandler)
  {
    this._stream = pdfStream;
    this._securityHandler = securityHandler;
    this._layout = PdfWriterLayout.Verbose;
  }

  public void Close(bool closeUnderlyingStream)
  {
    if (this._stream != null & closeUnderlyingStream)
      this._stream.Close();
    this._stream = (Stream) null;
  }

  public void Close() => this.Close(true);

  public int Position => (int) this._stream.Position;

  public PdfWriterLayout Layout
  {
    get => this._layout;
    set => this._layout = value;
  }

  public PdfWriterOptions Options
  {
    get => this._options;
    set => this._options = value;
  }

  public void Write(bool value)
  {
    this.WriteSeparator(PdfWriter.CharCat.Character);
    this.WriteRaw(value ? bool.TrueString : bool.FalseString);
    this._lastCat = PdfWriter.CharCat.Character;
  }

  public void Write(PdfBoolean value)
  {
    this.WriteSeparator(PdfWriter.CharCat.Character);
    this.WriteRaw(value.Value ? "true" : "false");
    this._lastCat = PdfWriter.CharCat.Character;
  }

  public void Write(int value)
  {
    this.WriteSeparator(PdfWriter.CharCat.Character);
    this.WriteRaw(value.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    this._lastCat = PdfWriter.CharCat.Character;
  }

  public void Write(uint value)
  {
    this.WriteSeparator(PdfWriter.CharCat.Character);
    this.WriteRaw(value.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    this._lastCat = PdfWriter.CharCat.Character;
  }

  public void Write(PdfInteger value)
  {
    this.WriteSeparator(PdfWriter.CharCat.Character);
    this._lastCat = PdfWriter.CharCat.Character;
    this.WriteRaw(value.Value.ToString((IFormatProvider) CultureInfo.InvariantCulture));
  }

  public void Write(PdfUInteger value)
  {
    this.WriteSeparator(PdfWriter.CharCat.Character);
    this._lastCat = PdfWriter.CharCat.Character;
    this.WriteRaw(value.Value.ToString((IFormatProvider) CultureInfo.InvariantCulture));
  }

  public void Write(double value)
  {
    this.WriteSeparator(PdfWriter.CharCat.Character);
    this.WriteRaw(value.ToString("0.#######", (IFormatProvider) CultureInfo.InvariantCulture));
    this._lastCat = PdfWriter.CharCat.Character;
  }

  public void Write(PdfReal value)
  {
    this.WriteSeparator(PdfWriter.CharCat.Character);
    this.WriteRaw(value.Value.ToString("0.#######", (IFormatProvider) CultureInfo.InvariantCulture));
    this._lastCat = PdfWriter.CharCat.Character;
  }

  public void Write(PdfString value)
  {
    this.WriteSeparator(PdfWriter.CharCat.Delimiter);
    PdfStringEncoding encoding = (PdfStringEncoding) (value.Flags & PdfStringFlags.EncodingMask);
    this.WriteRaw((value.Flags & PdfStringFlags.HexLiteral) == PdfStringFlags.RawEncoding ? PdfEncoders.ToStringLiteral(value.Value, encoding, this.SecurityHandler) : PdfEncoders.ToHexStringLiteral(value.Value, encoding, this.SecurityHandler));
    this._lastCat = PdfWriter.CharCat.Delimiter;
  }

  public void Write(PdfName value)
  {
    this.WriteSeparator(PdfWriter.CharCat.Delimiter, '/');
    string str = value.Value;
    StringBuilder stringBuilder = new StringBuilder("/");
    for (int index = 1; index < str.Length; ++index)
    {
      char ch = str[index];
      Debug.Assert(ch < 'Ā');
      if (ch > ' ')
      {
        switch (ch)
        {
          case '#':
          case '%':
          case '(':
          case ')':
          case '/':
          case '<':
          case '>':
            break;
          default:
            stringBuilder.Append(str[index]);
            continue;
        }
      }
      stringBuilder.AppendFormat("#{0:X2}", (object) (int) str[index]);
    }
    this.WriteRaw(stringBuilder.ToString());
    this._lastCat = PdfWriter.CharCat.Character;
  }

  public void Write(PdfLiteral value)
  {
    this.WriteSeparator(PdfWriter.CharCat.Character);
    this.WriteRaw(value.Value);
    this._lastCat = PdfWriter.CharCat.Character;
  }

  public void Write(PdfRectangle rect)
  {
    this.WriteSeparator(PdfWriter.CharCat.Delimiter, '/');
    this.WriteRaw(PdfEncoders.Format("[{0:0.###} {1:0.###} {2:0.###} {3:0.###}]", (object) rect.X1, (object) rect.Y1, (object) rect.X2, (object) rect.Y2));
    this._lastCat = PdfWriter.CharCat.Delimiter;
  }

  public void Write(PdfReference iref)
  {
    this.WriteSeparator(PdfWriter.CharCat.Character);
    this.WriteRaw(iref.ToString());
    this._lastCat = PdfWriter.CharCat.Character;
  }

  public void WriteDocString(string text, bool unicode)
  {
    this.WriteSeparator(PdfWriter.CharCat.Delimiter);
    this.Write(PdfEncoders.FormatStringLiteral(unicode ? PdfEncoders.UnicodeEncoding.GetBytes(text) : PdfEncoders.DocEncoding.GetBytes(text), unicode, true, false, this._securityHandler));
    this._lastCat = PdfWriter.CharCat.Delimiter;
  }

  public void WriteDocString(string text)
  {
    this.WriteSeparator(PdfWriter.CharCat.Delimiter);
    this.Write(PdfEncoders.FormatStringLiteral(PdfEncoders.DocEncoding.GetBytes(text), false, false, false, this._securityHandler));
    this._lastCat = PdfWriter.CharCat.Delimiter;
  }

  public void WriteDocStringHex(string text)
  {
    this.WriteSeparator(PdfWriter.CharCat.Delimiter);
    byte[] buffer = PdfEncoders.FormatStringLiteral(PdfEncoders.DocEncoding.GetBytes(text), false, false, true, this._securityHandler);
    this._stream.Write(buffer, 0, buffer.Length);
    this._lastCat = PdfWriter.CharCat.Delimiter;
  }

  public void WriteBeginObject(PdfObject obj)
  {
    bool isIndirect;
    if (isIndirect = obj.IsIndirect)
    {
      this.WriteObjectAddress(obj);
      if (this._securityHandler != null)
        this._securityHandler.SetHashKey(obj.ObjectID);
    }
    this._stack.Add(new PdfWriter.StackItem(obj));
    if (isIndirect)
    {
      switch (obj)
      {
        case PdfArray _:
          this.WriteRaw("[\n");
          break;
        case PdfDictionary _:
          this.WriteRaw("<<\n");
          break;
      }
      this._lastCat = PdfWriter.CharCat.NewLine;
    }
    else if (obj is PdfArray)
    {
      this.WriteSeparator(PdfWriter.CharCat.Delimiter);
      this.WriteRaw('[');
      this._lastCat = PdfWriter.CharCat.Delimiter;
    }
    else if (obj is PdfDictionary)
    {
      this.NewLine();
      this.WriteSeparator(PdfWriter.CharCat.Delimiter);
      this.WriteRaw("<<\n");
      this._lastCat = PdfWriter.CharCat.NewLine;
    }
    if (this._layout != PdfWriterLayout.Verbose)
      return;
    this.IncreaseIndent();
  }

  public void WriteEndObject()
  {
    int count = this._stack.Count;
    Debug.Assert(count > 0, "PdfWriter stack underflow.");
    PdfWriter.StackItem stackItem = this._stack[count - 1];
    this._stack.RemoveAt(count - 1);
    PdfObject pdfObject = stackItem.Object;
    bool isIndirect = pdfObject.IsIndirect;
    if (this._layout == PdfWriterLayout.Verbose)
      this.DecreaseIndent();
    if (pdfObject is PdfArray)
    {
      if (isIndirect)
      {
        this.WriteRaw("\n]\n");
        this._lastCat = PdfWriter.CharCat.NewLine;
      }
      else
      {
        this.WriteRaw("]");
        this._lastCat = PdfWriter.CharCat.Delimiter;
      }
    }
    else if (pdfObject is PdfDictionary)
    {
      if (isIndirect)
      {
        if (!stackItem.HasStream)
          this.WriteRaw(this._lastCat == PdfWriter.CharCat.NewLine ? ">>\n" : " >>\n");
      }
      else
      {
        Debug.Assert(!stackItem.HasStream, "Direct object with stream??");
        this.WriteSeparator(PdfWriter.CharCat.NewLine);
        this.WriteRaw(">>\n");
        this._lastCat = PdfWriter.CharCat.NewLine;
      }
    }
    if (!isIndirect)
      return;
    this.NewLine();
    this.WriteRaw("endobj\n");
    if (this._layout != PdfWriterLayout.Verbose)
      return;
    this.WriteRaw("%--------------------------------------------------------------------------------------------------\n");
  }

  public void WriteStream(PdfDictionary value, bool omitStream)
  {
    PdfWriter.StackItem stackItem = this._stack[this._stack.Count - 1];
    Debug.Assert(stackItem.Object is PdfDictionary);
    Debug.Assert(stackItem.Object.IsIndirect);
    stackItem.HasStream = true;
    this.WriteRaw(this._lastCat == PdfWriter.CharCat.NewLine ? ">>\nstream\n" : " >>\nstream\n");
    if (omitStream)
    {
      this.WriteRaw("  «...stream content omitted...»\n");
    }
    else
    {
      byte[] bytes = value.Stream.Value;
      if (bytes.Length != 0)
      {
        if (this._securityHandler != null)
          bytes = this._securityHandler.EncryptBytes((byte[]) bytes.Clone());
        this.Write(bytes);
        if (this._lastCat != 0)
          this.WriteRaw('\n');
      }
    }
    this.WriteRaw("endstream\n");
  }

  public void WriteRaw(string rawString)
  {
    if (string.IsNullOrEmpty(rawString))
      return;
    byte[] bytes = PdfEncoders.RawEncoding.GetBytes(rawString);
    this._stream.Write(bytes, 0, bytes.Length);
    this._lastCat = this.GetCategory((char) bytes[bytes.Length - 1]);
  }

  public void WriteRaw(char ch)
  {
    Debug.Assert(ch < 'Ā', "Raw character greater than 255 detected.");
    this._stream.WriteByte((byte) ch);
    this._lastCat = this.GetCategory(ch);
  }

  public void Write(byte[] bytes)
  {
    if ((bytes == null ? 1 : (bytes.Length == 0 ? 1 : 0)) != 0)
      return;
    this._stream.Write(bytes, 0, bytes.Length);
    this._lastCat = this.GetCategory((char) bytes[bytes.Length - 1]);
  }

  private void WriteObjectAddress(PdfObject value)
  {
    if (this._layout == PdfWriterLayout.Verbose)
    {
      PdfObjectID objectId = value.ObjectID;
      // ISSUE: variable of a boxed type
      __Boxed<int> objectNumber = (ValueType) objectId.ObjectNumber;
      objectId = value.ObjectID;
      // ISSUE: variable of a boxed type
      __Boxed<int> generationNumber = (ValueType) objectId.GenerationNumber;
      string fullName = value.GetType().FullName;
      this.WriteRaw($"{objectNumber} {generationNumber} obj   % {fullName}\n");
    }
    else
    {
      PdfObjectID objectId = value.ObjectID;
      // ISSUE: variable of a boxed type
      __Boxed<int> objectNumber = (ValueType) objectId.ObjectNumber;
      objectId = value.ObjectID;
      // ISSUE: variable of a boxed type
      __Boxed<int> generationNumber = (ValueType) objectId.GenerationNumber;
      this.WriteRaw($"{objectNumber} {generationNumber} obj\n");
    }
  }

  public void WriteFileHeader(PdfDocument document)
  {
    StringBuilder stringBuilder1 = new StringBuilder("%PDF-");
    int version = document._version;
    StringBuilder stringBuilder2 = stringBuilder1;
    int num = version / 10;
    string str1 = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    num = version % 10;
    string str2 = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    string str3 = $"{str1}.{str2}\n%ÓôÌá\n";
    stringBuilder2.Append(str3);
    this.WriteRaw(stringBuilder1.ToString());
    if (this._layout != PdfWriterLayout.Verbose)
      return;
    this.WriteRaw($"% PDFsharp Version {"1.50.4740.0"} (verbose mode)\n");
    this._commentPosition = (int) this._stream.Position + 2;
    this.WriteRaw("%                                                \n");
    this.WriteRaw("%                                                \n");
    this.WriteRaw("%                                                \n");
    this.WriteRaw("%                                                \n");
    this.WriteRaw("%                                                \n");
    this.WriteRaw("%--------------------------------------------------------------------------------------------------\n");
  }

  public void WriteEof(PdfDocument document, int startxref)
  {
    this.WriteRaw("startxref\n");
    this.WriteRaw(startxref.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    this.WriteRaw("\n%%EOF\n");
    int position = (int) this._stream.Position;
    if (this._layout != PdfWriterLayout.Verbose)
      return;
    TimeSpan timeSpan = DateTime.Now - document._creation;
    this._stream.Position = (long) this._commentPosition;
    this.WriteRaw("Creation date: " + document._creation.ToString("G", (IFormatProvider) CultureInfo.InvariantCulture));
    this._stream.Position = (long) (this._commentPosition + 50);
    this.WriteRaw($"Creation time: {timeSpan.TotalSeconds.ToString("0.000", (IFormatProvider) CultureInfo.InvariantCulture)} seconds");
    this._stream.Position = (long) (this._commentPosition + 100);
    this.WriteRaw($"File size: {position.ToString((IFormatProvider) CultureInfo.InvariantCulture)} bytes");
    this._stream.Position = (long) (this._commentPosition + 150);
    this.WriteRaw("Pages: " + document.Pages.Count.ToString((IFormatProvider) CultureInfo.InvariantCulture));
    this._stream.Position = (long) (this._commentPosition + 200);
    this.WriteRaw("Objects: " + document._irefTable.ObjectTable.Count.ToString((IFormatProvider) CultureInfo.InvariantCulture));
  }

  internal int Indent
  {
    get => this._indent;
    set => this._indent = value;
  }

  private void IncreaseIndent() => this._writeIndent += this._indent;

  private void DecreaseIndent() => this._writeIndent -= this._indent;

  private string IndentBlanks => new string(' ', this._writeIndent);

  private void WriteIndent() => this.WriteRaw(this.IndentBlanks);

  private void WriteSeparator(PdfWriter.CharCat cat, char ch)
  {
    switch (this._lastCat)
    {
      case PdfWriter.CharCat.NewLine:
        if (this._layout != PdfWriterLayout.Verbose)
          break;
        this.WriteIndent();
        break;
      case PdfWriter.CharCat.Character:
        if (this._layout == PdfWriterLayout.Verbose)
        {
          this._stream.WriteByte((byte) 32 /*0x20*/);
          break;
        }
        if (cat != PdfWriter.CharCat.Character)
          break;
        this._stream.WriteByte((byte) 32 /*0x20*/);
        break;
    }
  }

  private void WriteSeparator(PdfWriter.CharCat cat) => this.WriteSeparator(cat, char.MinValue);

  public void NewLine()
  {
    if (this._lastCat == 0)
      return;
    this.WriteRaw('\n');
  }

  private PdfWriter.CharCat GetCategory(char ch)
  {
    return !Lexer.IsDelimiter(ch) ? (ch != '\n' ? PdfWriter.CharCat.Character : PdfWriter.CharCat.NewLine) : PdfWriter.CharCat.Delimiter;
  }

  internal Stream Stream => this._stream;

  internal PdfStandardSecurityHandler SecurityHandler
  {
    get => this._securityHandler;
    set => this._securityHandler = value;
  }

  private enum CharCat
  {
    NewLine,
    Character,
    Delimiter,
  }

  private class StackItem
  {
    public readonly PdfObject Object;
    public bool HasStream;

    public StackItem(PdfObject value) => this.Object = value;
  }
}
