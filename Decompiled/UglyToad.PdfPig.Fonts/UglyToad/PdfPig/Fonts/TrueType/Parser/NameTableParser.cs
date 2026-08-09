using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.TrueType.Names;
using UglyToad.PdfPig.Fonts.TrueType.Tables;

namespace UglyToad.PdfPig.Fonts.TrueType.Parser;

internal class NameTableParser : ITrueTypeTableParser<NameTable>
{
	private readonly struct NameRecordBuilder
	{
		public TrueTypePlatformIdentifier PlatformId { get; }

		public ushort PlatformEncodingId { get; }

		private ushort LanguageId { get; }

		private ushort NameId { get; }

		public ushort Length { get; }

		public ushort Offset { get; }

		private NameRecordBuilder(ushort platformId, ushort platformEncodingId, ushort languageId, ushort nameId, ushort length, ushort offset)
		{
			PlatformId = (TrueTypePlatformIdentifier)platformId;
			PlatformEncodingId = platformEncodingId;
			LanguageId = languageId;
			NameId = nameId;
			Length = length;
			Offset = offset;
		}

		public TrueTypeNameRecord ToNameRecord(string s)
		{
			return new TrueTypeNameRecord(PlatformId, PlatformEncodingId, LanguageId, NameId, s);
		}

		public static NameRecordBuilder Read(TrueTypeDataBytes data)
		{
			return new NameRecordBuilder(data.ReadUnsignedShort(), data.ReadUnsignedShort(), data.ReadUnsignedShort(), data.ReadUnsignedShort(), data.ReadUnsignedShort(), data.ReadUnsignedShort());
		}
	}

	public NameTable Parse(TrueTypeHeaderTable header, TrueTypeDataBytes data, TableRegister.Builder register)
	{
		data.Seek(header.Offset);
		data.ReadUnsignedShort();
		ushort num = data.ReadUnsignedShort();
		ushort num2 = data.ReadUnsignedShort();
		NameRecordBuilder[] array = new NameRecordBuilder[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = NameRecordBuilder.Read(data);
		}
		TrueTypeNameRecord[] array2 = new TrueTypeNameRecord[num];
		uint offset = header.Offset + num2;
		for (int j = 0; j < num; j++)
		{
			array2[j] = GetTrueTypeNameRecord(array[j], data, offset);
		}
		return new NameTable(header, GetName(4, array2), GetName(1, array2), GetName(2, array2), array2);
	}

	private static TrueTypeNameRecord GetTrueTypeNameRecord(NameRecordBuilder nameRecord, TrueTypeDataBytes data, uint offset)
	{
		try
		{
			Encoding encoding = OtherEncodings.Iso88591;
			switch (nameRecord.PlatformId)
			{
			case TrueTypePlatformIdentifier.Windows:
			{
				TrueTypeWindowsEncodingIdentifier platformEncodingId = (TrueTypeWindowsEncodingIdentifier)nameRecord.PlatformEncodingId;
				if (platformEncodingId == TrueTypeWindowsEncodingIdentifier.Symbol || platformEncodingId == TrueTypeWindowsEncodingIdentifier.UnicodeBmp)
				{
					encoding = Encoding.BigEndianUnicode;
				}
				break;
			}
			case TrueTypePlatformIdentifier.Unicode:
				encoding = Encoding.BigEndianUnicode;
				break;
			case TrueTypePlatformIdentifier.Iso:
				switch (nameRecord.PlatformEncodingId)
				{
				case 0:
					encoding = Encoding.GetEncoding("US-ASCII");
					break;
				case 1:
					encoding = Encoding.GetEncoding("ISO-10646-UCS-2");
					break;
				}
				break;
			}
			uint num = offset + nameRecord.Offset;
			if (num >= data.Length)
			{
				return null;
			}
			data.Seek(num);
			if (data.TryReadString(nameRecord.Length, encoding, out string result))
			{
				return nameRecord.ToNameRecord(result);
			}
			return null;
		}
		catch
		{
			return null;
		}
	}

	private static string GetName(int nameId, TrueTypeNameRecord[] names)
	{
		string text = null;
		string text2 = null;
		foreach (TrueTypeNameRecord trueTypeNameRecord in names)
		{
			if (trueTypeNameRecord != null && trueTypeNameRecord.NameId == nameId)
			{
				if (trueTypeNameRecord.PlatformId == TrueTypePlatformIdentifier.Windows && trueTypeNameRecord.LanguageId == 409)
				{
					return trueTypeNameRecord.Value;
				}
				if (trueTypeNameRecord.PlatformId == TrueTypePlatformIdentifier.Windows)
				{
					text = trueTypeNameRecord.Value;
				}
				text2 = trueTypeNameRecord.Value;
			}
		}
		return text ?? text2;
	}
}
