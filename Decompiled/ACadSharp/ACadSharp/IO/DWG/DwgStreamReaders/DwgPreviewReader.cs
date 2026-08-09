namespace ACadSharp.IO.DWG.DwgStreamReaders;

internal class DwgPreviewReader : DwgSectionIO
{
	private readonly byte[] _startSentinel = DwgSectionDefinition.StartSentinels["AcDb:Preview"];

	private readonly byte[] _endSentinel = DwgSectionDefinition.EndSentinels["AcDb:Preview"];

	private readonly IDwgStreamReader _reader;

	private readonly long _previewAddress;

	public override string SectionName => "AcDb:Preview";

	public DwgPreviewReader(ACadVersion version, IDwgStreamReader reader, long previewAddress)
		: base(version)
	{
		_reader = reader;
		_previewAddress = previewAddress;
	}

	public DwgPreview Read()
	{
		_reader.ReadSentinel();
		_reader.ReadRawLong();
		byte b = (byte)_reader.ReadRawChar();
		long? num = null;
		long? num2 = null;
		DwgPreview.PreviewType code = DwgPreview.PreviewType.Unknown;
		for (int i = 0; i < b; i++)
		{
			byte b2 = (byte)_reader.ReadRawChar();
			if (b2 == 1)
			{
				_reader.ReadRawLong();
				num = _reader.ReadRawLong();
			}
			else
			{
				code = (DwgPreview.PreviewType)b2;
				_reader.ReadRawLong();
				num2 = _reader.ReadRawLong();
			}
		}
		byte[] array = null;
		array = _reader.ReadBytes((int)num.Value);
		byte[] array2 = null;
		array2 = ((!num2.HasValue) ? new byte[0] : _reader.ReadBytes((int)num2.Value));
		_reader.ReadSentinel();
		return new DwgPreview(code, array, array2);
	}
}
