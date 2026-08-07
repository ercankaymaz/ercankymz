// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Annotations.PdfAnnotation
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;

#nullable disable
namespace PdfSharp.Pdf.Annotations;

public abstract class PdfAnnotation : PdfDictionary
{
  private PdfAnnotations _parent;

  protected PdfAnnotation() => this.Initialize();

  protected PdfAnnotation(PdfDocument document)
    : base(document)
  {
    this.Initialize();
  }

  internal PdfAnnotation(PdfDictionary dict)
    : base(dict)
  {
  }

  private void Initialize()
  {
    this.Elements.SetName("/Type", "/Annot");
    this.Elements.SetString("/NM", Guid.NewGuid().ToString("D"));
    this.Elements.SetDateTime("/M", DateTime.Now);
  }

  [Obsolete("Use 'Parent.Remove(this)'")]
  public void Delete() => this.Parent.Remove(this);

  public PdfAnnotationFlags Flags
  {
    get => (PdfAnnotationFlags) this.Elements.GetInteger("/F");
    set
    {
      this.Elements.SetInteger("/F", (int) value);
      this.Elements.SetDateTime("/M", DateTime.Now);
    }
  }

  public PdfAnnotations Parent
  {
    get => this._parent;
    set => this._parent = value;
  }

  public PdfRectangle Rectangle
  {
    get => this.Elements.GetRectangle("/Rect", true);
    set
    {
      this.Elements.SetRectangle("/Rect", value);
      this.Elements.SetDateTime("/M", DateTime.Now);
    }
  }

  public string Title
  {
    get => this.Elements.GetString("/T", true);
    set
    {
      this.Elements.SetString("/T", value);
      this.Elements.SetDateTime("/M", DateTime.Now);
    }
  }

  public string Subject
  {
    get => this.Elements.GetString("/Subj", true);
    set
    {
      this.Elements.SetString("/Subj", value);
      this.Elements.SetDateTime("/M", DateTime.Now);
    }
  }

  public string Contents
  {
    get => this.Elements.GetString("/Contents", true);
    set
    {
      this.Elements.SetString("/Contents", value);
      this.Elements.SetDateTime("/M", DateTime.Now);
    }
  }

  public XColor Color
  {
    get
    {
      return !(this.Elements["/C"] is PdfArray element) || element.Elements.Count != 3 ? XColors.Black : XColor.FromArgb((int) (element.Elements.GetReal(0) * (double) byte.MaxValue), (int) (element.Elements.GetReal(1) * (double) byte.MaxValue), (int) (element.Elements.GetReal(2) * (double) byte.MaxValue));
    }
    set
    {
      this.Elements["/C"] = (PdfItem) new PdfArray(this.Owner, (PdfItem[]) new PdfReal[3]
      {
        new PdfReal((double) value.R / (double) byte.MaxValue),
        new PdfReal((double) value.G / (double) byte.MaxValue),
        new PdfReal((double) value.B / (double) byte.MaxValue)
      });
      this.Elements.SetDateTime("/M", DateTime.Now);
    }
  }

  public double Opacity
  {
    get => this.Elements.ContainsKey("/CA") ? this.Elements.GetReal("/CA", true) : 1.0;
    set
    {
      if ((value < 0.0 ? 1 : (value > 1.0 ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (value), (object) value, "Opacity must be a value in the range from 0 to 1.");
      this.Elements.SetReal("/CA", value);
      this.Elements.SetDateTime("/M", DateTime.Now);
    }
  }

  public class Keys : KeysBase
  {
    [KeyInfo(KeyType.Name | KeyType.Optional, FixedValue = "Annot")]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string Subtype = "/Subtype";
    [KeyInfo(KeyType.Rectangle | KeyType.Required)]
    public const string Rect = "/Rect";
    [KeyInfo(KeyType.TextString | KeyType.Optional)]
    public const string Contents = "/Contents";
    [KeyInfo(KeyType.TextString | KeyType.Optional)]
    public const string NM = "/NM";
    [KeyInfo(KeyType.Date | KeyType.Optional)]
    public const string M = "/M";
    [KeyInfo("1.1", KeyType.Integer | KeyType.Optional)]
    public const string F = "/F";
    [KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional)]
    public const string BS = "/BS";
    [KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional)]
    public const string AP = "/AP";
    [KeyInfo("1.2", KeyType.Dictionary | KeyType.Optional)]
    public const string AS = "/AS";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Border = "/Border";
    [KeyInfo("1.1", KeyType.Array | KeyType.Optional)]
    public const string C = "/C";
    [KeyInfo("1.3", KeyType.Integer | KeyType.Optional)]
    public const string StructParent = "/StructParent";
    [KeyInfo("1.1", KeyType.Dictionary | KeyType.Optional)]
    public const string A = "/A";
    [KeyInfo(KeyType.TextString | KeyType.Optional)]
    public const string T = "/T";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional)]
    public const string Popup = "/Popup";
    [KeyInfo(KeyType.Real | KeyType.Optional)]
    public const string CA = "/CA";
    [KeyInfo("1.5", KeyType.TextString | KeyType.Optional)]
    public const string Subj = "/Subj";
  }
}
