// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfCatalog
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf.IO;
using System;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfCatalog : PdfDictionary
{
  private string _version = "1.3";
  private PdfPages _pages;
  private PdfViewerPreferences _viewerPreferences;
  private PdfOutline _outline;
  private PdfAcroForm _acroForm;

  public PdfCatalog(PdfDocument document)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Catalog");
    this._version = "1.4";
  }

  internal PdfCatalog(PdfDictionary dictionary)
    : base(dictionary)
  {
  }

  public string Version
  {
    get => this._version;
    set
    {
      switch (value)
      {
        case "1.0":
        case "1.1":
        case "1.2":
          throw new InvalidOperationException("Unsupported PDF version.");
        case "1.3":
        case "1.4":
          this._version = value;
          break;
        case "1.5":
        case "1.6":
          throw new InvalidOperationException("Unsupported PDF version.");
        default:
          throw new ArgumentException("Invalid version.");
      }
    }
  }

  public PdfPages Pages
  {
    get
    {
      if (this._pages == null)
      {
        this._pages = (PdfPages) this.Elements.GetValue("/Pages", VCF.CreateIndirect);
        if (this.Owner.IsImported)
          this._pages.FlattenPageTree();
      }
      return this._pages;
    }
  }

  internal PdfPageLayout PageLayout
  {
    get
    {
      return (PdfPageLayout) this.Elements.GetEnumFromName("/PageLayout", (object) PdfPageLayout.SinglePage);
    }
    set => this.Elements.SetEnumAsName("/PageLayout", (object) value);
  }

  internal PdfPageMode PageMode
  {
    get => (PdfPageMode) this.Elements.GetEnumFromName("/PageMode", (object) PdfPageMode.UseNone);
    set => this.Elements.SetEnumAsName("/PageMode", (object) value);
  }

  internal PdfViewerPreferences ViewerPreferences
  {
    get
    {
      if (this._viewerPreferences == null)
        this._viewerPreferences = (PdfViewerPreferences) this.Elements.GetValue("/ViewerPreferences", VCF.CreateIndirect);
      return this._viewerPreferences;
    }
  }

  internal PdfOutlineCollection Outlines
  {
    get
    {
      if (this._outline == null)
        this._outline = (PdfOutline) this.Elements.GetValue("/Outlines", VCF.CreateIndirect);
      return this._outline.Outlines;
    }
  }

  public PdfAcroForm AcroForm
  {
    get
    {
      if (this._acroForm == null)
        this._acroForm = (PdfAcroForm) this.Elements.GetValue("/AcroForm");
      return this._acroForm;
    }
  }

  public string Language
  {
    get => this.Elements.GetString("/Lang");
    set
    {
      if (value == null)
        this.Elements.Remove("/Lang");
      else
        this.Elements.SetString("/Lang", value);
    }
  }

  internal override void PrepareForSave()
  {
    if (this._pages != null)
      this._pages.PrepareForSave();
    if ((this._outline == null ? 0 : (this._outline.Outlines.Count > 0 ? 1 : 0)) == 0)
      return;
    if (this.Elements["/PageMode"] == null)
      this.PageMode = PdfPageMode.UseOutlines;
    this._outline.PrepareForSave();
  }

  internal override void WriteObject(PdfWriter writer)
  {
    if ((this._outline == null ? 0 : (this._outline.Outlines.Count > 0 ? 1 : 0)) != 0 && this.Elements["/PageMode"] == null)
      this.PageMode = PdfPageMode.UseOutlines;
    base.WriteObject(writer);
  }

  internal override DictionaryMeta Meta => PdfCatalog.Keys.Meta;

  internal sealed class Keys : KeysBase
  {
    [KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Catalog")]
    public const string Type = "/Type";
    [KeyInfo("1.4", KeyType.Name | KeyType.Optional)]
    public const string Version = "/Version";
    [KeyInfo(KeyType.Dictionary | KeyType.Required | KeyType.MustBeIndirect, typeof (PdfPages))]
    public const string Pages = "/Pages";
    [KeyInfo("1.3", KeyType.NumberTree | KeyType.Optional)]
    public const string PageLabels = "/PageLabels";
    [KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional)]
    public const string Names = "/Names";
    [KeyInfo("1.1", KeyType.Dictionary | KeyType.Optional)]
    public const string Dests = "/Dests";
    [KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional, typeof (PdfViewerPreferences))]
    public const string ViewerPreferences = "/ViewerPreferences";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string PageLayout = "/PageLayout";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string PageMode = "/PageMode";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof (PdfOutline))]
    public const string Outlines = "/Outlines";
    [KeyInfo("1.1", KeyType.Array | KeyType.Optional)]
    public const string Threads = "/Threads";
    [KeyInfo("1.1", KeyType.ArrayOrDictionary | KeyType.Optional)]
    public const string OpenAction = "/OpenAction";
    [KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional)]
    public const string AA = "/AA";
    [KeyInfo("1.1", KeyType.Dictionary | KeyType.Optional)]
    public const string URI = "/URI";
    [KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional, typeof (PdfAcroForm))]
    public const string AcroForm = "/AcroForm";
    [KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional | KeyType.MustBeIndirect)]
    public const string Metadata = "/Metadata";
    [KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional)]
    public const string StructTreeRoot = "/StructTreeRoot";
    [KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional)]
    public const string MarkInfo = "/MarkInfo";
    [KeyInfo("1.4", KeyType.String | KeyType.Optional)]
    public const string Lang = "/Lang";
    [KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional)]
    public const string SpiderInfo = "/SpiderInfo";
    [KeyInfo("1.4", KeyType.Array | KeyType.Optional)]
    public const string OutputIntents = "/OutputIntents";
    [KeyInfo("1.4", KeyType.Dictionary | KeyType.Optional)]
    public const string PieceInfo = "/PieceInfo";
    [KeyInfo("1.5", KeyType.Dictionary | KeyType.Optional)]
    public const string OCProperties = "/OCProperties";
    [KeyInfo("1.5", KeyType.Dictionary | KeyType.Optional)]
    public const string Perms = "/Perms";
    [KeyInfo("1.5", KeyType.Dictionary | KeyType.Optional)]
    public const string Legal = "/Legal";
    [KeyInfo("1.7", KeyType.Array | KeyType.Optional)]
    public const string Requirements = "/Requirements";
    [KeyInfo("1.7", KeyType.Dictionary | KeyType.Optional)]
    public const string Collection = "/Collection";
    [KeyInfo("1.7", KeyType.Boolean | KeyType.Optional)]
    public const string NeedsRendering = "/NeedsRendering";
    private static DictionaryMeta _meta;

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfCatalog.Keys._meta ?? (PdfCatalog.Keys._meta = KeysBase.CreateMeta(typeof (PdfCatalog.Keys)));
      }
    }
  }
}
