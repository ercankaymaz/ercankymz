// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.ContentWriter
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Internal;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace PdfSharp.Pdf.Content;

internal class ContentWriter
{
  protected int _indent = 2;
  protected int _writeIndent = 0;
  private ContentWriter.CharCat _lastCat;
  private Stream _stream;

  public ContentWriter(Stream contentStream) => this._stream = contentStream;

  public void Close(bool closeUnderlyingStream)
  {
    if (!(this._stream != null & closeUnderlyingStream))
      return;
    this._stream.Close();
    this._stream = (Stream) null;
  }

  public void Close() => this.Close(true);

  public int Position => (int) this._stream.Position;

  public void Write(bool value)
  {
  }

  public void WriteRaw(string rawString)
  {
    if (string.IsNullOrEmpty(rawString))
      return;
    byte[] bytes = PdfEncoders.RawEncoding.GetBytes(rawString);
    this._stream.Write(bytes, 0, bytes.Length);
    this._lastCat = this.GetCategory((char) bytes[bytes.Length - 1]);
  }

  public void WriteLineRaw(string rawString)
  {
    if (string.IsNullOrEmpty(rawString))
      return;
    byte[] bytes = PdfEncoders.RawEncoding.GetBytes(rawString);
    this._stream.Write(bytes, 0, bytes.Length);
    this._stream.Write(new byte[1]{ (byte) 10 }, 0, 1);
    this._lastCat = this.GetCategory((char) bytes[bytes.Length - 1]);
  }

  public void WriteRaw(char ch)
  {
    Debug.Assert(ch < 'Ā', "Raw character greater than 255 detected.");
    this._stream.WriteByte((byte) ch);
    this._lastCat = this.GetCategory(ch);
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

  private void WriteSeparator(ContentWriter.CharCat cat, char ch)
  {
    if (this._lastCat == ContentWriter.CharCat.Delimiter)
      ;
  }

  private void WriteSeparator(ContentWriter.CharCat cat) => this.WriteSeparator(cat, char.MinValue);

  public void NewLine()
  {
    if (this._lastCat == 0)
      return;
    this.WriteRaw('\n');
  }

  private ContentWriter.CharCat GetCategory(char ch) => ContentWriter.CharCat.Character;

  internal Stream Stream => this._stream;

  private enum CharCat
  {
    NewLine,
    Character,
    Delimiter,
  }
}
