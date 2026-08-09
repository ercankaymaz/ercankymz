namespace PdfSharp.Drawing;

internal abstract class ImagePrivateData
{
	private ImportedImage _image;

	public ImportedImage Image
	{
		get
		{
			return _image;
		}
		internal set
		{
			_image = value;
		}
	}

	internal ImagePrivateData()
	{
	}
}
