// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfViewerPreferences
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf;

public sealed class PdfViewerPreferences : PdfDictionary
{
  internal PdfViewerPreferences(PdfDocument document)
    : base(document)
  {
  }

  private PdfViewerPreferences(PdfDictionary dict)
    : base(dict)
  {
  }

  public bool HideToolbar
  {
    get => this.Elements.GetBoolean("/HideToolbar");
    set => this.Elements.SetBoolean("/HideToolbar", value);
  }

  public bool HideMenubar
  {
    get => this.Elements.GetBoolean("/HideMenubar");
    set => this.Elements.SetBoolean("/HideMenubar", value);
  }

  public bool HideWindowUI
  {
    get => this.Elements.GetBoolean("/HideWindowUI");
    set => this.Elements.SetBoolean("/HideWindowUI", value);
  }

  public bool FitWindow
  {
    get => this.Elements.GetBoolean("/FitWindow");
    set => this.Elements.SetBoolean("/FitWindow", value);
  }

  public bool CenterWindow
  {
    get => this.Elements.GetBoolean("/CenterWindow");
    set => this.Elements.SetBoolean("/CenterWindow", value);
  }

  public bool DisplayDocTitle
  {
    get => this.Elements.GetBoolean("/DisplayDocTitle");
    set => this.Elements.SetBoolean("/DisplayDocTitle", value);
  }

  public PdfReadingDirection? Direction
  {
    get
    {
      PdfReadingDirection? direction;
      switch (this.Elements.GetName("/Direction"))
      {
        case "L2R":
          direction = new PdfReadingDirection?(PdfReadingDirection.LeftToRight);
          break;
        case "R2L":
          direction = new PdfReadingDirection?(PdfReadingDirection.RightToLeft);
          break;
        default:
          direction = new PdfReadingDirection?();
          break;
      }
      return direction;
    }
    set
    {
      if (value.HasValue)
      {
        if (value.Value != PdfReadingDirection.RightToLeft)
          this.Elements.SetName("/Direction", "L2R");
        else
          this.Elements.SetName("/Direction", "R2L");
      }
      else
        this.Elements.Remove("/Direction");
    }
  }

  internal override DictionaryMeta Meta => PdfViewerPreferences.Keys.Meta;

  internal sealed class Keys : KeysBase
  {
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string HideToolbar = "/HideToolbar";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string HideMenubar = "/HideMenubar";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string HideWindowUI = "/HideWindowUI";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string FitWindow = "/FitWindow";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string CenterWindow = "/CenterWindow";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string DisplayDocTitle = "/DisplayDocTitle";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string NonFullScreenPageMode = "/NonFullScreenPageMode";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string Direction = "/Direction";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string ViewArea = "/ViewArea";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string ViewClip = "/ViewClip";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string PrintArea = "/PrintArea";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string PrintClip = "/PrintClip";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string PrintScaling = "/PrintScaling";
    private static DictionaryMeta _meta;

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfViewerPreferences.Keys._meta ?? (PdfViewerPreferences.Keys._meta = KeysBase.CreateMeta(typeof (PdfViewerPreferences.Keys)));
      }
    }
  }
}
