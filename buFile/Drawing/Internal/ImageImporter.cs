// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.Internal.ImageImporter
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace PdfSharp.Drawing.Internal;

internal class ImageImporter
{
  private readonly List<IImageImporter> _importers = new List<IImageImporter>();

  public static ImageImporter GetImageImporter() => new ImageImporter();

  private ImageImporter()
  {
    this._importers.Add((IImageImporter) new ImageImporterJpeg());
    this._importers.Add((IImageImporter) new ImageImporterBmp());
  }

  public ImportedImage ImportImage(Stream stream, PdfDocument document)
  {
    StreamReaderHelper stream1 = new StreamReaderHelper(stream);
    ImportedImage importedImage1;
    foreach (IImageImporter importer in this._importers)
    {
      stream1.Reset();
      ImportedImage importedImage2 = importer.ImportImage(stream1, document);
      if (importedImage2 != null)
      {
        importedImage1 = importedImage2;
        goto label_7;
      }
    }
    importedImage1 = (ImportedImage) null;
label_7:
    return importedImage1;
  }

  public ImportedImage ImportImage(string filename, PdfDocument document)
  {
    ImportedImage importedImage;
    using (Stream stream = (Stream) File.OpenRead(filename))
      importedImage = this.ImportImage(stream, document);
    return importedImage;
  }
}
