using System.Collections.Generic;
using CSUtilities.Converters;

namespace ACadSharp.IO.DWG;

internal class DwgHandleReader : DwgSectionIO
{
	private IDwgStreamReader _sreader;

	public override string SectionName => "AcDb:Handles";

	public DwgHandleReader(ACadVersion version, IDwgStreamReader sreader)
		: base(version)
	{
		_sreader = sreader;
	}

	public Dictionary<ulong, long> Read()
	{
		Dictionary<ulong, long> dictionary = new Dictionary<ulong, long>();
		while (true)
		{
			ulong num = 0uL;
			long num2 = 0L;
			int num3 = _sreader.ReadShort<BigEndianConverter>();
			if (num3 == 2)
			{
				break;
			}
			long position = _sreader.Position;
			int num4 = num3 - 2;
			if (num4 > 2032)
			{
				num4 = 2032;
			}
			long num5 = position + num4;
			while (_sreader.Position < num5)
			{
				ulong num6 = _sreader.ReadModularChar();
				num += num6;
				num2 += _sreader.ReadSignedModularChar();
				if (num6 != 0)
				{
					dictionary[num] = num2;
				}
				else
				{
					notify($"Negative offset: {num6} for the handle: {num}", NotificationType.Warning);
				}
			}
			_sreader.ReadByte();
			_sreader.ReadByte();
		}
		return dictionary;
	}
}
