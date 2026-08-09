using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal;

internal class ImportedImageBitmap : ImportedImage
{
	public ImportedImageBitmap(IImageImporter importer, ImagePrivateDataBitmap data, PdfDocument document)
		: base(importer, data, document)
	{
	}

	internal override ImageData PrepareImageData()
	{
		ImagePrivateDataBitmap imagePrivateDataBitmap = (ImagePrivateDataBitmap)Data;
		ImageDataBitmap imageDataBitmap = new ImageDataBitmap(_document);
		imagePrivateDataBitmap.CopyBitmap(imageDataBitmap);
		return imageDataBitmap;
	}
}
