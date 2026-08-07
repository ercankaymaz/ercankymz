// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.FontResolverInfo
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;
using System.Globalization;

#nullable disable
namespace PdfSharp.Fonts;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
public class FontResolverInfo
{
  private const string KeyPrefix = "frik:";
  private string _key;
  private readonly string _faceName;
  private readonly bool _mustSimulateBold;
  private readonly bool _mustSimulateItalic;
  private readonly int _collectionNumber;

  public FontResolverInfo(string faceName)
    : this(faceName, false, false, 0)
  {
  }

  internal FontResolverInfo(
    string faceName,
    bool mustSimulateBold,
    bool mustSimulateItalic,
    int collectionNumber)
  {
    if (string.IsNullOrEmpty(faceName))
      throw new ArgumentNullException(nameof (faceName));
    if (collectionNumber != 0)
      throw new NotImplementedException("collectionNumber is not yet implemented and must be 0.");
    this._faceName = faceName;
    this._mustSimulateBold = mustSimulateBold;
    this._mustSimulateItalic = mustSimulateItalic;
    this._collectionNumber = collectionNumber;
  }

  public FontResolverInfo(string faceName, bool mustSimulateBold, bool mustSimulateItalic)
    : this(faceName, mustSimulateBold, mustSimulateItalic, 0)
  {
  }

  public FontResolverInfo(string faceName, XStyleSimulations styleSimulations)
    : this(faceName, (styleSimulations & XStyleSimulations.BoldSimulation) == XStyleSimulations.BoldSimulation, (styleSimulations & XStyleSimulations.ItalicSimulation) == XStyleSimulations.ItalicSimulation, 0)
  {
  }

  internal string Key
  {
    get
    {
      string key = this._key;
      if (key == null)
        key = this._key = $"frik:{this._faceName.ToLowerInvariant()}/{(this._mustSimulateBold ? "b+" : "b-")}{(this._mustSimulateItalic ? "i+" : "i-")}";
      return key;
    }
  }

  public string FaceName => this._faceName;

  public bool MustSimulateBold => this._mustSimulateBold;

  public bool MustSimulateItalic => this._mustSimulateItalic;

  public XStyleSimulations StyleSimulations
  {
    get
    {
      return (XStyleSimulations) ((this._mustSimulateBold ? 1 : 0) | (this._mustSimulateItalic ? 2 : 0));
    }
  }

  internal int CollectionNumber => this._collectionNumber;

  internal string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "FontResolverInfo: '{0}',{1}{2}", (object) this.FaceName, this.MustSimulateBold ? (object) " simulate Bold" : (object) "", this.MustSimulateItalic ? (object) " simulate Italic" : (object) "");
    }
  }
}
