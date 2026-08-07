// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfImageTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfImageTable(PdfDocument document) : PdfResourceTable(document)
{
  private readonly Dictionary<PdfImageTable.ImageSelector, PdfImage> _images = new Dictionary<PdfImageTable.ImageSelector, PdfImage>();

  public PdfImage GetImage(XImage image)
  {
    PdfImageTable.ImageSelector key = image._selector;
    if (key == null)
    {
      key = new PdfImageTable.ImageSelector(image);
      image._selector = key;
    }
    PdfImage image1;
    if (!this._images.TryGetValue(key, out image1))
    {
      image1 = new PdfImage(this.Owner, image);
      Debug.Assert(image1.Owner == this.Owner);
      this._images[key] = image1;
    }
    return image1;
  }

  public class ImageSelector
  {
    private string _path;

    public ImageSelector(XImage image)
    {
      if (image._path == null)
        image._path = "*" + Guid.NewGuid().ToString("B");
      this._path = image._path.ToLowerInvariant();
    }

    public string Path
    {
      get => this._path;
      set => this._path = value;
    }

    public override bool Equals(object obj)
    {
      return obj is PdfImageTable.ImageSelector imageSelector && this._path == imageSelector._path;
    }

    public override int GetHashCode() => this._path.GetHashCode();
  }
}
