// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.OpenTypeFontWriter
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Diagnostics;
using System.IO;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class OpenTypeFontWriter(Stream stream) : FontWriter(stream)
{
  public void WriteTag(string tag)
  {
    Debug.Assert(tag.Length == 4);
    this.WriteByte((byte) tag[0]);
    this.WriteByte((byte) tag[1]);
    this.WriteByte((byte) tag[2]);
    this.WriteByte((byte) tag[3]);
  }
}
