using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal;

internal class ImportedImageJpeg : ImportedImage
{
	public ImportedImageJpeg(IImageImporter importer, ImagePrivateDataDct data, PdfDocument document)
		: base(importer, data, document)
	{
	}

	internal override ImageData PrepareImageData()
	{
		ImagePrivateDataDct imagePrivateDataDct = (ImagePrivateDataDct)Data;
		ImageDataDct imageDataDct = new ImageDataDct();
		imageDataDct.Data = imagePrivateDataDct.Data;
		imageDataDct.Length = imagePrivateDataDct.Length;
		return imageDataDct;
	}
}
