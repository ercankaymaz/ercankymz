namespace PdfSharp.Drawing.Internal;

internal class ImagePrivateDataDct : ImagePrivateData
{
	private readonly byte[] _data;

	private readonly int _length;

	public byte[] Data => _data;

	public int Length => _length;

	public ImagePrivateDataDct(byte[] data, int length)
	{
		_data = data;
		_length = length;
	}
}
