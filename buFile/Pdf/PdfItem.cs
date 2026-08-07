// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfItem
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using System;

#nullable disable
namespace PdfSharp.Pdf;

public abstract class PdfItem : ICloneable
{
  object ICloneable.Clone() => this.Copy();

  public PdfItem Clone() => (PdfItem) this.Copy();

  protected virtual object Copy() => this.MemberwiseClone();

  internal abstract void WriteObject(PdfWriter writer);
}
