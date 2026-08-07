// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfCustomValues
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf;

public class PdfCustomValues : PdfDictionary
{
  internal PdfCustomValues()
  {
  }

  internal PdfCustomValues(PdfDocument document)
    : base(document)
  {
  }

  internal PdfCustomValues(PdfDictionary dict)
    : base(dict)
  {
  }

  public PdfCustomValueCompressionMode CompressionMode
  {
    set => throw new NotImplementedException();
  }

  public bool Contains(string key) => this.Elements.ContainsKey(key);

  public PdfCustomValue this[string key]
  {
    get
    {
      PdfDictionary dictionary = this.Elements.GetDictionary(key);
      PdfCustomValue pdfCustomValue1;
      if (dictionary == null)
      {
        pdfCustomValue1 = (PdfCustomValue) null;
      }
      else
      {
        if (!(dictionary is PdfCustomValue pdfCustomValue2))
          pdfCustomValue2 = new PdfCustomValue(dictionary);
        pdfCustomValue1 = pdfCustomValue2;
      }
      return pdfCustomValue1;
    }
    set
    {
      if (value == null)
      {
        this.Elements.Remove(key);
      }
      else
      {
        this.Owner.Internals.AddObject((PdfObject) value);
        this.Elements.SetReference(key, (PdfObject) value);
      }
    }
  }

  public static void ClearAllCustomValues(PdfDocument document)
  {
    document.CustomValues = (PdfCustomValues) null;
    foreach (PdfPage page in document.Pages)
      page.CustomValues = (PdfCustomValues) null;
  }

  internal static PdfCustomValues Get(PdfDictionary.DictionaryElements elem)
  {
    string customValueKey = elem.Owner.Owner.Internals.CustomValueKey;
    PdfDictionary dictionary = elem.GetDictionary(customValueKey);
    if (dictionary == null)
    {
      pdfCustomValues = new PdfCustomValues();
      elem.Owner.Owner.Internals.AddObject((PdfObject) pdfCustomValues);
      elem.Add(customValueKey, (PdfItem) pdfCustomValues);
    }
    else if (!(dictionary is PdfCustomValues pdfCustomValues))
      pdfCustomValues = new PdfCustomValues(dictionary);
    return pdfCustomValues;
  }

  internal static void Remove(PdfDictionary.DictionaryElements elem)
  {
    elem.Remove(elem.Owner.Owner.Internals.CustomValueKey);
  }
}
