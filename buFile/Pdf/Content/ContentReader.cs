// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.ContentReader
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Content.Objects;
using System.IO;

#nullable disable
namespace PdfSharp.Pdf.Content;

public static class ContentReader
{
  public static CSequence ReadContent(PdfPage page) => new CParser(page).ReadContent();

  public static CSequence ReadContent(byte[] content) => new CParser(content).ReadContent();

  public static CSequence ReadContent(MemoryStream content) => new CParser(content).ReadContent();
}
