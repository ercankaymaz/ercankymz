using System.IO;
using CSUtilities.Text;

namespace ACadSharp.IO.DWG;

internal class DwgPreviewWriter : DwgSectionIO
{
	private IDwgStreamWriter _swriter;

	private readonly byte[] _startSentinel = DwgSectionDefinition.StartSentinels["AcDb:Preview"];

	private readonly byte[] _endSentinel = DwgSectionDefinition.EndSentinels["AcDb:Preview"];

	public override string SectionName => "AcDb:Preview";

	public DwgPreviewWriter(ACadVersion version, Stream stream)
		: base(version)
	{
		_swriter = DwgStreamWriterBase.GetStreamWriter(version, stream, TextEncoding.Windows1252());
	}

	public void Write()
	{
		_swriter.WriteBytes(_startSentinel);
		_swriter.WriteRawLong(1L);
		_swriter.WriteByte(0);
		_swriter.WriteBytes(_endSentinel);
	}

	public void Write(DwgPreview preview, long startPos)
	{
		int num = preview.RawHeader.Length + preview.RawImage.Length + 19;
		_swriter.WriteBytes(_startSentinel);
		_swriter.WriteRawLong(num);
		_swriter.WriteByte(2);
		_swriter.WriteByte(1);
		long num2 = startPos + _swriter.Stream.Position + 12 + 5 + 32;
		_swriter.WriteRawLong(num2);
		_swriter.WriteRawLong(preview.RawHeader.Length);
		_swriter.WriteByte((byte)preview.Code);
		long value = num2 + preview.RawHeader.Length;
		_swriter.WriteRawLong(value);
		_swriter.WriteRawLong(preview.RawImage.Length);
		_swriter.WriteBytes(preview.RawHeader);
		_swriter.WriteBytes(preview.RawImage);
		_swriter.WriteBytes(_endSentinel);
	}
}
