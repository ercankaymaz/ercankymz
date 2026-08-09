namespace PdfSharp.Drawing.Internal;

internal class ImageDataDct : ImageData
{
	private byte[] _data;

	private int _length;

	public byte[] Data
	{
		get
		{
			return _data;
		}
		internal set
		{
			_data = value;
		}
	}

	public int Length
	{
		get
		{
			return _length;
		}
		internal set
		{
			_length = value;
		}
	}
}
