// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.AcroForms.PdfChoiceField
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Advanced;
using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.AcroForms;

public abstract class PdfChoiceField : PdfAcroField
{
  protected PdfChoiceField(PdfDocument document)
    : base(document)
  {
  }

  protected PdfChoiceField(PdfDictionary dict)
    : base(dict)
  {
  }

  protected int IndexInOptArray(string value)
  {
    PdfArray array = this.Elements.GetArray("/Opt");
    PdfArray pdfArray1 = (PdfArray) null;
    if (this.Elements["/Opt"] is PdfArray)
      pdfArray1 = this.Elements["/Opt"] as PdfArray;
    else if (this.Elements["/Opt"] is PdfReference)
      pdfArray1 = ((PdfReference) this.Elements["/Opt"]).Value as PdfArray;
    Debug.Assert(array == pdfArray1);
    int num;
    if (array != null)
    {
      int count = array.Elements.Count;
      for (int index = 0; index < count; ++index)
      {
        PdfItem element = array.Elements[index];
        switch (element)
        {
          case PdfString _:
            if (element.ToString() == value)
            {
              num = index;
              goto label_14;
            }
            break;
          case PdfArray _:
            PdfArray pdfArray2 = (PdfArray) element;
            if (pdfArray2.Elements.Count != 0 && pdfArray2.Elements[0].ToString() == value)
            {
              num = index;
              goto label_14;
            }
            break;
        }
      }
    }
    num = -1;
label_14:
    return num;
  }

  protected string ValueInOptArray(int index)
  {
    PdfArray array = this.Elements.GetArray("/Opt");
    string str;
    if (array != null)
    {
      int count = array.Elements.Count;
      if ((index < 0 ? 1 : (index >= count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (index));
      PdfItem element = array.Elements[index];
      switch (element)
      {
        case PdfString _:
          str = element.ToString();
          goto label_8;
        case PdfArray _:
          PdfArray pdfArray = (PdfArray) element;
          if (pdfArray.Elements.Count != 0)
          {
            str = pdfArray.Elements[0].ToString();
            goto label_8;
          }
          break;
      }
    }
    str = "";
label_8:
    return str;
  }

  internal override DictionaryMeta Meta => PdfChoiceField.Keys.Meta;

  public new class Keys : PdfAcroField.Keys
  {
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Opt = "/Opt";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string TI = "/TI";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string I = "/I";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfChoiceField.Keys._meta ?? (PdfChoiceField.Keys._meta = KeysBase.CreateMeta(typeof (PdfChoiceField.Keys)));
      }
    }
  }
}
