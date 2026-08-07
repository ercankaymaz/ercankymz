// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfExtGState
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Globalization;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfExtGState : PdfDictionary
{
  private double _strokeAlpha;
  private double _nonStrokeAlpha;
  private bool _strokeOverprint;
  private bool _nonStrokeOverprint;
  private string _key;

  public PdfExtGState(PdfDocument document)
    : base(document)
  {
    this.Elements.SetName("/Type", "/ExtGState");
  }

  internal void SetDefault1()
  {
    this.Elements.SetBoolean("/AIS", false);
    if (this.Elements.ContainsKey("/BM"))
      this.Elements.SetName("/BM", "/Normal");
    this.StrokeAlpha = 1.0;
    this.NonStrokeAlpha = 1.0;
    this.Elements.SetBoolean("/op", false);
    this.Elements.SetBoolean("/OP", false);
    this.Elements.SetBoolean("/SA", true);
    this.Elements.SetName("/SMask", "/None");
  }

  internal void SetDefault2()
  {
    this.Elements.SetBoolean("/AIS", false);
    this.Elements.SetName("/BM", "/Normal");
    this.StrokeAlpha = 1.0;
    this.NonStrokeAlpha = 1.0;
    this.Elements.SetBoolean("/op", true);
    this.Elements.SetBoolean("/OP", true);
    this.Elements.SetInteger("/OPM", 1);
    this.Elements.SetBoolean("/SA", true);
    this.Elements.SetName("/SMask", "/None");
  }

  public double StrokeAlpha
  {
    set
    {
      this._strokeAlpha = value;
      this.Elements.SetReal("/CA", value);
      this.UpdateKey();
    }
  }

  public double NonStrokeAlpha
  {
    set
    {
      this._nonStrokeAlpha = value;
      this.Elements.SetReal("/ca", value);
      this.UpdateKey();
    }
  }

  public bool StrokeOverprint
  {
    set
    {
      this._strokeOverprint = value;
      this.Elements.SetBoolean("/OP", value);
      this.UpdateKey();
    }
  }

  public bool NonStrokeOverprint
  {
    set
    {
      this._nonStrokeOverprint = value;
      this.Elements.SetBoolean("/op", value);
      this.UpdateKey();
    }
  }

  public PdfSoftMask SoftMask
  {
    set => this.Elements.SetReference("/SMask", (PdfObject) value);
  }

  internal string Key => this._key;

  private void UpdateKey()
  {
    int num = (int) (1000.0 * this._strokeAlpha);
    string str1 = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    num = (int) (1000.0 * this._nonStrokeAlpha);
    string str2 = num.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    string str3 = this._strokeOverprint ? "S" : "s";
    string str4 = this._nonStrokeOverprint ? "N" : "n";
    this._key = str1 + str2 + str3 + str4;
  }

  internal static string MakeKey(double alpha, bool overPaint)
  {
    return ((int) (1000.0 * alpha)).ToString((IFormatProvider) CultureInfo.InvariantCulture) + (overPaint ? "O" : "0");
  }

  internal override DictionaryMeta Meta => PdfExtGState.Keys.Meta;

  internal sealed class Keys : KeysBase
  {
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string LW = "/LW";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string LC = "/LC";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string LJ = "/LJ";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string ML = "/ML";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string D = "/D";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string RI = "/RI";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string OP = "/OP";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string op = "/op";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string OPM = "/OPM";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Font = "/Font";
    [KeyInfo(KeyType.Function | KeyType.Optional)]
    public const string BG = "/BG";
    [KeyInfo(KeyType.FunctionOrName | KeyType.Optional)]
    public const string BG2 = "/BG2";
    [KeyInfo(KeyType.Function | KeyType.Optional)]
    public const string UCR = "/UCR";
    [KeyInfo(KeyType.FunctionOrName | KeyType.Optional)]
    public const string UCR2 = "/UCR2";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string SA = "/SA";
    [KeyInfo(KeyType.NameOrArray | KeyType.Optional)]
    public const string BM = "/BM";
    [KeyInfo(KeyType.NameOrDictionary | KeyType.Optional)]
    public const string SMask = "/SMask";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string CA = "/CA";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string ca = "/ca";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string AIS = "/AIS";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string TK = "/TK";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfExtGState.Keys._meta ?? (PdfExtGState.Keys._meta = KeysBase.CreateMeta(typeof (PdfExtGState.Keys)));
      }
    }
  }
}
