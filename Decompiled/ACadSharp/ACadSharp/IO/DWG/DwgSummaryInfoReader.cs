using System;
using CSUtilities.Converters;
using CSUtilities.IO;
using CSUtilities.Text;

namespace ACadSharp.IO.DWG;

internal class DwgSummaryInfoReader : DwgSectionIO
{
	private delegate string readString();

	private readString _readStringMethod;

	private IDwgStreamReader _reader;

	private StreamIO _sreader;

	public override string SectionName => "AcDb:SummaryInfo";

	public DwgSummaryInfoReader(ACadVersion version, IDwgStreamReader reader)
		: base(version)
	{
		_reader = reader;
		_sreader = new StreamIO(reader.Stream);
		if (version < ACadVersion.AC1021)
		{
			_readStringMethod = readUnicodeString;
		}
		else
		{
			_readStringMethod = _reader.ReadTextUnicode;
		}
	}

	public CadSummaryInfo Read()
	{
		CadSummaryInfo cadSummaryInfo = new CadSummaryInfo();
		try
		{
			cadSummaryInfo.Title = _readStringMethod();
			cadSummaryInfo.Subject = _readStringMethod();
			cadSummaryInfo.Author = _readStringMethod();
			cadSummaryInfo.Keywords = _readStringMethod();
			cadSummaryInfo.Comments = _readStringMethod();
			cadSummaryInfo.LastSavedBy = _readStringMethod();
			cadSummaryInfo.RevisionNumber = _readStringMethod();
			cadSummaryInfo.HyperlinkBase = _readStringMethod();
			_reader.ReadInt();
			_reader.ReadInt();
			cadSummaryInfo.CreatedDate = _reader.Read8BitJulianDate();
			cadSummaryInfo.ModifiedDate = _reader.Read8BitJulianDate();
			short num = _reader.ReadShort();
			for (int i = 0; i < num; i++)
			{
				string key = _readStringMethod();
				string value = _readStringMethod();
				try
				{
					cadSummaryInfo.Properties.Add(key, value);
				}
				catch (Exception ex)
				{
					notify("[SummaryInfo] An error ocurred while adding a property in the SummaryInfo", NotificationType.Error, ex);
				}
			}
			_reader.ReadInt();
			_reader.ReadInt();
		}
		catch (Exception ex2)
		{
			if (_reader.Stream.Position != _reader.Stream.Length)
			{
				notify("An error occurred while reading the Summary Info", NotificationType.Error, ex2);
			}
		}
		return cadSummaryInfo;
	}

	private string readUnicodeString()
	{
		short num = _sreader.ReadShort<LittleEndianConverter>();
		if (num == 0)
		{
			return string.Empty;
		}
		return _sreader.ReadString(num, TextEncoding.GetListedEncoding(CodePage.Windows1252)).Replace("\0", "");
	}
}
