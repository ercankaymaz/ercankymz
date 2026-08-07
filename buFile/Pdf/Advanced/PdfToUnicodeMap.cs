// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfToUnicodeMap
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Fonts;
using PdfSharp.Pdf.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfToUnicodeMap : PdfDictionary
{
  private CMapInfo _cmapInfo;

  public PdfToUnicodeMap(PdfDocument document)
    : base(document)
  {
  }

  public PdfToUnicodeMap(PdfDocument document, CMapInfo cmapInfo)
    : base(document)
  {
    this._cmapInfo = cmapInfo;
  }

  public CMapInfo CMapInfo
  {
    get => this._cmapInfo;
    set => this._cmapInfo = value;
  }

  internal override void PrepareForSave()
  {
    base.PrepareForSave();
    string str1 = "/CIDInit /ProcSet findresource begin\n12 dict begin\nbegincmap\n/CIDSystemInfo << /Registry (Adobe)/Ordering (UCS)/Supplement 0>> def\n/CMapName /Adobe-Identity-UCS def /CMapType 2 def\n";
    string str2 = "endcmap CMapName currentdict /CMap defineresource pop end end";
    Dictionary<int, char> dictionary = new Dictionary<int, char>();
    int val1_1 = 65536 /*0x010000*/;
    int val1_2 = -1;
    foreach (KeyValuePair<char, int> keyValuePair in this._cmapInfo.CharacterToGlyphIndex)
    {
      int num = keyValuePair.Value;
      val1_1 = Math.Min(val1_1, num);
      val1_2 = Math.Max(val1_2, num);
      dictionary[num] = keyValuePair.Key;
    }
    MemoryStream memoryStream = new MemoryStream();
    StreamWriter streamWriter = new StreamWriter((System.IO.Stream) memoryStream, Encoding.ASCII);
    streamWriter.Write(str1);
    streamWriter.WriteLine("1 begincodespacerange");
    streamWriter.WriteLine($"<{val1_1:X4}><{val1_2:X4}>");
    streamWriter.WriteLine("endcodespacerange");
    streamWriter.WriteLine($"{dictionary.Count} beginbfrange");
    foreach (KeyValuePair<int, char> keyValuePair in dictionary)
      streamWriter.WriteLine(string.Format("<{0:X4}><{0:X4}><{1:X4}>", (object) keyValuePair.Key, (object) (int) keyValuePair.Value));
    streamWriter.WriteLine("endbfrange");
    streamWriter.Write(str2);
    streamWriter.Close();
    byte[] data = memoryStream.ToArray();
    memoryStream.Close();
    if (this.Owner.Options.CompressContentStreams)
    {
      this.Elements.SetName("/Filter", "/FlateDecode");
      data = Filtering.FlateDecode.Encode(data, this._document.Options.FlateEncodeMode);
    }
    else
      this.Elements.Remove("/Filter");
    if (this.Stream == null)
    {
      this.CreateStream(data);
    }
    else
    {
      this.Stream.Value = data;
      this.Elements.SetInteger("/Length", this.Stream.Length);
    }
  }

  public sealed class Keys : PdfDictionary.PdfStream.Keys
  {
  }
}
