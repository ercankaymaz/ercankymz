// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.CMapInfo
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Fonts.OpenType;
using PdfSharp.Pdf.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Fonts;

internal class CMapInfo
{
  internal OpenTypeDescriptor _descriptor;
  public char MinChar = char.MaxValue;
  public char MaxChar = char.MinValue;
  public Dictionary<char, int> CharacterToGlyphIndex = new Dictionary<char, int>();
  public Dictionary<int, object> GlyphIndices = new Dictionary<int, object>();

  public CMapInfo(OpenTypeDescriptor descriptor)
  {
    Debug.Assert(descriptor != null);
    this._descriptor = descriptor;
  }

  public void AddChars(string text)
  {
    if (text == null)
      return;
    bool symbol = this._descriptor.FontFace.cmap.symbol;
    int length = text.Length;
    for (int index = 0; index < length; ++index)
    {
      char ch1 = text[index];
      if (!this.CharacterToGlyphIndex.ContainsKey(ch1))
      {
        char ch2 = ch1;
        if (symbol)
          ch2 = (char) ((uint) ch1 | (uint) this._descriptor.FontFace.os2.usFirstCharIndex & 65280U);
        int glyphIndex = this._descriptor.CharCodeToGlyphIndex(ch2);
        this.CharacterToGlyphIndex.Add(ch1, glyphIndex);
        this.GlyphIndices[glyphIndex] = (object) null;
        this.MinChar = (char) Math.Min((ushort) this.MinChar, (ushort) ch1);
        this.MaxChar = (char) Math.Max((ushort) this.MaxChar, (ushort) ch1);
      }
    }
  }

  public void AddGlyphIndices(string glyphIndices)
  {
    if (glyphIndices == null)
      return;
    int length = glyphIndices.Length;
    for (int index = 0; index < length; ++index)
      this.GlyphIndices[(int) glyphIndices[index]] = (object) null;
  }

  internal void AddAnsiChars()
  {
    byte[] bytes = new byte[224 /*0xE0*/];
    for (int index = 0; index < 224 /*0xE0*/; ++index)
      bytes[index] = (byte) (index + 32 /*0x20*/);
    this.AddChars(PdfEncoders.WinAnsiEncoding.GetString(bytes, 0, bytes.Length));
  }

  internal bool Contains(char ch) => this.CharacterToGlyphIndex.ContainsKey(ch);

  public char[] Chars
  {
    get
    {
      char[] array = new char[this.CharacterToGlyphIndex.Count];
      this.CharacterToGlyphIndex.Keys.CopyTo(array, 0);
      Array.Sort<char>(array);
      return array;
    }
  }

  public int[] GetGlyphIndices()
  {
    int[] array = new int[this.GlyphIndices.Count];
    this.GlyphIndices.Keys.CopyTo(array, 0);
    Array.Sort<int>(array);
    return array;
  }
}
