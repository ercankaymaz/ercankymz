// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfResourceMap
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Collections.Generic;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal class PdfResourceMap : PdfDictionary
{
  public PdfResourceMap()
  {
  }

  public PdfResourceMap(PdfDocument document)
    : base(document)
  {
  }

  protected PdfResourceMap(PdfDictionary dict)
    : base(dict)
  {
  }

  internal void CollectResourceNames(Dictionary<string, object> usedResourceNames)
  {
    foreach (PdfName keyName in this.Elements.KeyNames)
      usedResourceNames.Add(keyName.ToString(), (object) null);
  }
}
