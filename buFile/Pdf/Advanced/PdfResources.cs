// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfResources
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfResources : PdfDictionary
{
  private PdfResourceMap _fonts;
  private PdfResourceMap _xObjects;
  private PdfResourceMap _extGStates;
  private PdfResourceMap _colorSpaces;
  private PdfResourceMap _patterns;
  private PdfResourceMap _shadings;
  private PdfResourceMap _properties;
  private int _fontNumber;
  private int _imageNumber;
  private int _formNumber;
  private int _extGStateNumber;
  private int _patternNumber;
  private int _shadingNumber;
  private Dictionary<string, object> _importedResourceNames;
  private readonly Dictionary<PdfObject, string> _resources = new Dictionary<PdfObject, string>();

  public PdfResources(PdfDocument document)
    : base(document)
  {
    this.Elements["/ProcSet"] = (PdfItem) new PdfLiteral("[/PDF/Text/ImageB/ImageC/ImageI]");
  }

  internal PdfResources(PdfDictionary dict)
    : base(dict)
  {
  }

  public string AddFont(PdfFont font)
  {
    string nextFontName;
    if (!this._resources.TryGetValue((PdfObject) font, out nextFontName))
    {
      nextFontName = this.NextFontName;
      this._resources[(PdfObject) font] = nextFontName;
      if (font.Reference == null)
        this.Owner._irefTable.Add((PdfObject) font);
      this.Fonts.Elements[nextFontName] = (PdfItem) font.Reference;
    }
    return nextFontName;
  }

  public string AddImage(PdfImage image)
  {
    string nextImageName;
    if (!this._resources.TryGetValue((PdfObject) image, out nextImageName))
    {
      nextImageName = this.NextImageName;
      this._resources[(PdfObject) image] = nextImageName;
      if (image.Reference == null)
        this.Owner._irefTable.Add((PdfObject) image);
      this.XObjects.Elements[nextImageName] = (PdfItem) image.Reference;
    }
    return nextImageName;
  }

  public string AddForm(PdfFormXObject form)
  {
    string nextFormName;
    if (!this._resources.TryGetValue((PdfObject) form, out nextFormName))
    {
      nextFormName = this.NextFormName;
      this._resources[(PdfObject) form] = nextFormName;
      if (form.Reference == null)
        this.Owner._irefTable.Add((PdfObject) form);
      this.XObjects.Elements[nextFormName] = (PdfItem) form.Reference;
    }
    return nextFormName;
  }

  public string AddExtGState(PdfExtGState extGState)
  {
    string nextExtGstateName;
    if (!this._resources.TryGetValue((PdfObject) extGState, out nextExtGstateName))
    {
      nextExtGstateName = this.NextExtGStateName;
      this._resources[(PdfObject) extGState] = nextExtGstateName;
      if (extGState.Reference == null)
        this.Owner._irefTable.Add((PdfObject) extGState);
      this.ExtGStates.Elements[nextExtGstateName] = (PdfItem) extGState.Reference;
    }
    return nextExtGstateName;
  }

  public string AddPattern(PdfShadingPattern pattern)
  {
    string nextPatternName;
    if (!this._resources.TryGetValue((PdfObject) pattern, out nextPatternName))
    {
      nextPatternName = this.NextPatternName;
      this._resources[(PdfObject) pattern] = nextPatternName;
      if (pattern.Reference == null)
        this.Owner._irefTable.Add((PdfObject) pattern);
      this.Patterns.Elements[nextPatternName] = (PdfItem) pattern.Reference;
    }
    return nextPatternName;
  }

  public string AddPattern(PdfTilingPattern pattern)
  {
    string nextPatternName;
    if (!this._resources.TryGetValue((PdfObject) pattern, out nextPatternName))
    {
      nextPatternName = this.NextPatternName;
      this._resources[(PdfObject) pattern] = nextPatternName;
      if (pattern.Reference == null)
        this.Owner._irefTable.Add((PdfObject) pattern);
      this.Patterns.Elements[nextPatternName] = (PdfItem) pattern.Reference;
    }
    return nextPatternName;
  }

  public string AddShading(PdfShading shading)
  {
    string nextShadingName;
    if (!this._resources.TryGetValue((PdfObject) shading, out nextShadingName))
    {
      nextShadingName = this.NextShadingName;
      this._resources[(PdfObject) shading] = nextShadingName;
      if (shading.Reference == null)
        this.Owner._irefTable.Add((PdfObject) shading);
      this.Shadings.Elements[nextShadingName] = (PdfItem) shading.Reference;
    }
    return nextShadingName;
  }

  internal PdfResourceMap Fonts
  {
    get
    {
      return this._fonts ?? (this._fonts = (PdfResourceMap) this.Elements.GetValue("/Font", VCF.Create));
    }
  }

  internal PdfResourceMap XObjects
  {
    get
    {
      return this._xObjects ?? (this._xObjects = (PdfResourceMap) this.Elements.GetValue("/XObject", VCF.Create));
    }
  }

  internal PdfResourceMap ExtGStates
  {
    get
    {
      return this._extGStates ?? (this._extGStates = (PdfResourceMap) this.Elements.GetValue("/ExtGState", VCF.Create));
    }
  }

  internal PdfResourceMap ColorSpaces
  {
    get
    {
      return this._colorSpaces ?? (this._colorSpaces = (PdfResourceMap) this.Elements.GetValue("/ColorSpace", VCF.Create));
    }
  }

  internal PdfResourceMap Patterns
  {
    get
    {
      return this._patterns ?? (this._patterns = (PdfResourceMap) this.Elements.GetValue("/Pattern", VCF.Create));
    }
  }

  internal PdfResourceMap Shadings
  {
    get
    {
      return this._shadings ?? (this._shadings = (PdfResourceMap) this.Elements.GetValue("/Shading", VCF.Create));
    }
  }

  internal PdfResourceMap Properties
  {
    get
    {
      return this._properties ?? (this._properties = (PdfResourceMap) this.Elements.GetValue("/Properties", VCF.Create));
    }
  }

  private string NextFontName
  {
    get
    {
      string nextFontName;
      __Boxed<int> local;
      do
      {
        local = (ValueType) this._fontNumber++;
      }
      while (this.ExistsResourceNames(nextFontName = $"/F{local}"));
      return nextFontName;
    }
  }

  private string NextImageName
  {
    get
    {
      string nextImageName;
      __Boxed<int> local;
      do
      {
        local = (ValueType) this._imageNumber++;
      }
      while (this.ExistsResourceNames(nextImageName = $"/I{local}"));
      return nextImageName;
    }
  }

  private string NextFormName
  {
    get
    {
      string nextFormName;
      __Boxed<int> local;
      do
      {
        local = (ValueType) this._formNumber++;
      }
      while (this.ExistsResourceNames(nextFormName = $"/Fm{local}"));
      return nextFormName;
    }
  }

  private string NextExtGStateName
  {
    get
    {
      string nextExtGstateName;
      __Boxed<int> local;
      do
      {
        local = (ValueType) this._extGStateNumber++;
      }
      while (this.ExistsResourceNames(nextExtGstateName = $"/GS{local}"));
      return nextExtGstateName;
    }
  }

  private string NextPatternName
  {
    get
    {
      string nextPatternName;
      __Boxed<int> local;
      do
      {
        local = (ValueType) this._patternNumber++;
      }
      while (this.ExistsResourceNames(nextPatternName = $"/Pa{local}"));
      return nextPatternName;
    }
  }

  private string NextShadingName
  {
    get
    {
      string nextShadingName;
      __Boxed<int> local;
      do
      {
        local = (ValueType) this._shadingNumber++;
      }
      while (this.ExistsResourceNames(nextShadingName = $"/Sh{local}"));
      return nextShadingName;
    }
  }

  internal bool ExistsResourceNames(string name)
  {
    if (this._importedResourceNames == null)
    {
      this._importedResourceNames = new Dictionary<string, object>();
      if (this.Elements["/Font"] != null)
        this.Fonts.CollectResourceNames(this._importedResourceNames);
      if (this.Elements["/XObject"] != null)
        this.XObjects.CollectResourceNames(this._importedResourceNames);
      if (this.Elements["/ExtGState"] != null)
        this.ExtGStates.CollectResourceNames(this._importedResourceNames);
      if (this.Elements["/ColorSpace"] != null)
        this.ColorSpaces.CollectResourceNames(this._importedResourceNames);
      if (this.Elements["/Pattern"] != null)
        this.Patterns.CollectResourceNames(this._importedResourceNames);
      if (this.Elements["/Shading"] != null)
        this.Shadings.CollectResourceNames(this._importedResourceNames);
      if (this.Elements["/Properties"] != null)
        this.Properties.CollectResourceNames(this._importedResourceNames);
    }
    return this._importedResourceNames.ContainsKey(name);
  }

  internal override DictionaryMeta Meta => PdfResources.Keys.Meta;

  public sealed class Keys : KeysBase
  {
    [KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof (PdfResourceMap))]
    public const string ExtGState = "/ExtGState";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof (PdfResourceMap))]
    public const string ColorSpace = "/ColorSpace";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof (PdfResourceMap))]
    public const string Pattern = "/Pattern";
    [KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional, typeof (PdfResourceMap))]
    public const string Shading = "/Shading";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof (PdfResourceMap))]
    public const string XObject = "/XObject";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof (PdfResourceMap))]
    public const string Font = "/Font";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string ProcSet = "/ProcSet";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof (PdfResourceMap))]
    public const string Properties = "/Properties";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfResources.Keys._meta ?? (PdfResources.Keys._meta = KeysBase.CreateMeta(typeof (PdfResources.Keys)));
      }
    }
  }
}
