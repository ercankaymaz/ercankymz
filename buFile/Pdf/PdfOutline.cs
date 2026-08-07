// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfOutline
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf;

public sealed class PdfOutline : PdfDictionary
{
  private int _count;
  internal int OpenCount;
  private PdfOutline _parent;
  private PdfPage _destinationPage;
  private double? _left = new double?();
  private double? _top = new double?();
  private double _right = double.NaN;
  private double _bottom = double.NaN;
  private double? _zoom;
  private bool _opened;
  private PdfPageDestinationType _pageDestinationType = PdfPageDestinationType.Xyz;
  private XColor _textColor;
  private PdfOutlineCollection _outlines;

  public PdfOutline()
  {
  }

  internal PdfOutline(PdfDocument document)
    : base(document)
  {
  }

  public PdfOutline(PdfDictionary dict)
    : base(dict)
  {
    this.Initialize();
  }

  public PdfOutline(
    string title,
    PdfPage destinationPage,
    bool opened,
    PdfOutlineStyle style,
    XColor textColor)
  {
    this.Title = title;
    this.DestinationPage = destinationPage;
    this.Opened = opened;
    this.Style = style;
    this.TextColor = textColor;
  }

  public PdfOutline(string title, PdfPage destinationPage, bool opened, PdfOutlineStyle style)
  {
    this.Title = title;
    this.DestinationPage = destinationPage;
    this.Opened = opened;
    this.Style = style;
  }

  public PdfOutline(string title, PdfPage destinationPage, bool opened)
  {
    this.Title = title;
    this.DestinationPage = destinationPage;
    this.Opened = opened;
  }

  public PdfOutline(string title, PdfPage destinationPage)
  {
    this.Title = title;
    this.DestinationPage = destinationPage;
  }

  internal int Count
  {
    get => this._count;
    set => this._count = value;
  }

  internal int CountOpen()
  {
    int num = this._opened ? 1 : 0;
    if (this._outlines != null)
      num += this._outlines.CountOpen();
    return num;
  }

  public PdfOutline Parent
  {
    get => this._parent;
    internal set => this._parent = value;
  }

  public string Title
  {
    get => this.Elements.GetString("/Title");
    set
    {
      this.Elements.SetValue("/Title", (PdfItem) new PdfString(value, PdfStringEncoding.Unicode));
    }
  }

  public PdfPage DestinationPage
  {
    get => this._destinationPage;
    set => this._destinationPage = value;
  }

  public double? Left
  {
    get => this._left;
    set => this._left = value;
  }

  public double? Top
  {
    get => this._top;
    set => this._top = value;
  }

  public double Right
  {
    get => this._right;
    set => this._right = value;
  }

  public double Bottom
  {
    get => this._bottom;
    set => this._bottom = value;
  }

  public double? Zoom
  {
    get => this._zoom;
    set
    {
      if ((!value.HasValue ? 0 : (value.Value == 0.0 ? 1 : 0)) != 0)
        this._zoom = new double?();
      else
        this._zoom = value;
    }
  }

  public bool Opened
  {
    get => this._opened;
    set => this._opened = value;
  }

  public PdfOutlineStyle Style
  {
    get => (PdfOutlineStyle) this.Elements.GetInteger("/F");
    set => this.Elements.SetInteger("/F", (int) value);
  }

  public PdfPageDestinationType PageDestinationType
  {
    get => this._pageDestinationType;
    set => this._pageDestinationType = value;
  }

  public XColor TextColor
  {
    get => this._textColor;
    set => this._textColor = value;
  }

  public bool HasChildren => this._outlines != null && this._outlines.Count > 0;

  public PdfOutlineCollection Outlines
  {
    get => this._outlines ?? (this._outlines = new PdfOutlineCollection(this.Owner, this));
  }

  private void Initialize()
  {
    string str;
    if (this.Elements.TryGetString("/Title", out str))
      this.Title = str;
    PdfReference reference = this.Elements.GetReference("/Parent");
    if (reference != null && reference.Value is PdfOutline pdfOutline)
      this.Parent = pdfOutline;
    this.Count = this.Elements.GetInteger("/Count");
    PdfArray array = this.Elements.GetArray("/C");
    if ((array == null ? 0 : (array.Elements.Count == 3 ? 1 : 0)) != 0)
      this.TextColor = XColor.FromArgb((int) (array.Elements.GetReal(0) * (double) byte.MaxValue), (int) (array.Elements.GetReal(1) * (double) byte.MaxValue), (int) (array.Elements.GetReal(2) * (double) byte.MaxValue));
    PdfItem pdfItem1 = this.Elements.GetValue("/Dest");
    PdfItem pdfItem2 = this.Elements.GetValue("/A");
    Debug.Assert(pdfItem1 == null || pdfItem2 == null, "Either destination or goto action.");
    if (pdfItem1 != null)
    {
      if (pdfItem1 is PdfArray destination)
        this.SplitDestinationPage(destination);
      else
        Debug.Assert(false, "See what to do when this happened.");
    }
    else if (pdfItem2 != null)
    {
      if ((!(pdfItem2 is PdfDictionary pdfDictionary) ? 0 : (pdfDictionary.Elements.GetName("/S") == "/GoTo" ? 1 : 0)) != 0)
      {
        if (!(pdfDictionary.Elements["/D"] is PdfArray element))
          throw new Exception("Destination Array expected.");
        this.Elements.Remove("/A");
        this.Elements.Add("/Dest", (PdfItem) element);
        this.SplitDestinationPage(element);
      }
      else
        Debug.Assert(false, "See what to do when this happened.");
    }
    this.InitializeChildren();
  }

