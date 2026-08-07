// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Annotations.PdfLinkAnnotation
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using System;

#nullable disable
namespace PdfSharp.Pdf.Annotations;

public sealed class PdfLinkAnnotation : PdfAnnotation
{
  private int _destPage;
  private PdfLinkAnnotation.LinkType _linkType;
  private string _url;

  public PdfLinkAnnotation()
  {
    this._linkType = PdfLinkAnnotation.LinkType.None;
    this.Elements.SetName("/Subtype", "/Link");
  }

  public PdfLinkAnnotation(PdfDocument document)
    : base(document)
  {
    this._linkType = PdfLinkAnnotation.LinkType.None;
    this.Elements.SetName("/Subtype", "/Link");
  }

  public static PdfLinkAnnotation CreateDocumentLink(PdfRectangle rect, int destinationPage)
  {
    if (destinationPage < 1)
      throw new ArgumentException("Invalid destination page in call to CreateDocumentLink: page number is one-based and must be 1 or higher.", nameof (destinationPage));
    PdfLinkAnnotation documentLink = new PdfLinkAnnotation();
    documentLink._linkType = PdfLinkAnnotation.LinkType.Document;
    documentLink.Rectangle = rect;
    documentLink._destPage = destinationPage;
    return documentLink;
  }

  public static PdfLinkAnnotation CreateWebLink(PdfRectangle rect, string url)
  {
    PdfLinkAnnotation webLink = new PdfLinkAnnotation();
    webLink._linkType = PdfLinkAnnotation.LinkType.Web;
    webLink.Rectangle = rect;
    webLink._url = url;
    return webLink;
  }

  public static PdfLinkAnnotation CreateFileLink(PdfRectangle rect, string fileName)
  {
    PdfLinkAnnotation fileLink = new PdfLinkAnnotation();
    fileLink._linkType = PdfLinkAnnotation.LinkType.File;
    fileLink.Rectangle = rect;
    fileLink._url = fileName;
    return fileLink;
  }

  internal override void WriteObject(PdfWriter writer)
  {
    if (this.Elements["/BS"] == null)
      this.Elements["/BS"] = (PdfItem) new PdfLiteral("<</Type/Border/W 0>>");
    if (this.Elements["/Border"] == null)
      this.Elements["/Border"] = (PdfItem) new PdfLiteral("[0 0 0]");
    switch (this._linkType)
    {
      case PdfLinkAnnotation.LinkType.Document:
        int num = this._destPage;
        if (num > this.Owner.PageCount)
          num = this.Owner.PageCount;
        this.Elements["/Dest"] = (PdfItem) new PdfLiteral("[{0} 0 R/XYZ null null 0]", new object[1]
        {
          (object) this.Owner.Pages[num - 1].ObjectNumber
        });
        break;
      case PdfLinkAnnotation.LinkType.Web:
        this.Elements["/A"] = (PdfItem) new PdfLiteral("<</S/URI/URI{0}>>", new object[1]
        {
          (object) PdfEncoders.ToStringLiteral(this._url, PdfStringEncoding.WinAnsiEncoding, writer.SecurityHandler)
        });
        break;
      case PdfLinkAnnotation.LinkType.File:
        this.Elements["/A"] = (PdfItem) new PdfLiteral("<</Type/Action/S/Launch/F<</Type/Filespec/F{0}>> >>", new object[1]
        {
          (object) PdfEncoders.ToStringLiteral(this._url, PdfStringEncoding.WinAnsiEncoding, writer.SecurityHandler)
        });
        break;
    }
    base.WriteObject(writer);
  }

  internal override DictionaryMeta Meta => PdfLinkAnnotation.Keys.Meta;

  private enum LinkType
  {
    None,
    Document,
    Web,
    File,
  }

  internal new class Keys : PdfAnnotation.Keys
  {
    [KeyInfo(KeyType.ArrayOrNameOrString | KeyType.Optional)]
    public const string Dest = "/Dest";
    [KeyInfo("1.2", KeyType.Name | KeyType.Optional)]
    public const string H = "/H";
    [KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional)]
    public const string PA = "/PA";
    private static DictionaryMeta _meta;

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfLinkAnnotation.Keys._meta ?? (PdfLinkAnnotation.Keys._meta = KeysBase.CreateMeta(typeof (PdfLinkAnnotation.Keys)));
      }
    }
  }
}
