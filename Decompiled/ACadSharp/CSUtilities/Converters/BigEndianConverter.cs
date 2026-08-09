using System;

namespace CSUtilities.Converters;

internal class BigEndianConverter : EndianConverter
{
	public static BigEndianConverter Instance = new BigEndianConverter();

	private static IEndianConverter init()
	{
		if (BitConverter.IsLittleEndian)
		{
			return new InverseConverter();
		}
		return new DefaultEndianConverter();
	}

	public BigEndianConverter()
		: base(init())
	{
	}
}
