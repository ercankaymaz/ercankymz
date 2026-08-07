// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.AcroForms.PdfTextField
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;

#nullable disable
namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfTextField : PdfAcroField
{
  private XFont _font = new XFont("Courier New", 10.0);
  private XColor _foreColor = XColors.Black;
  private XColor _backColor = XColor.Empty;

  internal PdfTextField(PdfDocument document)
    : base(document)
  {
  }

  internal PdfTextField(PdfDictionary dict)
    : base(dict)
  {
  }

  public string Text
  {
    get => this.Elements.GetString("/V");
    set
    {
      this.Elements.SetString("/V", value);
      this.RenderAppearance();
    }
  }

  public XFont Font
  {
    get => this._font;
    set => this._font = value;
  }

  public XColor ForeColor
  {
    get => this._foreColor;
    set => this._foreColor = value;
  }

  public XColor BackColor
  {
    get => this._backColor;
    set => this._backColor = value;
  }

  public int MaxLength
  {
    get => this.Elements.GetInteger("/MaxLen");
    set => this.Elements.SetInteger("/MaxLen", value);
  }

  public bool MultiLine
  {
    get => (this.Flags & PdfAcroFieldFlags.Multiline) != 0;
    set
    {
      if (value)
        this.SetFlags |= PdfAcroFieldFlags.Multiline;
      else
        this.SetFlags &= ~PdfAcroFieldFlags.Multiline;
    }
  }

  public bool Password
  {
    get => (this.Flags & PdfAcroFieldFlags.Password) != 0;
    set
    {
      if (value)
        this.SetFlags |= PdfAcroFieldFlags.Password;
      else
        this.SetFlags &= ~PdfAcroFieldFlags.Password;
    }
  }

  private void RenderAppearance()
  {
    PdfRectangle rectangle = this.Elements.GetRectangle("/Rect");
    XForm form = new XForm(this._document, rectangle.Size);
    XGraphics xgraphics = XGraphics.FromForm(form);
    if (this._backColor != XColor.Empty)
      xgraphics.DrawRectangle((XBrush) new XSolidBrush(this.BackColor), rectangle.ToXRect() - rectangle.Location);
    if (this.Text.Length > 0)
      xgraphics.DrawString(this.Text, this.Font, (XBrush) new XSolidBrush(this.ForeColor), rectangle.ToXRect() - rectangle.Location + new XPoint(2.0, 0.0), XStringFormats.TopLeft);
    form.DrawingFinished();
    form.PdfForm.Elements.Add("/FormType", (PdfItem) new PdfLiteral("1"));
    if (!(this.Elements["/AP"] is PdfDictionary pdfDictionary))
    {
      pdfDictionary = new PdfDictionary(this._document);
      this.Elements["/AP"] = (PdfItem) pdfDictionary;
    }
    pdfDictionary.Elements["/N"] = (PdfItem) form.PdfForm.Reference;
    PdfFormXObject pdfForm = form.PdfForm;
    string s = $"/Tx BMC\n{pdfForm.Stream.ToString()}\nEMC";
    pdfForm.Stream.Value = new RawEncoding().GetBytes(s);
  }

  internal override void PrepareForSave()
  {
    base.PrepareForSave();
    this.RenderAppearance();
  }

  internal override DictionaryMeta Meta => PdfTextField.Keys.Meta;

  public new class Keys : PdfAcroField.Keys
  {
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string MaxLen = "/MaxLen";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfTextField.Keys._meta ?? (PdfTextField.Keys._meta = KeysBase.CreateMeta(typeof (PdfTextField.Keys)));
      }
    }
  }
}
