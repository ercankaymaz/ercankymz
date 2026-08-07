// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.AcroForms.PdfButtonField
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.AcroForms;

public abstract class PdfButtonField : PdfAcroField
{
  protected PdfButtonField(PdfDocument document)
    : base(document)
  {
  }

  protected PdfButtonField(PdfDictionary dict)
    : base(dict)
  {
  }

  protected string GetNonOffValue()
  {
    string nonOffValue;
    if (this.Elements["/AP"] is PdfDictionary element1 && element1.Elements["/N"] is PdfDictionary element2)
    {
      foreach (string key in (IEnumerable<string>) element2.Elements.Keys)
      {
        if (key != "/Off")
        {
          nonOffValue = key;
          goto label_10;
        }
      }
    }
    nonOffValue = (string) null;
label_10:
    return nonOffValue;
  }

  internal override void GetDescendantNames(ref List<string> names, string partialName)
  {
    string str = this.Elements.GetString("/T");
    if (str == "")
      str = "???";
    Debug.Assert(str != "");
    if (str.Length <= 0)
      return;
    if (!string.IsNullOrEmpty(partialName))
      names.Add($"{partialName}.{str}");
    else
      names.Add(str);
  }

  public new class Keys : PdfAcroField.Keys
  {
  }
}
