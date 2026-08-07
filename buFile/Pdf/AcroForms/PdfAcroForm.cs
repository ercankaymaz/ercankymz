// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.AcroForms.PdfAcroForm
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfAcroForm : PdfDictionary
{
  private PdfAcroField.PdfAcroFieldCollection _fields;

  internal PdfAcroForm(PdfDocument document)
    : base(document)
  {
    this._document = document;
  }

  internal PdfAcroForm(PdfDictionary dictionary)
    : base(dictionary)
  {
  }

  public PdfAcroField.PdfAcroFieldCollection Fields
  {
    get
    {
      if (this._fields == null)
        this._fields = (PdfAcroField.PdfAcroFieldCollection) (object) this.Elements.GetValue("/Fields", VCF.CreateIndirect);
      return this._fields;
    }
  }

  internal override DictionaryMeta Meta => PdfAcroForm.Keys.Meta;

  public sealed class Keys : KeysBase
  {
    [KeyInfo(KeyType.Array | KeyType.Required, typeof (PdfAcroField.PdfAcroFieldCollection))]
    public const string Fields = "/Fields";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string NeedAppearances = "/NeedAppearances";
    [KeyInfo("1.3", KeyType.Integer | KeyType.Optional)]
    public const string SigFlags = "/SigFlags";
    [KeyInfo(KeyType.Array)]
    public const string CO = "/CO";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional)]
    public const string DR = "/DR";
    [KeyInfo(KeyType.String | KeyType.Optional)]
    public const string DA = "/DA";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string Q = "/Q";
    private static DictionaryMeta s_meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        if (PdfAcroForm.Keys.s_meta == null)
          PdfAcroForm.Keys.s_meta = KeysBase.CreateMeta(typeof (PdfAcroForm.Keys));
        return PdfAcroForm.Keys.s_meta;
      }
    }
  }
}
