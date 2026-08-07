// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.AcroForms.PdfRadioButtonField
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfRadioButtonField : PdfButtonField
{
  internal PdfRadioButtonField(PdfDocument document)
    : base(document)
  {
    this._document = document;
  }

  internal PdfRadioButtonField(PdfDictionary dict)
    : base(dict)
  {
  }

  public int SelectedIndex
  {
    get => this.IndexInOptStrings(this.Elements.GetString("/V"));
    set
    {
      if (!(this.Elements["/Opt"] is PdfArray element))
        element = this.Elements["/Kids"] as PdfArray;
      if (element == null)
        return;
      int count = element.Elements.Count;
      if ((value < 0 ? 1 : (value >= count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (value));
      this.Elements.SetName("/V", element.Elements[value].ToString());
    }
  }

  private int IndexInOptStrings(string value)
  {
    int num;
    if (this.Elements["/Opt"] is PdfArray element1)
    {
      int count = element1.Elements.Count;
      for (int index = 0; index < count; ++index)
      {
        PdfItem element = element1.Elements[index];
        if (element is PdfString && element.ToString() == value)
        {
          num = index;
          goto label_7;
        }
      }
    }
    num = -1;
label_7:
    return num;
  }

  internal override DictionaryMeta Meta => PdfRadioButtonField.Keys.Meta;

  public new class Keys : PdfButtonField.Keys
  {
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Opt = "/Opt";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfRadioButtonField.Keys._meta ?? (PdfRadioButtonField.Keys._meta = KeysBase.CreateMeta(typeof (PdfRadioButtonField.Keys)));
      }
    }
  }
}
