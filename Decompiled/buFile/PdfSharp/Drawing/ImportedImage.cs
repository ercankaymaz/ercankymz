using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing;

internal abstract class ImportedImage
{
	private ImageInformation _information = new ImageInformation();

	private ImageData _imageData;

	private IImageImporter _importer;

	internal ImagePrivateData Data;

	internal readonly PdfDocument _document;

	public ImageInformation Information
	{
		get
		{
			return _information;
		}
		private set
		{
			_information = value;
		}
	}

	public bool HasImageData => _imageData != null;

	public ImageData ImageData
	{
		get
		{
			if (!HasImageData)
			{
				_imageData = PrepareImageData();
			}
			return _imageData;
		}
		private set
		{
			_imageData = value;
		}
	}

	protected ImportedImage(IImageImporter importer, ImagePrivateData data, PdfDocument document)
	{
		Data = data;
		_document = document;
		data.Image = this;
		_importer = importer;
	}

	internal virtual ImageData PrepareImageData()
	{
		throw new NotImplementedException();
	}
}
