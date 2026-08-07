// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.AcroForms.PdfComboBoxField
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfComboBoxField : PdfChoiceField
{
  internal PdfComboBoxField(PdfDocument document)
    : base(document)
  {
  }

  internal PdfComboBoxField(PdfDictionary dict)
    : base(dict)
  {
  }

  public int SelectedIndex
  {
    get => this.IndexInOptArray(this.Elements.GetString("/V"));
    set
    {
      if (value == -1)
        return;
      this.Elements.SetString("/V", this.ValueInOptArray(value));
      this.Elements.SetInteger("/I", value);
    }
  }

  public override PdfItem Value
  {
    get => this.Elements["/V"];
    set
    {
      if (this.ReadOnly)
        throw new InvalidOperationException("The field is read only.");
      this.Elements["/V"] = (value is PdfString ? 1 : (value is PdfName ? 1 : 0)) != 0 ? value : throw new NotImplementedException("Values other than string cannot be set.");
      this.SelectedIndex = this.SelectedIndex;
      if (this.SelectedIndex != -1)
        return;
      try
      {
        ((PdfArray) ((PdfItem[]) this.Elements.Values)[2]).Elements.Add(this.Value);
        this.SelectedIndex = this.SelectedIndex;
      }
      catch
      {
      }
    }
  }

  internal override DictionaryMeta Meta => PdfComboBoxField.Keys.Meta;

  public new class Keys : PdfAcroField.Keys
  {
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        if (PdfComboBoxField.Keys._meta == null)
          PdfComboBoxField.Keys._meta = KeysBase.CreateMeta(typeof (PdfComboBoxField.Keys));
        return PdfComboBoxField.Keys._meta;
      }
    }
  }
}
