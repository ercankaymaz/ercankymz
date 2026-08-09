using System.Collections.Generic;
using System.IO;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal;

internal class ImageImporter
{
	private readonly List<IImageImporter> _importers = new List<IImageImporter>();

	public static ImageImporter GetImageImporter()
	{
		return new ImageImporter();
	}

	private ImageImporter()
	{
		_importers.Add(new ImageImporterJpeg());
		_importers.Add(new ImageImporterBmp());
	}

	public ImportedImage ImportImage(Stream stream, PdfDocument document)
	{
		StreamReaderHelper streamReaderHelper = new StreamReaderHelper(stream);
		foreach (IImageImporter importer in _importers)
		{
			streamReaderHelper.Reset();
			ImportedImage importedImage = importer.ImportImage(streamReaderHelper, document);
			if (importedImage != null)
			{
				return importedImage;
			}
		}
		return null;
	}

	public ImportedImage ImportImage(string filename, PdfDocument document)
	{
		using Stream stream = File.OpenRead(filename);
		return ImportImage(stream, document);
	}
}
