using PdfSharp.Pdf;

namespace PdfSharp.Drawing;

internal interface IImageImporter
{
	ImportedImage ImportImage(StreamReaderHelper stream, PdfDocument document);

	ImageData PrepareImage(ImagePrivateData data);
}
