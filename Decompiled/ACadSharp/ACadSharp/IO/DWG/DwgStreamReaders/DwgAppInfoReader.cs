namespace ACadSharp.IO.DWG.DwgStreamReaders;

internal class DwgAppInfoReader : DwgSectionIO
{
	private readonly IDwgStreamReader _reader;

	public override string SectionName => "AcDb:AppInfo";

	public DwgAppInfoReader(ACadVersion version, IDwgStreamReader reader)
		: base(version)
	{
		_reader = reader;
	}

	public void Read()
	{
		if (!R2007Plus)
		{
			readR18();
		}
		_reader.ReadInt();
		_reader.ReadTextUnicode();
		_reader.ReadInt();
		_reader.ReadBytes(16);
		_reader.ReadTextUnicode();
		_reader.ReadBytes(16);
		if (R2010Plus)
		{
			_reader.ReadTextUnicode();
			_reader.ReadBytes(16);
			_reader.ReadTextUnicode();
		}
	}

	private void readR18()
	{
		_reader.ReadVariableText();
		_reader.ReadInt();
		_reader.ReadVariableText();
		_reader.ReadVariableText();
		_reader.ReadVariableText();
	}
}
