// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfNull
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;

#nullable disable
namespace PdfSharp.Pdf;

public sealed class PdfNull : PdfItem
{
  public static readonly PdfNull Value = new PdfNull();

  private PdfNull()
  {
  }

  public override string ToString() => "null";

  internal override void WriteObject(PdfWriter writer) => writer.WriteRaw(" null ");
}
