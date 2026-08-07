// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfResourceTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public class PdfResourceTable
{
  private readonly PdfDocument _owner;

  public PdfResourceTable(PdfDocument owner)
  {
    this._owner = owner != null ? owner : throw new ArgumentNullException(nameof (owner));
  }

  protected PdfDocument Owner => this._owner;
}
