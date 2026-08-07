// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfContent
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing.Pdf;
using PdfSharp.Pdf.Filters;
using PdfSharp.Pdf.IO;
using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfContent : PdfDictionary
{
  internal XGraphicsPdfRenderer _pdfRenderer;

  public PdfContent(PdfDocument document)
    : base(document)
  {
  }

  internal PdfContent(PdfPage page)
    : base(page?.Owner)
  {
  }

  public PdfContent(PdfDictionary dict)
    : base(dict)
  {
    this.Decode();
  }

  public bool Compressed
  {
    set
    {
      if (!value || this.Elements["/Filter"] != null)
        return;
      this.Stream.Value = Filtering.FlateDecode.Encode(this.Stream.Value, this._document.Options.FlateEncodeMode);
      this.Elements.SetInteger("/Length", this.Stream.Length);
      this.Elements.SetName("/Filter", "/FlateDecode");
    }
  }

  private void Decode()
  {
    if ((this.Stream == null ? 0 : (this.Stream.Value != null ? 1 : 0)) == 0)
      return;
    PdfItem element = this.Elements["/Filter"];
    if (element == null)
      return;
    byte[] numArray = Filtering.Decode(this.Stream.Value, element);
    if (numArray == null)
      return;
    this.Stream.Value = numArray;
    this.Elements.Remove("/Filter");
    this.Elements.SetInteger("/Length", this.Stream.Length);
  }

  internal void PreserveGraphicsState()
  {
    if (this.Stream == null)
      return;
    byte[] sourceArray = this.Stream.Value;
    int length = sourceArray.Length;
    if ((length == 0 ? 0 : (sourceArray[0] != (byte) 113 ? 1 : (sourceArray[1] != (byte) 10 ? 1 : 0))) == 0)
      return;
    byte[] destinationArray = new byte[length + 2 + 3];
    destinationArray[0] = (byte) 113;
    destinationArray[1] = (byte) 10;
    Array.Copy((Array) sourceArray, 0, (Array) destinationArray, 2, length);
    destinationArray[length + 2] = (byte) 32 /*0x20*/;
    destinationArray[length + 3] = (byte) 81;
    destinationArray[length + 4] = (byte) 10;
    this.Stream.Value = destinationArray;
    this.Elements.SetInteger("/Length", this.Stream.Length);
  }

  internal override void WriteObject(PdfWriter writer)
  {
    if (this._pdfRenderer != null)
    {
      this._pdfRenderer.Close();
      Debug.Assert(this._pdfRenderer == null);
    }
    if (this.Stream != null)
    {
      if ((!this.Owner.Options.CompressContentStreams ? 0 : (this.Elements.GetName("/Filter").Length == 0 ? 1 : 0)) != 0)
      {
        this.Stream.Value = Filtering.FlateDecode.Encode(this.Stream.Value, this._document.Options.FlateEncodeMode);
        this.Elements.SetName("/Filter", "/FlateDecode");
      }
      this.Elements.SetInteger("/Length", this.Stream.Length);
    }
    base.WriteObject(writer);
  }

  internal override DictionaryMeta Meta => PdfContent.Keys.Meta;

  internal sealed class Keys : PdfDictionary.PdfStream.Keys
  {
    private static DictionaryMeta _meta;

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfContent.Keys._meta ?? (PdfContent.Keys._meta = KeysBase.CreateMeta(typeof (PdfContent.Keys)));
      }
    }
  }
}