  private void SplitDestinationPage(PdfArray destination)
  {
    PdfDictionary dict = (PdfDictionary) ((PdfReference) destination.Elements[0]).Value;
    if (!(dict is PdfPage pdfPage))
      pdfPage = new PdfPage(dict);
    this.DestinationPage = pdfPage;
    PdfName element = destination.Elements[1] as PdfName;
    if (!(element != (string) null))
      return;
    this.PageDestinationType = (PdfPageDestinationType) Enum.Parse(typeof (PdfPageDestinationType), element.Value.Substring(1), true);
    switch (this.PageDestinationType)
    {
      case PdfPageDestinationType.Xyz:
        this.Left = destination.Elements.GetNullableReal(2);
        this.Top = destination.Elements.GetNullableReal(3);
        this.Zoom = destination.Elements.GetNullableReal(4);
        break;
      case PdfPageDestinationType.Fit:
        break;
      case PdfPageDestinationType.FitH:
        this.Top = destination.Elements.GetNullableReal(2);
        break;
      case PdfPageDestinationType.FitV:
        this.Left = destination.Elements.GetNullableReal(2);
        break;
      case PdfPageDestinationType.FitR:
        this.Left = new double?(destination.Elements.GetReal(2));
        this.Bottom = destination.Elements.GetReal(3);
        this.Right = destination.Elements.GetReal(4);
        this.Top = new double?(destination.Elements.GetReal(5));
        break;
      case PdfPageDestinationType.FitB:
        break;
      case PdfPageDestinationType.FitBH:
        this.Top = new double?(destination.Elements.GetReal(2));
        break;
      case PdfPageDestinationType.FitBV:
        this.Left = new double?(destination.Elements.GetReal(2));
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }

  private void InitializeChildren()
  {
    PdfReference reference = this.Elements.GetReference("/First");
    this.Elements.GetReference("/Last");
    PdfOutline outline;
    for (PdfReference pdfReference = reference; pdfReference != null; pdfReference = outline.Elements.GetReference("/Next"))
    {
      outline = new PdfOutline((PdfDictionary) pdfReference.Value);
      this.Outlines.Add(outline);
    }
  }

  internal override void PrepareForSave()
  {
    bool hasChildren = this.HasChildren;
    if (!(this._parent != null | hasChildren))
      return;
    if (this._parent == null)
    {
      Debug.Assert(this._outlines != null && this._outlines.Count > 0 && this._outlines[0] != null);
      this.Elements["/First"] = (PdfItem) this._outlines[0].Reference;
      this.Elements["/Last"] = (PdfItem) this._outlines[this._outlines.Count - 1].Reference;
      if (this.OpenCount > 0)
        this.Elements["/Count"] = (PdfItem) new PdfInteger(this.OpenCount);
    }
    else
    {
      this.Elements["/Parent"] = (PdfItem) this._parent.Reference;
      int count = this._parent._outlines.Count;
      int num = this._parent._outlines.IndexOf(this);
      Debug.Assert(num != -1);
      if (this.DestinationPage != null)
        this.Elements["/Dest"] = (PdfItem) this.CreateDestArray();
      if (num > 0)
        this.Elements["/Prev"] = (PdfItem) this._parent._outlines[num - 1].Reference;
      if (num < count - 1)
        this.Elements["/Next"] = (PdfItem) this._parent._outlines[num + 1].Reference;
      if (hasChildren)
      {
        this.Elements["/First"] = (PdfItem) this._outlines[0].Reference;
        this.Elements["/Last"] = (PdfItem) this._outlines[this._outlines.Count - 1].Reference;
      }
      if (this.OpenCount > 0)
        this.Elements["/Count"] = (PdfItem) new PdfInteger((this._opened ? 1 : -1) * this.OpenCount);
      if ((!(this._textColor != XColor.Empty) ? 0 : (this.Owner.HasVersion("1.4") ? 1 : 0)) != 0)
        this.Elements["/C"] = (PdfItem) new PdfLiteral("[{0}]", new object[1]
        {
          (object) PdfEncoders.ToString(this._textColor, PdfColorMode.Rgb)
        });
    }
    if (!hasChildren)
      return;
    foreach (PdfObject outline in this._outlines)
      outline.PrepareForSave();
  }

  private PdfArray CreateDestArray()
  {
    PdfArray destArray;
    switch (this.PageDestinationType)
    {
      case PdfPageDestinationType.Xyz:
        destArray = new PdfArray(this.Owner, new PdfItem[2]
        {
          (PdfItem) this.DestinationPage.Reference,
          (PdfItem) new PdfLiteral($"/XYZ {this.Fd(this.Left)} {this.Fd(this.Top)} {this.Fd(this.Zoom)}")
        });
        break;
      case PdfPageDestinationType.Fit:
        destArray = new PdfArray(this.Owner, new PdfItem[2]
        {
          (PdfItem) this.DestinationPage.Reference,
          (PdfItem) new PdfLiteral("/Fit")
        });
        break;
      case PdfPageDestinationType.FitH:
        destArray = new PdfArray(this.Owner, new PdfItem[2]
        {
          (PdfItem) this.DestinationPage.Reference,
          (PdfItem) new PdfLiteral($"/FitH {this.Fd(this.Top)}")
        });
        break;
      case PdfPageDestinationType.FitV:
        destArray = new PdfArray(this.Owner, new PdfItem[2]
        {
          (PdfItem) this.DestinationPage.Reference,
          (PdfItem) new PdfLiteral($"/FitV {this.Fd(this.Left)}")
        });
        break;
      case PdfPageDestinationType.FitR:
        destArray = new PdfArray(this.Owner, new PdfItem[2]
        {
          (PdfItem) this.DestinationPage.Reference,
          (PdfItem) new PdfLiteral($"/FitR {this.Fd(this.Left)} {this.Fd(this.Bottom)} {this.Fd(this.Right)} {this.Fd(this.Top)}")
        });
        break;
      case PdfPageDestinationType.FitB:
        destArray = new PdfArray(this.Owner, new PdfItem[2]
        {
          (PdfItem) this.DestinationPage.Reference,
          (PdfItem) new PdfLiteral("/FitB")
        });
        break;
      case PdfPageDestinationType.FitBH:
        destArray = new PdfArray(this.Owner, new PdfItem[2]
        {
          (PdfItem) this.DestinationPage.Reference,
          (PdfItem) new PdfLiteral($"/FitBH {this.Fd(this.Top)}")
        });
        break;
      case PdfPageDestinationType.FitBV:
        destArray = new PdfArray(this.Owner, new PdfItem[2]
        {
          (PdfItem) this.DestinationPage.Reference,
          (PdfItem) new PdfLiteral($"/FitBV {this.Fd(this.Left)}")
        });
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
    return destArray;
  }

  private string Fd(double value)
  {
    return !double.IsNaN(value) ? value.ToString("#.##", (IFormatProvider) CultureInfo.InvariantCulture) : throw new InvalidOperationException("Value is not a valid Double.");
  }

  private string Fd(double? value)
  {
    return value.HasValue ? value.Value.ToString("#.##", (IFormatProvider) CultureInfo.InvariantCulture) : "null";
  }

  internal override void WriteObject(PdfWriter writer)
  {
    writer.WriteRaw($"% Title = {this.FilterUnicode(this.Title)}\n");
    if (!(this._parent != null | this.HasChildren))
      return;
    base.WriteObject(writer);
  }

  private string FilterUnicode(string text)
  {
    StringBuilder stringBuilder = new StringBuilder();
    foreach (char ch in text)
      stringBuilder.Append(ch < 'Ā' ? (ch == '\r' || ch == '\n' ? ' ' : ch) : '?');
    return stringBuilder.ToString();
  }

  internal override DictionaryMeta Meta => PdfOutline.Keys.Meta;

  internal sealed class Keys : KeysBase
  {
    [KeyInfo(KeyType.Name | KeyType.Optional, FixedValue = "Outlines")]
    public const string Type = "/Type";
    [KeyInfo(KeyType.String | KeyType.Required)]
    public const string Title = "/Title";
    [KeyInfo(KeyType.Dictionary | KeyType.Required)]
    public const string Parent = "/Parent";
    [KeyInfo(KeyType.Dictionary | KeyType.Required)]
    public const string Prev = "/Prev";
    [KeyInfo(KeyType.Dictionary | KeyType.Required)]
    public const string Next = "/Next";
    [KeyInfo(KeyType.Dictionary | KeyType.Required)]
    public const string First = "/First";
    [KeyInfo(KeyType.Dictionary | KeyType.Required)]
    public const string Last = "/Last";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string Count = "/Count";
    [KeyInfo(KeyType.ArrayOrNameOrString | KeyType.Optional)]
    public const string Dest = "/Dest";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional)]
    public const string A = "/A";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional)]
    public const string SE = "/SE";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string C = "/C";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string F = "/F";
    private static DictionaryMeta _meta;

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfOutline.Keys._meta ?? (PdfOutline.Keys._meta = KeysBase.CreateMeta(typeof (PdfOutline.Keys)));
      }
    }
  }
}
