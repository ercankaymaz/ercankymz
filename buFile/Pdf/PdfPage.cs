// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfPage
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Pdf.IO;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

#nullable disable
namespace PdfSharp.Pdf;

public sealed class PdfPage : PdfDictionary, IContentStream
{
  private object _tag;
  private bool _closed;
  private PageOrientation _orientation;
  private PageSize _pageSize;
  private TrimMargins _trimMargins = new TrimMargins();
  internal PdfContent RenderContent;
  private PdfContents _contents;
  private PdfAnnotations _annotations;
  private PdfCustomValues _customValues;
  private PdfResources _resources;
  internal bool TransparencyUsed;

  public PdfPage()
  {
    this.Elements.SetName("/Type", "/Page");
    this.Initialize();
  }

  public PdfPage(PdfDocument document)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Page");
    this.Elements["/Parent"] = (PdfItem) document.Pages.Reference;
    this.Initialize();
  }

  internal PdfPage(PdfDictionary dict)
    : base(dict)
  {
  }

  private void Initialize()
  {
    this.Size = RegionInfo.CurrentRegion.IsMetric ? PageSize.A4 : PageSize.Letter;
    PdfRectangle mediaBox = this.MediaBox;
  }

  public object Tag
  {
    get => this._tag;
    set => this._tag = value;
  }

  public void Close() => this._closed = true;

  internal bool IsClosed => this._closed;

  internal override PdfDocument Document
  {
    set
    {
      if (this._document == value)
        return;
      this._document = this._document == null ? value : throw new InvalidOperationException("Cannot change document.");
      if (this.Reference != null)
        this.Reference.Document = value;
      this.Elements["/Parent"] = (PdfItem) this._document.Pages.Reference;
    }
  }

  public PageOrientation Orientation
  {
    get => this._orientation;
    set => this._orientation = value;
  }

  public PageSize Size
  {
    get => this._pageSize;
    set
    {
      XSize xsize = Enum.IsDefined(typeof (PageSize), (object) value) ? PageSizeConverter.ToSize(value) : throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (PageSize));
      this.MediaBox = new PdfRectangle(0.0, 0.0, xsize.Width, xsize.Height);
      this._pageSize = value;
    }
  }

  public TrimMargins TrimMargins
  {
    get
    {
      if (this._trimMargins == null)
        this._trimMargins = new TrimMargins();
      return this._trimMargins;
    }
    set
    {
      if (this._trimMargins == null)
        this._trimMargins = new TrimMargins();
      if (value != null)
      {
        this._trimMargins.Left = value.Left;
        this._trimMargins.Right = value.Right;
        this._trimMargins.Top = value.Top;
        this._trimMargins.Bottom = value.Bottom;
      }
      else
        this._trimMargins.All = (XUnit) 0;
    }
  }

  public PdfRectangle MediaBox
  {
    get => this.Elements.GetRectangle("/MediaBox", true);
    set => this.Elements.SetRectangle("/MediaBox", value);
  }

  public PdfRectangle CropBox
  {
    get => this.Elements.GetRectangle("/CropBox", true);
    set => this.Elements.SetRectangle("/CropBox", value);
  }

  public PdfRectangle BleedBox
  {
    get => this.Elements.GetRectangle("/BleedBox", true);
    set => this.Elements.SetRectangle("/BleedBox", value);
  }

  public PdfRectangle ArtBox
  {
    get => this.Elements.GetRectangle("/ArtBox", true);
    set => this.Elements.SetRectangle("/ArtBox", value);
  }

  public PdfRectangle TrimBox
  {
    get => this.Elements.GetRectangle("/TrimBox", true);
    set => this.Elements.SetRectangle("/TrimBox", value);
  }

  public XUnit Height
  {
    get
    {
      PdfRectangle mediaBox = this.MediaBox;
      return (XUnit) (this._orientation == PageOrientation.Portrait ? mediaBox.Height : mediaBox.Width);
    }
    set
    {
      PdfRectangle mediaBox = this.MediaBox;
      this.MediaBox = this._orientation != PageOrientation.Portrait ? new PdfRectangle(0.0, mediaBox.Y1, (double) value, mediaBox.Y2) : new PdfRectangle(mediaBox.X1, 0.0, mediaBox.X2, (double) value);
      this._pageSize = PageSize.Undefined;
    }
  }

  public XUnit Width
  {
    get
    {
      PdfRectangle mediaBox = this.MediaBox;
      return (XUnit) (this._orientation == PageOrientation.Portrait ? mediaBox.Width : mediaBox.Height);
    }
    set
    {
      PdfRectangle mediaBox = this.MediaBox;
      this.MediaBox = this._orientation != PageOrientation.Portrait ? new PdfRectangle(mediaBox.X1, 0.0, mediaBox.X2, (double) value) : new PdfRectangle(0.0, mediaBox.Y1, (double) value, mediaBox.Y2);
      this._pageSize = PageSize.Undefined;
    }
  }

  public int Rotate
  {
    get => this._elements.GetInteger("/Rotate");
    set
    {
      if (value % 90 != 0)
        throw new ArgumentException("Value must be a multiple of 90.");
      this._elements.SetInteger("/Rotate", value);
    }
  }

  public PdfContents Contents
  {
    get
    {
      if (this._contents == null)
      {
        PdfItem element = this.Elements["/Contents"];
        if (element == null)
        {
          this._contents = new PdfContents(this.Owner);
        }
        else
        {
          if (element is PdfReference)
            element = (PdfItem) ((PdfReference) element).Value;
          if (element is PdfArray array)
          {
            if (array.IsIndirect)
            {
              array = array.Clone();
              array.Document = this.Owner;
            }
            this._contents = new PdfContents(array);
          }
          else
          {
            this._contents = new PdfContents(this.Owner);
            this._contents.Elements.Add((PdfItem) new PdfContent((PdfDictionary) element).Reference);
          }
        }
        Debug.Assert(this._contents.Reference == null);
        this.Elements["/Contents"] = (PdfItem) this._contents;
      }
      return this._contents;
    }
  }

  public bool HasAnnotations
  {
    get
    {
      if (this._annotations == null)
      {
        this._annotations = (PdfAnnotations) this.Elements.GetValue("/Annots");
        this._annotations.Page = this;
      }
      return this._annotations != null;
    }
  }

  public PdfAnnotations Annotations
  {
    get
    {
      if (this._annotations == null)
      {
        this._annotations = (PdfAnnotations) this.Elements.GetValue("/Annots", VCF.Create);
        this._annotations.Page = this;
      }
      return this._annotations;
    }
  }

  public PdfLinkAnnotation AddDocumentLink(PdfRectangle rect, int destinationPage)
  {
    PdfLinkAnnotation documentLink = PdfLinkAnnotation.CreateDocumentLink(rect, destinationPage);
    this.Annotations.Add((PdfAnnotation) documentLink);
    return documentLink;
  }

  public PdfLinkAnnotation AddWebLink(PdfRectangle rect, string url)
  {
    PdfLinkAnnotation webLink = PdfLinkAnnotation.CreateWebLink(rect, url);
    this.Annotations.Add((PdfAnnotation) webLink);
    return webLink;
  }

  public PdfLinkAnnotation AddFileLink(PdfRectangle rect, string fileName)
  {
    PdfLinkAnnotation fileLink = PdfLinkAnnotation.CreateFileLink(rect, fileName);
    this.Annotations.Add((PdfAnnotation) fileLink);
    return fileLink;
  }

  public PdfCustomValues CustomValues
  {
    get
    {
      if (this._customValues == null)
        this._customValues = PdfCustomValues.Get(this.Elements);
      return this._customValues;
    }
    set
    {
      if (value != null)
        throw new ArgumentException("Only null is allowed to clear all custom values.");
      PdfCustomValues.Remove(this.Elements);
      this._customValues = (PdfCustomValues) null;
    }
  }

  public PdfResources Resources
  {
    get
    {
      if (this._resources == null)
        this._resources = (PdfResources) this.Elements.GetValue("/Resources", VCF.Create);
      return this._resources;
    }
  }

  PdfResources IContentStream.Resources => this.Resources;

  internal string GetFontName(XFont font, out PdfFont pdfFont)
  {
    pdfFont = this._document.FontTable.GetFont(font);
    Debug.Assert(pdfFont != null);
    return this.Resources.AddFont(pdfFont);
  }

  string IContentStream.GetFontName(XFont font, out PdfFont pdfFont)
  {
    return this.GetFontName(font, out pdfFont);
  }

  internal string TryGetFontName(string idName, out PdfFont pdfFont)
  {
    pdfFont = this._document.FontTable.TryGetFont(idName);
    string fontName = (string) null;
    if (pdfFont != null)
      fontName = this.Resources.AddFont(pdfFont);
    return fontName;
  }

  internal string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
  {
    pdfFont = this._document.FontTable.GetFont(idName, fontData);
    Debug.Assert(pdfFont != null);
    return this.Resources.AddFont(pdfFont);
  }

  string IContentStream.GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
  {
    return this.GetFontName(idName, fontData, out pdfFont);
  }

  internal string GetImageName(XImage image)
  {
    PdfImage image1 = this._document.ImageTable.GetImage(image);
    Debug.Assert(image1 != null);
    return this.Resources.AddImage(image1);
  }

  string IContentStream.GetImageName(XImage image) => this.GetImageName(image);

  internal string GetFormName(XForm form)
  {
    PdfFormXObject form1 = this._document.FormTable.GetForm(form);
    Debug.Assert(form1 != null);
    return this.Resources.AddForm(form1);
  }

  string IContentStream.GetFormName(XForm form) => this.GetFormName(form);

  internal override void WriteObject(PdfWriter writer)
  {
    PdfRectangle mediaBox = this.MediaBox;
    if (this._orientation == PageOrientation.Landscape)
      this.MediaBox = new PdfRectangle(mediaBox.X1, mediaBox.Y1, mediaBox.Y2, mediaBox.X2);
    this.TransparencyUsed = true;
    if ((!this.TransparencyUsed || this.Elements.ContainsKey("/Group") ? 0 : (this._document.Options.ColorMode != 0 ? 1 : 0)) != 0)
    {
      PdfDictionary pdfDictionary = new PdfDictionary();
      this._elements["/Group"] = (PdfItem) pdfDictionary;
      if (this._document.Options.ColorMode != PdfColorMode.Cmyk)
        pdfDictionary.Elements.SetName("/CS", "/DeviceRGB");
      else
        pdfDictionary.Elements.SetName("/CS", "/DeviceCMYK");
      pdfDictionary.Elements.SetName("/S", "/Transparency");
    }
    base.WriteObject(writer);
    if (this._orientation != PageOrientation.Landscape)
      return;
    this.MediaBox = mediaBox;
  }

  internal static void InheritValues(PdfDictionary page, PdfPage.InheritedValues values)
  {
    if (values.Resources != null)
    {
      PdfItem element = page.Elements["/Resources"];
      PdfDictionary pdfDictionary1;
      if (element is PdfReference)
      {
        pdfDictionary1 = (PdfDictionary) ((PdfReference) element).Value.Clone();
        pdfDictionary1.Document = page.Owner;
      }
      else
        pdfDictionary1 = (PdfDictionary) element;
      if (pdfDictionary1 == null)
      {
        PdfDictionary pdfDictionary2 = values.Resources.Clone();
        pdfDictionary2.Document = page.Owner;
        page.Elements.Add("/Resources", (PdfItem) pdfDictionary2);
      }
      else
      {
        foreach (PdfName keyName in values.Resources.Elements.KeyNames)
        {
          if (!pdfDictionary1.Elements.ContainsKey(keyName.Value))
          {
            PdfItem pdfItem = values.Resources.Elements[keyName];
            if (pdfItem is PdfObject)
              pdfItem = pdfItem.Clone();
            pdfDictionary1.Elements.Add(keyName.ToString(), pdfItem);
          }
        }
      }
    }
    if ((!(values.MediaBox != (PdfRectangle) null) ? 0 : (page.Elements["/MediaBox"] == null ? 1 : 0)) != 0)
      page.Elements["/MediaBox"] = (PdfItem) values.MediaBox;
    if ((!(values.CropBox != (PdfRectangle) null) ? 0 : (page.Elements["/CropBox"] == null ? 1 : 0)) != 0)
      page.Elements["/CropBox"] = (PdfItem) values.CropBox;
    if ((values.Rotate == null ? 0 : (page.Elements["/Rotate"] == null ? 1 : 0)) == 0)
      return;
    page.Elements["/Rotate"] = (PdfItem) values.Rotate;
  }

  internal static void InheritValues(PdfDictionary page, ref PdfPage.InheritedValues values)
  {
    PdfItem element1 = page.Elements["/Resources"];
    if (element1 != null)
      values.Resources = !(element1 is PdfReference pdfReference) ? (PdfDictionary) element1 : (PdfDictionary) pdfReference.Value;
    PdfItem element2 = page.Elements["/MediaBox"];
    if (element2 != null)
      values.MediaBox = new PdfRectangle(element2);
    PdfItem element3 = page.Elements["/CropBox"];
    if (element3 != null)
      values.CropBox = new PdfRectangle(element3);
    PdfItem element4 = page.Elements["/Rotate"];
    if (element4 == null)
      return;
    if (element4 is PdfReference)
      element4 = (PdfItem) ((PdfReference) element4).Value;
    values.Rotate = (PdfInteger) element4;
  }

  internal override void PrepareForSave()
  {
    if (!this._trimMargins.AreSet)
      return;
    double point1 = this._trimMargins.Left.Point;
    XUnit xunit1 = this.Width;
    double point2 = xunit1.Point;
    double num1 = point1 + point2;
    xunit1 = this._trimMargins.Right;
    double point3 = xunit1.Point;
    double x2 = num1 + point3;
    xunit1 = this._trimMargins.Top;
    double point4 = xunit1.Point;
    XUnit xunit2 = this.Height;
    double point5 = xunit2.Point;
    double num2 = point4 + point5;
    xunit2 = this._trimMargins.Bottom;
    double point6 = xunit2.Point;
    double y2 = num2 + point6;
    this.MediaBox = new PdfRectangle(0.0, 0.0, x2, y2);
    this.CropBox = new PdfRectangle(0.0, 0.0, x2, y2);
    this.BleedBox = new PdfRectangle(0.0, 0.0, x2, y2);
    PdfRectangle pdfRectangle = new PdfRectangle(this._trimMargins.Left.Point, this._trimMargins.Top.Point, x2 - this._trimMargins.Right.Point, y2 - this._trimMargins.Bottom.Point);
    this.TrimBox = pdfRectangle;
    this.ArtBox = pdfRectangle.Clone();
  }

  internal override DictionaryMeta Meta => PdfPage.Keys.Meta;

  internal sealed class Keys : PdfPage.InheritablePageKeys
  {
    [KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Page")]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Dictionary | KeyType.Required | KeyType.MustBeIndirect)]
    public const string Parent = "/Parent";
    [KeyInfo(KeyType.Date)]
    public const string LastModified = "/LastModified";
    [KeyInfo("1.3", KeyType.Rectangle | KeyType.Optional)]
    public const string BleedBox = "/BleedBox";
    [KeyInfo("1.3", KeyType.Rectangle | KeyType.Optional)]
    public const string TrimBox = "/TrimBox";
    [KeyInfo("1.3", KeyType.Rectangle | KeyType.Optional)]
    public const string ArtBox = "/ArtBox";
    [KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional)]
    public const string BoxColorInfo = "/BoxColorInfo";
    [KeyInfo(KeyType.Stream | KeyType.Optional)]
    public const string Contents = "/Contents";
    [KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional)]
    public const string Group = "/Group";
    [KeyInfo(KeyType.Stream | KeyType.Optional)]
    public const string Thumb = "/Thumb";
    [KeyInfo("1.1", KeyType.Array | KeyType.Optional)]
    public const string B = "/B";
    [KeyInfo("1.1", KeyType.Real | KeyType.Optional)]
    public const string Dur = "/Dur";
    [KeyInfo("1.1", KeyType.Dictionary | KeyType.Optional)]
    public const string Trans = "/Trans";
    [KeyInfo(KeyType.Array | KeyType.Optional, typeof (PdfAnnotations))]
    public const string Annots = "/Annots";
    [KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional)]
    public const string AA = "/AA";
    [KeyInfo("1.4", KeyType.Stream | KeyType.Optional)]
    public const string Metadata = "/Metadata";
    [KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional)]
    public const string PieceInfo = "/PieceInfo";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string StructParents = "/StructParents";
    [KeyInfo("1.3", KeyType.String | KeyType.Optional)]
    public const string ID = "/ID";
    [KeyInfo("1.3", KeyType.Real | KeyType.Optional)]
    public const string PZ = "/PZ";
    [KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional)]
    public const string SeparationInfo = "/SeparationInfo";
    [KeyInfo("1.5", KeyType.Name | KeyType.Optional)]
    public const string Tabs = "/Tabs";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string TemplateInstantiated = "/TemplateInstantiated";
    [KeyInfo("1.5", KeyType.Dictionary | KeyType.Optional)]
    public const string PresSteps = "/PresSteps";
    [KeyInfo("1.6", KeyType.Real | KeyType.Optional)]
    public const string UserUnit = "/UserUnit";
    [KeyInfo("1.6", KeyType.Dictionary | KeyType.Optional)]
    public const string VP = "/VP";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfPage.Keys._meta ?? (PdfPage.Keys._meta = KeysBase.CreateMeta(typeof (PdfPage.Keys)));
      }
    }
  }

  internal class InheritablePageKeys : KeysBase
  {
    [KeyInfo(KeyType.Dictionary | KeyType.Required | KeyType.Inheritable, typeof (PdfResources))]
    public const string Resources = "/Resources";
    [KeyInfo(KeyType.Rectangle | KeyType.Required | KeyType.Inheritable)]
    public const string MediaBox = "/MediaBox";
    [KeyInfo(KeyType.Rectangle | KeyType.Optional | KeyType.Inheritable)]
    public const string CropBox = "/CropBox";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string Rotate = "/Rotate";
  }

  internal struct InheritedValues
  {
    public PdfDictionary Resources;
    public PdfRectangle MediaBox;
    public PdfRectangle CropBox;
    public PdfInteger Rotate;
  }
}
